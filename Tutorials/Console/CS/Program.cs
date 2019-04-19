using System;
using System.Data;
using System.IO;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DevExpress.Xpo.ConsoleCoreDemo {
    class Program {
        static void Main(string[] args) {
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DevExpress.Xpo.ConsoleCoreDemo");
            if(!Directory.Exists(appDataPath)) {
                Directory.CreateDirectory(appDataPath);
            }
            // XPO data layer setup against a local SQLite database. Learn more at https://documentation.devexpress.com/CoreLibraries/2020/DevExpress-ORM-Tool/Feature-Center/Connecting-to-a-Data-Store.
            string connectionString = SQLiteConnectionProvider.GetConnectionString(Path.Combine(appDataPath, "xpoConsole.db"));
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);
            XpoDefault.Session = null;

            try {
                Console.WriteLine();
                Console.WriteLine("XPO console demo application 1.0");
                Console.WriteLine("     Uses eXpressPersistent Objects (XPO) for .NET Standard 2.0 - Object-Relational Mapping for .NET Developers");
                Console.WriteLine("     and Microsoft.Data.Sqlite 2.0 - ADO.NET provider for SQLite database");
                while(true) {
                    Console.WriteLine();
                    Console.WriteLine("- Enter some text to create a new record.");
                    Console.WriteLine("- Say \"show\" to display stored records.");
                    Console.WriteLine("- Say \"clear\" to delete all records.");
                    Console.WriteLine("- Say \"xpo\" to learn more.");
                    Console.WriteLine("- Say \"quit\" for exit.");
                    Console.WriteLine();
                    Console.Write("XPO > ");
                    string result = Console.ReadLine();
                    switch(result.ToLowerInvariant()) {
                        case "show":
                            Console.WriteLine();
                            Console.WriteLine("|-------------------- start --------------------|");
                            using(UnitOfWork uow = new UnitOfWork()) {
                                var query = uow.Query<StatisticInfo>()
                                    .OrderBy(info => info.Date)
                                    .Select(info => $"[{info.Date}] {info.Info}");
                                foreach(var line in query) {
                                    Console.WriteLine(line);
                                }
                            }
                            Console.WriteLine("|--------------------  end  --------------------|");
                            Console.WriteLine();
                            break;
                        case "clear":
                            // Querying and deleting XPO objects. Learn more at https://documentation.devexpress.com/CoreLibraries/2026/DevExpress-ORM-Tool/Feature-Center/Data-Exchange-and-Manipulation/Deleting-Persistent-Objects.
                            using(UnitOfWork uow = new UnitOfWork()) {
                                var itemsToDelete = uow.Query<StatisticInfo>().ToList();
                                if(itemsToDelete.Count > 0) {
                                    var pluralEnding = itemsToDelete.Count > 1 ? "s" : "";
                                    Console.Write($"Are you sure you want to delete {itemsToDelete.Count} record{pluralEnding} (y/N)?: ");
                                    if(Console.ReadLine().ToLowerInvariant() == "y") {
                                        uow.Delete(itemsToDelete);
                                        uow.CommitChanges();
                                        Console.WriteLine($"Done.");
                                    }
                                }
                                else {
                                    Console.WriteLine("There are no records to delete.");
                                }
                            }
                            break;
                        case "exit":
                        case "quit":
                            return;
                        case "xpo": {
                                Console.WriteLine("Starting browser...");
                                string runWwwPrefix = "";
                                if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                                    runWwwPrefix = "x-www-browser ";
                                }
                                else if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                                    runWwwPrefix = "open ";
                                }
                                var psi = new ProcessStartInfo(runWwwPrefix + "https://www.devexpress.com/Products/NET/ORM/");
                                psi.UseShellExecute = true;
                                Process.Start(psi);
                                Console.WriteLine("Done.");
                            }
                            break;
                        default:
                            // Creating and saving a new XPO object. Learn more at https://documentation.devexpress.com/CoreLibraries/2023/DevExpress-ORM-Tool/Feature-Center/Data-Exchange-and-Manipulation.
                            using(UnitOfWork uow = new UnitOfWork()) {
                                StatisticInfo newInfo = new StatisticInfo(uow);
                                newInfo.Info = result;
                                newInfo.Date = DateTime.Now;
                                uow.CommitChanges();
                                Console.WriteLine("Saved.");
                            }
                            break;
                    }
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
