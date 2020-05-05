using AutoMapper;
using Marketplace.BLL.Services;
using Marketplace.DAL.Models;
using Marketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Marketplace.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public ActionResult Login() =>
            View();

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginUserVM model)
        {
            var user = _userService.GetUser(model.Username);
            if (user != null || PasswordIsCorrect(user.Username, model.Password))
            {
                Json("Successfull Login", JsonRequestBehavior.AllowGet);
                //FormsAuthentication.SetAuthCookie(user.Username, true);

                //if (Url.IsLocalUrl(url) && url.Length > 1 && url.StartsWith("/")
                //    && !url.StartsWith("//") && !url.StartsWith("/\\"))
                //    return Redirect(url);
                //else
                //    return RedirectToAction("RedirectToDefault");
            }
            else
                ModelState.AddModelError("LoginError", "The user name or password provided is incorrect.");

            return RedirectToAction("ListOfProduct", "Product");
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


        public JsonResult SaveData(RegistrationUserVM model)
        {
            var credentials = _mapper.Map<Credential>(Credentials(model.Username, model.Password));

            var user = _mapper.Map<User>(model);
            user.Id = 1;

            _userService.SaveData(user, credentials);

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

    }
}