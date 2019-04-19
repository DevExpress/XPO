using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;

namespace ORMBenchmark.Models.XPO {
    [Persistent("Entities")]
    public class XPOEntity : XPLiteObject {
        long fId;
        [Key]
        public long Id {
            get { return fId; }
            set { SetPropertyValue<long>(nameof(Id), ref fId, value); }
        }
        long fValue;
        public long Value {
            get { return fValue; }
            set { SetPropertyValue<long>(nameof(Value), ref fValue, value); }
        }
        public XPOEntity(Session session) : base(session) { }
        public XPOEntity() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
