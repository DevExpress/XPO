using DevExpress.Web.Mvc;
using DevExpress.Xpo;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using XpoTutorial;

namespace AspNetMvcApplication {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.DefaultBinder = new DevExpressEditorsBinder();

            ConnectionHelper.Connect();
            using (UnitOfWork uow = new UnitOfWork()) {
                DemoDataHelper.Seed(uow);
            }

            DevExpress.Web.ASPxWebControl.CallbackError += Application_Error;
        }

        protected void Application_Error(object sender, EventArgs e) {
            Exception exception = System.Web.HttpContext.Current.Server.GetLastError();
            //TODO: Handle Exception
        }
    }
}