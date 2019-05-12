using DevExpress.Xpo;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XpoTutorial;

namespace BlazorServerSideApplication.Services {
    public class CustomerService {
        UnitOfWork unitOfWork;
        public CustomerService(UnitOfWork uow) {
            unitOfWork = uow;
        }
        public Task<IQueryable<Customer>> Get() {
            var query = (IQueryable<Customer>)unitOfWork.Query<Customer>();
            return Task.FromResult(query);
        }
        public async Task<Customer> Add(Dictionary<string, object> values) {
            string json = JsonConvert.SerializeObject(values);
            var dataItem = JsonPopulateObjectHelper.PopulateObject<Customer>(json, unitOfWork);
            await unitOfWork.CommitChangesAsync();
            return dataItem;
        }
        public async Task<Customer> Update(Customer dataItem, Dictionary<string, object> values) {
            if(dataItem != null) {
                string json = JsonConvert.SerializeObject(values);
                JsonPopulateObjectHelper.PopulateObject(json, unitOfWork, dataItem);
                await unitOfWork.CommitChangesAsync();
            }
            return dataItem;
        }
        public async Task Delete(Customer dataItem) {
            if(dataItem != null) {
                dataItem.Delete();
                await unitOfWork.CommitChangesAsync();
            }
        }
    }
}
