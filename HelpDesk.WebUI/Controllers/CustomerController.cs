using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelpDesk.BLL;
using HelpDesk.BLL.Repository.Abstracts;
using HelpDesk.BLL.Repository.Fault_Repo;
using HelpDesk.Model.Entities.Poco;
using HelpDesk.Model.ViewModels.FaultViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MembershipTools _membershipTools;
        private readonly IRepository<FaultRecord, int> _faultRepo;

        public CustomerController(MembershipTools membershipTools, IRepository<FaultRecord, int> faultRepo)
        {
            _membershipTools = membershipTools;
            _faultRepo = faultRepo;
        }
        public IActionResult Index()
        {
        
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FaultAddAsync(FaultViewModels model)
        {
            //TODO RESİM EKleme Olmumyor Yapılcak.
            var data = Mapper.Map<FaultRecord>(model);

            var user = await _membershipTools.UserManager.GetUserAsync(HttpContext.User);
            data.CreatedUserId = user.Id;
            var res = (_faultRepo as Fault_Repo).FaultAdd(data);
            if (res.Result.Responce > 0)
            {

                TempData["Message"] = $"Kayıt başarılı teşekkürler. Olusturdugunuz kaydı Kayıt Takip Sayfasına giderek tabkip edebilirsiniz.";
                return View("Index");
            }
            else
            {
                TempData["Message"] = $"Kayıt başarısız";
                return View("Index");
            }



        }
    }
}