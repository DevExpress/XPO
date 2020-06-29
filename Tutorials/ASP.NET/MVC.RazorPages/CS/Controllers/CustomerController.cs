
using System.Linq;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using DevExpress.Xpo;
using System.Threading.Tasks;
using AspNetCoreRazorPagesApplication.DataAccess;
using AspNetCoreRazorPagesApplication.Helpers;

namespace AspNetCoreRazorPagesApplication.Controllers {

    [Route("api/[controller]")]
    public class CustomerController : Controller {

        UnitOfWork unitOfWork;

        public CustomerController(UnitOfWork uow) {
            unitOfWork = uow;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions) {
            var query = unitOfWork.Query<Customer>().Select(t => new {
                t.Oid,
                t.FirstName,
                t.LastName,
                t.ContactName
            });
            return DataSourceLoader.Load(query, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string values) {
            var newCustomer = JsonPopulateObjectHelper.PopulateObject<Customer>(values, unitOfWork);
            await unitOfWork.CommitChangesAsync();
            return Ok(new {
                newCustomer.Oid,
                newCustomer.FirstName,
                newCustomer.LastName,
                newCustomer.ContactName
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(int key, string values) {
            var customer = await unitOfWork.GetObjectByKeyAsync<Customer>(key);
            if(customer == null) {
                return NotFound();
            }
            JsonPopulateObjectHelper.PopulateObject(values, unitOfWork, customer);
            await unitOfWork.CommitChangesAsync();
            return Ok(new {
                customer.Oid,
                customer.FirstName,
                customer.LastName,
                customer.ContactName
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key) {
            var customer = await unitOfWork.GetObjectByKeyAsync<Customer>(key);
            if(customer == null) {
                return NotFound();
            }
            customer.Delete();
            await unitOfWork.CommitChangesAsync();
            return Ok();
        }
    }
}