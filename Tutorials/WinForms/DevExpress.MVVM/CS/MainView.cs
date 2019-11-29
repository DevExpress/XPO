using DevExpress.XtraBars.Ribbon;
using WinFormsApplication.ViewModels;

namespace WinFormsApplication {
    public partial class MainView : RibbonForm {
        public MainView() {
            InitializeComponent();
            if(!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }
        void InitializeBindings() {
            var fluentApi = mvvmContext1.OfType<MainViewModel>();
            fluentApi.WithEvent(this, nameof(Load))
                .EventToCommand(x => x.ShowCustomers());
            //
            fluentApi.BindCommand(customersBarButtonItem, x => x.ShowCustomers());
            fluentApi.BindCommand(customersAccordionControlElement, x => x.ShowCustomers());
            fluentApi.BindCommand(ordersBarButtonItem, x => x.ShowOrders());
            fluentApi.BindCommand(ordersAccordionControlElement, x => x.ShowOrders());
        }
    }
}
