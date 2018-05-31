using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Engines;


namespace ORMBenchmark.PerformanceTests {

    [HtmlExporter]
    [Config(typeof(TestSetConfig))]
    public class PerformanceTestSet {

        [ParamsSource(nameof(RowCounts))]
        public int RowCount;

        [ParamsSource(nameof(TestProviders))]
        public TestProviderBase TestProvider;

        public IEnumerable<int> RowCounts() {
            return TestSetConfig.RowCounts;
        }

        public IEnumerable<TestProviderBase> TestProviders() {
            yield return new XPOPerfTestProvider();
            yield return new EF6TestProvider();
            yield return new EFCoreTestProvider();
        }

        [IterationSetup(Target = nameof(InsertMultipleTest) + "," + nameof(InsertOne))]
        public void IterationSetupForInsert() {
            TestProvider.CleanupTestDataSet();
            TestProvider.InitSession();
        }

        [IterationSetup(Target = nameof(DeleteMany) + "," + nameof(DeleteOne))]
        public void IterationSetupForDelete() {
            TestProvider.CreateTestDataSet(RowCount);
            TestProvider.InitSession();
        }

        [IterationSetup(Target = nameof(UpdateMany)
            + "," + nameof(UpdateOne)
            + "," + nameof(Fetch)
            + "," + nameof(LinqQuery)
            + "," + nameof(ObjectInstantiationLinq)
            + "," + nameof(ObjectInstantiationNative)
            + "," + nameof(LinqTakeRecords10)
            + "," + nameof(LinqTakeRecords20)
            + "," + nameof(LinqTakeRecords50)
            + "," + nameof(LinqTakeRecords100)
            )]
        public void IterationSetupForUpdateAndSelect() {
            TestProvider.InitSession();
        }

        [GlobalSetup(Target = nameof(UpdateMany)
            +"," + nameof(UpdateOne)
            + "," + nameof(Fetch)
            + "," + nameof(LinqQuery)
            + "," + nameof(ObjectInstantiationLinq)
            + "," + nameof(ObjectInstantiationNative)
            + "," + nameof(LinqTakeRecords10)
            + "," + nameof(LinqTakeRecords20)
            + "," + nameof(LinqTakeRecords50)
            + "," + nameof(LinqTakeRecords100)
            )]
        public void GlobalSetupForUpdateAndSelect() {
            TestProvider.CreateTestDataSet(RowCount);
        }

        [IterationCleanup]
        public void IterationCleanup() {
            TestProvider.TearDownSession();
        }

        [Benchmark]
        public void InsertOne() {
            TestProvider.InsertOne(RowCount);
        }

        [Benchmark]
        public void InsertMultipleTest() {
            TestProvider.InsertMany(RowCount);
        }

        [Benchmark]
        public void UpdateOne() {
            TestProvider.UpdateOne();
        }

        [Benchmark]
        public void UpdateMany() {
            TestProvider.UpdateMany();
        }

        [Benchmark]
        public void DeleteOne() {
            TestProvider.DeleteOne();
        }

        [Benchmark]
        public void DeleteMany() {
            TestProvider.DeleteMany();
        }

        [Benchmark]
        public void Fetch() {
            TestProvider.Fetch();
        }

        [Benchmark]
        public void LinqQuery() {
            TestProvider.LinqQuery();
        }

        [Benchmark]
        public void ObjectInstantiationNative() {
            TestProvider.ObjectInstantiationNative();
        }

        [Benchmark]
        public void ObjectInstantiationLinq() {
            TestProvider.ObjectInstantiationLinq();
        }

        [Benchmark]
        public void LinqTakeRecords10() {
            TestProvider.LinqTakeRecords10();
        }

        [Benchmark]
        public void LinqTakeRecords20() {
            TestProvider.LinqTakeRecords20();
        }

        [Benchmark]
        public void LinqTakeRecords50() {
            TestProvider.LinqTakeRecords50();
        }

        [Benchmark]
        public void LinqTakeRecords100() {
            TestProvider.LinqTakeRecords100();
        }
    }
}
