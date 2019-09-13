using System;
using DevExpress.Xpo;
using System.ComponentModel;
using XpoTutorial;
using System.Collections.Generic;
using System.Linq;

namespace WpfApplication.Wrappers {

    public class OrderEditWrapper : INotifyPropertyChanged {
        public OrderEditWrapper(Order order) {
            Order = order;
            ((IEditableObject)order).BeginEdit();
        }

        Order fOrder;
        public Order Order {
            get {
                return fOrder;
            }
            set {
                fOrder = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        public IList<Customer> CustomerList {
            get {
                var customers = Order.Session.Query<Customer>().OrderBy(t => t.FirstName).ThenBy(t => t.LastName).ToList();
                if(!customers.Contains(Order.Customer)) {
                    customers.Add(Order.Customer);
                }
                return customers;
            }
        }

        public void Reload() {
            ((IEditableObject)Order).CancelEdit();
            ((IEditableObject)Order).BeginEdit();
        }

        public void EndEdit() {
            ((IEditableObject)Order).EndEdit();
        }

        public void CancelEdit() {
            ((IEditableObject)Order).CancelEdit();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
