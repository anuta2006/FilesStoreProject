using System.Net;
using System.Web.Mvc;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(string id)
        {         
            return View(new ErrorViewModel(){Message = id});
        }
    }
}
