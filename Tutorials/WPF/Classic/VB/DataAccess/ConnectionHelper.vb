Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata
Imports System
Imports System.Configuration

Namespace XpoTutorial
	Public Module ConnectionHelper

		Private ReadOnly PersistentTypes() As Type = { GetType(Order), GetType(Customer) }

		Public Sub Connect(Optional ByVal threadSafe As Boolean = True)
			XpoDefault.DataLayer = CreateDataLayer(threadSafe)
		End Sub

		Private Function CreateDataLayer(ByVal threadSafe As Boolean) As IDataLayer
			Dim connStr As String = ConfigurationManager.ConnectionStrings("XpoTutorial").ConnectionString
			'connStr = XpoDefault.GetConnectionPoolString(connStr);  // Uncomment this line if you use a database server like SQL Server, Oracle, PostgreSql etc.
			Dim dictionary As New ReflectionDictionary()
			dictionary.GetDataStoreSchema(PersistentTypes) ' Pass all of your persistent object types to this method.
			Dim autoCreateOption As AutoCreateOption = DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema ' Use AutoCreateOption.DatabaseAndSchema if the database or tables does not exists. Use AutoCreateOption.SchemaAlreadyExists if the database already exists.
			Dim provider As IDataStore = XpoDefault.GetConnectionProvider(connStr, autoCreateOption)
			Return If(threadSafe, DirectCast(New ThreadSafeDataLayer(dictionary, provider), IDataLayer), New SimpleDataLayer(dictionary, provider))
		End Function
	End Module
End Namespace
