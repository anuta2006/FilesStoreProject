using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using MvcPL.ViewModels;
using MvcPL.Providers;

namespace MvcPL.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Fields
        private readonly IUserServise servise;
        #endregion

        #region Constructor
        public AccountController(IUserServise servise)
        {
            this.servise = servise;
        }
        #endregion

        #region Methods
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOnViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Login, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Login, viewModel.RememberMe);

                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Неправильный логин или пароль");
            }
            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            var anyUser = servise.GetAll().Any(u => u.Login == viewModel.Login);

            if (anyUser)
            {
                ModelState.AddModelError("", "Пользователь с таким паролем уже существует.");
                return View(viewModel);
            }

            if (ModelState.IsValid)
            {
                var membershipUser = ((CustomMembershipProvider) Membership.Provider)
                    .CreateUser(viewModel.Login, viewModel.Password);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка регистрации");
                }
            }
            return View(viewModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
