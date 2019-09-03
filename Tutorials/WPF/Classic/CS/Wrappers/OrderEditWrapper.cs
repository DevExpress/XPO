using System;
using DevExpress.Xpo;
using System.ComponentModel;
using XpoTutorial;
using System.Collections.Generic;
using System.Linq;

namespace WpfApplication.Wrappers {

    pubilc class OrderEditWrapper : INotifyPropertyChanged {
        public OrderEditWrapper(Order order) {
            Order = order;
            ((IEditableObject)order).BeginEdit();
        }

        Order order;
        public Order Order {
            get {
                return order;
            }
            set {
                order = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        public IList<Customer> CustomerList {
            get {
                var customers = order.Session.Query<Customer>().OrderBy(t => t.FirstName).ThenBy(t => t.LastName).ToList();
                if(!customers.Contains(order.Customer)) {
                    customers.Add(order.Customer);
                }
                return customers;
            }
        }

        public void Reload() {
            ((IEditableObject)order).CancelEdit();
            ((IEditableObject)order).BeginEdit();
        }

        public void EndEdit() {
            ((IEditableObject)order).EndEdit();
        }

        public void CancelEdit() {
            ((IEditableObject)order).CancelEdit();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
