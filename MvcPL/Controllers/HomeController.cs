using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;

namespace MvcPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileService fileService;

        public HomeController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public ActionResult Index()
        {
            try
            {
                var files = fileService.GetShared(true).Select(item => item.ToMvcFileModel());

                ViewBag.Action = RouteData.Values["controller"];

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
    }
}
