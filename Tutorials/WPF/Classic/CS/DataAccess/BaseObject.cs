using DevExpress.Xpo;

namespace XpoTutorial {

    [NonPersistent]
    [DeferredDeletion]
    [OptimisticLocking]
    public class BaseObject : PersistentBase {
        public BaseObject(Session session) : base(session) { }

        [Key(true)]
        public int Oid {
            get { return GetPropertyValue<int>(nameof(Oid)); }
            set { SetPropertyValue(nameof(Oid), value); }
        }
    }
}
