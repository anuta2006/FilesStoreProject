using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    [Authorize(Roles = "Пользователь, Администратор")]
    public class FilesController : Controller
    {
        #region Fields
        private readonly IUserServise userService;
        private readonly IFileService fileService;
        #endregion

        #region Constructor

        public FilesController(IFileService fileService, IUserServise userService)
        {
            this.fileService = fileService;
            this.userService = userService;
        }
        #endregion

        #region Methods
        public ActionResult Index()
        {
            try
            {
                var userId = userService.GetByLogin(HttpContext.User.Identity.Name).Id;
                var files = fileService.GetShared(false)
                    .Where(item => item.UserId == userId)
                    .Select(item => item.ToMvcFileModel());

                ViewBag.Action = RouteData.Values["controller"];

                return View(files);
            }
            catch (ArgumentNullException e)
            {
                return RedirectToAction("Index", "Error", new { id = "Параметр " + e.Message + " NULL" });
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { id = "Ошибка при обращении к БД" });
            }
        }

        [HttpPost]
        public ActionResult Upload()
        {
            var result = new List<FileViewModel>();

            foreach (string file in Request.Files)
            {
                var uploadFile = Request.Files[file];

                if (uploadFile == null)
                    return RedirectToAction("Index", "Error", "Ошибка при загрузке файла");

                var bllFile = new BllFile { Name = Path.GetFileName(uploadFile.FileName) };

                using (var binaryReader = new BinaryReader(uploadFile.InputStream))
                {
                    bllFile.DataOfFile = binaryReader.ReadBytes(uploadFile.ContentLength);
                }

                bllFile.IsShared = false;
                bllFile.UserId = userService.GetByLogin(HttpContext.User.Identity.Name).Id;

                try
                {
                    fileService.Create(bllFile);
                }
                catch (ArgumentNullException e)
                {
                    return RedirectToAction("Index", "Error", new {id = "Параметр " + e.Message + " NULL"});
                }
                catch
                {
                    return RedirectToAction("Index", "Error", new {id = "Ошибка при сохранении файла в БД"});
                }
                    
                result.Add(bllFile.ToMvcFileModel());
            }
            return PartialView("_FilePartial", result);
        }

        [AllowAnonymous]
        public ActionResult GetFile(string id)
        {
            BllFile file;
            BllUser user; 

            try
            {
                file = fileService.GetByUrlLink(id);
                user = userService.GetByLogin(HttpContext.User.Identity.Name);
            }
            catch (ArgumentNullException e)
            {
                return RedirectToAction("Index", "Error", new { id = "Параметр " + e.Message + " NULL" });
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { id = "Ошибка при сохранении файла в БД" });
            }

            if (HttpContext.User.IsInRole("Администратор") || file.IsShared || (user != null && file.UserId == user.Id))
            {
                var arr = file.DataOfFile;
                var fileName = file.Name;
                var contentType = MimeMapping.GetMimeMapping(fileName);
                return File(arr, contentType, fileName);
            }
            return RedirectToAction("Index", "Error", new {id = "Вам недоступен данный файл"});
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            BllFile file;

            try
            {
                file = fileService.GetById(id);
            }
            catch (ArgumentException e)
            {
                return RedirectToAction("Index", "Error", new { id = e.Message });
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { id = "Ошибка при сохранении файла в БД" });
            }

            if (file == null)
            {
                return RedirectToAction("Index", "Error", new { id = "Файл не найден" });
            }
            return View(file.ToMvcFileModel());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(BllFile file)
        {
            try
            {
                fileService.Delete(file);
            }
            catch (ArgumentNullException e)
            {
                return RedirectToAction("Index", "Error", new { id = "Параметр " + e.Message + " NULL" });
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { id = "Ошибка при сохранении файла в БД" });
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFile(FileViewModel file)
        {
            var access = Request.Form["access"];
            file.IsShared = access.Equals("Общий");

            try
            {
                fileService.Update(file.ToBllFile());
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

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Search(string name)
        {
            List<BllFile> files;

            try
            {
                files = fileService.Search(name).ToList();
            }
            catch (ArgumentNullException e)
            {
                return RedirectToAction("Index", "Error", new { id = "Параметр " + e.Message + " NULL" });
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { id = "Ошибка при сохранении файла в БД" });
            }

            if (!files.Any())
            {
                return RedirectToAction("Index", "Error", new { id = "Файлы не найдены" });
            }

            return PartialView("_Search", files.Select(item => item.UserId != null 
                ? item.ToMvcFileModel(userService.GetById(item.UserId.Value).Login) 
                : null));
        }

        public ActionResult GetUsersFiles()
        {
            try
            {
                var files = fileService.GetShared(false)
                    .Select(item => item.ToMvcFileModel());

                return View(files);
            }
            catch (ArgumentNullException e)
            {
                return RedirectToAction("Index", "Error", new { id = "Параметр " + e.Message + " NULL" });
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { id = "Ошибка при сохранении файла в БД" });
            }
        }
        #endregion
    }
}
