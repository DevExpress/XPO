using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiApplication.Helpers {
    public static class ApplicationBuilderExtensions {
        public static IApplicationBuilder UseXpoDemoData(this IApplicationBuilder app) {
            IDataStore dataStore = app.ApplicationServices.GetService<IDataStore>();
            IDictionary<string, DBTable> schema = CreateSchema(dataStore);
            CreateData(dataStore, schema);
            return app;
        }
        static IDictionary<string, DBTable> CreateSchema(IDataStore dataStore) {
            DBTable customer = CreateTable("Customer");
            customer.AddColumn(new DBColumn("FirstName", false, null, SizeAttribute.DefaultStringMappingFieldSize, DBColumnType.String));
            customer.AddColumn(new DBColumn("LastName", false, null, SizeAttribute.DefaultStringMappingFieldSize, DBColumnType.String));
            DBTable order = CreateTable("Order");
            order.AddColumn(new DBColumn("ProductName", false, null, 200, DBColumnType.String));
            order.AddColumn(new DBColumn("OrderDate", false, null, 0, DBColumnType.DateTime));
            order.AddColumn(new DBColumn("Freight", false, null, 0, DBColumnType.Decimal));
            order.AddColumn(new DBColumn("Customer", false, null, 0, DBColumnType.Int32));
            order.AddForeignKey(new DBForeignKey(new StringCollection() { "Customer" }, "Customer", new StringCollection() { "OID" }));
            DBTable objectType = new DBTable("XPObjectType");
            objectType.AddColumn(new DBColumn("OID", true, null, 0, DBColumnType.Int32) { IsIdentity = true });
            objectType.AddColumn(new DBColumn("TypeName", false, null, 254, DBColumnType.String));
            objectType.AddColumn(new DBColumn("AssemblyName", false, null, 154, DBColumnType.String));
            objectType.AddIndex(new DBIndex(new StringCollection() { "TypeName" }, true));
            objectType.PrimaryKey = new DBPrimaryKey(new StringCollection() { "OID" });
            dataStore.UpdateSchema(false, customer, order, objectType);
            return new Dictionary<string, DBTable>() {
                { "Customer", customer },
                { "Order", order }
            };
        }
        static DBTable CreateTable(string name) {
            DBTable table = new DBTable(name);
            table.AddColumn(new DBColumn("OID", true, null, 0, DBColumnType.Int32) { IsIdentity = true });
            table.AddColumn(new DBColumn("OptimisticLockField", false, null, 0, DBColumnType.Int32));
            table.AddColumn(new DBColumn("GCRecord", false, null, 0, DBColumnType.Int32));
            table.PrimaryKey = new DBPrimaryKey(new StringCollection() { "OID" });
            return table;
        }
        static void CreateData(IDataStore dataStore, IDictionary<string, DBTable> tables) {
            if(IsEmpty(dataStore, tables["Customer"])) {
                ParameterValue[] identities = CreateCustomers(dataStore, tables["Customer"]);
                CreateOrders(dataStore, tables["Order"], identities);
            }
        }
        static bool IsEmpty(IDataStore dataStore, DBTable table) {
            SelectStatement select = new SelectStatement(table, "N0") {
                Condition = new QueryOperand("GCRecord", "N0", DBColumnType.Int32).IsNull(),
                TopSelectedRecords = 1
            };
            select.Operands.AddRange(new[] { new QuerySubQueryContainer(null, null, Aggregate.Count) });
            SelectedData data = dataStore.SelectData(select);
            int cnt = (int)data.ResultSet[0].Rows[0].Values[0];
            return cnt == 0;
        }
        static ParameterValue[] CreateCustomers(IDataStore dataStore, DBTable table) {
            int combinationsNum = firstNames.Length * lastNames.Length;
            var names = new (string FirstName, string LastName)[combinationsNum];
            for(int i = 0; i < combinationsNum; i++) {
                int j = Random.Next(i + 1);
                names[i] = names[j];
                names[j] = (firstNames[i / lastNames.Length], lastNames[i % lastNames.Length]);
            }
            ModificationStatement[] dmlStatements = new ModificationStatement[names.Length];
            int tag = 0;
            for(int i = 0; i < names.Length; i++) {
                var name = names[i];
                InsertStatement stmt = CreateInsertStatement(table, tag++, tag++, tag++);
                stmt.Operands.AddRange(new[] {
                    new QueryOperand("FirstName", null, DBColumnType.String),
                    new QueryOperand("LastName", null, DBColumnType.String),
                });
                stmt.Parameters.AddRange(new[] {
                    CreateParameter(tag++, name.FirstName),
                    CreateParameter(tag++, name.LastName)
                });
                dmlStatements[i] = stmt;
            }
            return dataStore.ModifyData(dmlStatements).Identities;
        }
        static void CreateOrders(IDataStore dataStore, DBTable table, ParameterValue[] identities) {
            int combinationsNum = identities.Length * 10;
            ModificationStatement[] dmlStatements = new ModificationStatement[combinationsNum];
            int tag = 0;
            for(int i = 0; i < combinationsNum; i++) {
                InsertStatement stmt = CreateInsertStatement(table, tag++, tag++, tag++);
                stmt.Operands.AddRange(new[] {
                    new QueryOperand("ProductName", null, DBColumnType.String),
                    new QueryOperand("OrderDate", null, DBColumnType.DateTime),
                    new QueryOperand("Freight", null, DBColumnType.Decimal),
                    new QueryOperand("Customer", null, DBColumnType.Int32)
                });
                stmt.Parameters.AddRange(new[] {
                    CreateParameter(tag++, DBColumnType.String, 200, productNames[Random.Next(productNames.Length)]),
                    CreateParameter(tag++, DBColumnType.DateTime, new DateTime(Random.Next(2014, 2024), Random.Next(1, 12), Random.Next(1, 28))),
                    CreateParameter(tag++, DBColumnType.Decimal, Random.Next(1000) / 100m),
                    CreateParameter(tag++, DBColumnType.Int32, identities[Random.Next(identities.Length)].Value)
                });
                dmlStatements[i] = stmt;
            }
            dataStore.ModifyData(dmlStatements);
        }
        static InsertStatement CreateInsertStatement(DBTable table, int identityTag, int optimisticLockFieldTag, int gcRecordTag) {
            InsertStatement stmt = new InsertStatement(table, null) {
                IdentityColumn = "OID",
                IdentityColumnType = DBColumnType.Int32,
                IdentityParameter = new ParameterValue(identityTag) {
                    DBType = DBColumnType.Int32
                }
            };
            stmt.Operands.AddRange(new[] {
                new QueryOperand("OptimisticLockField", null, DBColumnType.Int32),
                new QueryOperand("GCRecord", null, DBColumnType.Int32)
            });
            stmt.Parameters.AddRange(new[] {
                new ParameterValue(optimisticLockFieldTag) { DBType = DBColumnType.Int32, Value = 0 },
                new ParameterValue(gcRecordTag) { DBType = DBColumnType.Int32 }
            });
            return stmt;
        }
        static ParameterValue CreateParameter(int tag, DBColumnType type, int size, object value) {
            return new ParameterValue(tag) { DBType = type, Size = size, Value = value };
        }
        static ParameterValue CreateParameter(int tag, DBColumnType type, object value) {
            return CreateParameter(tag, type, 0, value);
        }
        static ParameterValue CreateParameter(int tag, string value) {
            return CreateParameter(tag, DBColumnType.String, SizeAttribute.DefaultStringMappingFieldSize, value);
        }
        private static readonly string[] firstNames = new string[] {
            "Peter", "Ryan", "Richard", "Tom", "Mark", "Steve",
            "Jimmy", "Jeffrey", "Andrew", "Dave", "Bert", "Mike",
            "Ray", "Paul", "Brad", "Carl", "Jerry" };
        private static readonly string[] lastNames = new string[] {
            "Dolan", "Fischer", "Hamlett", "Hamilton", "Lee",
            "Lewis", "McClain", "Miller", "Murrel", "Parkins",
            "Roller", "Shipman", "Bailey", "Barnes", "Lucas", "Campbell" };
        private static readonly string[] productNames = new string[] {
            "Chai", "Chang", "Aniseed Syrup", "Chef Anton's Cajun Seasoning",
            "Chef Anton's Gumbo Mix", "Grandma's Boysenberry Spread",
            "Uncle Bob's Organic Dried Pears", "Northwoods Cranberry Sauce",
            "Mishi Kobe Niku", "Ikura", "Queso Cabrales", "Queso Manchego La Pastora",
            "Konbu", "Tofu", "Genen Shouyu", "Pavlova", "Alice Mutton",
            "Carnarvon Tigers", "Teatime Chocolate Biscuits",
            "Sir Rodney's Marmalade", "Sir Rodney's Scones",
            "Gustaf's Knäckebröd", "Tunnbröd", "Guaraná Fantástica",
            "NuNuCa Nuß-Nougat-Creme", "Gumbär Gummibärchen",
            "Schoggi Schokolade", "Rössle Sauerkraut", "Thüringer Rostbratwurst",
            "Nord-Ost Matjeshering", "Gorgonzola Telino", "Mascarpone Fabioli",
            "Geitost", "Sasquatch Ale", "Steeleye Stout", "Inlagd Sill",
            "Gravad lax", "Côte de Blaye", "Chartreuse verte",
            "Boston Crab Meat", "Jack's New England Clam Chowder",
            "Singaporean Hokkien Fried Mee", "Ipoh Coffee",
            "Gula Malacca", "Rogede sild", "Spegesild", "Zaanse koeken",
            "Chocolade", "Maxilaku", "Valkoinen suklaa", "Manjimup Dried Apples",
            "Filo Mix", "Perth Pasties", "Tourtière", "Pâté chinois",
            "Gnocchi di nonna Alice", "Ravioli Angelo", "Escargots de Bourgogne",
            "Raclette Courdavault", "Camembert Pierrot", "Sirop d'érable",
            "Tarte au sucre", "Vegie-spread", "Wimmers gute Semmelknödel",
            "Louisiana Fiery Hot Pepper Sauce", "Louisiana Hot Spiced Okra",
            "Laughing Lumberjack Lager", "Scottish Longbreads",
            "Gudbrandsdalsost", "Outback Lager", "Flotemysost",
            "Mozzarella di Giovanni", "Röd Kaviar", "Longlife Tofu",
            "Rhönbräu Klosterbier", "Lakkalikööri", "Original Frankfurter grüne Soße" };
        private static readonly Random Random = new Random(0);

    }
}
