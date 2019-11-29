using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpo;
using WinFormsApplication.Services;
using XpoTutorial;

namespace WinFormsApplication.ViewModels {
    public class CustomerListViewModel {
        public virtual IListSource Customers {
            get;
            protected set;
        }
        protected IInstantFeedbackService InstantFeedbackService {
            get { return this.GetService<IInstantFeedbackService>(); }
        }
        void ReloadCore() {
            Customers = Customers ?? new XPInstantFeedbackView(typeof(Customer), new ServerViewProperty[] {
                    new ServerViewProperty("Oid","Oid"),
                    new ServerViewProperty("ContactName", SortDirection.Ascending, new OperandProperty("ContactName"))
                }, null);
            ((XPInstantFeedbackView)Customers).Refresh();
        }
        public void Reload() {
            if(InstantFeedbackService == null)
                ReloadCore();
            else {
                object focusedObjectKey = InstantFeedbackService.GetFocusedRowKey();
                ReloadCore();
                InstantFeedbackService.SetFocusedRowByKey(focusedObjectKey);
            }
        }
        public async void Delete() {
            using(UnitOfWork uow = new UnitOfWork()) {
                object key = InstantFeedbackService.GetFocusedRowKey();
                Customer customer = uow.GetObjectByKey<Customer>(key);
                uow.Delete(customer);
                await uow.CommitChangesAsync();
            }
            Reload();
        }
        public void Edit() {
            CreateDocument((int)InstantFeedbackService.GetFocusedRowKey());
        }
        public void Add() {
            CreateDocument(-1);
        }
        //
        protected IDocumentManagerService DocumentManagerService {
            get { return this.GetService<IDocumentManagerService>(); }
        }
        protected void CreateDocument(int customerId) {
            var id = new ViewID(typeof(Customer), customerId);
            IDocument document = DocumentManagerService.FindDocumentByIdOrCreate(id, svc => {
                var doc = svc.CreateDocument("EditCustomerView", customerId, this);
                doc.Id = id;
                doc.Title = string.Format("Edit Customer {0}", customerId);
                return doc;
            });
            document.Show();
        }
    }
}
