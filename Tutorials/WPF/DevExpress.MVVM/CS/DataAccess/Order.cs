using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace XpoTutorial {

    public class Order : BaseObject, IEditableObject {
        public Order(Session session) : base(session) { }
        string fProductName;
        public string ProductName {
            get { return fProductName; }
            set { SetPropertyValue(nameof(ProductName), ref fProductName, value); }
        }
        DateTime fOrderDate;
        public DateTime OrderDate {
            get { return fOrderDate; }
            set { SetPropertyValue(nameof(OrderDate), ref fOrderDate, value); }
        }
        decimal? fFreight;
        public decimal? Freight {
            get { return fFreight; }
            set { SetPropertyValue(nameof(Freight), ref fFreight, value); }
        }
        Customer fCustomer;
        [Association("CustomerOrders")]
        public Customer Customer {
            get { return fCustomer; }
            set { SetPropertyValue(nameof(Customer), ref fCustomer, value); }
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
