using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HelpDesk.BLL;
using HelpDesk.BLL.Helper;
using HelpDesk.BLL.Repository.Abstracts;
using HelpDesk.BLL.Repository.RoleUser;
using HelpDesk.BLL.Service.Sender;
using HelpDesk.Model.ViewModels;
using HelpDesk.Model.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepoIdentity _userRoleRepo;
        private readonly MembershipTools _membershipTools;
        private readonly RoleUserRepo _roleUserRepo;
        private readonly IHostingEnvironment _hostingEnvironment;


        public AccountController(IRepoIdentity userRoleRepo, MembershipTools membershipTools, RoleUserRepo roleUserRepo,
            IHostingEnvironment hostingEnvironment)
        {
            _membershipTools = membershipTools;
            _userRoleRepo = userRoleRepo;
            _roleUserRepo = roleUserRepo;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userRoleRepo.RegisterUser(model);

            var uri = new UriBuilder()
            {
                Scheme = Uri.UriSchemeHttps
            };
            var hostComponents = Request.Host.ToUriComponent();
            string SiteUrl = uri.Scheme + System.Uri.SchemeDelimiter + hostComponents;


            if (result.IdentityResult.Succeeded)
            {

                await _userRoleRepo.CreateRoles();
                await _userRoleRepo.AddRole(result.User);
                await _userRoleRepo.SendActivationMail(SiteUrl, result);
                TempData["Message"] = "Kaydınız alınmıştır. Lütfen giriş yapınız ve Mailinizi kontrol ediniz.s";
                return RedirectToAction(nameof(Login));
            }
            else
            {
                var errorMsg = "";
                foreach (var error in result.IdentityResult.Errors)
                {
                    errorMsg += error.Description;
                }

                ModelState.AddModelError(String.Empty, errorMsg);
                return View(model);
            }

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _userRoleRepo.LoginUser(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(String.Empty, "Kullanıcı adı veya şifre hatalı");
            return View(model);

        }

        public async Task<IActionResult> Logout()
        {
            await _userRoleRepo.Logout();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult> UserProfile()
        {
            try
            {
                //MVCDEki HTTPCONTEXT gitti sadece context kaldı . context. diyincede olur
                var user = await _membershipTools.GetCurrentUser(User);
                var data = _membershipTools.ConvertProfile(user);


                return View(data);
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu {ex.Message}",
                    ActionName = "UserProfile",
                    ControllerName = "Account",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateProfile(ProfilePasswordViewModel _model)
        {
            var model = _model.UserProfileViewModel;
            var user = await _membershipTools.UserManager.FindByIdAsync(model.Id);

            if (model.PostedFile != null &&
                model.PostedFile.Length > 0)
            {
                var file = model.PostedFile;
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extName = Path.GetExtension(file.FileName);
                fileName = StringHelpers.UrlFormatConverter(fileName);
                fileName += StringHelpers.GetCode();

                var webpath = _hostingEnvironment.WebRootPath;
                var directorypath = Path.Combine(webpath, "Uploads");
                var filePath = Path.Combine(directorypath, fileName + extName);

                if (!Directory.Exists(directorypath))
                {
                    Directory.CreateDirectory(directorypath);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                user.AvatarPath = "/Uploads/" + fileName + extName;
            }

            try
            {
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.PhoneNumber = model.PhoneNumber;
                //user.Location = model.Location;
                if (user.Email != model.Email)
                {
                    //todo tekrar aktivasyon maili gönderilmeli. rolü de aktif olmamış role çevrilmeli.
                }

                user.Email = model.Email;

                await _membershipTools.UserManager.UpdateAsync(user);
                TempData["Message"] = "Güncelleme işlemi başarılı.";
                return RedirectToAction("UserProfile");
            }
            catch (Exception ex)
            {
                TempData["Message"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu: {ex.Message}",
                    ActionName = "UserProfile",
                    ControllerName = "Account",
                    ErrorCode = 500
                };
                return View("UserProfile", _model);
            }

        }


        //TODO BURADAN SONRASI KONTROL EDİLECEK
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> ChangePassword(ProfilePasswordViewModel _model)
        {
            var model = _model.ChangePasswordViewModel;

            try
            {
                var user = await _membershipTools.UserManager.GetUserAsync(HttpContext.User);

                //var id = _membershipTools.IHttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
                //var user = await _membershipTools.UserManager.FindByIdAsync(id);

                var data = new ChangePasswordViewModel()
                {
                    OldPassword = model.OldPassword,
                    NewPassword = model.NewPassword,
                    ConfirmNewPassword = model.ConfirmNewPassword
                };

                model = data;
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");
                }

                var result = await _membershipTools.UserManager.ChangePasswordAsync(
                    await _membershipTools.UserManager.GetUserAsync(HttpContext.User),
                    model.OldPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    var emailService = new EMailService();
                    var body =
                        $"Merhaba <b>{user.Name} {user.Surname}</b><br>Hesabınızın şifresi değiştirilmiştir. <br> Bilginiz dahilinde olmayan değişiklikler için hesabınızı güvence altına almanızı öneririz.</p>";
                    emailService.Send(new MailModel() { Body = body, Subject = "Şifre Değiştirme hk." }, user.Email);

                    return RedirectToAction("Logout", "Account");
                }
                else
                {
                    var err = "";
                    foreach (var resultError in result.Errors)
                    {
                        err += resultError + " ";
                    }

                    ModelState.AddModelError("", err);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu {ex.Message}",
                    ActionName = "ChangePassword",
                    ControllerName = "Account",
                    ErrorCode = 500
                };
                return RedirectToAction("Error500", "Home");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Activation(string code)
        {

            try
            {
                var user = _membershipTools.UserManager.Users.FirstOrDefault(x => x.ActivationCode == code);

                if (user != null)
                {
                    if (user.EmailConfirmed)
                    {
                        ViewBag.Message =
                            $"<span class='alert alert-success'>Bu hesap daha önce aktive edilmiştir.</span>";
                    }
                    else
                    {
                        user.EmailConfirmed = true;
                        _membershipTools.UserManager.UpdateAsync(user);
                        ViewBag.Message = $"<span class='alert alert-success'>Aktivasyon işleminiz başarılı</span>";
                    }
                }
                else
                {
                    ViewBag.Message = $"<span class='alert alert-danger'>Aktivasyon başarısız</span>";
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "<span class='alert alert-danger'>Aktivasyon işleminde bir hata oluştu</span>";
            }

            return View();
        }



    }

}