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
            Version version = typeof(IXPObject).Assembly.GetName().Version;
            return string.Format("XPO {0}.{1}.{2}", version.Major, version.Minor, version.Build);
        }

        public override void InitSession() {
            dataLayer = GetDataLayer(DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);
            session = GetUnitOfWork(dataLayer);
            session.TypesManager.EnsureIsTypedObjectValid();
        }

        private IDataLayer GetDataLayer(DevExpress.Xpo.DB.AutoCreateOption autoCreateOption) {
            string connstr = "XpoProvider=MSSqlServer;" + ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            IDataLayer dl = XpoDefault.GetDataLayer(connstr, autoCreateOption);
            dl.Dictionary.GetDataStoreSchema(typeof(XPOEntity));
            return dl;
        }

        private UnitOfWork GetUnitOfWork(IDataLayer dataLayer) {
            return new UnitOfWork(dataLayer) {
                IdentityMapBehavior = IdentityMapBehavior.Strong
            };
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
            using(IDataLayer dl = GetDataLayer(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)) {
                using(UnitOfWork uow = GetUnitOfWork(dl)) {
                    for(int i = 0; i < recordsCount; i++) {
                        var XPOEntity = new XPOEntity(uow) { Id = i, Value = i };
                    }
                    uow.CommitChanges();
                }
            }
            RecordsCount = recordsCount;
        }

        public override void CleanupTestDataSet() {
            using(IDataLayer dl = GetDataLayer(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)) {
                using(UnitOfWork uow = GetUnitOfWork(dl)) {
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

        public override void InstantiationNative() {
            foreach(var o in new XPCollection<XPOEntity>(session)) { }
        }

        public override void InstantiationLinq() {
            foreach(var o in session.Query<XPOEntity>()) { }
        }
        
        protected override void LinqTakeRecords(int takeRecords) {
            for(int i = 0; i < RecordsCount; i += takeRecords) {
                var query = session.Query<XPOEntity>().Where(o => o.Id >= i).Take(takeRecords);
                foreach(var o in query) { }
            }
        }

        public override void ProjectionLinq() {
            foreach(var o in session.Query<XPOEntity>().Select(o => new {
                o.Id,
                o.Value
            })) { };
        }
    }
}
