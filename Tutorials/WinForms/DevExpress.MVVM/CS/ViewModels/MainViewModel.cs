using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using XpoTutorial;

namespace WinFormsApplication.ViewModels {
    public class MainViewModel {
        protected IDocumentManagerService DocumentManagerService {
            get { return this.GetService<IDocumentManagerService>(); }
        }
        public void ShowCustomers() {
            var id = new ViewID(typeof(Customer));
            IDocument document = DocumentManagerService.FindDocumentByIdOrCreate(id, svc => {
                var doc = svc.CreateDocument("CustomerListView", null, this);
                doc.Id = id;
                doc.Title = "Customers";
                return doc;
            });
            document.Show();
        }
        public void ShowOrders() {
            var id = new ViewID(typeof(Order));
            IDocument document = DocumentManagerService.FindDocumentByIdOrCreate(id, svc => {
                var doc = svc.CreateDocument("OrderListView", null, this);
                doc.Id = id;
                doc.Title = "Orders";
                return doc;
            });
            document.Show();
        }
    }
}
