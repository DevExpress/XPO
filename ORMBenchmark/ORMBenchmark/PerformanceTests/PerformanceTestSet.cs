using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Engines;
using System.Runtime;

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
            yield return new DirectSQLTestProvider();
        }

        [IterationSetup(Target = nameof(InsertMany) + "," + nameof(InsertOne))]
        public void IterationSetupForInsert() {
            TestProvider.CleanupTestDataSet();
            TestProvider.InitSession();
        }

        [IterationSetup(Target = nameof(DeleteMany) + "," + nameof(DeleteOne))]
        public void IterationSetupForDelete() {
            TestProvider.CreateTestDataSet(RowCount);
            TestProvider.InitSession();
            System.GC.Collect();
        }

        [IterationSetup(Target = nameof(UpdateMany)
            + "," + nameof(UpdateOne)
            + "," + nameof(Fetch)
            + "," + nameof(LinqQuery)
            + "," + nameof(InstantiationLinq)
            + "," + nameof(InstantiationNative)
            + "," + nameof(LinqTakeRecords10)
            + "," + nameof(LinqTakeRecords20)
            + "," + nameof(LinqTakeRecords50)
            + "," + nameof(LinqTakeRecords100)
            + "," + nameof(ProjectionLinq)
            )]
        public void IterationSetupForUpdateAndSelect() {
            TestProvider.InitSession();
            System.GC.Collect();
        }

        [GlobalSetup(Target = nameof(UpdateMany)
            +"," + nameof(UpdateOne)
            + "," + nameof(Fetch)
            + "," + nameof(LinqQuery)
            + "," + nameof(InstantiationLinq)
            + "," + nameof(InstantiationNative)
            + "," + nameof(LinqTakeRecords10)
            + "," + nameof(LinqTakeRecords20)
            + "," + nameof(LinqTakeRecords50)
            + "," + nameof(LinqTakeRecords100)
            + "," + nameof(ProjectionLinq)
            )]
        public void GlobalSetupForUpdateAndSelect() {
            TestProvider.CreateTestDataSet(RowCount);
            System.GC.Collect();
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
        public void InsertMany() {
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

        [Benchmark(OperationsPerInvoke = 1000)]
        public void InstantiationNative() {
            for(int i = 0; i < 1000; i++) {
                TestProvider.InstantiationNative();
            }
        }

        [Benchmark(OperationsPerInvoke = 1000)]
        public void InstantiationLinq() {
            for(int i = 0; i < 1000; i++) {
                TestProvider.InstantiationLinq();
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void LinqTakeRecords10() {
            for(int i = 0; i < 10; i++) {
                TestProvider.LinqTakeRecords10();
            }
        }

        [Benchmark(OperationsPerInvoke = 50)]
        public void LinqTakeRecords20() {
            for(int i = 0; i < 50; i++) {
                TestProvider.LinqTakeRecords20();
            }
        }

        [Benchmark(OperationsPerInvoke = 100)]
        public void LinqTakeRecords50() {
            for(int i = 0; i < 100; i++) {
                TestProvider.LinqTakeRecords50();
            }
        }

        [Benchmark(OperationsPerInvoke = 100)]
        public void LinqTakeRecords100() {
            for(int i = 0; i < 100; i++) {
                TestProvider.LinqTakeRecords100();
            }
        }

        [Benchmark(OperationsPerInvoke = 1000)]
        public void ProjectionLinq() {
            for(int i = 0; i < 1000; i++) {
                TestProvider.ProjectionLinq();
            }
        }
    }
}
