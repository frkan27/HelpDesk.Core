using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class PartialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult DrawerPartial()
        {
            return PartialView("_Partial/_DrawerPartial");
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView("_Partial/_HeaderPartial");
        }
        public PartialViewResult ModalPartial()
        {
            return PartialView("_Partial/_ModalPartial");
        }
    }
}