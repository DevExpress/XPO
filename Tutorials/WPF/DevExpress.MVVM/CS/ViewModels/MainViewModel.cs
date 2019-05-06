using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System.Linq;

namespace WpfApplicationMvvm.ViewModels {
    public class MainViewModel :ViewModelBase {
        protected IDocumentManagerService DocumentManagerService {
            get { return GetService<IDocumentManagerService>(); }
        }
        [Command]
        public void CreateDocument() {
            IDocument doc = DocumentManagerService.CreateDocument("CustomerListView", null, this);
            doc.Id = string.Format("DocId_{0}", DocumentManagerService.Documents.Count());
            doc.Title = "Customers";
            doc.Show();
        }
    }
}
