using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ORMBenchmark.Models.DirectSQL;

namespace ORMBenchmark.PerformanceTests {

    public class DirectSQLTestProvider : TestProviderBase {
        private SqlConnection connection;

        public override string ToString() {
            return "Direct SQL";
        }

        public override void CreateTestDataSet(int recordsCount) {
            CleanupTestDataSet();
            using(SqlConnection conn = CreateSqlConnection()) {
                using(SqlCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = "insert into Entities (Id, Value) values (@Id, @Value)";
                    for(int i = 0; i < recordsCount; i++) {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("Id", i);
                        cmd.Parameters.AddWithValue("Value", i);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            RecordsCount = recordsCount;
        }

        public override void CleanupTestDataSet() {
            using(SqlConnection conn = CreateSqlConnection()) {
                using(SqlCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = "delete from Entities";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void InitSession() {
            connection = CreateSqlConnection();
        }

        public override void TearDownSession() {
            if(connection != null) {
                connection.Dispose();
                connection = null;
            }
        }

        SqlConnection CreateSqlConnection() {
            string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connstr);
            sqlConnection.Open();
            return sqlConnection;
        }

        public override void InsertOne(int recordsCount) {
            using(SqlTransaction transaction = connection.BeginTransaction()) {
                using(SqlCommand cmd = connection.CreateCommand()) {
                    cmd.Transaction = transaction;
                    cmd.CommandText = "insert into Entities (Id, Value) values (@Id, @Value)";
                    for(int i = 0; i < recordsCount; i++) {
                        cmd.Parameters.Clear();
                        SqlParameter param1 = new SqlParameter("Id", SqlDbType.BigInt);
                        SqlParameter param2 = new SqlParameter("Value", SqlDbType.BigInt);
                        param1.Value = i;
                        param2.Value = i;
                        cmd.Parameters.Add(param1);
                        cmd.Parameters.Add(param2);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        public override void InsertMany(int recordsCount) {
            const int batchSize = 1000;
            using(SqlTransaction transaction = connection.BeginTransaction()) {
                using(SqlCommand cmd = connection.CreateCommand()) {
                    cmd.Transaction = transaction;
                    for(int i = 0; i < recordsCount; i += batchSize) {
                        cmd.Parameters.Clear();
                        StringBuilder sb = new StringBuilder();
                        for(int j = i; j < recordsCount && j < i + batchSize; j++) {
                            SqlParameter param1 = new SqlParameter(string.Concat("p", (j * 2).ToString()), SqlDbType.BigInt);
                            SqlParameter param2 = new SqlParameter(string.Concat("p", (j * 2 + 1).ToString()), SqlDbType.BigInt);
                            param1.Value = j;
                            param2.Value = j;
                            cmd.Parameters.Add(param1);
                            cmd.Parameters.Add(param2);
                            if(j != i) {
                                sb.Append(",");
                            }
                            sb.Append(string.Concat("(@", param1.ParameterName, ", @", param2.ParameterName, ")"));
                        }
                        cmd.CommandText = "insert into Entities (Id, Value) values " + sb.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
            }
        }

        public override void UpdateOne() {
            using(SqlTransaction transaction = connection.BeginTransaction()) {
                using(SqlCommand readCmd = connection.CreateCommand()) {
                    readCmd.Transaction = transaction;
                    readCmd.CommandText = "select Id from Entities";
                    using(SqlDataReader rdr = readCmd.ExecuteReader(CommandBehavior.SequentialAccess)) {
                        using(SqlCommand updateCmd = connection.CreateCommand()) {
                            updateCmd.Transaction = transaction;
                            updateCmd.CommandText = "update Entities set Value = Value + 1 where Id = @Id";
                            while(rdr.Read()) {
                                long id = (long)rdr["Id"];
                                updateCmd.Parameters.Clear();
                                SqlParameter param = new SqlParameter("Id", SqlDbType.BigInt);
                                param.Value = id;
                                updateCmd.Parameters.Add(param);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        public override void UpdateMany() {
            const int batchSize = 1000;
            using(SqlTransaction transaction = connection.BeginTransaction()) {
                using(SqlCommand cmd = connection.CreateCommand()) {
                    cmd.Transaction = transaction;
                    cmd.CommandText = "select Id, Value from Entities";
                    List<long> ids = new List<long>();
                    List<long> values = new List<long>();
                    using(SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess)) {
                        while(rdr.Read()) {
                            ids.Add((long)rdr["Id"]);
                            values.Add((long)rdr["Value"]);
                        }
                    }
                    for(int i = 0; i < ids.Count; i += batchSize) {
                        cmd.Parameters.Clear();
                        StringBuilder sb = new StringBuilder();
                        for(int j = i; j < i + batchSize && j < ids.Count; j++) {
                            SqlParameter param1 = new SqlParameter(string.Concat("p", (j * 2).ToString()), SqlDbType.BigInt);
                            SqlParameter param2 = new SqlParameter(string.Concat("p", (j * 2 + 1).ToString()), SqlDbType.BigInt);
                            param1.Value = ids[j];
                            param2.Value = values[j] + 1;
                            cmd.Parameters.Add(param1);
                            cmd.Parameters.Add(param2);
                            sb.Append(string.Concat("update Entities set Value = @", param2.ParameterName, " where Id = @", param1.ParameterName, ";"));
                        }
                        cmd.CommandText = sb.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
            }
        }

        public override void DeleteOne() {
            using(SqlTransaction transaction = connection.BeginTransaction()) {
                using(SqlCommand readCmd = connection.CreateCommand()) {
                    readCmd.Transaction = transaction;
                    readCmd.CommandText = "select Id from Entities";
                    using(SqlDataReader rdr = readCmd.ExecuteReader(CommandBehavior.SequentialAccess)) {
                        using(SqlCommand deleteCmd = connection.CreateCommand()) {
                            deleteCmd.Transaction = transaction;
                            deleteCmd.CommandText = "delete from Entities where Id = @Id";
                            while(rdr.Read()) {
                                long id = (long)rdr["Id"];
                                deleteCmd.Parameters.Clear();
                                SqlParameter param = new SqlParameter("Id", SqlDbType.BigInt);
                                param.Value = id;
                                deleteCmd.Parameters.Add(param);
                                deleteCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        public override void DeleteMany() {
            const int batchSize = 50;
            using(SqlCommand cmd = connection.CreateCommand()) {
                cmd.CommandText = "select Id from Entities";
                List<long> ids = new List<long>();
                using(SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess)) {
                    while(rdr.Read()) {
                        ids.Add((long)rdr["Id"]);
                    }
                }
                using(SqlTransaction transaction = connection.BeginTransaction()) {
                    cmd.Transaction = transaction;
                    for(int i = 0; i < ids.Count; i += batchSize) {
                        cmd.Parameters.Clear();
                        StringBuilder sb = new StringBuilder();
                        for(int j = i; j < i + batchSize && j < ids.Count; j++) {
                            SqlParameter param1 = new SqlParameter(string.Concat("p", j.ToString()), SqlDbType.BigInt);
                            param1.Value = ids[j];
                            if(cmd.Parameters.Count > 0) {
                                sb.Append(",");
                            }
                            sb.Append(string.Concat("@", param1.ParameterName));
                            cmd.Parameters.Add(param1);
                        }
                        cmd.CommandText = string.Concat("delete from Entities where Id in (", sb.ToString(), ")");
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        public override void Fetch() {
            using(SqlCommand cmd = connection.CreateCommand()) {
                cmd.CommandText = "select Id, Value from Entities where Id = @Id";
                for(int i = 0; i < RecordsCount; i++) {
                    cmd.Parameters.Clear();
                    SqlParameter param = new SqlParameter("Id", SqlDbType.BigInt);
                    param.Value = i;
                    cmd.Parameters.Add(param);
                    using(SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess)) {
                        rdr.Read();
                        Entity item = new Entity() {
                            Id = (long)rdr["Id"],
                            Value = (long)rdr["Value"]
                        };
                    }
                }
            }
        }

        public override void LinqQuery() {
            Fetch();
        }

        public override void InstantiationNative() {
            using(SqlCommand cmd = connection.CreateCommand()) {
                cmd.CommandText = "select Id, Value from Entities";
                using(SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess)) {
                    while(rdr.Read()) {
                        var item = new Entity {
                            Id = (long)rdr["Id"],
                            Value = (long)rdr["Value"]
                        };
                    }
                }
            }
        }

        public override void InstantiationLinq() {
            InstantiationNative();
        }

        protected override void LinqTakeRecords(int takeRecords) {
            using(SqlCommand cmd = connection.CreateCommand()) {
                cmd.CommandText = string.Format("select top {0} Id, Value from Entities where Id >= @i", takeRecords);
                for(int i = 0; i < RecordsCount; i += takeRecords) {
                    cmd.Parameters.Clear();
                    SqlParameter param = new SqlParameter("i", SqlDbType.BigInt);
                    param.Value = i;
                    cmd.Parameters.Add(param);
                    using(SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess)) {
                        while(rdr.Read()) {
                            Entity item = new Entity() {
                                Id = (long)rdr["Id"],
                                Value = (long)rdr["Value"]
                            };
                        }
                    }
                }
            }
        }

        public override void ProjectionLinq() {
            using(SqlCommand cmd = connection.CreateCommand()) {
                cmd.CommandText = "select Id, Value from Entities";
                using(SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess)) {
                    while(rdr.Read()) {
                        var item = new {
                            Id = (long)rdr["Id"],
                            Value = (long)rdr["Value"]
                        };
                    }
                }
            }
        }
    }
}
