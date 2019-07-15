using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace XpoTutorial {

    public class Customer : BaseObject {
        public Customer(Session session) : base(session) { }
        public string FirstName {
            get { return GetPropertyValue<string>(nameof(FirstName)); }
            set { SetPropertyValue(nameof(FirstName), value); }
        }
        public string LastName {
            get { return GetPropertyValue<string>(nameof(LastName)); }
            set { SetPropertyValue(nameof(LastName), value); }
        }
        [NonPersistent]
        public string ContactName {
            get { return string.Concat(FirstName, " ", LastName); }
        }
        [Association("CustomerOrders")]
        public IList<Order> Orders {
            get { return GetList<Order>(nameof(Orders)); }
        }
    }

}
