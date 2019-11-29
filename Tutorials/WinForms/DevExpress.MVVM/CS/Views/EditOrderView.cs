using DevExpress.XtraEditors;
using WinFormsApplication.ViewModels;

namespace WinFormsApplication.Forms {
    public partial class EditOrderView : XtraForm {
        public EditOrderView() {
            InitializeComponent();
            if(!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }
        void InitializeBindings() {
            var fluentApi = mvvmContext1.OfType<EditOrderViewModel>();
            fluentApi.SetBinding(OrderBindingSource, bs => bs.DataSource, x => x.Order);
            fluentApi.SetBinding(CustomersBindingSource, bs => bs.DataSource, x => x.Customers);
            //
            fluentApi.BindCommand(btnSave, x => x.Save());
            fluentApi.BindCommand(btnReload, x => x.Reload());
        }
    }
}
