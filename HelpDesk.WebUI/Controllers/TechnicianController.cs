using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class TechnicianController : Controller
    {
        public IActionResult Index()
        {
            //try
            //{
            //    //Sistemdeki teknisyenId sini verir.
            //    var teknisyenId = HttpContext.User.Identity.GetUserId();
            //    //arızalar tablosuna sistemdeki teknisyen ıd  alındı ve sorgu atıldı . mapper ile view model e çevrilip sayfaya gönderildi
            //    var data = new ArizaKayitRepo()
            //        .GetAll(x => x.TeknisyenId == teknisyenId).Select(x => Mapper.Map<ArizaViewModel>(x))
            //        .ToList();

            //    return View(data);
            //}
            //catch (Exception ex)
            //{
            //    TempData["Model"] = new ErrorViewModel()
            //    {
            //        Text = $"Bir hata oluştu {ex.Message}",
            //        ActionName = "Index",
            //        ControllerName = "Home",
            //        ErrorCode = 500
            //    };
            //    return RedirectToAction("Error", "Home");
            //}
            return View();
        }
        public IActionResult TechnicianFaultReport(int id)
        {
            //try
            //{
            //    var ariza = new ArizaKayitRepo().GetById(id);
            //    var data = Mapper.Map<ArizaViewModel>(ariza);
            //    data.ArızaPath = new FotografRepo().GetAll(z => z.ArizaId == id).Select(u => u.Yol).ToList();
            //    //ilgili log kayıtları getiriyor. o arizaya ait.
            //    var Logs = new ArizaLogRepo().GetAll()
            //        .Where(u => u.ArızaId == id)
            //        .OrderByDescending(u => u.CreatedDate)
            //        .ToList();
            //    data.ArizaLogs.Clear();

            //    //data.ArizaLogViewModels.Clear();
            //    //gelen logkayitlarini mapper ile view model e çevirip. arizaviewmoedeki alana ekliyoruz.
            //    //BURADA VİEWMODEL YAPAMADIK NEDEN BAK SOR ...
            //    foreach (ArizaLOG log in Logs)
            //    {

            //        data.ArizaLogs.Add(log);
            //    }
            //    return View(data);

            //}
            //catch (Exception ex)
            //{
            //    TempData["Model"] = new ErrorViewModel()
            //    {
            //        Text = $"Bir hata oluştu {ex.Message}",
            //        ActionName = "Index",
            //        ControllerName = "Home",
            //        ErrorCode = 500
            //    };
            //    return RedirectToAction("Error", "Home");

            //}
            return View();
        }


    }
}