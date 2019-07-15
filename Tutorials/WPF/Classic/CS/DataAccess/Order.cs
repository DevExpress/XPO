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
        public DateTime OrderDate {
            get { return GetPropertyValue<DateTime>(nameof(OrderDate)); }
            set { SetPropertyValue(nameof(OrderDate), value); }
        }
        public decimal? Freight {
            get { return GetPropertyValue<decimal?>(nameof(Freight)); }
            set { SetPropertyValue(nameof(Freight), value); }
        }
        [Association("CustomerOrders")]
        public Customer Customer {
            get { return GetPropertyValue<Customer>(nameof(Customer)); }
            set { SetPropertyValue(nameof(Customer), value); }
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
