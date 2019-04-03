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


        public AccountController(IRepoIdentity userRoleRepo, MembershipTools membershipTools, RoleUserRepo roleUserRepo, IHostingEnvironment hostingEnvironment)
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
                var data =  _membershipTools.ConvertProfile(user);

               
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
        public async Task<ActionResult> UpdateProfile(UserProfileViewModel model)
        {
            var user = await _membershipTools.UserManager.FindByIdAsync(model.Id);
            //var oldPath = user.AvatarPath;
            //if (oldPath != null || oldPath != "")
            //{
            //    System.IO.File.Delete(oldPath);
            //}
            if (!ModelState.IsValid)
            {
                return View("UserProfile", model);
            }

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
                return RedirectToAction("Error500", "Home");
            }
        }


        //TODO BURADAN SONRASI KONTROL EDİLECEK
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public async Task<ActionResult> ChangePassword(ProfilePasswordViewModel model)
        //{
        //    try
        //    {
        //        var userManager = NewUserManager();
        //        var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
        //        var user = NewUserManager().FindById(id);
        //        var data = new ProfilePasswordViewModel()
        //        {
        //            UserProfileViewModel = new UserProfileViewModel()
        //            {
        //                Email = user.Email,
        //                Id = user.Id,
        //                Name = user.Name,
        //                PhoneNumber = user.PhoneNumber,
        //                Surname = user.Surname,
        //                UserName = user.UserName
        //            }
        //        };
        //        model.UserProfileViewModel = data.UserProfileViewModel;
        //        if (!ModelState.IsValid)
        //        {
        //            model.ChangePasswordViewModel = new ChangePasswordViewModel();
        //            return View("UserProfile", model);
        //        }


        //        var result = await userManager.ChangePasswordAsync(
        //            HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId(),
        //            model.ChangePasswordViewModel.OldPassword, model.ChangePasswordViewModel.NewPassword);

        //        if (result.Succeeded)
        //        {
        //            //todo kullanıcıyı bilgilendiren bir mail atılır
        //            return RedirectToAction("Logout", "Account");
        //        }
        //        else
        //        {
        //            var err = "";
        //            foreach (var resultError in result.Errors)
        //            {
        //                err += resultError + " ";
        //            }
        //            ModelState.AddModelError("", err);
        //            model.ChangePasswordViewModel = new ChangePasswordViewModel();
        //            return View("UserProfile", model);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Model"] = new ErrorViewModel()
        //        {
        //            Text = $"Bir hata oluştu {ex.Message}",
        //            ActionName = "UserProfile",
        //            ControllerName = "Account",
        //            ErrorCode = 500
        //        };
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

        //[HttpGet]
        //[AllowAnonymous]
        //public ActionResult Activation(string code)
        //{
        //    try
        //    {
        //        var userStore = NewUserStore();
        //        var user = userStore.Users.FirstOrDefault(x => x.ActivationCode == code);

        //        if (user != null)
        //        {
        //            if (user.EmailConfirmed)
        //            {
        //                ViewBag.Message = $"<span class='alert alert-success'>Bu hesap daha önce aktive edilmiştir.</span>";
        //            }
        //            else
        //            {
        //                user.EmailConfirmed = true;

        //                userStore.Context.SaveChanges();
        //                ViewBag.Message = $"<span class='alert alert-success'>Aktivasyon işleminiz başarılı</span>";
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Message = $"<span class='alert alert-danger'>Aktivasyon başarısız</span>";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Message = "<span class='alert alert-danger'>Aktivasyon işleminde bir hata oluştu</span>";
        //    }

        //    return View();
        //}

        //[HttpGet]
        //[AllowAnonymous]
        //public ActionResult RecoverPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[AllowAnonymous]
        //public async Task<ActionResult> RecoverPassword(RecoverPasswordViewModel model)
        //{
        //    try
        //    {
        //        var userStore = NewUserStore();
        //        var userManager = NewUserManager();
        //        var user = await userStore.FindByEmailAsync(model.Email);
        //        if (user == null)
        //        {
        //            ModelState.AddModelError(string.Empty, $"{model.Email} mail adresine kayıtlı bir üyeliğe erişilemedi");
        //            return View(model);
        //        }

        //        var newPassword = StringHelpers.GetCode().Substring(0, 6);
        //        await userStore.SetPasswordHashAsync(user, userManager.PasswordHasher.HashPassword(newPassword));
        //        var result = userStore.Context.SaveChanges();
        //        if (result == 0)
        //        {
        //            TempData["Model"] = new ErrorViewModel()
        //            {
        //                Text = $"Bir hata oluştu",
        //                ActionName = "RecoverPassword",
        //                ControllerName = "Account",
        //                ErrorCode = 500
        //            };
        //            return RedirectToAction("Error", "Home");
        //        }

        //        var emailService = new EmailService();
        //        var body = $"Merhaba <b>{user.Name} {user.Surname}</b><br>Hesabınızın parolası sıfırlanmıştır<br> Yeni parolanız: <b>{newPassword}</b> <p>Yukarıdaki parolayı kullanarak sistemize giriş yapabilirsiniz.</p>";
        //        emailService.Send(new IdentityMessage() { Body = body, Subject = $"{user.UserName} Şifre Kurtarma" }, user.Email);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Model"] = new ErrorViewModel()
        //        {
        //            Text = $"Bir hata oluştu {ex.Message}",
        //            ActionName = "RecoverPassword",
        //            ControllerName = "Account",
        //            ErrorCode = 500
        //        };
        //        return RedirectToAction("Error", "Home");
        //    }

        //    return View();
        //}
    }

}