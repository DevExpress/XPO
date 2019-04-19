using System;
using System.Web.Mvc;
using DevExpress.Xpo;

namespace AspNetMvcApplication.Controllers {

    public abstract class BaseController : Controller {
        protected readonly UnitOfWork UnitOfWork;
        public BaseController() {
            UnitOfWork = new UnitOfWork(XpoDefault.DataLayer);
        }
        public void SafeExecute(Action method) {
            try {
                method();
            } catch(Exception e) {
                ViewData["EditError"] = e.Message;
            }
        }
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            if(disposing) {
                UnitOfWork.Dispose();
            }
        }
    }
}