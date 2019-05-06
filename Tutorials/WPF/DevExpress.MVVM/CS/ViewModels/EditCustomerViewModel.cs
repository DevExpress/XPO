using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using XpoTutorial;
using System.Linq;

namespace WpfApplicationMvvm.ViewModels {
    public class EditCustomerViewModel : ViewModelBase {
        public EditCustomerViewModel() {
            if (!IsInDesignMode)
                UnitOfWork = new UnitOfWork();
        }
        public Customer CurrentItem {
            get { return GetProperty(() => CurrentItem); }
            set { SetProperty(() => CurrentItem, value); }
        }
        public Order CurrentOrder {
            get { return GetProperty(() => CurrentOrder); }
            set { SetProperty(() => CurrentOrder, value); }
        }
        protected UnitOfWork UnitOfWork { get; private set; }
        protected IMessageBoxService MessageBoxService {
            get { return GetService<IMessageBoxService>(); }
        }
        protected IDocumentManagerService DocumentManagerService {
            get { return GetService<IDocumentManagerService>(); }
        }
        protected override void OnParameterChanged(object parameter) {
            if (UnitOfWork == null) return;
            CurrentItem = UnitOfWork.GetObjectByKey<Customer>(parameter);
            if (CurrentItem == null)
                CurrentItem = new Customer(UnitOfWork);
        }
        protected void CreateDocument(object arg) {
            IDocument doc = DocumentManagerService.FindDocument(arg, this);
            if (doc == null) {
                doc = DocumentManagerService.CreateDocument("EditOrderView", arg, this);
                doc.Id = string.Format("DocId_{0}", DocumentManagerService.Documents.Count());
                Order order = arg as Order;
                if (order == null)
                    doc.Title = "Edit New Order";
                else doc.Title = string.Format("Edit Order {0}", order.ProductName);
            }
            doc.Show();
        }
        [Command]
        public async void Save() {
            try {
                await UnitOfWork.CommitChangesAsync();
            } catch (LockingException) {
                MessageBoxService.ShowMessage("The object was modified by another user. Please reload data.", "XPO Tutorial", MessageButton.OK, MessageIcon.Stop);
                return;
            }
            ISupportParentViewModel spv = (ISupportParentViewModel)this;
            CustomerListViewModel vm = (CustomerListViewModel)spv.ParentViewModel;
            vm.Reload();
            DocumentManagerService.ActiveDocument.Close();
        }
        [Command]
        public void Cancel() {
            DocumentManagerService.ActiveDocument.Close();
        }
        [Command]
        public async void Reload() {
            bool isNewObject = UnitOfWork.IsNewObject(CurrentItem);
            UnitOfWork = new UnitOfWork();
            CurrentItem = isNewObject ? new Customer(UnitOfWork) : await UnitOfWork.GetObjectByKeyAsync<Customer>(CurrentItem.Oid);
        }
        [Command]
        public void EditOrder() {
            CreateDocument(CurrentOrder);
        }
        [Command]
        public void AddOrder() {
            CreateDocument(CurrentItem);
        }
        [Command]
        public void DeleteOrder() {
            UnitOfWork.Delete(CurrentOrder);
        }
    }
}
