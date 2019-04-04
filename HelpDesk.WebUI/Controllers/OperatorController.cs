using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelpDesk.BLL;
using HelpDesk.BLL.Repository;
using HelpDesk.BLL.Repository.Abstracts;
using HelpDesk.Model.Entities.Poco;
using HelpDesk.Model.ViewModels.FaultViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;

namespace HelpDesk.WebUI.Controllers
{
    public class OperatorController : Controller
    {
        private readonly IRepoIdentity _userRoleRepo;
        private readonly MembershipTools _membershipTools;
        private readonly Operator_Repo _operatorRepo;
        private readonly IHostingEnvironment _hostingEnvironment;

        public OperatorController(IRepoIdentity userRoleRepo, MembershipTools membershipTools, Operator_Repo operatorRepo, IHostingEnvironment hostingEnvironment)
        {
            _userRoleRepo = userRoleRepo;
            _membershipTools = membershipTools;
            _operatorRepo = operatorRepo;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {

            var UnapprovedRecords = _operatorRepo.GetUnApproveRecords();
            //var data = new ArizaKayitRepo()
            //   .GetAll(x => x.OperatorKabul == false)
            //   .Select(x => Mapper.Map<ArizaViewModel>(x))
            //   .ToList();
            if (UnapprovedRecords == null)
            {
                TempData["Message"] = "Bir hata oluştu. Tekrar Deneyiniz";
                return View();
            }
            else
            {
                var data = Mapper.Map<List<FaultViewModels>>(UnapprovedRecords);

                return View(data);
            }
            //return View(data);

           
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
        public IActionResult OpeFaultDetail(int id)
        {
            //try
            //{
            //    var ariza = new ArizaKayitRepo().GetById(id);
            //    var data = Mapper.Map<ArizaViewModel>(ariza);
            //    data.ArızaPath = new FotografRepo().GetAll(z => z.ArizaId == id).Select(u => u.Yol).ToList();
            //    ViewBag.TeknisyenK = BostaOlanTeknisyenler(data);



            //    return View(data);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    throw;
            //}
            return View();
        }
    }
}