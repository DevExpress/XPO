﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace ORMBenchmark.PerformanceTests {
    public class TestSetConfig : ManualConfig {

        public static int[] RowCounts = new int[] { 10, 50, 100, 250, 500, 1000, 2500, 5000 };

        public TestSetConfig() {
            var job = Job.Default.WithRuntime(CoreRuntime.Core31)
                    .WithLaunchCount(1)
                    .WithWarmupCount(1)
                    .WithMinInvokeCount(1)
                    .WithInvocationCount(1)
                    .WithMaxRelativeError(0.1)
                    .WithUnrollFactor(1);
            job.Run.RunStrategy = BenchmarkDotNet.Engines.RunStrategy.Throughput;
            AddJob(job);
            Orderer = new TestSetOrderProvider();
            AddExporter(new JsonExporter("", true, true));
            AddValidator(JitOptimizationsValidator.DontFailOnError);
            AddLogger(DefaultConfig.Instance.GetLoggers().ToArray());
            AddExporter(DefaultConfig.Instance.GetExporters().ToArray());
            AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());
        }

        private class TestSetOrderProvider : IOrderer {

            public bool SeparateLogicalGroups {
                get {
                    return true;
                }
            }

            public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase) {
                return benchmarksCase;
            }

            public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary) {
                return benchmarksCase
                    .OrderBy(t => t.Parameters["Count"])
                    .ThenBy(t => t.Descriptor.WorkloadMethodDisplayInfo.ToString())
                    .ThenBy(t => t.Parameters["TestProvider"].ToString());
            }

            public string GetHighlightGroupKey(BenchmarkCase benchmarkCase) {
                return null;
            }

            public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase) {
                return null;
            }

            public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups) {
                return logicalGroups;
            }
        }
    }
}
