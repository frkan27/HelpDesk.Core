using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.BLL.Repository.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepoIdentity _userRoleRepo;

        public AccountController(IRepoIdentity userRoleRepo)
        {
            _userRoleRepo = userRoleRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}