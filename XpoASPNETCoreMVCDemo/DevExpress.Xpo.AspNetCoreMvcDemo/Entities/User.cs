using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevExpress.Xpo.Demo.Entities {
    public class User : XPLiteObject {
        Guid oid;
        [Key(true)]
        public Guid Oid {
            get { return oid; }
            set { SetPropertyValue(nameof(Oid), ref oid, value); }
        }
        string firstName;
        [Size(100)]
        public string FirstName {
            get { return firstName; }
            set { SetPropertyValue(nameof(FirstName), ref firstName, value); }
        }
        string lastName;
        [Size(100)]
        public string LastName {
            get { return lastName; }
            set { SetPropertyValue(nameof(LastName), ref lastName, value); }
        }
        string email;
        [Size(256)]
        public string Email {
            get { return email; }
            set { SetPropertyValue(nameof(Email), ref email, value); }
        }
        public User(Session session)
            : base(session) {
        }
    }
}
