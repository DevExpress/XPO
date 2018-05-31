namespace ORMBenchmark.PerformanceTests {

    public abstract class TestProviderBase {
        protected int RecordsCount;
        public abstract void InitSession();
        public abstract void TearDownSession();
        public abstract void CreateTestDataSet(int recordsCount);
        public abstract void CleanupTestDataSet();
        public abstract void InsertOne(int recordsCount);
        public abstract void InsertMany(int recordsCount);
        public abstract void UpdateOne();
        public abstract void UpdateMany();
        public abstract void DeleteOne();
        public abstract void DeleteMany();
        public abstract void Fetch();
        public abstract void LinqQuery();
        public abstract void ObjectInstantiationLinq();
        public abstract void ObjectInstantiationNative();
        
        public void LinqTakeRecords10() {
            LinqTakeRecords(10);
        }

        public void LinqTakeRecords20() {
            LinqTakeRecords(20);
        }

        public void LinqTakeRecords50() {
            LinqTakeRecords(50);
        }

        public void LinqTakeRecords100() {
            LinqTakeRecords(100);
        }
        
        protected abstract void LinqTakeRecords(int takeRecords);
    }
}