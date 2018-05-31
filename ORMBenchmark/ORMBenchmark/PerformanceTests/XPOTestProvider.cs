using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using ORMBenchmark.Models.XPO;
using System.Configuration;

namespace ORMBenchmark.PerformanceTests {
    
    public class XPOPerfTestProvider : TestProviderBase {
        private UnitOfWork session;
        private IDataLayer dataLayer;

        public override string ToString() {
            return "XPO";
        }

        public override void InitSession() {
            dataLayer = GetDataLayer(DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);
            session = new UnitOfWork(dataLayer);
            session.TypesManager.EnsureIsTypedObjectValid();
        }

        private IDataLayer GetDataLayer(DevExpress.Xpo.DB.AutoCreateOption autoCreateOption) {
            string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            IDataLayer dl = XpoDefault.GetDataLayer(connstr, autoCreateOption);
            dl.Dictionary.GetDataStoreSchema(typeof(XPOEntity));
            return dl;
        }

        public override void TearDownSession() {
            if(dataLayer != null) {
                IDisposable dld = dataLayer as IDisposable;
                if(dld != null) dld.Dispose();
                dataLayer = null;
            }
            if(session != null) {
                session.Dispose();
                session = null;
            }
        }

        public override void CreateTestDataSet(int recordsCount) {
            CleanupTestDataSet();
            using(IDataLayer dl = GetDataLayer(DevExpress.Xpo.DB.AutoCreateOption.SchemaOnly)) {
                using(UnitOfWork uow = new UnitOfWork(dl)) {
                    for(int i = 0; i < recordsCount; i++) {
                        var XPOEntity = new XPOEntity(uow) { Id = i, Value = i };
                    }
                    uow.CommitChanges();
                }
            }
            RecordsCount = recordsCount;
        }

        public override void CleanupTestDataSet() {
            using(IDataLayer dl = GetDataLayer(DevExpress.Xpo.DB.AutoCreateOption.SchemaOnly)) {
                using(UnitOfWork uow = new UnitOfWork(dl)) {
                    uow.UpdateSchema();
                    foreach(var item in uow.Query<XPOEntity>()) {
                        uow.Delete(item);
                    }
                    uow.CommitChanges();
                }
            }
        }

        public override void InsertOne(int recordsCount) {
            session.ExplicitBeginTransaction();
            try {
                for(int i = 0; i < recordsCount; i++) {
                    var XPOEntity = new XPOEntity(session) { Id = i, Value = i };
                    session.CommitChanges();
                }
            } finally {
                session.ExplicitCommitTransaction();
            }
        }

        public override void InsertMany(int recordsCount) {
            session.ExplicitBeginTransaction();
            try {
                for(int i = 0; i < recordsCount; i++) {
                    var XPOEntity = new XPOEntity(session) { Id = i, Value = i };
                }
                session.CommitChanges();
            } finally {
                session.ExplicitCommitTransaction();
            }
        }

        public override void UpdateOne() {
            session.ExplicitBeginTransaction();
            try {
                foreach(var XPOEntity in session.Query<XPOEntity>()) {
                    XPOEntity.Value++;
                    session.CommitChanges();
                }
            } finally {
                session.ExplicitCommitTransaction();
            }
        }

        public override void UpdateMany() {
            session.ExplicitBeginTransaction();
            try {
                foreach(var XPOEntity in session.Query<XPOEntity>()) {
                    XPOEntity.Value++;
                }
                session.CommitChanges();
            } finally {
                session.ExplicitCommitTransaction();
            }
        }

        public override void DeleteOne() {
            session.ExplicitBeginTransaction();
            try {
                foreach(var XPOEntity in session.Query<XPOEntity>()) {
                    session.Delete(XPOEntity);
                    session.CommitChanges();
                }
            } finally {
                session.ExplicitCommitTransaction();
            }
        }

        public override void DeleteMany() {
            session.ExplicitBeginTransaction();
            try {
                foreach(var XPOEntity in session.Query<XPOEntity>()) {
                    session.Delete(XPOEntity);
                }
                session.CommitChanges();
            } finally {
                session.ExplicitCommitTransaction();
            }
        }

        public override void Fetch() {
            for(int i = 0; i < RecordsCount; i++) {
                var XPOEntity = session.GetObjectByKey<XPOEntity>((long)i);
            }
        }

        public override void LinqQuery() {
            for(int i = 0; i < RecordsCount; i++) {
                var query = session.Query<XPOEntity>().Where(o => o.Id == i);
                foreach(var XPOEntity in query) { }
            }
        }
        
        public override void ObjectInstantiationNative() {
            foreach(var o in new XPCollection<XPOEntity>(session)) { }
        }

        public override void ObjectInstantiationLinq() {
            foreach(var o in session.Query<XPOEntity>()) { }
        }
        
        protected override void LinqTakeRecords(int takeRecords) {
            for(int i = 0; i < RecordsCount; i += takeRecords) {
                var query = session.Query<XPOEntity>().Where(o => o.Id >= i).Take(takeRecords);
                foreach(var o in query) { }
            }
        }
    }
}
