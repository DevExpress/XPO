using DevExpress.Xpo;

namespace XpoTutorial {

    [DeferredDeletion]
    [OptimisticLocking]
    public class BaseObject : PersistentBase {
        public BaseObject(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        public int Oid {
            get { fOid; }
            set { SetPropertyValue(nameof(Oid), ref fOid, value); }
        }
    }
}
