using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.BLL;
using HelpDesk.Model.ViewModels.FaultViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MembershipTools _membershipTools;

        public CustomerController(MembershipTools membershipTools)
        {
            _membershipTools = membershipTools;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FaultAdd(FaultViewModels model)
        {

            return View();
        }
    }
}