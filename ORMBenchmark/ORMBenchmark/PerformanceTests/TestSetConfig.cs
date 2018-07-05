using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace ORMBenchmark.PerformanceTests {
    public class TestSetConfig : ManualConfig {

        public static int[] RowCounts = new int[] { 10, 50, 100, 250, 500, 1000, 2500, 5000 };

        public TestSetConfig() {
            var job = Job.InProcess
                    .With(Runtime.Clr)
                    .WithLaunchCount(1)
                    .WithWarmupCount(1)
                    .WithMinInvokeCount(1)
                    .WithInvocationCount(1)
                    .WithMaxRelativeError(0.1)
                    .WithUnrollFactor(1);
            job.Run.RunStrategy = BenchmarkDotNet.Engines.RunStrategy.Throughput;
            Add(job);
            Set(new TestSetOrderProvider());
        }

        private class TestSetOrderProvider : IOrderProvider {

            public IEnumerable<Benchmark> GetExecutionOrder(Benchmark[] benchmarks) {
                return benchmarks;
            }

            public IEnumerable<Benchmark> GetSummaryOrder(Benchmark[] benchmarks, Summary summary) {
                return benchmarks
                    .OrderBy(t => t.Parameters["Count"])
                    .ThenBy(t => t.Target.MethodDisplayInfo.ToString())
                    .ThenBy(t => t.Parameters["TestProvider"].ToString());
            }

            public bool SeparateLogicalGroups {
                get {
                    return true;
                }
            }

            public string GetGroupKey(Benchmark benchmark, Summary summary) {
                return null;
            }

            public string GetHighlightGroupKey(Benchmark benchmark) {
                return null;
            }

            public string GetLogicalGroupKey(IConfig config, Benchmark[] allBenchmarks, Benchmark benchmark) {
                return null;
            }

            public IEnumerable<IGrouping<string, Benchmark>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, Benchmark>> logicalGroups) {
                return logicalGroups;
            }
        }
    }
}
