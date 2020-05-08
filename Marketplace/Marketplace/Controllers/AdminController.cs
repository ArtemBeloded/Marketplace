using AutoMapper;
using Marketplace.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Marketplace.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AdminController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public ActionResult ListOfUsers(int page = 1, int count = 10)
        {
            var users = _userService.GetUsers(page, count);
            return View(users);
        }
    }
}