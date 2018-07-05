# .NET ORM Benchmark

This project is a [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)-based benchmark. We used it to test the performance of the following Object-Relational Mapping (ORM) libraries for .NET Framework 4.6.1 and higher:<br/>
 - [Entity Framework 6.0.2](https://docs.microsoft.com/en-us/ef/ef6/) (EF 6);<br/>
 - [Entity Framework Core 2.0.3](https://docs.microsoft.com/en-us/ef/core/) (EF Core);<br/>
 - [eXpress Persistent Objects™ 18.1.3](https://www.devexpress.com/Products/NET/ORM/) (XPO).<br/>
 
You can run the benchmark tests or review our results below. Needless to say, the lower the execution time the better. 

All benchmarks were executed using .NET 4.6.1, AnyCPU release builds (include warm-up), Windows 10 Enterprise x64, local Microsoft SQL Server 2016 Developer Edition, i7-7700 CPU @3.6GHz / 16GB RAM / SSD. Please note that [DevExpress.Xpo](https://www.nuget.org/packages/DevExpress.Xpo/) and other referenced libraries will automatically be restored from Nuget. Edit the connection string in the [App.config](/ORMBenchmark/ORMBenchmark/App.config) file, update the ORM library and target framework versions, if necessary. 

We kept the first version of this test as simple as possible.  Feel free to make data model and test case modifications to cover additional usage scenarios. For instance,  measure memory consumption, include scenarios with BLOBs, reference and collection properties, etc. We'd love to hear your feedback about this project. Drop us a line in this [blog post](https://community.devexpress.com/blogs/xpo/archive/2018/06/22/xpo-a-simple-benchmark-against-ef-6-and-ef-core.aspx), thanks.

**See Also:**<br/>
[XPO ORM Library – Available Free-of-Charge in v18.1!](https://community.devexpress.com/blogs/xpo/archive/2018/05/21/xpo-free-of-charge-in-v18-1.aspx) (blog)<br/>
[How to: Connect to a Data Store](https://documentation.devexpress.com/CoreLibraries/2123/DevExpress-ORM-Tool/Concepts/How-to-Connect-to-a-Data-Store) (online documentation)<br/>
[Getting Started with \.NET Core](https://documentation.devexpress.com/CoreLibraries/119377/DevExpress-ORM-Tool/Getting-Started/Getting-Started-with-NET-Core) (online documentation)



## InsertOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/InsertOne-small-data-set.png) | ![](/images/InsertOne-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |3.6468                        |3.2059                        |2.0109                        |
|50                            |16.6132                       |11.6943                       |8.2731                        |
|100                           |31.8198                       |24.1677                       |13.7745                       |
|250                           |87.9603                       |80.6925                       |31.3714                       |
|500                           |236.7884                      |233.9296                      |68.3546                       |
|1000                          |669.2225                      |756.8632                      |139.1956                      |
|2500                          |3066.1437                     |3687.7787                     |324.2071                      |
|5000                          |10778.3849                    |14139.2871                    |642.9388                      |

**Source:** [ORMBenchmark.PerformanceTests.InsertOne](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L85-L87)

## InsertMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/InsertMany-small-data-set.png) | ![](/images/InsertMany-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |3.1646                        |1.3857                        |1.5144                        |
|50                            |9.7881                        |2.0376                        |5.0172                        |
|100                           |17.1645                       |3.1708                        |6.022                         |
|250                           |42.0912                       |7.6434                        |12.1765                       |
|500                           |104.4375                      |23.0093                       |28.7814                       |
|1000                          |278.0174                      |68.9055                       |59.1068                       |
|2500                          |1156.0837                     |125.1638                      |138.2078                      |
|5000                          |3793.305                      |340.5845                      |260.4955                      |

**Source:** [ORMBenchmark.PerformanceTests.InsertMany](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L90-L92)

## UpdateOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/UpdateOne-small-data-set.png) | ![](/images/UpdateOne-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |4.4828                        |3.7997                        |3.2936                        |
|50                            |14.6988                       |13.5383                       |8.9576                        |
|100                           |26.8667                       |24.5467                       |15.3601                       |
|250                           |72.8955                       |82.1338                       |33.2184                       |
|500                           |184.4039                      |226.8572                      |66.4556                       |
|1000                          |490.917                       |715.7156                      |151.4051                      |
|2500                          |2026.5181                     |3709.8866                     |316.4259                      |
|5000                          |6848.0788                     |13813.1268                    |586.063                       |

**Source:** [ORMBenchmark.PerformanceTests.UpdateOne](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L95-L97)

## UpdateMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/UpdateMany-small-data-set.png) | ![](/images/UpdateMany-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |4.5434                        |2.9346                        |3.0141                        |
|50                            |8.751                         |2.7303                        |5.6892                        |
|100                           |16.3787                       |4.5108                        |7.0334                        |
|250                           |33.733                        |9.5704                        |13.5268                       |
|500                           |67.5303                       |21.1547                       |24.7128                       |
|1000                          |153.1516                      |57.7461                       |47.2574                       |
|2500                          |368.9839                      |138.038                       |112.6205                      |
|5000                          |757.0275                      |295.0757                      |223.9792                      |

**Source:** [ORMBenchmark.PerformanceTests.UpdateMany](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L100-L102)

## DeleteOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/DeleteOne-small-data-set.png) | ![](/images/DeleteOne-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |3.9742                        |3.5429                        |4.3712                        |
|50                            |13.6068                       |11.0883                       |8.8385                        |
|100                           |23.0411                       |19.6916                       |14.6973                       |
|250                           |53.9951                       |46.2317                       |32.9369                       |
|500                           |96.6874                       |80.3932                       |64.4876                       |
|1000                          |198.0186                      |147.9286                      |118.5972                      |
|2500                          |478.2741                      |387.1099                      |313.6993                      |
|5000                          |934.7661                      |780.087                       |662.5583                      |

**Source:** [ORMBenchmark.PerformanceTests.DeleteOne](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L105-L107)

## DeleteMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/DeleteMany-small-data-set.png) | ![](/images/DeleteMany-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |2.9315                        |1.6348                        |1.3408                        |
|50                            |9.3622                        |3.6627                        |1.5809                        |
|100                           |15.4807                       |8.2583                        |3.7129                        |
|250                           |45.4516                       |35.7966                       |15.9567                       |
|500                           |98.6082                       |126.6155                      |20.5131                       |
|1000                          |257.487                       |480.7028                      |26.5237                       |
|2500                          |1149.465                      |2935.5197                     |72.5234                       |
|5000                          |3995.015                      |11573.3495                    |124.1232                      |

**Source:** [ORMBenchmark.PerformanceTests.DeleteMany](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L110-L112)

## Fetch Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/Fetch-small-data-set.png) | ![](/images/Fetch-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |4.9359                        |3.5214                        |2.1867                        |
|50                            |21.4742                       |12.6337                       |7.8819                        |
|100                           |42.4654                       |23.1171                       |14.0514                       |
|250                           |112.6379                      |56.3635                       |29.5522                       |
|500                           |215.7814                      |95.8708                       |61.3144                       |
|1000                          |400.2174                      |181.2916                      |109.2093                      |
|2500                          |1007.634                      |448.979                       |295.0182                      |
|5000                          |2162.202                      |900.4441                      |617.9753                      |

**Source:** [ORMBenchmark.PerformanceTests.Fetch](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L115-L117)

## InstantiationNative Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/InstantiationNative-small-data-set.png) | ![](/images/InstantiationNative-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.1027                        |0.1483                        |0.1263                        |
|50                            |0.1418                        |0.1703                        |0.1447                        |
|100                           |0.1725                        |0.2224                        |0.1828                        |
|250                           |0.3325                        |0.3825                        |0.3847                        |
|500                           |0.4926                        |0.4712                        |0.5782                        |
|1000                          |0.7988                        |0.7654                        |0.964                         |
|2500                          |1.7073                        |1.4457                        |2.2611                        |
|5000                          |3.1418                        |2.6653                        |4.7852                        |

**Source:** [ORMBenchmark.PerformanceTests.InstantiationNative](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L125-L129)

## InstantiationLinq Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/InstantiationLinq-small-data-set.png) | ![](/images/InstantiationLinq-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.2579                        |0.1916                        |0.1006                        |
|50                            |0.3047                        |0.2278                        |0.1269                        |
|100                           |0.373                         |0.2854                        |0.1808                        |
|250                           |0.5041                        |0.4207                        |0.2955                        |
|500                           |0.6973                        |0.5395                        |0.4419                        |
|1000                          |0.93                          |0.7819                        |0.764                         |
|2500                          |1.8178                        |1.4915                        |1.6101                        |
|5000                          |3.2746                        |2.7236                        |3.1768                        |

**Source:** [ORMBenchmark.PerformanceTests.InstantiationLinq](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L132-L136)

## ProjectionLinq Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/ProjectionLinq-small-data-set.png) | ![](/images/ProjectionLinq-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.2202                        |0.1752                        |0.1431                        |
|50                            |0.254                         |0.1827                        |0.1785                        |
|100                           |0.3118                        |0.2302                        |0.1987                        |
|250                           |0.4556                        |0.3755                        |0.3119                        |
|500                           |0.5781                        |0.5045                        |0.4639                        |
|1000                          |0.761                         |0.7447                        |0.6927                        |
|2500                          |1.4305                        |1.4753                        |1.4039                        |
|5000                          |2.5174                        |2.6872                        |2.7274                        |

**Source:** [ORMBenchmark.PerformanceTests.ProjectionLinq](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L167-L171)

## LinqQuery Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/LinqQuery-small-data-set.png) | ![](/images/LinqQuery-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |5.1944                        |3.323                         |2.4617                        |
|50                            |22.7323                       |13.1107                       |10.6768                       |
|100                           |44.1835                       |25.5668                       |19.3918                       |
|250                           |100.8101                      |52.1778                       |40.15                         |
|500                           |196.1996                      |91.3075                       |80.2875                       |
|1000                          |406.9472                      |176.056                       |153.9416                      |
|2500                          |1007.7786                     |503.2828                      |389.4942                      |
|5000                          |1980.8833                     |927.9413                      |776.0701                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqQuery](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L120-L122)

## LinqTakeRecords10 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/LinqTakeRecords10-small-data-set.png) | ![](/images/LinqTakeRecords10-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.5387                        |0.372                         |0.2693                        |
|50                            |2.2945                        |1.473                         |1.1869                        |
|100                           |4.4478                        |2.7227                        |1.9575                        |
|250                           |11.4284                       |6.1486                        |4.568                         |
|500                           |21.9762                       |10.9826                       |9.0061                        |
|1000                          |44.8547                       |21.492                        |16.7879                       |
|2500                          |115.9143                      |50.2855                       |39.5269                       |
|5000                          |215.7867                      |95.8005                       |79.9497                       |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords10](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L139-L143)

## LinqTakeRecords20 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/LinqTakeRecords20-small-data-set.png) | ![](/images/LinqTakeRecords20-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.5976                        |0.2984                        |0.3125                        |
|50                            |1.3465                        |0.8372                        |0.5699                        |
|100                           |2.2961                        |1.2031                        |1.0255                        |
|250                           |5.7992                        |2.9658                        |2.3234                        |
|500                           |10.9723                       |5.0778                        |4.4677                        |
|1000                          |23.8131                       |10.3702                       |8.3582                        |
|2500                          |54.8983                       |24.4662                       |20.6841                       |
|5000                          |110.093                       |51.3742                       |41.742                        |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords20](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L146-L150)

## LinqTakeRecords50 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/LinqTakeRecords50-small-data-set.png) | ![](/images/LinqTakeRecords50-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.4596                        |0.2689                        |0.28                          |
|50                            |0.5076                        |0.3108                        |0.2541                        |
|100                           |0.94                          |0.5772                        |0.4632                        |
|250                           |2.5524                        |1.4366                        |1.0343                        |
|500                           |4.9647                        |2.5153                        |1.9276                        |
|1000                          |9.2351                        |4.8291                        |4.2158                        |
|2500                          |25.0524                       |11.4944                       |9.7966                        |
|5000                          |50.0844                       |22.9799                       |19.8754                       |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords50](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L153-L157)

## LinqTakeRecords100 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/LinqTakeRecords100-small-data-set.png) | ![](/images/LinqTakeRecords100-large-data-set.png) |

|Row Count                     |EF 6 Time (milliseconds)      |EF Core Time (milliseconds)   |XPO Time (milliseconds)       |
|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.6749                        |0.3911                        |0.9448                        |
|50                            |0.5012                        |0.3061                        |0.3461                        |
|100                           |0.5536                        |0.3637                        |0.289                         |
|250                           |1.4859                        |0.9413                        |0.7918                        |
|500                           |2.5495                        |1.5113                        |1.3781                        |
|1000                          |5.3379                        |2.9755                        |2.6051                        |
|2500                          |12.569                        |6.6606                        |5.9008                        |
|5000                          |25.1495                       |13.8809                       |11.7254                       |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords100](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L160-L1164)
