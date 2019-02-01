using BotDetect.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeduShop.Common;
using TeduShop.Model.Model;
using TeduShop.Web.App_Start;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Account
        public ActionResult Login(string url)
        {
            ViewBag.ReturnUrl = url;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = _userManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                    ClaimsIdentity identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationProperties props = new AuthenticationProperties();
                    props.IsPersistent = model.RememberMe;
                    authenticationManager.SignIn(props, identity);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng")]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var userEmail = await _userManager.FindByEmailAsync(model.Email);
                if (userEmail != null)
                {
                    ModelState.AddModelError("email", "Email đã tồn tại.");
                    return View(model);
                }
                var userUserName = await _userManager.FindByNameAsync(model.UserName);
                if (userUserName != null)
                {
                    ModelState.AddModelError("tai khoan", "Tài khoản đã tồn tại.");
                    return View(model);
                }

                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = true,
                    Birthday = DateTime.Today,
                    FullName = model.FullName,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber
                };

                await _userManager.CreateAsync(user, model.Password);

                var adminEmail = await _userManager.FindByEmailAsync(model.Email);
                if (adminEmail != null)
                {
                    await _userManager.AddToRolesAsync(adminEmail.Id, new string[] { "User" });
                }

                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/Client/template/email.html"));
                content = content.Replace("{{UserName}}", adminEmail.FullName);
                content = content.Replace("{{Link}}", ConfigHelper.GetByKey("CurrentLink") + "dangnhap.html");

                MailHelper.SendMail(adminEmail.Email, "đăng ký thành công từ website", content);

                ViewData["SuccessMsg"] = "Đăng ký thành công.";
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}