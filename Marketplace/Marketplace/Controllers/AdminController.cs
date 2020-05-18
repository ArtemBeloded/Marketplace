using AutoMapper;
using Marketplace.BLL.Services;
using System.Web.Mvc;

namespace Marketplace.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
        }

        [Authorize (Roles = "Admin")]
        public ActionResult ListOfUsers(int page = 1, int count = 10)
        {
            var users = _userService.GetUsers(page, count);

            return View(users);
        }
    }
}