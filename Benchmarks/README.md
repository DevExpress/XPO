# .NET ORM Benchmark

This project is a [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)-based benchmark. We used it to test the performance of the following Object-Relational Mapping (ORM) libraries for .NET Framework 4.6.1 and higher:<br/>
 - [Entity Framework 6.2.0](https://docs.microsoft.com/en-us/ef/ef6/) (EF 6);<br/>
 - [Entity Framework Core 2.1.4](https://docs.microsoft.com/en-us/ef/core/) (EF Core);<br/>
 - [eXpress Persistent Objects™ 18.2.3](https://www.devexpress.com/Products/NET/ORM/) (XPO).<br/>
 
You can run the benchmark tests or review our results below. Needless to say, the lower the execution time the better. 

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

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.73962                       |4.07246                       |3.4352                        |3.61192                       |2.77565                       |
|50                            |6.03672                       |14.17344                      |16.19069                      |17.32995                      |9.66230                       |
|100                           |10.66534                      |29.5362                       |40.64983                      |38.92176                      |15.89942                      |
|250                           |27.64593                      |85.26505                      |180.65651                     |182.3166                      |39.24309                      |
|500                           |55.07918                      |237.97093                     |571.80035                     |572.07229                     |81.11432                      |
|1000                          |116.54062                     |639.35085                     |2042.99305                    |2092.05979                    |156.42765                     |
|2500                          |295.30879                     |3123.16237                    |11647.75534                   |12009.38720                   |369.52967                     |
|5000                          |616.37593                     |10902.97887                   |45298.12038                   |48312.1037                    |738.86667                     |

**Source:** [ORMBenchmark.PerformanceTests.InsertOne](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L79-L81)

## InsertMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/InsertMany-small-data-set.png) | ![](/Benchmarks/images/InsertMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.65360                       |3.02192                       |1.11847                       |1.35194                       |1.68383                       |
|50                            |0.88279                       |10.95042                      |2.03493                       |2.28043                       |4.6896                        |
|100                           |1.19116                       |18.23309                      |3.4235                        |3.77848                       |8.01737                       |
|250                           |3.79302                       |48.15898                      |8.59677                       |9.35492                       |14.56509                      |
|500                           |14.66801                      |122.28126                     |25.59953                      |26.25026                      |35.32538                      |
|1000                          |47.76823                      |294.82587                     |70.56259                      |59.93899                      |77.16263                      |
|2500                          |247.69393                     |1156.12815                    |148.81218                     |141.06052                     |160.34947                     |
|5000                          |219.56949                     |3849.15074                    |347.9049                      |300.98287                     |337.30777                     |

**Source:** [ORMBenchmark.PerformanceTests.InsertMany](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L84-L86)

## UpdateOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/UpdateOne-small-data-set.png) | ![](/Benchmarks/images/UpdateOne-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |2.36251                       |5.49886                       |3.35536                       |4.70701                       |3.80497                       |
|50                            |6.34295                       |15.72518                      |15.58636                      |19.04896                      |11.17015                      |
|100                           |10.52854                      |30.17319                      |38.8199                       |39.66276                      |18.40818                      |
|250                           |24.85497                      |83.34587                      |170.49041                     |174.29491                     |37.63005                      |
|500                           |51.08687                      |195.48005                     |579.65307                     |588.2776                      |75.59602                      |
|1000                          |98.96975                      |480.54675                     |2035.99023                    |2078.87032                    |147.5052                      |
|2500                          |257.14056                     |2148.19716                    |11715.29958                   |11888.13749                   |344.9783                      |
|5000                          |521.47357                     |7087.08559                    |45394.41268                   |46464.48004                   |720.11414                     |

**Source:** [ORMBenchmark.PerformanceTests.UpdateOne](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L89-L91)

## UpdateMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/UpdateMany-small-data-set.png) | ![](/Benchmarks/images/UpdateMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.91046                       |3.42920                       |1.51221                       |2.61773                       |2.77639                       |
|50                            |1.21645                       |11.51714                      |2.66107                       |3.26748                       |4.80271                       |
|100                           |2.04208                       |18.02331                      |4.58947                       |5.00931                       |8.35463                       |
|250                           |5.23918                       |39.42159                      |10.84401                      |12.01799                      |16.45979                      |
|500                           |13.11423                      |89.47904                      |24.23441                      |26.50674                      |30.95326                      |
|1000                          |39.9537                       |160.11983                     |63.85569                      |67.9653                       |57.78805                      |
|2500                          |93.10671                      |387.97961                     |153.43295                     |162.22685                     |133.61674                     |
|5000                          |194.72988                     |831.08461                     |329.09344                     |346.0105                      |275.46309                     |

**Source:** [ORMBenchmark.PerformanceTests.UpdateMany](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L94-L96)

## DeleteOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/DeleteOne-small-data-set.png) | ![](/Benchmarks/images/DeleteOne-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.33852                       |4.53867                       |3.03013                       |4.62185                       |3.77317                       |
|50                            |5.44095                       |11.06477                      |10.04024                      |12.88457                      |9.27452                       |
|100                           |10.45788                      |20.50265                      |19.74576                      |21.50623                      |16.12891                      |
|250                           |25.57794                      |51.80054                      |43.97961                      |48.33123                      |37.84214                      |
|500                           |50.15543                      |96.86983                      |93.55461                      |92.11277                      |73.25274                      |
|1000                          |100.36425                     |200.95553                     |169.51417                     |183.87272                     |146.24676                     |
|2500                          |240.14830                     |487.32658                     |429.06331                     |422.4718                      |348.15547                     |
|5000                          |504.13353                     |1027.94682                    |823.10765                     |840.3509                      |677.68108                     |

**Source:** [ORMBenchmark.PerformanceTests.DeleteOne](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L99-L101)

## DeleteMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/DeleteMany-small-data-set.png) | ![](/Benchmarks/images/DeleteMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.52578                       |3.5095                        |3.59623                       |1.32776                       |2.22844                       |
|50                            |0.67696                       |11.71397                      |6.78747                       |2.5124                        |2.21869                       |
|100                           |2.66097                       |19.67493                      |20.94507                      |4.29046                       |3.63285                       |
|250                           |9.37838                       |49.99989                      |116.42391                     |9.42004                       |16.45232                      |
|500                           |10.96700                      |117.69275                     |443.36872                     |18.554                        |19.00541                      |
|1000                          |20.51131                      |310.25931                     |1747.45364                    |41.05455                      |28.29817                      |
|2500                          |20.11293                      |1255.34869                    |10682.44125                   |100.98221                     |72.84516                      |
|5000                          |38.56548                      |4087.60924                    |43027.98913                   |212.66981                     |122.59508                     |

**Source:** [ORMBenchmark.PerformanceTests.DeleteMany](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L104-L106)

## Fetch Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/Fetch-small-data-set.png) | ![](/Benchmarks/images/Fetch-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.51951                       |4.77528                       |2.82808                       |4.54663                       |1.90578                       |
|50                            |5.40663                       |21.76818                      |10.77758                      |19.97553                      |9.81407                       |
|100                           |10.24543                      |43.15999                      |19.18312                      |35.30929                      |16.6243                       |
|250                           |28.96181                      |106.67897                     |51.44533                      |100.37569                     |37.27808                      |
|500                           |50.31016                      |213.87091                     |98.69856                      |168.16593                     |71.94949                      |
|1000                          |98.93808                      |429.29627                     |181.56138                     |383.66375                     |136.40752                     |
|2500                          |257.06416                     |1063.98311                    |460.11643                     |957.76044                     |328.01292                     |
|5000                          |501.61401                     |2120.17679                    |948.27589                     |1948.90339                    |664.55349                     |

**Source:** [ORMBenchmark.PerformanceTests.Fetch](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L109-L111)

## InstantiationNative Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/InstantiationNative-small-data-set.png) | ![](/Benchmarks/images/InstantiationNative-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.09950                       |0.13276                       |0.15026                       |0.19345                       |0.13311                       |
|50                            |0.11808                       |0.18186                       |0.17726                       |0.17409                       |0.17909                       |
|100                           |0.14715                       |0.21173                       |0.20743                       |0.20861                       |0.23820                       |
|250                           |0.28471                       |0.36634                       |0.28985                       |0.24991                       |0.39036                       |
|500                           |0.40491                       |0.52791                       |0.41624                       |0.42773                       |0.62581                       |
|1000                          |0.61059                       |0.82042                       |0.58050                       |0.52978                       |1.03968                       |
|2500                          |1.22468                       |1.64713                       |1.02136                       |0.97868                       |2.24607                       |
|5000                          |2.33870                       |3.07875                       |1.76378                       |1.77039                       |4.63476                       |

**Source:** [ORMBenchmark.PerformanceTests.InstantiationNative](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L119-L123)

## InstantiationLinq Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/InstantiationLinq-small-data-set.png) | ![](/Benchmarks/images/InstantiationLinq-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.09635                       |0.24830                       |0.22387                       |0.22575                       |0.12598                       |
|50                            |0.11870                       |0.27017                       |0.22258                       |0.29285                       |0.15913                       |
|100                           |0.14294                       |0.31080                       |0.26445                       |0.29656                       |0.20394                       |
|250                           |0.24261                       |0.42622                       |0.36348                       |0.42083                       |0.32864                       |
|500                           |0.40338                       |0.60533                       |0.47937                       |0.47689                       |0.51469                       |
|1000                          |0.63322                       |0.94381                       |0.63469                       |0.66072                       |0.76273                       |
|2500                          |1.22857                       |1.77319                       |1.04791                       |1.04572                       |1.61542                       |
|5000                          |2.32554                       |3.25058                       |1.84898                       |1.86080                       |3.12108                       |

**Source:** [ORMBenchmark.PerformanceTests.InstantiationLinq](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L126-L130)

## ProjectionLinq Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/ProjectionLinq-small-data-set.png) | ![](/Benchmarks/images/ProjectionLinq-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.09662                       |0.22152                       |0.17582                       |0.19792                       |0.15567                       |
|50                            |0.11742                       |0.27056                       |0.20086                       |0.25331                       |0.19181                       |
|100                           |0.15900                       |0.27288                       |0.25103                       |0.29162                       |0.23807                       |
|250                           |0.27086                       |0.45607                       |0.42853                       |0.37263                       |0.34942                       |
|500                           |0.42462                       |0.59469                       |0.49048                       |0.51705                       |0.51753                       |
|1000                          |0.63772                       |0.76586                       |0.70299                       |0.70422                       |0.72524                       |
|2500                          |1.23250                       |1.42354                       |1.24504                       |1.28792                       |1.45929                       |
|5000                          |2.28840                       |2.58889                       |2.34596                       |2.33921                       |2.70533                       |

**Source:** [ORMBenchmark.PerformanceTests.ProjectionLinq](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L161-L165)

## LinqQuery Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqQuery-small-data-set.png) | ![](/Benchmarks/images/LinqQuery-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.32181                       |4.48081                       |2.88096                       |4.22276                       |2.53907                       |
|50                            |5.05446                       |19.98585                      |10.82552                      |18.18289                      |10.91869                      |
|100                           |9.82534                       |37.36982                      |20.29295                      |37.27043                      |20.94422                      |
|250                           |25.42797                      |98.38637                      |52.97859                      |79.06414                      |45.41502                      |
|500                           |50.68713                      |171.74744                     |94.62915                      |187.30041                     |83.94716                      |
|1000                          |100.99166                     |342.43                        |187.9514                      |327.21772                     |173.22154                     |
|2500                          |254.34656                     |1036.81246                    |476.15931                     |935.12916                     |415.39351                     |
|5000                          |521.42787                     |2045.21112                    |953.07941                     |1670.75624                    |780.55637                     |

**Source:** [ORMBenchmark.PerformanceTests.LinqQuery](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L114-L116)

## LinqTakeRecords10 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords10-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords10-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.16089                       |0.49802                       |0.32263                       |0.46959                       |0.27728                       |
|50                            |0.55474                       |2.30429                       |1.16350                       |2.13433                       |1.23399                       |
|100                           |1.09588                       |4.59926                       |2.28395                       |4.3074                        |2.10002                       |
|250                           |2.76160                       |11.39917                      |5.14034                       |10.33702                      |5.57693                       |
|500                           |5.47185                       |23.33432                      |10.94953                      |21.09825                      |9.79022                       |
|1000                          |10.77127                      |46.57051                      |20.20437                      |40.52863                      |18.67267                      |
|2500                          |27.15959                      |112.75156                     |53.22884                      |102.22410                     |44.58662                      |
|5000                          |52.28115                      |225.49168                     |98.85198                      |213.32194                     |87.69885                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords10](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L133-L137)

## LinqTakeRecords20 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords20-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords20-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.11985                       |0.45322                       |0.27911                       |1.24411                       |1.01959                       |
|50                            |0.33515                       |1.38999                       |0.83671                       |1.28121                       |0.56730                       |
|100                           |0.56683                       |2.42267                       |1.42571                       |2.08300                       |1.03429                       |
|250                           |1.43090                       |6.07131                       |3.40338                       |5.34037                       |2.35104                       |
|500                           |2.86075                       |11.59316                      |6.73489                       |10.59165                      |4.48606                       |
|1000                          |5.54383                       |22.33894                      |12.84630                      |20.84494                      |9.29509                       |
|2500                          |14.20001                      |56.43614                      |28.08355                      |42.65827                      |22.37182                      |
|5000                          |27.42950                      |117.62454                     |49.96621                      |97.16000                      |46.40681                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords20](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L140-L144)

## LinqTakeRecords50 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords50-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords50-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.11562                       |0.44910                       |0.22991                       |0.62950                       |0.22316                       |
|50                            |0.14016                       |0.49697                       |0.27671                       |0.47756                       |0.28229                       |
|100                           |0.27756                       |1.01391                       |0.50096                       |0.87620                       |0.54324                       |
|250                           |0.70526                       |2.41303                       |1.14101                       |2.16481                       |1.27379                       |
|500                           |1.27833                       |4.86283                       |2.26669                       |4.23432                       |2.30002                       |
|1000                          |2.65066                       |9.64634                       |4.33190                       |8.80744                       |4.58569                       |
|2500                          |6.75150                       |24.16169                      |12.50124                      |21.56500                      |10.55035                      |
|5000                          |13.09084                      |42.38605                      |22.62225                      |45.16562                      |20.66631                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords50](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L147-L151)

## LinqTakeRecords100 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords100-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords100-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 2.2.4 Time (milliseconds)|EF Core 3.0.0 Time (milliseconds)|XPO 19.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.10765                       |0.43252                       |0.22206                       |1.25258                       |0.24698                       |
|50                            |0.14427                       |0.48572                       |0.27249                       |0.60882                       |0.28049                       |
|100                           |0.15730                       |0.48798                       |0.27696                       |0.48870                       |0.31934                       |
|250                           |0.49591                       |1.45369                       |0.94487                       |1.36618                       |0.82998                       |
|500                           |0.78765                       |2.71043                       |1.50762                       |2.34132                       |1.22823                       |
|1000                          |1.62793                       |5.33470                       |3.21595                       |4.66186                       |2.58408                       |
|2500                          |4.04061                       |13.55342                      |5.94522                       |11.46059                      |6.37433                       |
|5000                          |7.91092                       |22.86244                      |12.56981                      |19.79485                      |14.158                        |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords100](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L154-L158)
