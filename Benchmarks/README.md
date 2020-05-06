# .NET Core ORM Benchmark

This project is a [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)-based benchmark. We used it to test the performance of the following Object-Relational Mapping (ORM) libraries for .NET Core 3.1.3 and higher:<br/>
 - [Entity Framework 6.3.0](https://docs.microsoft.com/en-us/ef/ef6/) (EF 6);<br/>
 - [Entity Framework Core 3.1.3](https://docs.microsoft.com/en-us/ef/core/) (EF Core);<br/>
 - [eXpress Persistent Objects™ 20.1.3](https://www.devexpress.com/Products/NET/ORM/) (XPO).<br/>
 
You can run these benchmarks or review our test results below. Needless to say, the lower the execution time the better.

All benchmarks were executed using .NET Core 3.1, AnyCPU release builds (include warm-up), Windows 10 Enterprise x64, local Microsoft SQL Server 2016 Developer Edition, i7-7700 CPU @3.6GHz / 16GB RAM / SSD. 

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

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.89722                       |4.50444                       |3.87023                       |2.94051                       |
|50                            |4.65445                       |17.02534                      |16.06639                      |9.21372                       |
|100                           |8.8138                        |28.82075                      |33.38422                      |15.34767                      |
|250                           |22.27643                      |80.14244                      |112.51818                     |37.56445                      |
|500                           |48.97204                      |197.70918                     |359.09621                     |69.68434                      |
|1000                          |99.48589                      |573.93571                     |1205.32878                    |133.76597                     |
|2500                          |241.28246                     |2617.14784                    |6509.44738                    |331.40959                     |
|5000                          |485.70489                     |9417.45299                    |24878.17187                   |699.12193                     |

**Source:** [ORMBenchmark.PerformanceTests.InsertOne](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L79-L81)

## InsertMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/InsertMany-small-data-set.png) | ![](/Benchmarks/images/InsertMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.50429                       |3.58846                       |1.65905                       |1.43724                       |
|50                            |0.70323                       |10.501                        |2.97125                       |3.50639                       |
|100                           |1.17537                       |18.44991                      |5.18768                       |6.66488                       |
|250                           |3.83587                       |44.90028                      |11.33544                      |14.92906                      |
|500                           |29.46821                      |99.03968                      |28.40835                      |31.51651                      |
|1000                          |37.47659                      |258.98653                     |58.43992                      |66.65173                      |
|2500                          |113.78215                     |1035.95511                    |173.66415                     |139.34443                     |
|5000                          |235.50867                     |3361.11363                    |357.82358                     |320.22284                     |

**Source:** [ORMBenchmark.PerformanceTests.InsertMany](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L84-L86)

## UpdateOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/UpdateOne-small-data-set.png) | ![](/Benchmarks/images/UpdateOne-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.25804                       |4.78427                       |3.87971                       |4.10759                       |
|50                            |4.82898                       |16.16469                      |17.92349                      |8.66722                       |
|100                           |9.3033                        |28.10266                      |39.5498                       |16.19368                      |
|250                           |21.97511                      |63.96296                      |112.37524                     |37.39636                      |
|500                           |49.41406                      |148.6982                      |345.69169                     |70.80220                      |
|1000                          |84.82839                      |406.57509                     |1147.88166                    |138.09792                     |
|2500                          |209.16639                     |1930.92235                    |6213.67379                    |297.47923                     |
|5000                          |406.28502                     |5985.06223                    |25187.66883                   |649.85351                     |

**Source:** [ORMBenchmark.PerformanceTests.UpdateOne](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L89-L91)

## UpdateMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/UpdateMany-small-data-set.png) | ![](/Benchmarks/images/UpdateMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.67513                       |4.73851                       |1.78835                       |2.83599                       |
|50                            |0.88066                       |9.90781                       |3.55918                       |4.41454                       |
|100                           |2.05958                       |17.98052                      |6.30918                       |7.17731                       |
|250                           |5.51524                       |44.8828                       |14.46354                      |15.17969                      |
|500                           |13.43668                      |66.96298                      |30.80791                      |29.19095                      |
|1000                          |40.40333                      |132.72587                     |62.6407                       |55.84257                      |
|2500                          |93.55263                      |332.16088                     |158.11238                     |125.19935                     |
|5000                          |201.60227                     |687.81354                     |313.27882                     |236.8104                      |

**Source:** [ORMBenchmark.PerformanceTests.UpdateMany](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L94-L96)

## DeleteOne Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/DeleteOne-small-data-set.png) | ![](/Benchmarks/images/DeleteOne-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.24776                       |4.48338                       |2.83725                       |3.77990                       |
|50                            |4.68166                       |15.40654                      |12.00421                      |8.7653                        |
|100                           |9.23613                       |25.20727                      |22.40182                      |14.99505                      |
|250                           |21.88438                      |44.68992                      |50.91367                      |36.91218                      |
|500                           |41.95056                      |88.82418                      |83.65080                      |67.75671                      |
|1000                          |81.8679                       |178.23024                     |150.70473                     |119.77641                     |
|2500                          |211.13631                     |426.97543                     |364.46007                     |315.83966                     |
|5000                          |400.32042                     |803.48114                     |704.47928                     |592.44356                     |

**Source:** [ORMBenchmark.PerformanceTests.DeleteOne](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L99-L101)

## DeleteMany Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/DeleteMany-small-data-set.png) | ![](/Benchmarks/images/DeleteMany-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |1.63902                       |3.54475                       |1.73174                       |3.45339                       |
|50                            |0.62132                       |10.01454                      |3.35372                       |3.89208                       |
|100                           |2.62965                       |18.75259                      |5.63404                       |3.65203                       |
|250                           |9.22551                       |43.15788                      |11.6547                       |17.20724                      |
|500                           |11.18691                      |93.6943                       |19.12571                      |20.39139                      |
|1000                          |21.19079                      |234.38009                     |37.94742                      |28.40841                      |
|2500                          |17.59877                      |966.81329                     |88.41168                      |83.95296                      |
|5000                          |35.36605                      |3228.0457                     |185.26778                     |126.73919                     |

**Source:** [ORMBenchmark.PerformanceTests.DeleteMany](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L104-L106)

## Fetch Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/Fetch-small-data-set.png) | ![](/Benchmarks/images/Fetch-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.90886                       |5.67236                       |5.60735                       |1.87429                       |
|50                            |4.47919                       |25.124                        |24.98021                      |7.05659                       |
|100                           |8.93322                       |48.9807                       |46.39661                      |14.38778                      |
|250                           |23.11454                      |117.44157                     |115.99552                     |35.81668                      |
|500                           |51.05996                      |205.32002                     |222.18325                     |64.43542                      |
|1000                          |86.58939                      |418.41731                     |423.78128                     |122.07565                     |
|2500                          |207.06245                     |1014.68633                    |1072.88489                    |288.04551                     |
|5000                          |410.49743                     |2041.61321                    |2128.93713                    |577.46664                     |

**Source:** [ORMBenchmark.PerformanceTests.Fetch](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L109-L111)

## InstantiationNative Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/InstantiationNative-small-data-set.png) | ![](/Benchmarks/images/InstantiationNative-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.08274                       |0.10843                       |0.15383                       |0.10695                       |
|50                            |0.09914                       |0.13693                       |0.18174                       |0.14807                       |
|100                           |0.14106                       |0.16954                       |0.20961                       |0.20062                       |
|250                           |0.19200                       |0.27486                       |0.29884                       |0.31832                       |
|500                           |0.27972                       |0.38497                       |0.40195                       |0.54488                       |
|1000                          |0.45479                       |0.62806                       |0.60401                       |0.93781                       |
|2500                          |0.99552                       |1.25032                       |1.20355                       |2.16803                       |
|5000                          |1.73119                       |2.33282                       |2.18903                       |4.88613                       |

**Source:** [ORMBenchmark.PerformanceTests.InstantiationNative](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L119-L123)

## InstantiationLinq Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/InstantiationLinq-small-data-set.png) | ![](/Benchmarks/images/InstantiationLinq-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.08226                       |0.21443                       |0.20742                       |0.10513                       |
|50                            |0.10019                       |0.24132                       |0.24475                       |0.14001                       |
|100                           |0.13542                       |0.27474                       |0.28210                       |0.17991                       |
|250                           |0.24142                       |0.40475                       |0.36496                       |0.25428                       |
|500                           |0.31016                       |0.51607                       |0.49459                       |0.45063                       |
|1000                          |0.46126                       |0.75566                       |0.71189                       |0.71573                       |
|2500                          |0.95359                       |1.39289                       |1.29560                       |1.51533                       |
|5000                          |1.75222                       |2.53633                       |2.33187                       |3.04690                       |

**Source:** [ORMBenchmark.PerformanceTests.InstantiationLinq](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L126-L130)

## ProjectionLinq Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/ProjectionLinq-small-data-set.png) | ![](/Benchmarks/images/ProjectionLinq-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.08199                       |0.19312                       |0.17367                       |0.13509                       |
|50                            |0.09952                       |0.22451                       |0.20982                       |0.17371                       |
|100                           |0.12527                       |0.23613                       |0.22602                       |0.19704                       |
|250                           |0.19218                       |0.36316                       |0.31246                       |0.27900                       |
|500                           |0.28558                       |0.43731                       |0.42212                       |0.41303                       |
|1000                          |0.44190                       |0.61357                       |0.66012                       |0.62131                       |
|2500                          |0.96861                       |1.17181                       |1.16622                       |1.25247                       |
|5000                          |1.74565                       |1.93412                       |2.23250                       |2.35564                       |

**Source:** [ORMBenchmark.PerformanceTests.ProjectionLinq](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L161-L165)

## LinqQuery Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqQuery-small-data-set.png) | ![](/Benchmarks/images/LinqQuery-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.96154                       |5.74997                       |5.57862                       |2.69343                       |
|50                            |4.56479                       |27.57186                      |23.39864                      |9.60794                       |
|100                           |9.23555                       |48.93409                      |47.52729                      |19.55124                      |
|250                           |25.3233                       |121.40865                     |119.2011                      |44.76605                      |
|500                           |45.93122                      |208.16485                     |216.66931                     |80.8075                       |
|1000                          |86.69442                      |408.28955                     |423.03542                     |147.90912                     |
|2500                          |204.40069                     |1038.66237                    |1059.67875                    |354.92576                     |
|5000                          |421.59985                     |2079.50051                    |2121.066                      |703.97345                     |

**Source:** [ORMBenchmark.PerformanceTests.LinqQuery](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L114-L116)

## LinqTakeRecords10 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords10-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords10-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.11311                       |0.59438                       |0.55354                       |0.24966                       |
|50                            |0.53474                       |2.66097                       |2.55085                       |1.13569                       |
|100                           |1.06678                       |5.68929                       |5.19533                       |2.05470                       |
|250                           |2.49777                       |12.75142                      |12.93506                      |5.15059                       |
|500                           |4.72708                       |23.69013                      |23.67893                      |9.89882                       |
|1000                          |9.43008                       |44.70992                      |45.81382                      |16.53296                      |
|2500                          |22.84218                      |110.50101                     |109.30611                     |38.06061                      |
|5000                          |44.43986                      |220.31307                     |221.01861                     |74.47960                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords10](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L133-L137)

## LinqTakeRecords20 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords20-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords20-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.10401                       |0.55169                       |0.52017                       |0.21493                       |
|50                            |0.30935                       |1.62510                       |1.52193                       |0.66294                       |
|100                           |0.53483                       |2.53755                       |2.49644                       |1.11816                       |
|250                           |1.33332                       |6.00574                       |5.97640                       |2.52928                       |
|500                           |2.38558                       |11.79071                      |11.19163                      |3.95273                       |
|1000                          |4.72251                       |22.64017                      |22.42936                      |7.85263                       |
|2500                          |11.92171                      |56.08969                      |54.36159                      |19.62784                      |
|5000                          |23.46550                      |109.71432                     |112.85617                     |39.59147                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords20](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L140-L144)

## LinqTakeRecords50 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords50-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords50-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.10560                       |0.50777                       |0.51410                       |0.36572                       |
|50                            |0.13772                       |0.54572                       |0.54766                       |0.26556                       |
|100                           |0.24353                       |1.04939                       |1.08223                       |0.46748                       |
|250                           |0.62618                       |2.62470                       |2.53619                       |1.07339                       |
|500                           |1.16171                       |4.90092                       |4.68353                       |1.81717                       |
|1000                          |2.18842                       |9.35281                       |9.36434                       |3.72906                       |
|2500                          |5.89975                       |23.38099                      |23.36934                      |9.04641                       |
|5000                          |10.87480                      |45.91202                      |46.93824                      |17.64299                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords50](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L147-L151)

## LinqTakeRecords100 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/Benchmarks/images/LinqTakeRecords100-small-data-set.png) | ![](/Benchmarks/images/LinqTakeRecords100-large-data-set.png) |

|Row Count                     |Direct SQL Time (milliseconds)|EF 6.0.0 Time (milliseconds)  |EF Core 3.1.3 Time (milliseconds)|XPO 20.1.3 Time (milliseconds)|
|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|
|10                            |0.10512                       |0.53121                       |0.49123                       |0.18124                       |
|50                            |0.13604                       |0.54549                       |0.54017                       |0.25602                       |
|100                           |0.17324                       |0.60477                       |0.60097                       |0.31546                       |
|250                           |0.44693                       |1.56634                       |1.64345                       |0.79477                       |
|500                           |0.78249                       |2.84631                       |2.75256                       |1.22106                       |
|1000                          |1.34448                       |5.14260                       |5.06891                       |2.19576                       |
|2500                          |3.45998                       |12.94194                      |12.63784                      |5.32169                       |
|5000                          |6.67291                       |25.61892                      |25.24959                      |10.68485                      |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords100](/Benchmarks/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L154-L158)
