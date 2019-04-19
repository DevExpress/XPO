using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMvcApplication.Models;
using DevExpress.Xpo;
using XpoTutorial;

namespace AspNetMvcApplication.Controllers {

    public class CustomerController : BaseController {

        [ValidateInput(false)]
        public ActionResult CustomerListPartial() {
            var model = UnitOfWork.Query<Customer>()
                .Select(t => new CustomerViewModel() {
                    Oid = t.Oid,
                    FirstName = t.FirstName,
                    LastName = t.LastName
                });
            return PartialView("CustomerListPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddCustomer(CustomerViewModel model) {
            if(ModelState.IsValid) {
                SafeExecute(() => {
                    var customer = new Customer(UnitOfWork) {
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };
                    UnitOfWork.CommitChanges();
                });
            } else {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            return CustomerListPartial();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateCustomer(CustomerViewModel model) {
            if(ModelState.IsValid) {
                SafeExecute(() => {
                    var customer = UnitOfWork.GetObjectByKey<Customer>(model.Oid);
                    customer.FirstName = model.FirstName;
                    customer.LastName = model.LastName;
                    UnitOfWork.CommitChanges();
                });
            } else {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            return CustomerListPartial();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DeleteCustomer(int Oid) {
            SafeExecute(() => {
                var customer = UnitOfWork.GetObjectByKey<Customer>(Oid);
                customer.Delete();
                UnitOfWork.CommitChanges();
            });
            return CustomerListPartial();
        }
    }
}