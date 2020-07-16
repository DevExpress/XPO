using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinFormsDemo.Models;
using XamarinFormsDemo.Services;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinFormsDemo.XpoDataStore))]
namespace XamarinFormsDemo {
    public class XpoDataStore : IDataStore<Item> {
        public async Task<bool> AddItemAsync(Item item) {
            try {
                using(var uow = XpoHelper.CreateUnitOfWork()) {
                    item.Id = Guid.NewGuid().ToString();
                    uow.Save(item);
                    await uow.CommitChangesAsync();
                    return true;
                }
            } catch(Exception) {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(string id) {
            try {
                using(var uow = XpoHelper.CreateUnitOfWork()) {
                    var itemToDelete = uow.GetObjectByKey<Item>(id);
                    if(itemToDelete != null) {
                        uow.Delete(itemToDelete);
                        await uow.CommitChangesAsync();
                    }
                    return true;
                }
            } catch(Exception) {
                return false;
            }
        }

        public Task<Item> GetItemAsync(string id) {
            using(var uow = XpoHelper.CreateUnitOfWork()) {
                return uow.GetObjectByKeyAsync<Item>(id);
            }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false) {
            using(var uow = XpoHelper.CreateUnitOfWork()) {
                return await uow.Query<Item>().OrderBy(i => i.Description).ToListAsync();
            }
        }

        public async Task<bool> UpdateItemAsync(Item item) {
            try {
                using(var uow = XpoHelper.CreateUnitOfWork()) {
                    var itemToUpdate = await uow.GetObjectByKeyAsync<Item>(item.Id);
                    if(itemToUpdate == null) {
                        return false;
                    }
                    itemToUpdate.Text = item.Text;
                    itemToUpdate.Description = item.Description;
                    uow.Save(itemToUpdate);
                    await uow.CommitChangesAsync();
                    return true;
                }
            } catch(Exception) {
                return false;
            }
        }
    }
}
