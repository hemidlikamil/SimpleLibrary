using SimpleLibrary.CustomAuth;
using SimpleLibrary.Uow;
using SimpleLibrary.ViewModels;
using System.Web.Mvc;
using SimpleLibrary.Services;

namespace SimpleLibrary.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl = "")
        {
            if (SessionProvider.IsLoggedIn)
            {
                return LogOut();
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Logon(LogonViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = _userService.FindUserBy(model.UserName, model.Password);
                if (user != null)
                {
                    SessionProvider.Login(user);
                    return Json(new { Success = true });
                }

                return Json(new { Success = false, Error = "Login failed" });
            }

            return Json(new { Success = false, Error = "Invalid or empty username/password" });

        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var success = false;

            if (ModelState.IsValid)
            {
                success = _userService.Register(model.Username, model.Password, model.ConfirmPassword);
            }

            return Json(new { Success = success });
        }

        public ActionResult LogOut()
        {
            SessionProvider.Logout();
            return RedirectToAction("Login", "Account", null);
        }
    }
}