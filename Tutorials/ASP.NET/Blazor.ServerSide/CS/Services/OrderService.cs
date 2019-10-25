using DevExpress.Xpo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpoTutorial;

namespace BlazorServerSideApplication.Services {
    public class OrderService : BaseService {
        public OrderService(IDataLayer dataLayer, UnitOfWork readUnitOfWork)
            : base(dataLayer, readUnitOfWork) { }
        public Task<IQueryable<Order>> Get() {
            var query = (IQueryable<Order>)readUnitOfWork.Query<Order>();
            return Task.FromResult(query);
        }
        public Task<IQueryable<Order>> GetCustomerOrders(int customerOid) {
            var query = readUnitOfWork.Query<Order>().Where(order => order.Customer.Oid == customerOid);
            return Task.FromResult(query);
        }
        public async Task<Order> Add(Dictionary<string, object> values, int customerOid) {
            string json = JsonConvert.SerializeObject(values);
            using(UnitOfWork uow = CreateModificationUnitOfWork()) {
                var customer = await uow.GetObjectByKeyAsync<Customer>(customerOid);
                var newOrder = JsonPopulateObjectHelper.PopulateObject<Order>(json, uow);
                newOrder.Customer = customer;
                await uow.CommitChangesAsync();
                return await readUnitOfWork.GetObjectByKeyAsync<Order>(newOrder.Oid, true);
            }
        }
        public async Task<Order> Update(int oid, Dictionary<string, object> values) {
            string json = JsonConvert.SerializeObject(values);
            using(UnitOfWork uow = CreateModificationUnitOfWork()) {
                var order = await uow.GetObjectByKeyAsync<Order>(oid);
                JsonPopulateObjectHelper.PopulateObject(json, uow, order);
                await uow.CommitChangesAsync();
            }
            return await readUnitOfWork.GetObjectByKeyAsync<Order>(oid, true);
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
