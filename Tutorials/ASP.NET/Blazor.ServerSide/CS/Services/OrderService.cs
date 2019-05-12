using DevExpress.Xpo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpoTutorial;

namespace BlazorServerSideApplication.Services {
    public class OrderService {
        UnitOfWork unitOfWork;
        public OrderService(UnitOfWork uow) {
            unitOfWork = uow;
        }
        public Task<IQueryable<Order>> Get() {
            var query = (IQueryable<Order>)unitOfWork.Query<Order>();
            return Task.FromResult(query);
        }
        public Task<IQueryable<Order>> GetCustomerOrders(Customer customer) {
            var query = (IQueryable<Order>)unitOfWork.Query<Order>().Where(order => order.Customer != null && customer != null & order.Customer.Oid == customer.Oid);
            return Task.FromResult(query);
        }
        public async Task<Order> Add(Dictionary<string, object> values, Customer customer) {
            string json = JsonConvert.SerializeObject(values);
            var dataItem = JsonPopulateObjectHelper.PopulateObject<Order>(json, unitOfWork);
            dataItem.Customer = customer; //TODO: Remove once the DxDataGrid provides the InitNewItemRow event or passes current editor values even if they are unchanged.
            await unitOfWork.CommitChangesAsync();
            return dataItem;
        }
        public async Task<Order> Update(Order dataItem, Dictionary<string, object> values) {
            if(dataItem != null) {
                string json = JsonConvert.SerializeObject(values);
                JsonPopulateObjectHelper.PopulateObject(json, unitOfWork, dataItem);
                await unitOfWork.CommitChangesAsync();
            }
            return dataItem;
        }
        public async Task Delete(Order dataItem) {
            if(dataItem != null) {
                dataItem.Delete();
                await unitOfWork.CommitChangesAsync();
            }
        }
    }
}
