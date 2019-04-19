using System.Linq;
using System.Web.Mvc;
using DevExpress.Xpo;
using AspNetMvcApplication.Models;
using XpoTutorial;

namespace AspNetMvcApplication.Controllers {

    public class OrderController : BaseController {

        [ValidateInput(false)]
        public ActionResult OrderListPartial(int customerOid) {
            var model = UnitOfWork.Query<Customer>()
                .Select(t => new CustomerViewModel() {
                    Oid = t.Oid,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Orders = t.Orders.Select(o => new OrderViewModel() {
                        Oid = o.Oid,
                        OrderDate = o.OrderDate,
                        ProductName = o.ProductName,
                        Freight = o.Freight,
                        CustomerId = o.Customer.Oid
                    }).ToList()
                }).FirstOrDefault(t => t.Oid == customerOid);
            ViewData["CustomersList"] = UnitOfWork.Query<Customer>()
                .Select(t => new CustomerViewModel() {
                    Oid = t.Oid,
                    FirstName = t.FirstName,
                    LastName = t.LastName
                }).OrderBy(t => t.FirstName).ThenBy(t => t.LastName).ToList();
            return PartialView("OrderListPartial", model);
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult AddOrder(int customerOid, OrderViewModel model) {
            if(ModelState.IsValid) {
                SafeExecute(() => {
                    var order = new Order(UnitOfWork) {
                        OrderDate = model.OrderDate,
                        ProductName = model.ProductName,
                        Freight = model.Freight,
                        Customer = UnitOfWork.GetObjectByKey<Customer>(model.CustomerId)
                    };
                    UnitOfWork.CommitChanges();
                });
            } else {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            return OrderListPartial(customerOid);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateOrder(int customerOid, OrderViewModel model) {
            if(ModelState.IsValid) {
                SafeExecute(() => {
                    var order = UnitOfWork.GetObjectByKey<Order>(model.Oid);
                    order.OrderDate = model.OrderDate;
                    order.ProductName = model.ProductName;
                    order.Freight = model.Freight;
                    order.Customer = UnitOfWork.GetObjectByKey<Customer>(model.CustomerId);
                    UnitOfWork.CommitChanges();
                });
            } else {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            return OrderListPartial(customerOid);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DeleteOrder(int customerOid, int Oid) {
            SafeExecute(() => {
                var order = UnitOfWork.GetObjectByKey<Order>(Oid);
                order.Delete();
                UnitOfWork.CommitChanges();
            });
            return OrderListPartial(customerOid);
        }
    }
}