using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DevExpress.Xpo.XamarinFormsDemo {
    public class ItemsViewModel : BaseViewModel {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel() {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) => {
                var _item = item as Item;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
            MessagingCenter.Subscribe<ItemsPage, Item>(this, "DeleteItem", async (obj, item) => {
                var _item = item as Item;
                Items.Remove(_item);
                await DataStore.DeleteItemAsync(_item.Id);
            });
            MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "UpdateItem", async (obj, item) => {
                var _item = item as Item;
                Items.Remove(Items.Single(i => i.Id == _item.Id));
                Items.Add(_item);
                await DataStore.UpdateItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand() {
            if(IsBusy)
                return;

            IsBusy = true;
            await LoadItemsAsync();
            IsBusy = false;
        }

        public void UpdateItems() {
            OnPropertyChanged("Items");
        }

        public async Task LoadItemsAsync() {
            try {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach(var item in items) {
                    Items.Add(item);
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex);
            }
        }
    }
}
