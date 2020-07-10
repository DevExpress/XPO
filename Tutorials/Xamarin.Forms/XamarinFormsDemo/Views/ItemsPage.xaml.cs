using System;
using Xamarin.Forms;

using XamarinFormsDemo.Models;
using XamarinFormsDemo.ViewModels;

namespace XamarinFormsDemo.Views {
    public partial class ItemsPage : ContentPage {
        ItemsViewModel viewModel;

        public ItemsPage() {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args) {
            var item = args.SelectedItem as Item;
            if(item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new NewItemPage());
        }

        async void Delete_Clicked(object sender, EventArgs e) {
            Button button = (Button)sender;
            Item item = button.BindingContext as Item;
            if(item != null) {
                var result = await DisplayAlert("Delete", $"Are you sure you want to delete the \"{item.Text}\" item?", "Yes", "No");
                if(result) {
                    MessagingCenter.Send(this, "DeleteItem", item);
                }
            }
        }

        protected override async void OnAppearing() {
            base.OnAppearing();

            if(viewModel.Items.Count == 0) {
                await viewModel.LoadItemsAsync();
            } else {
                viewModel.UpdateItems();
            }
        }
    }
}