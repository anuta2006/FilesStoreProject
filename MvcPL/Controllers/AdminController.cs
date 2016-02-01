using System.Web.Mvc;
using System.Web.Security;
using MvcPL.Providers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    [Authorize(Roles = "Администратор")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(RoleViewModel role)
        {
            if (!ModelState.IsValid) return View(role);

            ((CustomRoleProvider)Roles.Provider).CreateRole(role.Name);

            return RedirectToAction("Index");
        }
    }
}
