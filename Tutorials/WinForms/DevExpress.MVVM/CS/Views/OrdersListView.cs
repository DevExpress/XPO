using System.Windows.Forms;
using DevExpress.Utils.MVVM.UI;
using DevExpress.XtraGrid.Views.Grid;
using WinFormsApplication.Services;
using WinFormsApplication.ViewModels;

namespace WinFormsApplication.Views {
    [ViewType("OrderListView")]
    public partial class OrdersListView : DevExpress.XtraBars.Ribbon.RibbonForm {
        public OrdersListView() {
            InitializeComponent();
            if(!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }
        void InitializeBindings() {
            mvvmContext1.RegisterService(new InstantFeedbackService(ordersGridView));
            //
            var fluentApi = mvvmContext1.OfType<OrderListViewModel>();
            fluentApi.SetBinding(ordersGridControl, bs => bs.DataSource, x => x.Orders);
            fluentApi.WithEvent<RowClickEventArgs>(ordersGridView, nameof(ordersGridView.RowClick))
                .EventToCommand(x => x.Edit(),
                    (RowClickEventArgs args) => args.Clicks == 2 && args.Button == MouseButtons.Left);
            fluentApi.BindCommand(btnNew, x => x.Add());
            fluentApi.BindCommand(btnDelete, x => x.Delete());
        }
    }
}
