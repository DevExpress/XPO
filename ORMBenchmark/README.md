# .NET ORM Benchmark

This project is a [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)-based benchmark to test performance of the following Object-Relational Mapping (ORM) libraries under .NET  Framework 4.6.1 or newer:<br/>
 - [Entity Framework 6.0.2](https://docs.microsoft.com/en-us/ef/ef6/) (EF 6).<br/>
 - [Entity Framework Core 2.0.3](https://docs.microsoft.com/en-us/ef/core/) (EF Core);<br/>
 - [eXpressPersistent Objects™ 18.1.3](https://www.devexpress.com/Products/NET/ORM/) (XPO);<br/>
 
You can run this benchmark or review our results below (obtained with Microsoft SQL Server 2016 Developer Edition). In all charts, the less execution time is better.<br/>
[DevExpress.Xpo](https://www.nuget.org/packages/DevExpress.Xpo/) and other libraries will automatically be restored from Nuget. Edit the connection string in the [App.config](/ORMBenchmark/ORMBenchmark/App.config) file, update the ORM library and target framework versions, if required. Make data model and test case modifications to compare the speed in more scenarios.

## InsertOne Method

|               Small Data Set               |               Large Data Set               |
| ------------------------------------------ | ------------------------------------------ |
| ![](/images/insert-one-small-data-set.png) | ![](/images/insert-one-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 3.9382                   | 3.3298                      | 2.4337                  |
| 50        | 14.6122                  | 9.9241                      | 7.961                   |
| 100       | 30.0346                  | 23.5893                     | 13.6619                 |
| 250       | 86.9598                  | 80.8544                     | 29.8041                 |
| 500       | 207.0142                 | 233.2644                    | 60.8275                 |
| 1000      | 657.1523                 | 757.5676                    | 114.1055                |
| 2500      | 2946.7336                | 3767.6394                   | 276.5439                |
| 5000      | 10489.3505               | 13635.1981                  | 559.1924                |

**Source:** [ORMBenchmark.PerformanceTests.InsertOne](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L80-L82)

## InsertMultipleTest Method

|                 Small Data Set                  |                 Large Data Set                  |
| ----------------------------------------------- | ----------------------------------------------- |
| ![](/images/insert-multiple-small-data-set.png) | ![](/images/insert-multiple-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 2.9822                   | 1.2062                      | 4.3964                  |
| 50        | 9.1273                   | 2.0758                      | 4.7409                  |
| 100       | 15.6442                  | 3.107                       | 5.5234                  |
| 250       | 39.9253                  | 7.663                       | 12.534                  |
| 500       | 100.9607                 | 22.4626                     | 27.1542                 |
| 1000      | 262.3986                 | 67.6117                     | 55.2255                 |
| 2500      | 1079.3681                | 120.0971                    | 131.7559                |
| 5000      | 3608.7683                | 324.4928                    | 257.4605                |

**Source:** [ORMBenchmark.PerformanceTests.InsertMultipleTest](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L85-L87)

## UpdateOne Method

|               Small Data Set               |               Large Data Set               |
| ------------------------------------------ | ------------------------------------------ |
| ![](/images/update-one-small-data-set.png) | ![](/images/update-one-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 5.0205                   | 4.1716                      | 3.6902                  |
| 50        | 14.3803                  | 13.4512                     | 7.3203                  |
| 100       | 25.5959                  | 21.5953                     | 13.1188                 |
| 250       | 76.7652                  | 81.8542                     | 32.9867                 |
| 500       | 155.5194                 | 230.2918                    | 60.0551                 |
| 1000      | 489.3557                 | 698.2416                    | 104.9284                |
| 2500      | 2065.208                 | 3641.5042                   | 276.7798                |
| 5000      | 6852.2317                | 13509.5648                  | 558.4519                |

**Source:** [ORMBenchmark.PerformanceTests.UpdateOne](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L90-L92)

## UpdateMany Method

|               Small Data Set                |               Large Data Set                |
| ------------------------------------------- | ------------------------------------------- |
| ![](/images/update-many-small-data-set.png) | ![](/images/update-many-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 4.5549                   | 1.7673                      | 2.848                   |
| 50        | 9.1566                   | 2.7045                      | 4.1651                  |
| 100       | 14.9063                  | 4.1086                      | 6.2059                  |
| 250       | 30.7312                  | 9.1547                      | 13.8675                 |
| 500       | 62.102                   | 20.4484                     | 24.0208                 |
| 1000      | 126.9863                 | 55.2733                     | 44.8094                 |
| 2500      | 285.8227                 | 134.0106                    | 100.6008                |
| 5000      | 595.8876                 | 288.1156                    | 215.934                 |

**Source:** [ORMBenchmark.PerformanceTests.UpdateMany](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L95-L97)

## DeleteOne Method

|               Small Data Set               |               Large Data Set               |
| ------------------------------------------ | ------------------------------------------ |
| ![](/images/delete-one-small-data-set.png) | ![](/images/delete-one-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 4.0865                   | 3.7222                      | 2.9033                  |
| 50        | 13.9419                  | 10.5571                     | 6.8001                  |
| 100       | 23.8072                  | 17.9904                     | 14.2565                 |
| 250       | 46.3954                  | 37.3269                     | 27.5609                 |
| 500       | 91.2732                  | 67.6574                     | 57.8433                 |
| 1000      | 176.993                  | 136.2269                    | 101.0835                |
| 2500      | 433.5055                 | 337.3731                    | 250.5759                |
| 5000      | 867.4947                 | 690.0046                    | 541.7737                |

**Source:** [ORMBenchmark.PerformanceTests.DeleteOne](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L100-L102)

## DeleteMany Method
|               Small Data Set                |               Large Data Set                |
| ------------------------------------------- | ------------------------------------------- |
| ![](/images/delete-many-small-data-set.png) | ![](/images/delete-many-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 3.2466                   | 1.6439                      | 3.1682                  |
| 50        | 8.2793                   | 3.76                        | 3.4945                  |
| 100       | 18.1323                  | 8.3318                      | 3.5705                  |
| 250       | 42.6913                  | 36.4001                     | 5.8754                  |
| 500       | 97.2695                  | 125.7598                    | 9.4139                  |
| 1000      | 242.7894                 | 485.6754                    | 17.3806                 |
| 2500      | 1093.5522                | 2907.4599                   | 43.451                  |
| 5000      | 3855.8465                | 11422.7909                  | 77.3494                 |

**Source:** [ORMBenchmark.PerformanceTests.DeleteMany](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L105-L107)

## Fetch Method

|            Small Data Set             |            Large Data Set             |
| ------------------------------------- | ------------------------------------- |
| ![](/images/fetch-small-data-set.png) | ![](/images/fetch-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 4.8702                   | 2.9209                      | 2.4647                  |
| 50        | 20.8901                  | 12.3265                     | 8.0935                  |
| 100       | 39.8897                  | 18.681                      | 13.8328                 |
| 250       | 98.8093                  | 47.3867                     | 26.2636                 |
| 500       | 172.5827                 | 84.1566                     | 48.8763                 |
| 1000      | 410.2621                 | 159.602                     | 104.7498                |
| 2500      | 1020.3816                | 399.4074                    | 231.4023                |
| 5000      | 1906.1384                | 854.3664                    | 473.8172                |

**Source:** [ORMBenchmark.PerformanceTests.Fetch](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L110-L112)

## ObjectInstantiationNative Method

|                       Small Data Set                        |                       Large Data Set                        |
| ----------------------------------------------------------- | ----------------------------------------------------------- |
| ![](/images/object-instantiation-native-small-data-set.png) | ![](/images/object-instantiation-native-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 0.486                    | 0.5719                      | 0.3663                  |
| 50        | 0.5896                   | 0.6425                      | 0.439                   |
| 100       | 0.7313                   | 0.7578                      | 0.5382                  |
| 250       | 1.1555                   | 0.9473                      | 0.7949                  |
| 500       | 1.8038                   | 1.5018                      | 1.2471                  |
| 1000      | 2.9142                   | 2.291                       | 1.9856                  |
| 2500      | 6.2002                   | 4.5225                      | 4.1095                  |
| 5000      | 11.6849                  | 7.9922                      | 7.8626                  |

**Source:** [ORMBenchmark.PerformanceTests.ObjectInstantiationNative](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L120-L122)

## ObjectInstantiationLinq Method

|                      Small Data Set                       |                      Large Data Set                       |
| --------------------------------------------------------- | --------------------------------------------------------- |
| ![](/images/object-instantiation-linq-small-data-set.png) | ![](/images/object-instantiation-linq-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 1.7591                   | 1.752                       | 1.439                   |
| 50        | 0.8033                   | 0.7674                      | 0.445                   |
| 100       | 0.9229                   | 0.8761                      | 0.5366                  |
| 250       | 1.372                    | 1.1581                      | 0.7505                  |
| 500       | 2.0324                   | 1.6075                      | 1.1984                  |
| 1000      | 3.347                    | 2.4348                      | 1.7224                  |
| 2500      | 6.4652                   | 4.643                       | 3.817                   |
| 5000      | 11.8997                  | 7.9856                      | 7.2002                  |

**Source:** [ORMBenchmark.PerformanceTests.ObjectInstantiationLinq](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L125-L127)

## LinqQuery Method

|               Small Data Set               |                 Large Data Set                 |
| ------------------------------------------ | ---------------------------------------------- |
| ![](/images/linq-query-small-data-set.png) | ![](/images/linq-query-one-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 4.7457                   | 3.2509                      | 3.1598                  |
| 50        | 20.4839                  | 13.6501                     | 10.6826                 |
| 100       | 36.4223                  | 23.488                      | 17.0221                 |
| 250       | 85.4996                  | 46.3846                     | 37.7991                 |
| 500       | 201.4913                 | 81.8806                     | 65.5507                 |
| 1000      | 391.1011                 | 176.7632                    | 139.1455                |
| 2500      | 976.2392                 | 400.6309                    | 313.9293                |
| 5000      | 1723.1451                | 840.3734                    | 614.4659                |

**Source:** [ORMBenchmark.PerformanceTests.LinqQuery](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L115-L117)

## LinqTakeRecords10 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/linq-take-records-10-small-data-set.png) | ![](/images/linq-take-records-10-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 0.9054                   | 0.708                       | 0.4872                  |
| 50        | 2.819                    | 2.0338                      | 1.501                   |
| 100       | 5.4689                   | 3.7253                      | 2.7275                  |
| 250       | 12.1403                  | 8.0404                      | 6.4743                  |
| 500       | 22.8718                  | 16.2112                     | 12.2565                 |
| 1000      | 50.1689                  | 29.3617                     | 17.8815                 |
| 2500      | 120.7593                 | 65.0304                     | 41.3023                 |
| 5000      | 248.3594                 | 105.6765                    | 85.9597                 |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords10](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L130-L132)

## LinqTakeRecords20 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/linq-take-records-20-small-data-set.png) | ![](/images/linq-take-records-20-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 1.963                    | 1.7181                      | 1.5677                  |
| 50        | 3.1089                   | 1.6458                      | 2.0996                  |
| 100       | 3.1757                   | 2.1766                      | 1.7335                  |
| 250       | 7.2603                   | 4.8143                      | 3.7614                  |
| 500       | 12.862                   | 8.7951                      | 6.903                   |
| 1000      | 24.1678                  | 17.7842                     | 13.1497                 |
| 2500      | 62.2069                  | 38.8549                     | 24.8243                 |
| 5000      | 118.6731                 | 76.5116                     | 53.0361                 |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords20](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L135-L137)

## LinqTakeRecords50 Method

|                    Small Data Set                    |                    Large Data Set                    |
| ---------------------------------------------------- | ---------------------------------------------------- |
| ![](/images/linq-take-records-50-small-data-set.png) | ![](/images/linq-take-records-50-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 1.9604                   | 1.7528                      | 1.5514                  |
| 50        | 1.0316                   | 0.7783                      | 0.5729                  |
| 100       | 1.6568                   | 1.2202                      | 0.8686                  |
| 250       | 3.4619                   | 2.4293                      | 1.9379                  |
| 500       | 6.3305                   | 4.6616                      | 3.5355                  |
| 1000      | 11.9937                  | 8.4885                      | 6.6637                  |
| 2500      | 28.5058                  | 20.0323                     | 15.9553                 |
| 5000      | 58.4292                  | 33.468                      | 26.9299                 |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords50](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L140-L142)

## LinqTakeRecords100 Method

|                    Small Data Set                     |                    Large Data Set                     |
| ----------------------------------------------------- | ----------------------------------------------------- |
| ![](/images/linq-take-records-100-small-data-set.png) | ![](/images/linq-take-records-100-large-data-set.png) |

| Row Count | EF 6 Time (milliseconds) | EF Core Time (milliseconds) | XPO Time (milliseconds) |
| --------- | ------------------------ | --------------------------- | ----------------------- |
| 10        | 2.039                    | 0.7473                      | 1.5969                  |
| 50        | 1.2159                   | 0.7814                      | 0.7773                  |
| 100       | 1.188                    | 0.8686                      | 0.7244                  |
| 250       | 2.4994                   | 1.794                       | 1.4603                  |
| 500       | 4.1542                   | 2.944                       | 2.4636                  |
| 1000      | 7.881                    | 5.4638                      | 4.8496                  |
| 2500      | 17.8307                  | 12.0658                     | 11.6377                 |
| 5000      | 38.7205                  | 26.1791                     | 21.7918                 |

**Source:** [ORMBenchmark.PerformanceTests.LinqTakeRecords100](/ORMBenchmark/ORMBenchmark/PerformanceTests/PerformanceTestSet.cs#L145-L147)
