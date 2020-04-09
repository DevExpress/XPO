using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using XpoTutorial;

namespace WinFormsApplication.ViewModels {
    public class EditOrderViewModel : ISupportParameter, IDocumentContent {
        UnitOfWork unitOfWork;
        int? orderId;
        object ISupportParameter.Parameter {
            get { return orderId; }
            set {
                if(Equals(value, orderId) || orderId.HasValue && Equals(value, orderId.Value))
                    return;
                unitOfWork = unitOfWork ?? new UnitOfWork();
                orderId = (int)value;
                var order = unitOfWork.GetObjectByKey<Order>(orderId);
                Order = order ?? new Order(unitOfWork);
                if(Customers == null)
                    LoadCustomersAsync();
            }
        }
        async void LoadCustomersAsync() {
            Customers = await unitOfWork.Query<Customer>()
                .OrderBy(c => c.ContactName)
                .ToListAsync();
        }
        public virtual Order Order {
            get;
            protected set;
        }
        public virtual List<Customer> Customers {
            get;
            protected set;
        }
        protected IMessageBoxService MessageBoxService {
            get { return this.GetService<IMessageBoxService>(); }
        }
        protected IDocumentManagerService DocumentManagerService {
            get { return this.GetService<IDocumentManagerService>(); }
        }
        protected virtual void OnOrderChanged(Order oldValue) {
            if(oldValue != null)
                oldValue.Changed -= OnOrderObjectChange;
            this.RaiseCanExecuteChanged(x => x.Save());
            if(Order != null)
                Order.Changed += OnOrderObjectChange;
        }
        void OnOrderObjectChange(object sender, ObjectChangeEventArgs e) {
            this.RaiseCanExecuteChanged(x => x.Save());
        }
        public bool CanSave() {
            if(unitOfWork == null || !orderId.HasValue)
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
            var parent = this.GetParentViewModel<OrderListViewModel>();
            if(parent != null)
                parent.Reload(Order.Oid);
            ((IDocumentContent)this).DocumentOwner.Close(this);
        }
        public async void Reload() {
            bool isNewObject = unitOfWork.IsNewObject(Order);
            unitOfWork = new UnitOfWork();
            Order = isNewObject ? new Order(unitOfWork) : await unitOfWork.GetObjectByKeyAsync<Order>(Order.Oid);
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
            if(Order != null)
                Order.Changed -= OnOrderObjectChange;
            unitOfWork.Dispose();
            unitOfWork = null;
            orderId = null;
        }
    }
}
