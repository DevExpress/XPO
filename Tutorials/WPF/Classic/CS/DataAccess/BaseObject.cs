using DevExpress.Xpo;

namespace XpoTutorial {

    [NonPersistent]
    [DeferredDeletion]
    [OptimisticLocking]
    public class BaseObject : PersistentBase {
        public BaseObject(Session session) : base(session) { }

        [Key(true)]
        [Persistent("OID")]
        int fOid;
        [PersistentAlias("fOid")]
        public int Oid {
            get { fOid; }
        }
    }
}
