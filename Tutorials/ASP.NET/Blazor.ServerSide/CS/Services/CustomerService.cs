using DevExpress.Xpo;
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
        public async Task Add(Dictionary<string, object> values) {
            using(UnitOfWork uow = CreateModificationUnitOfWork()) {
                Customer newCustomer = new Customer(uow);
                PopulateObjectHelper.PopulateObject(uow, newCustomer, values);
                await uow.CommitChangesAsync();
            }
        }
        public async Task Update(int oid, Dictionary<string, object> values) {
            using(UnitOfWork uow = CreateModificationUnitOfWork()) {
                Customer customer = uow.GetObjectByKey<Customer>(oid);
                PopulateObjectHelper.PopulateObject(uow, customer, values);
                await uow.CommitChangesAsync();
            }
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
