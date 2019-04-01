using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.BLL;
using HelpDesk.BLL.Repository.Fault_Repo;
using HelpDesk.Model.ViewModels.FaultViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MembershipTools _membershipTools;
        private readonly Fault_Repo _fault_repo;

        public CustomerController(MembershipTools membershipTools, Fault_Repo fault_repo)
        {
            _membershipTools = membershipTools;
            _fault_repo = fault_repo;
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