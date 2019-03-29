using HelpDesk.BLL;
using HelpDesk.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace HelpDesk.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly MembershipTools _membershipTools;
        public HomeController(MembershipTools membershipTools)
        {
            _membershipTools = membershipTools;
        }
        [Authorize]
        public async System.Threading.Tasks.Task<IActionResult> Index()
        {
            //o an sistemdeki kullanıcı bulma
            var user = await _membershipTools.UserManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                // Id ile user bulma
                var wuser = await _membershipTools.UserManager.FindByIdAsync(user.Id);
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
