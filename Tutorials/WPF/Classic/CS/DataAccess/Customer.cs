using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace XpoTutorial {

    public class Customer : BaseObject {
        public Customer(Session session) : base(session) { }
        string firstName;
        public string FirstName {
            get { return firstName; }
            set { SetPropertyValue(nameof(FirstName), ref firstName, value); }
        }
        string lastName;
        public string LastName {
            get { return lastName; }
            set { SetPropertyValue(nameof(LastName), ref lastName, value); }
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
