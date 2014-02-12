using System.Web.Mvc;

namespace BrowserCMS_MVC.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Main page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}