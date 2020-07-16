using DevExpress.Xpo.DB;
using System;
using System.IO;
using Xamarin.Forms;

namespace XamarinFormsDemo.Views {
     public partial class MainPage : TabbedPage {
        public MainPage() {
            Page itemsPage, aboutPage = null;

            switch(Device.RuntimePlatform) {
                case Device.iOS:
                    itemsPage = new NavigationPage(new ItemsPage()) {
                        Title = "Browse"
                    };

                    aboutPage = new NavigationPage(new AboutPage()) {
                        Title = "About"
                    };
                    itemsPage.IconImageSource = "tab_feed.png";
                    aboutPage.IconImageSource = "tab_about.png";
                    break;
                default:
                    itemsPage = new ItemsPage() {
                        Title = "Browse"
                    };

                    aboutPage = new AboutPage() {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(itemsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged() {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
