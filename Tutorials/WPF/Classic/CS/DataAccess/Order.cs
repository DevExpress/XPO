using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace XpoTutorial {

    public class Order : BaseObject, IEditableObject {
        public Order(Session session) : base(session) { }
        string productName;
        public string ProductName {
            get { return productName; }
            set { SetPropertyValue(nameof(ProductName), ref productName, value); }
        }
        DateTime orderDate;
        public DateTime OrderDate {
            get { return orderDate; }
            set { SetPropertyValue(nameof(OrderDate), ref orderDate, value); }
        }
        decimal? freight;
        public decimal? Freight {
            get { return freight; }
            set { SetPropertyValue(nameof(Freight), ref freight, value); }
        }
        Customer customer;
        [Association("CustomerOrders")]
        public Customer Customer {
            get { return customer; }
            set { SetPropertyValue(nameof(Customer), ref customer, value); }
        }

        #region IEditableObject implementation
        
        bool isEditing;
        string oldProductName;
        DateTime oldOrderDate;
        decimal? oldFreight;
        Customer oldCustomer;

        public void BeginEdit() {
            if(isEditing) {
                throw new InvalidOperationException();
            }
            oldProductName = ProductName;
            oldOrderDate = OrderDate;
            oldFreight = Freight;
            oldCustomer = Customer;
            isEditing = true;
        }

        public void CancelEdit() {
            if(!isEditing) {
                throw new InvalidOperationException();
            }
            ProductName = oldProductName;
            OrderDate = oldOrderDate;
            Freight = oldFreight;
            Customer = oldCustomer;
            isEditing = false;
        }

        public void EndEdit() {
            if(!isEditing) {
                throw new InvalidOperationException();
            }
            isEditing = false;
        }

        #endregion
    }
}
