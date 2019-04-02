using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class OperatorController : Controller
    {
        public IActionResult Index()
        {
            //var data = new ArizaKayitRepo()
            //   .GetAll(x => x.OperatorKabul == false)
            //   .Select(x => Mapper.Map<ArizaViewModel>(x))
            //   .ToList();

            //return View(data);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FaultDetail(int id)
        {
            //try
            //{

            //    var x = new ArizaKayitRepo().GetById(id);

            //    var data = Mapper.Map<ArizaViewModel>(x);
            //    data.ArızaPath = new FotografRepo().GetAll(z => z.ArizaId == id).Select(u => u.Yol).ToList();

            //    return View(data);
            //}
            //catch (Exception ex)
            //{
            //    TempData["Model"] = new ErrorViewModel()
            //    {
            //        Text = $"Bir hata oluştu {ex.Message}",
            //        ActionName = "Index",
            //        ControllerName = "Admin",
            //        ErrorCode = 500
            //    };
            //    return RedirectToAction("Error", "Home");
            //}
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FaultAccept(int id)
        {
            return View();
            ////ikisiylede bulabilirsin o anki sistemde online olanı
            ////var OpertatorId = HttpContext.User.Identity.GetUserId();

            //var OpertatorId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            //try
            //{
            //    var ariza = await new ArizaKayitRepo().GetByIdAsync(id);
            //    var Operator = await NewUserManager().FindByIdAsync(OpertatorId);
            //    if (ariza == null)
            //    {
            //        RedirectToAction("Index", "Operator");
            //    }
            //    else
            //    {
            //        ariza.OperatorKabulTarih = DateTime.Now;
            //        ariza.OperatorKabul = true;
            //        ariza.OperatorId = OpertatorId;
            //        ariza.ArizaDurumu = ArizaDurum.OperatorTakibeAldı;
            //        new ArizaKayitRepo().Update(ariza);
            //        var OperatorLog = new ArizaLOG
            //        {
            //            CreatedDate = DateTime.Now,
            //            ArızaId = id,
            //            Aciklama = $"Ariza'nız {Operator.Name} {Operator.Surname} isimli Operator Tarafından Onaylanmıştır.",
            //            YapanınRolu = IdentityRoles.Teknisyen
            //        };
            //        new ArizaLogRepo().Insert(OperatorLog);
            //        return RedirectToAction("Index", "Operator");
            //        //TODO Müşteriye Mail gönderilir bilgilendirme belki
            //    }

            //    return RedirectToAction("Index", "Operator");

            //}

            //catch (Exception ex)
            //{
            //    TempData["Model"] = new ErrorViewModel()
            //    {
            //        Text = $"Bir hata oluştu {ex.Message}",
            //        ActionName = "Index",
            //        ControllerName = "Admin",
            //        ErrorCode = 500
            //    };
            //    return RedirectToAction("Error", "Home");
            //}
        }

    }
}