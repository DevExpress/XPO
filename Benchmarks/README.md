# .NET ORM Benchmark

This project is a [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)-based benchmark. We used it to test the performance of the following Object-Relational Mapping (ORM) libraries for .NET Framework 4.6.1 and higher:<br/>
 - [Entity Framework 6.2.0](https://docs.microsoft.com/en-us/ef/ef6/) (EF 6);<br/>
 - [Entity Framework Core 2.2.4, 3.0.0-preview5](https://docs.microsoft.com/en-us/ef/core/) (EF Core);<br/>
 - [eXpress Persistent Objects™ 19.1.3](https://www.devexpress.com/Products/NET/ORM/) (XPO).<br/>
 
The benchmark project uses EF Core 2.2.4 by default. Upgrade the NuGet package to v3.0.0-preview5, if required.

You can run these benchmarks or review our test results below. Needless to say, the lower the execution time the better.

All benchmarks were executed using .NET 4.7.2, AnyCPU release builds (include warm-up), Windows 10 Enterprise x64, local Microsoft SQL Server 2016 Developer Edition, i7-7700 CPU @3.6GHz / 16GB RAM / SSD. 

If you download the project to run benchmark tests in your environment, edit the connection string in the [App.config](/Benchmarks/ORMBenchmark/App.config) file and update the ORM library and target framework versions, if necessary. Please note that we used Nuget to add [DevExpress.Xpo](https://www.nuget.org/packages/DevExpress.Xpo/) and other libraries to project references.  

We kept the first version of this test as simple as possible.  Feel free to make data model and test case modifications to cover additional usage scenarios. For instance,  measure memory consumption, include scenarios with BLOBs, reference and collection properties, etc. We'd love to hear your feedback about this project. Drop us a line in this [blog post](https://community.devexpress.com/blogs/xpo/archive/2018/06/22/xpo-a-simple-benchmark-against-ef-6-and-ef-core.aspx), thanks.

**See Also:**<br/>
[XPO ORM Library – Available Free-of-Charge in v18.1!](https://community.devexpress.com/blogs/xpo/archive/2018/05/21/xpo-free-of-charge-in-v18-1.aspx) (blog)<br/>
[How to: Connect to a Data Store](https://documentation.devexpress.com/CoreLibraries/2123/DevExpress-ORM-Tool/Concepts/How-to-Connect-to-a-Data-Store) (online documentation)<br/>
[Getting Started with \.NET Core](https://documentation.devexpress.com/CoreLibraries/119377/DevExpress-ORM-Tool/Getting-Started/Getting-Started-with-NET-Core) (online documentation)



## InsertOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/InsertOne-small-data-set.png) | ![](/Benchmarks/images/InsertOne-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.30011                       |4.11676                       |2.81302                       |2.57604                       |
|50                            |4.77537                       |15.6529                       |16.13054                      |7.42094                       |
|100                           |9.22262                       |29.96274                      |42.14327                      |14.97818                      |
|250                           |23.15751                      |80.12939                      |108.82489                     |36.61419                      |
|500                           |50.51315                      |193.89164                     |344.29577                     |74.46987                      |
|1000                          |101.38515                     |568.98309                     |1159.26570                    |151.82508                     |
|2500                          |245.46695                     |2604.21166                    |6292.92698                    |332.02271                     |
|5000                          |497.54489                     |9007.21718                    |25106.7976                    |649.78532                     |

**Source:** [ORMBenchmark.PerformanceTests.InsertOne](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L79-L81)

## InsertMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/InsertMany-small-data-set.png) | ![](/Benchmarks/images/InsertMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.67114                       |3.33909                       |1.42089                       |1.76557                       |
|50                            |0.63108                       |11.5564                       |2.691                         |4.13336                       |
|100                           |1.17031                       |18.32265                      |4.12075                       |6.28404                       |
|250                           |4.05177                       |44.78349                      |10.66669                      |14.28352                      |
|500                           |14.77882                      |107.62586                     |27.58769                      |31.72569                      |
|1000                          |35.81162                      |258.8134                      |55.09975                      |66.42771                      |
|2500                          |92.74763                      |1034.00402                    |126.40582                     |132.89229                     |
|5000                          |218.90486                     |3357.97891                    |326.71912                     |267.40733                     |

**Source:** [ORMBenchmark.PerformanceTests.InsertMany](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L84-L86)

## UpdateOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/UpdateOne-small-data-set.png) | ![](/Benchmarks/images/UpdateOne-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.24421                       |4.56972                       |3.67776                       |4.24452                       |
|50                            |4.96218                       |16.0286                       |17.07123                      |8.88956                       |
|100                           |9.37855                       |32.08799                      |42.36861                      |15.11269                      |
|250                           |23.36444                      |70.44441                      |110.97235                     |36.8361                       |
|500                           |44.97534                      |170.47485                     |333.46657                     |69.41838                      |
|1000                          |86.4516                       |408.04783                     |1147.29963                    |126.81965                     |
|2500                          |244.29115                     |1764.14425                    |6193.44225                    |293.26149                     |
|5000                          |420.58131                     |6027.41618                    |24648.33769                   |598.76167                     |

**Source:** [ORMBenchmark.PerformanceTests.UpdateOne](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L89-L91)

## UpdateMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/UpdateMany-small-data-set.png) | ![](/Benchmarks/images/UpdateMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.66349                       |4.71978                       |1.60598                       |2.85543                       |
|50                            |0.89894                       |9.70245                       |3.38575                       |3.81804                       |
|100                           |1.57755                       |17.16909                      |5.36416                       |6.18521                       |
|250                           |5.26207                       |38.44798                      |13.0681                       |15.41077                      |
|500                           |13.5667                       |74.63640                      |26.63934                      |27.03474                      |
|1000                          |40.03485                      |136.47674                     |62.75546                      |54.69962                      |
|2500                          |91.21325                      |349.99986                     |151.01511                     |124.84083                     |
|5000                          |198.36534                     |716.66095                     |298.17015                     |234.37907                     |

**Source:** [ORMBenchmark.PerformanceTests.UpdateMany](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L94-L96)

## DeleteOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/DeleteOne-small-data-set.png) | ![](/Benchmarks/images/DeleteOne-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.25238                       |3.98533                       |3.23379                       |3.82995                       |
|50                            |5.36424                       |14.18938                      |10.89356                      |8.55818                       |
|100                           |9.22379                       |23.22533                      |21.60356                      |15.60869                      |
|250                           |22.45756                      |48.90852                      |48.58477                      |35.66454                      |
|500                           |42.76954                      |94.86517                      |81.09673                      |64.45386                      |
|1000                          |85.34417                      |165.47119                     |147.7784                      |125.24869                     |
|2500                          |212.24341                     |405.54826                     |348.50565                     |305.82269                     |
|5000                          |444.31019                     |833.35678                     |709.44072                     |590.31332                     |

**Source:** [ORMBenchmark.PerformanceTests.DeleteOne](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L99-L101)

## DeleteMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/DeleteMany-small-data-set.png) | ![](/Benchmarks/images/DeleteMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.45141                       |3.10115                       |1.64269                       |3.26521                       |
|50                            |0.68042                       |10.83143                      |9.85954                       |1.87902                       |
|100                           |2.61016                       |18.73241                      |4.77569                       |3.47448                       |
|250                           |9.00836                       |42.64552                      |11.00592                      |16.68288                      |
|500                           |11.08267                      |103.27750                     |16.19101                      |20.27799                      |
|1000                          |20.40733                      |236.49219                     |35.25814                      |27.60369                      |
|2500                          |17.57917                      |964.45545                     |80.46678                      |76.57273                      |
|5000                          |38.20989                      |3185.86815                    |169.88024                     |126.45437                     |

**Source:** [ORMBenchmark.PerformanceTests.DeleteMany](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L104-L106)

## Fetch Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/Fetch-small-data-set.png) | ![](/Benchmarks/images/Fetch-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.98873                       |5.27813                       |5.40789                       |1.85297                       |
|50                            |4.67256                       |24.48262                      |23.74783                      |7.41968                       |
|100                           |9.64231                       |49.33388                      |45.74759                      |14.83402                      |
|250                           |23.90271                      |116.59906                     |113.81097                     |32.41664                      |
|500                           |45.74341                      |199.78272                     |205.69606                     |63.11110                      |
|1000                          |90.28381                      |370.66036                     |423.68574                     |122.29599                     |
|2500                          |218.74215                     |925.83001                     |935.40279                     |276.47403                     |
|5000                          |422.48146                     |1885.44794                    |1894.71511                    |578.55525                     |

**Source:** [ORMBenchmark.PerformanceTests.Fetch](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L109-L111)

## InstantiationNative Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/InstantiationNative-small-data-set.png) | ![](/Benchmarks/images/InstantiationNative-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.08522                       |0.11052                       |0.15570                       |0.11886                       |
|50                            |0.11039                       |0.13752                       |0.17661                       |0.14601                       |
|100                           |0.13140                       |0.17098                       |0.19993                       |0.19902                       |
|250                           |0.20372                       |0.24480                       |0.32140                       |0.36143                       |
|500                           |0.35082                       |0.38100                       |0.43619                       |0.54106                       |
|1000                          |0.48068                       |0.59629                       |0.62512                       |0.91704                       |
|2500                          |0.93832                       |1.17798                       |1.15784                       |2.05258                       |
|5000                          |1.79114                       |2.20145                       |2.09480                       |4.81109                       |

**Source:** [ORMBenchmark.PerformanceTests.InstantiationNative](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L119-L123)

## InstantiationLinq Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/InstantiationLinq-small-data-set.png) | ![](/Benchmarks/images/InstantiationLinq-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.08763                       |0.21542                       |0.21484                       |0.11441                       |
|50                            |0.10834                       |0.24533                       |0.23727                       |0.13350                       |
|100                           |0.15603                       |0.29030                       |0.28999                       |0.17718                       |
|250                           |0.20616                       |0.40412                       |0.39067                       |0.28267                       |
|500                           |0.34413                       |0.51152                       |0.50340                       |0.40709                       |
|1000                          |0.49718                       |0.72333                       |0.69421                       |0.69253                       |
|2500                          |0.97776                       |1.26333                       |1.18859                       |1.40114                       |
|5000                          |1.77173                       |2.36007                       |2.17338                       |2.98182                       |

**Source:** [ORMBenchmark.PerformanceTests.InstantiationLinq](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L126-L130)

## ProjectionLinq Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/ProjectionLinq-small-data-set.png) | ![](/Benchmarks/images/ProjectionLinq-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.08743                       |0.18687                       |0.17857                       |0.12609                       |
|50                            |0.11202                       |0.21579                       |0.20087                       |0.16407                       |
|100                           |0.12558                       |0.23574                       |0.25473                       |0.19385                       |
|250                           |0.20617                       |0.33239                       |0.33852                       |0.27482                       |
|500                           |0.36319                       |0.43131                       |0.48489                       |0.40008                       |
|1000                          |0.49812                       |0.59980                       |0.63539                       |0.58971                       |
|2500                          |0.97949                       |1.10416                       |1.16273                       |1.18751                       |
|5000                          |1.75649                       |2.00352                       |2.04949                       |2.24846                       |

**Source:** [ORMBenchmark.PerformanceTests.ProjectionLinq](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L161-L165)

## LinqQuery Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqQuery-small-data-set.png) | ![](/Benchmarks/images/LinqQuery-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.95803                       |5.45303                       |4.91267                       |2.43442                       |
|50                            |4.78474                       |23.91646                      |22.79661                      |10.22349                      |
|100                           |9.2384                        |49.65043                      |44.18796                      |17.59868                      |
|250                           |23.04314                      |120.17915                     |111.17177                     |44.05605                      |
|500                           |44.50985                      |197.83109                     |205.64873                     |86.2816                       |
|1000                          |86.93072                      |382.42576                     |407.69247                     |145.17590                     |
|2500                          |215.13203                     |910.67515                     |928.87117                     |332.51037                     |
|5000                          |423.60955                     |1880.34862                    |1911.71875                    |715.52839                     |

**Source:** [ORMBenchmark.PerformanceTests.LinqQuery](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L114-L116)

## LinqTakeRecords10 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords10-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords10-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.10864                       |0.56074                       |0.56487                       |0.24024                       |
|50                            |0.51214                       |2.71173                       |2.65819                       |1.04253                       |
|100                           |1.16492                       |5.05973                       |5.34610                       |2.09797                       |
|250                           |2.52715                       |11.47826                      |12.36865                      |5.42891                       |
|500                           |4.95016                       |20.79770                      |21.62590                      |9.40839                       |
|1000                          |9.92035                       |40.63901                      |40.19699                      |15.48987                      |
|2500                          |22.34923                      |99.88746                      |95.90411                      |36.05571                      |
|5000                          |44.51433                      |193.2185                      |193.89335                     |72.94914                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords10](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L133-L137)

## LinqTakeRecords20 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords20-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords20-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.11130                       |0.55202                       |0.48056                       |1.09500                       |
|50                            |0.33198                       |1.47711                       |1.58994                       |0.64089                       |
|100                           |0.51741                       |2.43549                       |2.43646                       |1.02250                       |
|250                           |1.33115                       |5.60777                       |5.54501                       |2.27165                       |
|500                           |2.50957                       |9.93623                       |10.31630                      |4.01632                       |
|1000                          |4.68394                       |20.19257                      |20.32789                      |7.41087                       |
|2500                          |11.79132                      |50.52318                      |51.24161                      |19.23566                      |
|5000                          |24.29363                      |99.91946                      |101.51065                     |37.18284                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords20](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L140-L144)

## LinqTakeRecords50 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords50-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords50-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.10553                       |0.52329                       |0.51046                       |0.21737                       |
|50                            |0.13837                       |0.52211                       |0.51782                       |0.25672                       |
|100                           |0.26096                       |0.97406                       |1.02069                       |0.46712                       |
|250                           |0.61924                       |2.18390                       |2.30944                       |1.15105                       |
|500                           |1.26515                       |4.39583                       |4.31722                       |1.79432                       |
|1000                          |2.21447                       |8.17966                       |8.25544                       |3.54324                       |
|2500                          |5.58568                       |20.89797                      |21.28229                      |8.74106                       |
|5000                          |10.86242                      |41.97269                      |42.20363                      |16.99912                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords50](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L147-L151)

## LinqTakeRecords100 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords100-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords100-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.0.0 Time (milliseconds)|XPO 19.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.11056                       |0.51144                       |0.50984                       |1.09830                       |
|50                            |0.13692                       |0.54982                       |0.49349                       |0.26544                       |
|100                           |0.17188                       |0.58166                       |0.57680                       |0.30519                       |
|250                           |0.44256                       |1.43641                       |1.64473                       |0.71878                       |
|500                           |0.71132                       |2.33845                       |2.33190                       |1.11130                       |
|1000                          |1.47808                       |4.64970                       |4.51713                       |2.24010                       |
|2500                          |3.32311                       |11.14197                      |11.19637                      |5.02971                       |
|5000                          |6.55728                       |22.18122                      |23.11917                      |10.09272                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords100](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L154-L158)
