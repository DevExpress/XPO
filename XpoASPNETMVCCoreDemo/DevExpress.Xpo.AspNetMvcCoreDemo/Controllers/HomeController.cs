using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevExpress.Xpo.AspNetMvcCoreDemo.Models;

namespace DevExpress.Xpo.AspNetMvcCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "DevExpress XPO Demo Application for .NET Core 2.0";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "We are Here to Help";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
