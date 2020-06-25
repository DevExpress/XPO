using System.Linq;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using DevExpress.Xpo;
using System.Threading.Tasks;
using AspNetCoreMvcApplication.DataAccess;

namespace AspNetCoreMvcApplication.Controllers {

    [Route("api/[controller]")]
    public class OrderController : Controller {

        UnitOfWork unitOfWork;

        public OrderController(UnitOfWork uow) {
            unitOfWork = uow;
        }

        [HttpGet]
        public object Get(int customerId, DataSourceLoadOptions loadOptions) {
            var query = unitOfWork.Query<Order>().Where(t => t.Customer.Oid == customerId);
            return DataSourceLoader.Load(query, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string values) {
            Order newOrder = JsonPopulateObjectHelper.PopulateObject<Order>(values, unitOfWork);
            await unitOfWork.CommitChangesAsync();
            return Ok(newOrder);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int key, string values) {
            var order = await unitOfWork.GetObjectByKeyAsync<Order>(key);
            if(order == null) {
                return NotFound();
            }
            JsonPopulateObjectHelper.PopulateObject(values, unitOfWork, order);
            await unitOfWork.CommitChangesAsync();
            return Ok(order);
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