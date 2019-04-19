using DevExpress.Xpo;
using System;

namespace XpoTutorial {

    public class Order :XPObject {
        public Order(Session session) : base(session) { }
        public string ProductName {
            get { return GetPropertyValue<string>(nameof(ProductName)); }
            set { SetPropertyValue(nameof(ProductName), value); }
        }
        public DateTime OrderDate {
            get { return GetPropertyValue<DateTime>(nameof(OrderDate)); }
            set { SetPropertyValue(nameof(OrderDate), value); }
        }
        public decimal Freight {
            get { return GetPropertyValue<decimal>(nameof(Freight)); }
            set { SetPropertyValue(nameof(Freight), value); }
        }
        [Association("CustomerOrders")]
        public Customer Customer {
            get { return GetPropertyValue<Customer>(nameof(Customer)); }
            set { SetPropertyValue(nameof(Customer), value); }
        }
    }
}
