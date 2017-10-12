using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(DevExpress.Xpo.XamarinFormsDemo.XpoDataStore))]
namespace DevExpress.Xpo.XamarinFormsDemo {
    public class XpoDataStore : IDataStore<Item> {
        public async Task<bool> AddItemAsync(Item item) {
            try {
                using(var uow = XpoHelper.CreateUnitOfWork()) {
                    item.Id = Guid.NewGuid().ToString();
                    uow.Save(item);
                    uow.CommitChanges();
                }
            } catch(Exception) {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id) {
            try {
                using(var uow = XpoHelper.CreateUnitOfWork()) {
                    var itemToDelete = uow.GetObjectByKey<Item>(id);
                    if(itemToDelete != null) {
                        uow.Delete(itemToDelete);
                        uow.CommitChanges();
                    }
                }
            } catch(Exception) {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id) {
            using(var uow = XpoHelper.CreateUnitOfWork()) {
                var item = uow.GetObjectByKey<Item>(id);
                return await Task.FromResult(item);
            }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false) {
            using(var uow = XpoHelper.CreateUnitOfWork()) {
                return await Task.FromResult(uow.Query<Item>().OrderBy(i => i.Text).ToList());
            }
        }

        public async Task<bool> UpdateItemAsync(Item item) {
            try {
                using(var uow = XpoHelper.CreateUnitOfWork()) {
                    var itemToUpdate = uow.GetObjectByKey<Item>(item.Id);
                    if(itemToUpdate == null) {
                        return await Task.FromResult(false);
                    }
                    itemToUpdate.Text = item.Text;
                    itemToUpdate.Description = item.Description;
                    uow.Save(itemToUpdate);
                    uow.CommitChanges();
                }
            } catch(Exception) {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }
    }
}
