using System;
using System.Linq;
using ORMBenchmark.Models.EF6;

namespace ORMBenchmark.PerformanceTests {

    public class EF6TestProvider : TestProviderBase {
        private EF6Context dataContext;

        public override string ToString() {
            return "EF 6";
        }

        public override void CreateTestDataSet(int recordsCount) {
            CleanupTestDataSet();
            EF6Entity[] data = new EF6Entity[recordsCount];
            for(int i = 0; i < recordsCount; i++) {
                data[i] = new EF6Entity() { Id = i, Value = i };
            }
            using(var dataContext = new EF6Context()) {
                dataContext.Database.Connection.Open();
                dataContext.Entities.AddRange(data);
                dataContext.SaveChanges();
            }
            RecordsCount = recordsCount;
        }

        public override void CleanupTestDataSet() {
            using(var dataContext = new EF6Context()) {
                dataContext.Database.Connection.Open();
                dataContext.Entities.RemoveRange(dataContext.Entities.ToList());
                dataContext.SaveChanges();
            }
        }

        public override void InitSession() {
            dataContext = new EF6Context();
            dataContext.Database.Connection.Open();
        }

        public override void TearDownSession() {
            if(dataContext != null) {
                dataContext.Dispose();
                dataContext = null;
            }
        }

        public override void InsertOne(int recordsCount) {
            using(var transaction = dataContext.Database.BeginTransaction()) {
                for(int i = 0; i < recordsCount; i++) {
                    var item = new EF6Entity() { Id = i, Value = i };
                    dataContext.Entities.Add(item);
                    dataContext.SaveChanges();
                }
                transaction.Commit();
            }
        }

        public override void InsertMany(int recordsCount) {
            using(var transaction = dataContext.Database.BeginTransaction()) {
                for(int i = 0; i < recordsCount; i++) {
                    var item = new EF6Entity() { Id = i, Value = i };
                    dataContext.Entities.Add(item);
                }
                dataContext.SaveChanges();
                transaction.Commit();
            }
        }

        public override void UpdateOne() {
            using(var transaction = dataContext.Database.BeginTransaction()) {
                foreach(var item in dataContext.Entities) {
                    item.Value++;
                    dataContext.SaveChanges();
                }
                transaction.Commit();
            }
        }

        public override void UpdateMany() {
            using(var transaction = dataContext.Database.BeginTransaction()) {
                foreach(var item in dataContext.Entities) {
                    item.Value++;
                }
                dataContext.SaveChanges();
                transaction.Commit();
            }
        }

        public override void DeleteOne() {
            using(var transaction = dataContext.Database.BeginTransaction()) {
                foreach(var item in dataContext.Entities) {
                    dataContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    dataContext.SaveChanges();
                }
                transaction.Commit();
            }
        }

        public override void DeleteMany() {
            using(var transaction = dataContext.Database.BeginTransaction()) {
                foreach(var item in dataContext.Entities) {
                    dataContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                dataContext.SaveChanges();
                transaction.Commit();
            }
        }

        public override void Fetch() {
            for(int i = 0; i < RecordsCount; i++) {
                var item = dataContext.Entities.First(o => o.Id == i);
            }
        }

        public override void LinqQuery() {
            for(int i = 0; i < RecordsCount; i++) {
                var result = dataContext.Entities.Where(o => o.Id == i);
                foreach(var o in result) { }
            }
        }

        public override void ObjectInstantiationNative() {
            foreach(var o in dataContext.Entities) { }
        }

        public override void ObjectInstantiationLinq() {
            foreach(var o in dataContext.Entities.Where(o => o.Id != -1)) { }
        }

        protected override void LinqTakeRecords(int takeRecords) {
            for(int i = 0; i < RecordsCount; i += takeRecords) {
                var query = dataContext.Entities.Where(o => o.Id >= i).Take(takeRecords);
                foreach(var o in query) { }
            }
        }
    }
}