using System;
using DevExpress.Xpo;
using System.ComponentModel;
using XpoTutorial;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace WpfApplication.Wrappers {
    public class CustomerEditWrapper : INotifyPropertyChanged {
        UnitOfWork unitOfWork;
        readonly int? customerOid;

        public CustomerEditWrapper() {
            unitOfWork = new UnitOfWork(XpoDefault.DataLayer);
            Customer = new Customer(unitOfWork);
        }

        public CustomerEditWrapper(int customerOid) {
            this.customerOid = customerOid;
            unitOfWork = new UnitOfWork(XpoDefault.DataLayer);
            Customer = unitOfWork.GetObjectByKey<Customer>(customerOid);
        }

        Customer fCustomer;
        public Customer Customer {
            get {
                return fCustomer;
            }
            set {
                fCustomer = value;
                OrderList = fCustomer.Orders;
                OnPropertyChanged(nameof(Customer));
            }
        }

        IList<Order> fOrderList;
        public IList<Order> OrderList {
            get {
                return fOrderList;
            }
            set {
                fOrderList = value;
                OnPropertyChanged(nameof(OrderList));
            }
        }

        Order fSelectedOrder;
        public Order SelectedOrder {
            get {
                return fSelectedOrder;
            }
            set {
                fSelectedOrder = value;
                IsOrderSelected = (value != null);
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        bool fIsOrderSelected;
        public bool IsOrderSelected {
            get {
                return fIsOrderSelected;
            }
            set {
                fIsOrderSelected = value;
                OnPropertyChanged(nameof(IsOrderSelected));
            }
        }

        public Order CreateNewOrder() {
            Order order = new Order(unitOfWork);
            order.Customer = Customer;
            SelectedOrder = order;
            return order;
        }

        public void DeleteSelectedOrder() {
            if(SelectedOrder != null) {
                unitOfWork.Delete(SelectedOrder);
            }
        }

        public async Task ReloadAsync() {
            if(this.customerOid.HasValue) {
                unitOfWork = new UnitOfWork(XpoDefault.DataLayer);
                Customer = await unitOfWork.GetObjectByKeyAsync<Customer>(customerOid);
            }
        }

        public Task SaveAsync() {
            return unitOfWork.CommitChangesAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
