﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> usermanager;
        private readonly SignInManager<AppUser> signinmanager;

        public AccountController(UserManager<AppUser> _usermanager, SignInManager<AppUser> _signinmanager)
        {
            usermanager = _usermanager;
            signinmanager = _signinmanager;
        }
        // GET: AccountController
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Register collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Check ther required fields");
                    return View();
                }
                var user = new AppUser();
                user.Email = collection.Email;
                user.UserName = collection.Email;

                var result = await usermanager.CreateAsync(user,collection.Password);
                if (result.Succeeded)
                {
                    await signinmanager.SignInAsync(user,isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("", result.Errors.ToString());
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController
        public ActionResult Login()
        {
            var loginUrl = Url.Action("Login", "Account", new { area = "Admin" });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Check ther required fields");
                    return View();
                }
                

                var result = await signinmanager.PasswordSignInAsync(collection.Email,collection.Password,isPersistent:collection.RememberMe, lockoutOnFailure:false);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Wrong Email or Password!");
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController
        public ActionResult Logout()
        {
            signinmanager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}
