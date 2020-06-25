using DevExpress.Xpo;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerSideApplication.Services {

    public abstract class BaseService {
        readonly IDataLayer dataLayer;
        protected readonly UnitOfWork readUnitOfWork;
        public BaseService(IDataLayer dataLayer, UnitOfWork modificationUnitOfWork) {
            this.dataLayer = dataLayer;
            readUnitOfWork = modificationUnitOfWork;
        }
        protected UnitOfWork CreateModificationUnitOfWork() {
            return new UnitOfWork(dataLayer);
        }
    }

    public class CustomerService : BaseService {
        public CustomerService(IDataLayer dataLayer, UnitOfWork modificationUnitOfWork)
            : base(dataLayer, modificationUnitOfWork) { }
        public Task<IQueryable<Customer>> Get() {
            var query = (IQueryable<Customer>)readUnitOfWork.Query<Customer>();
            return Task.FromResult(query);
        }
        public async Task<Customer> Add(Dictionary<string, object> values) {
            string json = JsonConvert.SerializeObject(values);
            using(UnitOfWork uow = CreateModificationUnitOfWork()) {
                var newCustomer = JsonPopulateObjectHelper.PopulateObject<Customer>(json, uow);
                await uow.CommitChangesAsync();
                return await readUnitOfWork.GetObjectByKeyAsync<Customer>(newCustomer.Oid, true);
            }
        }
        public async Task<Customer> Update(int oid, Dictionary<string, object> values) {
            string json = JsonConvert.SerializeObject(values);
            using(UnitOfWork uow = CreateModificationUnitOfWork()) {
                var customer = await uow.GetObjectByKeyAsync<Customer>(oid);
                JsonPopulateObjectHelper.PopulateObject(json, uow, customer);
                await uow.CommitChangesAsync();
            }
            return await readUnitOfWork.GetObjectByKeyAsync<Customer>(oid, true);
        }
        public async Task Delete(int oid) {
            using(UnitOfWork uow = CreateModificationUnitOfWork()) {
                var customer = await uow.GetObjectByKeyAsync<Customer>(oid);
                customer.Delete();
                await uow.CommitChangesAsync();
            }
        }
    }
}