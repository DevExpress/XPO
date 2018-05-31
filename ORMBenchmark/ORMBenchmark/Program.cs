using System;
using System.IO;
using BenchmarkDotNet.Running;
using System.Linq;
using ORMBenchmark.PerformanceTests;
using System.Collections.Generic;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            for(int i = 0; i < args.Length; i++) {
                if(args[i].ToLower() == "-count") {
                    var counts = new List<int>();
                    for(i++; i < args.Length; i++) {
                        int count;
                        if(Int32.TryParse(args[i], out count)) {
                            counts.Add(count);
                        } else {
                            i--;
                            break;
                        }
                    }
                    if(counts.Count > 0) {
                        TestSetConfig.RowCounts = counts.ToArray();
                    }
                }
            }
            var summary = BenchmarkRunner.Run<PerformanceTestSet>();
            string resultsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BenchmarkDotNet.Artifacts", "results", "PerformanceTestSet-report.html");
            System.Diagnostics.Process.Start(resultsPath);
        }
    }
}
