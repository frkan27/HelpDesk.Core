﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HelpDesk.BLL;
using HelpDesk.BLL.Repository.Abstracts;
using HelpDesk.Model.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepoIdentity _userRoleRepo;
        private readonly MembershipTools _membershipTools;


        public AccountController(IRepoIdentity userRoleRepo, MembershipTools membershipTools)
        {
            _membershipTools = membershipTools;
            _userRoleRepo = userRoleRepo;
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
        public async Task<ActionResult> UserProfileAsync()
        {
            try
            {
                //MVCDEki HTTPCONTEXT gitti sadece context kaldı . context. diyincede olur
                var  UserId = await _membershipTools.GetCurrentUser(User);

                var data = new ProfilePasswordViewModel()
                {
                    UserProfileViewModel = new UserProfileViewModel()
                    {
                        Email = user.Email,
                        Id = user.Id,
                        Name = user.Name,
                        PhoneNumber = user.PhoneNumber,
                        Surname = user.Surname,
                        UserName = user.UserName,
                        AvatarPath = string.IsNullOrEmpty(user.AvatarPath) ? "/assets/img/avatars/avatar3.jpg" : user.AvatarPath
                    }
                };
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
    }

}