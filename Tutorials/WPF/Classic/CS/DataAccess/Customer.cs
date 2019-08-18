using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace XpoTutorial {

    public class Customer : BaseObject {
        public Customer(Session session) : base(session) { }
        string fFirstName;
        public string FirstName {
            get { return fFirstName; }
            set { SetPropertyValue(nameof(FirstName), ref fFirstName, value); }
        }
        string fLastName;
        public string LastName {
            get { return fLastName; }
            set { SetPropertyValue(nameof(LastName), ref fLastName, value); }
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
