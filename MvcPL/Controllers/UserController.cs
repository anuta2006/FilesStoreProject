using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    [Authorize(Roles = "Администратор")]
    public class UserController : Controller
    {
        private readonly IUserServise userService;
        private readonly IRoleService roleService;

        public UserController(IUserServise servise, IRoleService roleService)
        {
            this.userService = servise;
            this.roleService = roleService;
        }

        public ActionResult Index()
        {
            return View(userService.GetAll().Select(user => user.ToMvcUserModel()));
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            BllUser user;

            try
            {
                user = userService.GetById(id);
            }
            catch (ArgumentException e)
            {
                return RedirectToAction("Index", "Error", new { id = e.Message });
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { id = "Ошибка при сохранении файла в БД" });
            }
            
            if (user == null)
            {
                return RedirectToAction("Index", "Error", new { id = "Пользователь не найден!" });
            }

            ViewBag.Roles = roleService.GetAll().GroupBy(item => item.Name).Select(item => item.FirstOrDefault().ToMvcRoleModel());

            return View(user.ToMvcUserModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user, int[] selectedRoles)
        {
            var allRoles = roleService.GetAll().Select(item => item.ToMvcRoleModel());
            var roles = new List<RoleViewModel>();

            if (selectedRoles != null)
            {
                user.RoleNames = new List<string>();

                foreach (var r in allRoles.Where(role => selectedRoles.Contains(role.Id)))
                {
                    user.RoleNames.Add(r.Name);
                    roles.Add(r);
                }
            }

            try
            {
                userService.Update(user.ToBllUser(roles));
            }
            catch (ArgumentNullException e)
            {
                return RedirectToAction("Index", "Error", new { id = "Параметр " + e.Message + " NULL" });
            }
            catch (ArgumentException e)
            {
                return RedirectToAction("Index", "Error", new { id = e.Message });
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { id = "Ошибка при сохранении файла в БД" });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            BllUser user;

            try
            {
                user = userService.GetById(id);
            }
            catch (ArgumentException e)
            {
                return RedirectToAction("Index", "Error", new { id = e.Message });
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { id = "Ошибка при сохранении файла в БД" });
            }

            if (user == null)
            {
                return RedirectToAction("Index", "Error", new { id = "Пользователь не найден!" });
            }

            return View(user.ToMvcUserModel());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(BllUser user)
        {
            try
            {
                userService.Delete(user);
            }
            catch (ArgumentNullException e)
            {
                return RedirectToAction("Index", "Error", new { id = "Параметр " + e.Message + " NULL" });
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { id = "Ошибка при сохранении файла в БД" });
            }

            return RedirectToAction("Index", "User");
        }

    }
}
