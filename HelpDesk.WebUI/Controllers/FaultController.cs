using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class FaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}