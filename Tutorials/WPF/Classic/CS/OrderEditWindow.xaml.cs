using System;
using DevExpress.Xpf.Core;
using WpfApplication.Wrappers;
using XpoTutorial;

namespace WpfApplication {
    /// <summary>
    /// Interaction logic for OrderEditWindow.xaml
    /// </summary>
    public partial class OrderEditWindow : ThemedWindow {
        readonly OrderEditWrapper model;

        public OrderEditWindow(Order order) {
            InitializeComponent();
            model = new OrderEditWrapper(order);
            DataContext = model;
        }

        private void ButtonSave_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            model.Save();
            DialogResult = true;
        }

        private void ButtonCancel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            DialogResult = false;
        }

        private void ButtonReload_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            model.Reload();
        }
    }
}
