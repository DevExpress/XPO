using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace DevExpress.Xpo.XamarinFormsDemo {
    public class AboutViewModel : BaseViewModel {
        public AboutViewModel() {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.devexpress.com/Products/NET/ORM/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}