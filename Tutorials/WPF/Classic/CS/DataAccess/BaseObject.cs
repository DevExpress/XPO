using DevExpress.Xpo;

namespace XpoTutorial {

    [DeferredDeletion]
    [OptimisticLocking]
    public class BaseObject : PersistentBase {
        public BaseObject(Session session) : base(session) { }

        int oid;
        [Key(true)]
        public int Oid {
            get { oid; }
            set { SetPropertyValue(nameof(Oid), ref oid, value); }
        }
    }
}
