using System.Windows.Forms;
using DevExpress.Utils.MVVM.UI;
using DevExpress.XtraGrid.Views.Grid;
using WinFormsApplication.Services;
using WinFormsApplication.ViewModels;

namespace WinFormsApplication.Views {
    [ViewType("CustomerListView")]
    public partial class CustomersListView : DevExpress.XtraBars.Ribbon.RibbonForm {
        public CustomersListView() {
            InitializeComponent();
            if(!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }
        void InitializeBindings() {
            mvvmContext1.RegisterService(new InstantFeedbackService(CustomersGridView));
            //
            var fluentApi = mvvmContext1.OfType<CustomerListViewModel>();
            fluentApi.WithEvent(this, nameof(Load))
                .EventToCommand(x => x.Reload());
            fluentApi.SetBinding(CustomersGridControl, bs => bs.DataSource, x => x.Customers);
            fluentApi.WithEvent<RowClickEventArgs>(CustomersGridView, nameof(CustomersGridView.RowClick))
                .EventToCommand(x => x.Edit(),
                    (RowClickEventArgs args) => args.Clicks == 2 && args.Button == MouseButtons.Left);
            fluentApi.BindCommand(btnNew, x => x.Add());
            fluentApi.BindCommand(btnDelete, x => x.Delete());
        }
    }
}
