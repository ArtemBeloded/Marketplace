using AutoMapper;
using Marketplace.BLL.Services;
using Marketplace.DAL.Models;
using Marketplace.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web;
using Marketplace.DAL.DataBaseContext;

namespace Marketplace.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly MarketplaceContext _context;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public UserController(IUserService userService, IMapper mapper, MarketplaceContext context)
        {
            _userService = userService;
            _mapper = mapper;
            _context = context;
        }

        public ActionResult Login() =>
            View();

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(LoginUserVM model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userService.GetUser(model.Username, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
                    claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username, ClaimValueTypes.String));
                    claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                        "OWIN Provider", ClaimValueTypes.String));
                    if (user.Role != null)
                        claim.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name, ClaimValueTypes.String));

                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(nameof(UserController.Login));
        }

        private bool PasswordIsCorrect(string username, string password)
        {
            var credentials = _userService.GetCredential(username);

            var value = Encode(password + credentials.Salt);

            return value == credentials.Password;
        }

        private static string Encode(string value)
        {
            var hash = new StringBuilder();
            var bytes = Encoding.ASCII.GetBytes(value);

            using (var algorithm = new SHA256Managed())
                foreach (var @byte in algorithm.ComputeHash(bytes))

                    hash.Append(@byte.ToString("x2"));

            return hash.ToString();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult SaveData(RegistrationUserVM model)
        {
            var check = _userService.GetUser(model.Username);
            if (check == null) 
            {
                var credentials = _mapper.Map<Credential>(Credentials(model.Username, model.Password));

                var user = _mapper.Map<User>(model);

                _userService.SaveData(user, credentials);
            }
            else
                ModelState.AddModelError("Not new user", "Create new username");

            return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
        }

        private CredentialVM Credentials(string username, string password)
        {
            var size = 32;
            var bytes = new byte[size];

            using (var random = new RNGCryptoServiceProvider())
                random.GetNonZeroBytes(bytes);

            var salt = Encoding.ASCII.GetString(bytes, 0, bytes.Count());

            var encoded = Encode(password + salt);

            var credentials = new CredentialVM
            {
                Username = username,
                Salt = salt,
                Password = encoded
            };

            return credentials;
        }

        public ActionResult Logoff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public ActionResult RemoveUser(string id) 
        {
            _userService.RemoveUser(id);
            return RedirectToAction("ListOfUsers");
        }

    }
}