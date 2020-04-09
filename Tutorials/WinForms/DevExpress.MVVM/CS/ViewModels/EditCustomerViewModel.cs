using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using XpoTutorial;

namespace WinFormsApplication.ViewModels {
    public class EditCustomerViewModel : ISupportParameter, IDocumentContent {
        UnitOfWork unitOfWork;
        int? customerId;
        object ISupportParameter.Parameter {
            get { return customerId; }
            set {
                if(Equals(value, customerId) || customerId.HasValue && Equals(value, customerId.Value))
                    return;
                unitOfWork = unitOfWork ?? new UnitOfWork();
                customerId = (int)value;
                var customer = unitOfWork.GetObjectByKey<Customer>(customerId);
                Customer = customer ?? new Customer(unitOfWork);
            }
        }
        public virtual Customer Customer {
            get;
            protected set;
        }
        protected virtual void OnCustomerChanged(Customer oldValue) {
            if(oldValue != null)
                oldValue.Changed -= OnCustomerObjectChange;
            this.RaiseCanExecuteChanged(x => x.Save());
            if(Customer != null)
                Customer.Changed += OnCustomerObjectChange;
        }
        void OnCustomerObjectChange(object sender, ObjectChangeEventArgs e) {
            this.RaiseCanExecuteChanged(x => x.Save());
        }
        protected IMessageBoxService MessageBoxService {
            get { return this.GetService<IMessageBoxService>(); }
        }
        protected IDocumentManagerService DocumentManagerService {
            get { return this.GetService<IDocumentManagerService>(); }
        }
        public bool CanSave() {
            if(unitOfWork == null || !customerId.HasValue)
                return false;
            var objectsToSave = unitOfWork.GetObjectsToSave(false);
            return (objectsToSave != null) && objectsToSave.Count > 0;
        }
        public async void Save() {
            try {
                await unitOfWork.CommitChangesAsync();
            }
            catch(LockingException) {
                MessageBoxService.ShowMessage("The object was modified by another user. Please reload data.", "XPO Tutorial", MessageButton.OK, MessageIcon.Stop);
                return;
            }
            var parent = this.GetParentViewModel<CustomerListViewModel>();
            if(parent != null)
                parent.Reload(Customer.Oid);
            ((IDocumentContent)this).DocumentOwner.Close(this);
        }
        public async void Reload() {
            bool isNewObject = unitOfWork.IsNewObject(Customer);
            unitOfWork = new UnitOfWork();
            Customer = isNewObject ? new Customer(unitOfWork) : await unitOfWork.GetObjectByKeyAsync<Customer>(Customer.Oid);
        }
        IDocumentOwner IDocumentContent.DocumentOwner {
            get; set;
        }
        object IDocumentContent.Title {
            get { return string.Empty; }
        }
        void IDocumentContent.OnClose(CancelEventArgs e) {
            // do some validation here
        }
        void IDocumentContent.OnDestroy() {
            // some cleanup
            if(Customer != null)
                Customer.Changed -= OnCustomerObjectChange;
            unitOfWork.Dispose();
            unitOfWork = null;
            customerId = null;
        }
    }
}
