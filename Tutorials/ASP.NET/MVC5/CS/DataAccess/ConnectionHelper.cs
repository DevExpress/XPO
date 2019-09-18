using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System;
using System.Configuration;

namespace XpoTutorial {
    public static class ConnectionHelper {

        static readonly Type[] PersistentTypes = new Type[]{
            typeof(Order),
            typeof(Customer)
        };

        public static void Connect(bool threadSafe = true) {
            XpoDefault.DataLayer = CreateDataLayer(threadSafe);
        }

        static IDataLayer CreateDataLayer(bool threadSafe) {
            string connStr = ConfigurationManager.ConnectionStrings["XpoTutorial"].ConnectionString;
            //connStr = XpoDefault.GetConnectionPoolString(connStr);  // Uncomment this line if you use a database server like SQL Server, Oracle, PostgreSql etc.
            ReflectionDictionary dictionary = new ReflectionDictionary();
            dictionary.GetDataStoreSchema(PersistentTypes);   // Pass all of your persistent object types to this method.
            AutoCreateOption autoCreateOption = AutoCreateOption.DatabaseAndSchema;  // Use AutoCreateOption.DatabaseAndSchema if the database or tables does not exists. Use AutoCreateOption.SchemaAlreadyExists if the database already exists.
            IDataStore provider = XpoDefault.GetConnectionProvider(connStr, autoCreateOption);
            return threadSafe ? (IDataLayer)new ThreadSafeDataLayer(dictionary, provider) : new SimpleDataLayer(dictionary, provider);
        }
    }
}
