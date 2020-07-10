using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System;
using System.Linq;
using XamarinFormsDemo.Models;

namespace XamarinFormsDemo {
    public static class XpoHelper {
        static readonly Type[] entityTypes = new Type[] {
            typeof(Item)
        };
        public static void InitXpo(string connectionString) {
            var dictionary = PrepareDictionary();

            if(XpoDefault.DataLayer == null) {
                using(var updateDataLayer = XpoDefault.GetDataLayer(connectionString, dictionary, AutoCreateOption.DatabaseAndSchema)) {
                    updateDataLayer.UpdateSchema(false, dictionary.CollectClassInfos(entityTypes));
                }
            }

            var dataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.SchemaAlreadyExists);
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

        static readonly Item[] demoData = new Item[] {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description #1." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description #2." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description #3." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description #4." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description #5." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description #6." },
        };
        static void CreateDemoData() {
            using(var uow = CreateUnitOfWork()) {
                if(!uow.Query<Item>().Any()) {
                    foreach(var demoItem in demoData) {
                        uow.Save(demoItem);
                    }
                    uow.CommitChanges();
                }
            }
        }
    }
}
