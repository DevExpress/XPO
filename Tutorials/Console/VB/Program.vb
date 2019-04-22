Option Infer On

Imports System
Imports System.Data
Imports System.IO
Imports System.Linq
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.InteropServices

Namespace DevExpress.Xpo.ConsoleCoreDemo
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			Dim appDataPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DevExpress.Xpo.ConsoleCoreDemo")
			If Not Directory.Exists(appDataPath) Then
				Directory.CreateDirectory(appDataPath)
			End If
			' XPO data layer setup against a local SQLite database. Learn more at https://documentation.devexpress.com/CoreLibraries/2020/DevExpress-ORM-Tool/Feature-Center/Connecting-to-a-Data-Store.
			Dim connectionString As String = SQLiteConnectionProvider.GetConnectionString(Path.Combine(appDataPath, "xpoConsole.db"))
			XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema)
			XpoDefault.Session = Nothing

			Try
				Console.WriteLine()
				Console.WriteLine("XPO console demo application 1.0")
				Console.WriteLine("     Uses eXpressPersistent Objects (XPO) for .NET Standard 2.0 - Object-Relational Mapping for .NET Developers")
				Console.WriteLine("     and Microsoft.Data.Sqlite 2.0 - ADO.NET provider for SQLite database")
				Do
					Console.WriteLine()
					Console.WriteLine("- Enter some text to create a new record.")
					Console.WriteLine("- Say ""show"" to display stored records.")
					Console.WriteLine("- Say ""clear"" to delete all records.")
					Console.WriteLine("- Say ""xpo"" to learn more.")
					Console.WriteLine("- Say ""quit"" for exit.")
					Console.WriteLine()
					Console.Write("XPO > ")
					Dim result As String = Console.ReadLine()
					Select Case result.ToLowerInvariant()
						Case "show"
							Console.WriteLine()
							Console.WriteLine("|-------------------- start --------------------|")
							Using uow As New UnitOfWork()
								Dim query = uow.Query(Of StatisticInfo)().OrderBy(Function(info) info.Date).Select(Function(info) $"[{info.Date}] {info.Info}")
								For Each line In query
									Console.WriteLine(line)
								Next line
							End Using
							Console.WriteLine("|--------------------  end  --------------------|")
							Console.WriteLine()
						Case "clear"
							' Querying and deleting XPO objects. Learn more at https://documentation.devexpress.com/CoreLibraries/2026/DevExpress-ORM-Tool/Feature-Center/Data-Exchange-and-Manipulation/Deleting-Persistent-Objects.
							Using uow As New UnitOfWork()
								Dim itemsToDelete = uow.Query(Of StatisticInfo)().ToList()
								If itemsToDelete.Count > 0 Then
									Dim pluralEnding = If(itemsToDelete.Count > 1, "s", "")
									Console.Write($"Are you sure you want to delete {itemsToDelete.Count} record{pluralEnding} (y/N)?: ")
									If Console.ReadLine().ToLowerInvariant() = "y" Then
										uow.Delete(itemsToDelete)
										uow.CommitChanges()
										Console.WriteLine($"Done.")
									End If
								Else
									Console.WriteLine("There are no records to delete.")
								End If
							End Using
						Case "exit", "quit"
							Return
						Case "xpo"
								Console.WriteLine("Starting browser...")
								Dim runWwwPrefix As String = ""
								If RuntimeInformation.IsOSPlatform(OSPlatform.Linux) Then
									runWwwPrefix = "x-www-browser "
								ElseIf RuntimeInformation.IsOSPlatform(OSPlatform.OSX) Then
									runWwwPrefix = "open "
								End If
								Dim psi = New ProcessStartInfo(runWwwPrefix & "https://www.devexpress.com/Products/NET/ORM/")
								psi.UseShellExecute = True
								Process.Start(psi)
								Console.WriteLine("Done.")
						Case Else
							' Creating and saving a new XPO object. Learn more at https://documentation.devexpress.com/CoreLibraries/2023/DevExpress-ORM-Tool/Feature-Center/Data-Exchange-and-Manipulation.
							Using uow As New UnitOfWork()
								Dim newInfo As New StatisticInfo(uow)
								newInfo.Info = result
								newInfo.Date = Date.Now
								uow.CommitChanges()
								Console.WriteLine("Saved.")
							End Using
					End Select
				Loop
			Catch ex As Exception
				Console.WriteLine(ex.ToString())
				Console.ReadKey()
			End Try
		End Sub
	End Class
End Namespace
