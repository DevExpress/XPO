using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo.Demo.Entities;

namespace DevExpress.Xpo.Demo.Core
{
    public static class XpoHelper {
        static readonly Type[] entityTypes = new Type[] {
            typeof(User)
        };
        public static void InitXpo(string connectionString) {
            var dictionary = PrepareDictionary();

            using(var updateDataLayer = XpoDefault.GetDataLayer(connectionString, dictionary, AutoCreateOption.DatabaseAndSchema)) {
                updateDataLayer.UpdateSchema(false, dictionary.CollectClassInfos(entityTypes));
            }

            string pooledConnectionString = XpoDefault.GetConnectionPoolString(connectionString);
            var dataStore = XpoDefault.GetConnectionProvider(pooledConnectionString, AutoCreateOption.SchemaAlreadyExists);
            XpoDefault.DataLayer = new ThreadSafeDataLayer(dictionary, dataStore);
            XpoDefault.Session = null;

            CreateDemoData();
        }
        public static UnitOfWork CreateUnitOfWork() {
            return new UnitOfWork();
        }
        static XPDictionary PrepareDictionary() {
            var dict = new ReflectionDictionary();
            dict.GetDataStoreSchema(entityTypes);
            return dict;
        }

        static readonly string[][] demoData = new string[][]{
            new string[] { "Amelia", "Harper", "ameliah@dx-email.com" },
            new string[] { "Lincoln", "Bartlett", "lincolnb@dx-email.com" },
            new string[] { "Samantha", "Bright", "samanthab@dx-email.com" },
            new string[] { "David", "Jones", "davidj@dx-email.com" },
            new string[] { "Kelly", "Rodriguez", "kellyr@dx-email.com" },
            new string[] { "Bart", "Arnaz", "barta@dx-email.com" },
            new string[] { "Jennifer", "Hobbs", "jennyh@dx-email.com" },
            new string[] { "Stu", "Pizaro", "stu@dx-email.com" },
            new string[] { "Bartolomeo", "Pizaro", "bartop@dx-email.com" },
        };
        static void CreateDemoData() {
            using(var uow = CreateUnitOfWork()) {
                if(!uow.Query<User>().Any()) {
                    foreach(var row in demoData) {
                        var newUser = new User(uow) {
                            FirstName = row[0],
                            LastName = row[1],
                            Email = row[2]
                        };
                    }
                    uow.CommitChanges();
                }
            }
        }
    }
}