using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpo;
using WinFormsApplication.Services;
using XpoTutorial;

namespace WinFormsApplication.ViewModels {
    public class OrderListViewModel {
        public virtual IListSource Orders {
            get;
            protected set;
        }
        protected IInstantFeedbackService InstantFeedbackService {
            get { return this.GetService<IInstantFeedbackService>(); }
        }
        void ReloadCore() {
            Orders = Orders ?? new XPInstantFeedbackView(typeof(Order), new ServerViewProperty[] {
                    new ServerViewProperty("Oid","Oid"),
                    new ServerViewProperty("OrderDate", SortDirection.Ascending, new OperandProperty("OrderDate")),
                    new ServerViewProperty("ProductName", "ProductName")
                }, null);
            ((XPInstantFeedbackView)Orders).Refresh();
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
                Order order = uow.GetObjectByKey<Order>(key);
                uow.Delete(order);
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
        protected void CreateDocument(int orderId) {
            var id = new ViewID(typeof(Order), orderId);
            IDocument document = DocumentManagerService.FindDocumentByIdOrCreate(id, svc => {
                var doc = svc.CreateDocument("EditOrderView", orderId, this);
                doc.Id = id;
                doc.Title = string.Format("Edit Order {0}", orderId);
                return doc;
            });
            document.Show();
        }
    }
}
