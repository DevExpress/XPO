using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Microsoft.Data.Sqlite;
using UIKit;

namespace XamarinFormsDemo.iOS {
    [Preserve(typeof(SqliteConnection))]
    public class Application {
        // This is the main entry point of the application.
        static void Main(string[] args) {
            //Initialize SQLite with the sqlite3 provider
            SQLitePCL.Batteries_V2.Init();

            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
