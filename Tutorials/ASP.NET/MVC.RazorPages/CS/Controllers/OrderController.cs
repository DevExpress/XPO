using System.Linq;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using DevExpress.Xpo;
using System.Threading.Tasks;
using XpoTutorial;

namespace AspNetCoreRazorPagesApplication.Controllers {

    [Route("api/[controller]")]
    public class OrderController : Controller {

        UnitOfWork unitOfWork;

        public OrderController(UnitOfWork uow) {
            unitOfWork = uow;
        }

        [HttpGet]
        public object Get(int customerId, DataSourceLoadOptions loadOptions) {
            var query = unitOfWork.Query<Order>()
                .Where(t => t.Customer.Oid == customerId)
                .Select(t => new {
                    t.Oid,
                    t.OrderDate,
                    t.ProductName,
                    t.Freight,
                    Customer = new {
                        t.Customer.Oid,
                        t.Customer.FirstName,
                        t.Customer.LastName,
                        t.Customer.ContactName
                    }
                });
            return DataSourceLoader.Load(query, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string values) {
            Order newOrder = JsonPopulateObjectHelper.PopulateObject<Order>(values, unitOfWork);
            await unitOfWork.CommitChangesAsync();
            return Ok(new {
                newOrder.Oid,
                newOrder.OrderDate,
                newOrder.ProductName,
                newOrder.Freight,
                Customer = new {
                    newOrder.Customer.Oid,
                    newOrder.Customer.FirstName,
                    newOrder.Customer.LastName,
                    newOrder.Customer.ContactName
                }
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(int key, string values) {
            var order = await unitOfWork.GetObjectByKeyAsync<Order>(key);
            if(order == null) {
                return NotFound();
            }
            JsonPopulateObjectHelper.PopulateObject(values, unitOfWork, order);
            await unitOfWork.CommitChangesAsync();
            return Ok(new {
                order.Oid,
                order.OrderDate,
                order.ProductName,
                order.Freight,
                Customer = new {
                    order.Customer.Oid,
                    order.Customer.FirstName,
                    order.Customer.LastName,
                    order.Customer.ContactName
                }
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key) {
            var order = await unitOfWork.GetObjectByKeyAsync<Order>(key);
            if(order == null) {
                return NotFound();
            }
            unitOfWork.Delete(order);
            await unitOfWork.CommitTransactionAsync();
            return Ok();
        }
    }
}