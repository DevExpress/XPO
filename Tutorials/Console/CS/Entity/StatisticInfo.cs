using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;

namespace DevExpress.Xpo.ConsoleCoreDemo {
    class StatisticInfo : XPLiteObject {
        public StatisticInfo(Session session)
            : base(session) {
        }
        Guid key;
        [Key(true)]
        public Guid Key {
            get { return key; }
            set { SetPropertyValue(nameof(Key), ref key, value); }
        }
        string info;
        [Size(255)]
        public string Info {
            get { return info; }
            set { SetPropertyValue(nameof(Info), ref info, value); }
        }
        DateTime date;
        public DateTime Date {
            get { return date; }
            set { SetPropertyValue(nameof(Date), ref date, value); }
        }
    }
}
