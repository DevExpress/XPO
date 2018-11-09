# .NET ORM Benchmark

This project is a [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)-based benchmark. We used it to test the performance of the following Object-Relational Mapping (ORM) libraries for .NET Framework 4.6.1 and higher:<br/>
 - [Entity Framework 6.2.0](https://docs.microsoft.com/en-us/ef/ef6/) (EF 6);<br/>
 - [Entity Framework Core 2.1.4](https://docs.microsoft.com/en-us/ef/core/) (EF Core);<br/>
 - [eXpress Persistent Objects™ 18.2.3](https://www.devexpress.com/Products/NET/ORM/) (XPO).<br/>
 
You can run the benchmark tests or review our results below. Needless to say, the lower the execution time the better. 

All benchmarks were executed using .NET 4.7.2, AnyCPU release builds (include warm-up), Windows 10 Enterprise x64, local Microsoft SQL Server 2016 Developer Edition, i7-7700 CPU @3.6GHz / 16GB RAM / SSD. Please note that [DevExpress.Xpo](https://www.nuget.org/packages/DevExpress.Xpo/) and other referenced libraries will automatically be restored from Nuget. Edit the connection string in the [App.config](/ORMBenchmark/ORMBenchmark/App.config) file, update the ORM library and target framework versions, if necessary. 

We kept the first version of this test as simple as possible.  Feel free to make data model and test case modifications to cover additional usage scenarios. For instance,  measure memory consumption, include scenarios with BLOBs, reference and collection properties, etc. We'd love to hear your feedback about this project. Drop us a line in this [blog post](https://community.devexpress.com/blogs/xpo/archive/2018/06/22/xpo-a-simple-benchmark-against-ef-6-and-ef-core.aspx), thanks.

**See Also:**<br/>
[XPO ORM Library – Available Free-of-Charge in v18.1!](https://community.devexpress.com/blogs/xpo/archive/2018/05/21/xpo-free-of-charge-in-v18-1.aspx) (blog)<br/>
[How to: Connect to a Data Store](https://documentation.devexpress.com/CoreLibraries/2123/DevExpress-ORM-Tool/Concepts/How-to-Connect-to-a-Data-Store) (online documentation)<br/>
[Getting Started with \.NET Core](https://documentation.devexpress.com/CoreLibraries/119377/DevExpress-ORM-Tool/Getting-Started/Getting-Started-with-NET-Core) (online documentation)



## InsertOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/InsertOne-small-data-set.png) | ![](/images/InsertOne-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.60902                       |4.19273                       |3.34004                       |2.93242                       |
|50                            |5.09951                       |15.74197                      |16.58269                      |9.30857                       |
|100                           |9.86197                       |31.72592                      |40.53826                      |16.34155                      |
|250                           |25.95819                      |95.87419                      |172.07388                     |36.37188                      |
|500                           |52.69986                      |248.64171                     |598.28147                     |76.34854                      |
|1000                          |108.83357                     |690.65668                     |2092.24886                    |160.75236                     |
|2500                          |292.06215                     |3167.36457                    |12088.78309                   |387.6723                      |
|5000                          |546.74708                     |11342.09605                   |46913.26095                   |777.92085                     |

**Source:** [ORMBenchmark.PerformanceTests.InsertOne](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L79-L81)

## InsertMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/InsertMany-small-data-set.png) | ![](/images/InsertMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.44412                       |3.19567                       |1.17089                       |1.46893                       |
|50                            |0.6665                        |10.52717                      |2.12266                       |3.2773                        |
|100                           |1.17381                       |18.74183                      |3.41379                       |5.80527                       |
|250                           |3.89218                       |47.65224                      |8.53677                       |15.4555                       |
|500                           |15.41344                      |129.61142                     |25.27777                      |32.0607                       |
|1000                          |49.38669                      |305.3152                      |71.59549                      |66.9802                       |
|2500                          |113.09453                     |1228.29871                    |172.19131                     |153.5152                      |
|5000                          |229.19865                     |4027.46954                    |315.17467                     |331.50595                     |

**Source:** [ORMBenchmark.PerformanceTests.InsertMany](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L84-L86)

## UpdateOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/UpdateOne-small-data-set.png) | ![](/images/UpdateOne-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |2.20043                       |5.73669                       |4.28836                       |4.2939                        |
|50                            |5.42646                       |14.72858                      |16.6375                       |8.574                         |
|100                           |10.18625                      |29.83896                      |42.23037                      |15.82146                      |
|250                           |25.06713                      |77.1076                       |177.1056                      |37.33094                      |
|500                           |49.23121                      |183.01067                     |572.02567                     |72.99978                      |
|1000                          |107.53555                     |502.99577                     |2020.2119                     |155.55827                     |
|2500                          |248.40432                     |2147.50299                    |11719.29564                   |351.54008                     |
|5000                          |515.09404                     |7234.76898                    |46095.03902                   |721.8575                      |

**Source:** [ORMBenchmark.PerformanceTests.UpdateOne](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L89-L91)

## UpdateMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/UpdateMany-small-data-set.png) | ![](/images/UpdateMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.75418                       |4.8058                        |1.63989                       |3.00777                       |
|50                            |1.31211                       |10.22521                      |2.90689                       |4.86433                       |
|100                           |2.1651                        |17.7383                       |4.66325                       |7.09069                       |
|250                           |5.60912                       |38.29953                      |10.42979                      |15.48296                      |
|500                           |13.6331                       |79.42386                      |23.30861                      |28.57441                      |
|1000                          |42.8052                       |173.88825                     |62.99767                      |55.08882                      |
|2500                          |96.17823                      |391.34613                     |150.99402                     |138.47825                     |
|5000                          |207.47762                     |851.93428                     |319.44294                     |268.07379                     |

**Source:** [ORMBenchmark.PerformanceTests.UpdateMany](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L94-L96)

## DeleteOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/DeleteOne-small-data-set.png) | ![](/images/DeleteOne-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.35229                       |5.41725                       |3.03971                       |4.16354                       |
|50                            |5.154                         |13.07433                      |11.53816                      |8.58372                       |
|100                           |10.16879                      |25.70559                      |20.60953                      |15.86823                      |
|250                           |25.82096                      |56.64417                      |44.11558                      |37.39277                      |
|500                           |49.63083                      |105.85601                     |99.04998                      |73.61902                      |
|1000                          |104.14967                     |206.13318                     |171.90911                     |142.2042                      |
|2500                          |247.69084                     |544.98543                     |425.96493                     |343.9544                      |
|5000                          |524.66883                     |1078.21011                    |877.35448                     |682.81796                     |

**Source:** [ORMBenchmark.PerformanceTests.DeleteOne](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L99-L101)

## DeleteMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/DeleteMany-small-data-set.png) | ![](/images/DeleteMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.5698                        |2.86362                       |1.70813                       |2.95028                       |
|50                            |0.69874                       |9.04742                       |7.01512                       |1.23871                       |
|100                           |2.78285                       |18.09189                      |22.56979                      |3.75337                       |
|250                           |9.46971                       |51.83839                      |118.68252                     |17.14256                      |
|500                           |13.09931                      |113.65551                     |455.88367                     |19.64353                      |
|1000                          |20.48757                      |302.09433                     |1795.85268                    |27.69587                      |
|2500                          |19.65093                      |1233.94547                    |11479.91199                   |77.32662                      |
|5000                          |42.43921                      |4260.60081                    |44742.09767                   |132.49481                     |

**Source:** [ORMBenchmark.PerformanceTests.DeleteMany](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L104-L106)

## Fetch Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/Fetch-small-data-set.png) | ![](/images/Fetch-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.3227                        |4.96404                       |3.3855                        |1.96644                       |
|50                            |5.42141                       |21.46763                      |11.70938                      |7.66235                       |
|100                           |10.87347                      |40.92337                      |22.96266                      |15.81142                      |
|250                           |26.72016                      |98.56416                      |56.60525                      |35.34118                      |
|500                           |52.37216                      |198.80093                     |110.2443                      |74.22732                      |
|1000                          |105.27916                     |417.63245                     |214.92043                     |135.95051                     |
|2500                          |262.50663                     |898.72283                     |578.73005                     |331.22809                     |
|5000                          |488.77896                     |1841.69544                    |1071.00927                    |660.38679                     |

**Source:** [ORMBenchmark.PerformanceTests.Fetch](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L109-L111)

## InstantiationNative Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/InstantiationNative-small-data-set.png) | ![](/images/InstantiationNative-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.10226                       |0.14462                       |0.18488                       |0.12821                       |
|50                            |0.12387                       |0.1701                        |0.20155                       |0.16349                       |
|100                           |0.15231                       |0.20601                       |0.25893                       |0.2047                        |
|250                           |0.22746                       |0.3078                        |0.36665                       |0.3558                        |
|500                           |0.39536                       |0.51847                       |0.47162                       |0.58883                       |
|1000                          |0.60014                       |0.82071                       |0.62842                       |0.98372                       |
|2500                          |1.23472                       |1.74691                       |1.13827                       |2.29676                       |
|5000                          |2.33936                       |3.26244                       |2.08388                       |5.06711                       |

**Source:** [ORMBenchmark.PerformanceTests.InstantiationNative](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L119-L123)

## InstantiationLinq Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/InstantiationLinq-small-data-set.png) | ![](/images/InstantiationLinq-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.1021                        |0.26456                       |0.23122                       |0.12572                       |
|50                            |0.1303                        |0.2798                        |0.29375                       |0.15357                       |
|100                           |0.14887                       |0.32787                       |0.29588                       |0.20035                       |
|250                           |0.29271                       |0.43645                       |0.40177                       |0.30751                       |
|500                           |0.40632                       |0.66313                       |0.52037                       |0.47327                       |
|1000                          |0.62446                       |0.97965                       |0.7014                        |0.79302                       |
|2500                          |1.21593                       |1.89211                       |1.27493                       |1.68008                       |
|5000                          |2.33319                       |3.43492                       |2.16611                       |3.2028                        |

**Source:** [ORMBenchmark.PerformanceTests.InstantiationLinq](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L126-L130)

## ProjectionLinq Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/ProjectionLinq-small-data-set.png) | ![](/images/ProjectionLinq-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.09293                       |0.2483                        |0.20686                       |0.15559                       |
|50                            |0.11566                       |0.25758                       |0.22999                       |0.18291                       |
|100                           |0.14173                       |0.32311                       |0.26396                       |0.21877                       |
|250                           |0.23303                       |0.46037                       |0.4298                        |0.2867                        |
|500                           |0.38504                       |0.5402                        |0.52345                       |0.51931                       |
|1000                          |0.59133                       |0.77857                       |0.77933                       |0.72166                       |
|2500                          |1.26044                       |1.50227                       |1.54141                       |1.47414                       |
|5000                          |2.3381                        |2.6592                        |2.78247                       |2.77924                       |

**Source:** [ORMBenchmark.PerformanceTests.ProjectionLinq](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L161-L165)

## LinqQuery Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/LinqQuery-small-data-set.png) | ![](/images/LinqQuery-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.15423                       |5.08869                       |3.26728                       |2.89247                       |
|50                            |5.29321                       |21.34214                      |13.83274                      |10.62435                      |
|100                           |11.69196                      |36.72813                      |26.41915                      |18.71466                      |
|250                           |27.35913                      |90.27387                      |56.73275                      |43.0844                       |
|500                           |53.43025                      |178.76802                     |117.34178                     |84.14108                      |
|1000                          |106.06412                     |359.10334                     |231.5446                      |162.92102                     |
|2500                          |244.69358                     |931.62635                     |550.33537                     |409.95055                     |
|5000                          |530.93814                     |1825.54635                    |1121.17804                    |837.19205                     |

**Source:** [ORMBenchmark.PerformanceTests.LinqQuery](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L114-L116)

## LinqTakeRecords10 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/LinqTakeRecords10-small-data-set.png) | ![](/images/LinqTakeRecords10-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.1341                        |0.55771                       |0.3358                        |0.273                         |
|50                            |0.5381                        |2.2956                        |1.42636                       |1.11023                       |
|100                           |1.22423                       |3.95459                       |2.78434                       |1.97376                       |
|250                           |2.58282                       |11.52305                      |6.24925                       |4.76616                       |
|500                           |5.38934                       |22.37234                      |12.53354                      |9.10331                       |
|1000                          |10.65747                      |45.02374                      |23.25913                      |18.42596                      |
|2500                          |25.91311                      |113.81952                     |56.10668                      |45.58331                      |
|5000                          |56.18968                      |221.44833                     |112.00941                     |90.99834                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords10](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L133-L137)

## LinqTakeRecords20 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/LinqTakeRecords20-small-data-set.png) | ![](/images/LinqTakeRecords20-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.12406                       |0.43134                       |0.28383                       |1.10083                       |
|50                            |0.37367                       |1.20753                       |0.80671                       |0.59214                       |
|100                           |0.57877                       |2.06612                       |1.34241                       |1.02748                       |
|250                           |1.75186                       |5.21304                       |3.38826                       |2.43322                       |
|500                           |3.07536                       |10.03442                      |6.46456                       |4.90678                       |
|1000                          |5.72735                       |22.06357                      |12.68949                      |9.18562                       |
|2500                          |13.80206                      |57.02081                      |28.6854                       |22.73038                      |
|5000                          |29.85419                      |101.82034                     |63.03109                      |45.78746                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords20](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L140-L144)

## LinqTakeRecords50 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/LinqTakeRecords50-small-data-set.png) | ![](/images/LinqTakeRecords50-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.11437                       |0.47533                       |0.27785                       |1.10612                       |
|50                            |0.13076                       |0.47937                       |0.2974                        |0.24916                       |
|100                           |0.27473                       |0.98392                       |0.54425                       |0.43768                       |
|250                           |0.69                          |2.36144                       |1.35943                       |1.17533                       |
|500                           |1.4178                        |4.84134                       |2.62475                       |2.16815                       |
|1000                          |2.48865                       |9.83998                       |4.9942                        |4.29678                       |
|2500                          |6.40796                       |23.88416                      |12.52956                      |10.26229                      |
|5000                          |13.45901                      |48.89008                      |25.96608                      |19.87431                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords50](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L147-L151)

## LinqTakeRecords100 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/LinqTakeRecords100-small-data-set.png) | ![](/images/LinqTakeRecords100-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.1.4 Time (milliseconds)|XPO 18.2.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.10956                       |0.70423                       |0.28802                       |0.37299                       |
|50                            |0.14128                       |0.4901                        |0.31064                       |0.23853                       |
|100                           |0.17367                       |0.56087                       |0.34009                       |0.30046                       |
|250                           |0.51128                       |1.5627                        |0.82639                       |0.79334                       |
|500                           |0.84658                       |2.66096                       |1.57823                       |1.24907                       |
|1000                          |1.72457                       |5.33501                       |3.22263                       |2.67252                       |
|2500                          |3.84649                       |13.5022                       |7.24441                       |6.26659                       |
|5000                          |8.23894                       |26.91234                      |13.92579                      |12.44569                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords100](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L154-L158)
