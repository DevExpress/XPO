using System;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcApplication.Controllers {

    public class HomeController : BaseController {
        public ActionResult Index() {
            return View();
        }
    }
}