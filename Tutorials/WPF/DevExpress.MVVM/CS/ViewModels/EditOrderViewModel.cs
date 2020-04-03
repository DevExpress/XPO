using DevExpress.Mvvm;
using DevExpress.Xpo;
using System.Collections;
using XpoTutorial;
using System.Linq;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpo.DB.Exceptions;

namespace WpfApplicationMvvm.ViewModels {
    public class EditOrderViewModel :ViewModelBase {
        public Order CurrentItem {
            get { return GetProperty(() => CurrentItem); }
            set { SetProperty(() => CurrentItem, value); }
        }
        protected NestedUnitOfWork UnitOfWork { get; private set; }
        public ICollection Customers {
            get { return GetProperty(() => Customers); }
            set { SetProperty(() => Customers, value); }
        }
        protected IMessageBoxService MessageBoxService {
            get { return GetService<IMessageBoxService>(); }
        }
        protected IDocumentManagerService DocumentManagerService {
            get { return GetService<IDocumentManagerService>(); }
        }
        protected override void OnParameterChanged(object parameter) {
            Customer customer = parameter as Customer;
            Order order = parameter as Order;
            if (customer != null)
                SetCurrentItem(customer);
            else if (order != null)
                SetCurrentItem(order);
            else ResetCurrentItem();
        }
        private void ResetCurrentItem() {
            UnitOfWork = null;
            CurrentItem = null;
            Customers = null;
        }
        protected void SetCurrentItem(Order order) {
            UnitOfWork = order.Session.BeginNestedUnitOfWork();
            CurrentItem = UnitOfWork.GetNestedObject(order);
            LoadCustomers();
        }
        protected void SetCurrentItem(Customer customer) {
            UnitOfWork = customer.Session.BeginNestedUnitOfWork();
            CurrentItem = new Order(UnitOfWork);
            CurrentItem.Customer = UnitOfWork.GetNestedObject(customer);
            LoadCustomers();
        }
        private async void LoadCustomers() {
            Customers = await UnitOfWork.Query<Customer>()
                .Select(c => new { c.Oid, c.ContactName })
                .OrderBy(c => c.ContactName)
                .ToListAsync();
        }
        [Command]
        public void Save() {
            try {
                UnitOfWork.CommitChanges();
            } catch (LockingException) {
                MessageBoxService.ShowMessage("The object was modified int another window. Please reload data.", "XPO Tutorial", MessageButton.OK, MessageIcon.Stop);
                return;
            }
            DocumentManagerService.ActiveDocument.Close();
        }
        [Command]
        public void Cancel() {
            DocumentManagerService.ActiveDocument.Close();
        }
        [Command]
        public void Reload() {
            bool isNewObject = UnitOfWork.IsNewObject(CurrentItem);
            if (isNewObject) {
                Customer customer = UnitOfWork.GetParentObject(CurrentItem.Customer);
                SetCurrentItem(customer);
            } else {
                Order order = UnitOfWork.GetParentObject(CurrentItem);
                SetCurrentItem(order);
            }
        }
    }
}
