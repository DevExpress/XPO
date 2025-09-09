using DevExpress.Xpo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerSideApplication.Services {
    public class OrderService : BaseService {
        public OrderService(IDataLayer dataLayer, UnitOfWork readUnitOfWork)
            : base(dataLayer, readUnitOfWork) { }
        public Task<IQueryable<Order>> Get() {
            var query = (IQueryable<Order>)readUnitOfWork.Query<Order>();
            return Task.FromResult(query);
        }
        public Order CreateObject(Session session) {
            return new Order(session);
        }
        public Task<IQueryable<Order>> GetCustomerOrders(int customerOid) {
            readUnitOfWork.ReloadChangedObjects();
            var query = readUnitOfWork.Query<Order>().Where(order => order.Customer.Oid == customerOid);
            return Task.FromResult(query);
        }
        public async Task Add(Dictionary<string, object> values, int customerOid) {
            using(UnitOfWork uow = CreateModificationUnitOfWork()) {
                var customer = await uow.GetObjectByKeyAsync<Customer>(customerOid);
                Order newOrder = new Order(uow);
                newOrder.Customer = customer;
                PopulateObjectHelper.PopulateObject(uow, newOrder, values);
                await uow.CommitChangesAsync();
            }
        }
        public async Task Update(int oid, Dictionary<string, object> values) {
            using(UnitOfWork uow = CreateModificationUnitOfWork()) {
                Order order = uow.GetObjectByKey<Order>(oid);
                PopulateObjectHelper.PopulateObject(uow, order, values);
                await uow.CommitChangesAsync();
            }
        }
        public async Task Delete(int oid) {
            using(UnitOfWork uow = CreateModificationUnitOfWork()) {
                var order = await uow.GetObjectByKeyAsync<Order>(oid);
                order.Delete();
                await uow.CommitChangesAsync();
            }
        }
    }
}
