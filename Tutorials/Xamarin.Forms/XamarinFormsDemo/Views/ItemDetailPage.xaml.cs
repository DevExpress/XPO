using System;
using Xamarin.Forms;

using XamarinFormsDemo.Models;
using XamarinFormsDemo.ViewModels;

namespace XamarinFormsDemo.Views {
    public partial class ItemDetailPage : ContentPage {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage() {
            InitializeComponent();

            var item = new Item {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ItemDetailPage(ItemDetailViewModel viewModel) {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        async void Update_Clicked(object sender, EventArgs e) {
            MessagingCenter.Send(this, "UpdateItem", viewModel.Item);
            await Navigation.PopToRootAsync();
        }
    }
}
