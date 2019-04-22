Imports DevExpress.Xpo
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace XpoTutorial
	Public Module DemoDataHelper
		Private firstNames() As String = { "Peter", "Ryan", "Richard", "Tom", "Mark", "Steve", "Jimmy", "Jeffrey", "Andrew", "Dave", "Bert", "Mike", "Ray", "Paul", "Brad", "Carl", "Jerry" }
		Private lastNames() As String = { "Dolan", "Fischer", "Hamlett", "Hamilton", "Lee", "Lewis", "McClain", "Miller", "Murrel", "Parkins", "Roller", "Shipman", "Bailey", "Barnes", "Lucas", "Campbell" }
		Private productNames() As String = { "Chai", "Chang", "Aniseed Syrup", "Chef Anton's Cajun Seasoning", "Chef Anton's Gumbo Mix", "Grandma's Boysenberry Spread", "Uncle Bob's Organic Dried Pears", "Northwoods Cranberry Sauce", "Mishi Kobe Niku", "Ikura", "Queso Cabrales", "Queso Manchego La Pastora", "Konbu", "Tofu", "Genen Shouyu", "Pavlova", "Alice Mutton", "Carnarvon Tigers", "Teatime Chocolate Biscuits", "Sir Rodney's Marmalade", "Sir Rodney's Scones", "Gustaf's Knäckebröd", "Tunnbröd", "Guaraná Fantástica", "NuNuCa Nuß-Nougat-Creme", "Gumbär Gummibärchen", "Schoggi Schokolade", "Rössle Sauerkraut", "Thüringer Rostbratwurst", "Nord-Ost Matjeshering", "Gorgonzola Telino", "Mascarpone Fabioli", "Geitost", "Sasquatch Ale", "Steeleye Stout", "Inlagd Sill", "Gravad lax", "Côte de Blaye", "Chartreuse verte", "Boston Crab Meat", "Jack's New England Clam Chowder", "Singaporean Hokkien Fried Mee", "Ipoh Coffee", "Gula Malacca", "Rogede sild", "Spegesild", "Zaanse koeken", "Chocolade", "Maxilaku", "Valkoinen suklaa", "Manjimup Dried Apples", "Filo Mix", "Perth Pasties", "Tourtière", "Pâté chinois", "Gnocchi di nonna Alice", "Ravioli Angelo", "Escargots de Bourgogne", "Raclette Courdavault", "Camembert Pierrot", "Sirop d'érable", "Tarte au sucre", "Vegie-spread", "Wimmers gute Semmelknödel", "Louisiana Fiery Hot Pepper Sauce", "Louisiana Hot Spiced Okra", "Laughing Lumberjack Lager", "Scottish Longbreads", "Gudbrandsdalsost", "Outback Lager", "Flotemysost", "Mozzarella di Giovanni", "Röd Kaviar", "Longlife Tofu", "Rhönbräu Klosterbier", "Lakkalikööri", "Original Frankfurter grüne Soße" }
		Private Random As New Random(0)

		Public Sub Seed(ByVal uow As UnitOfWork)
			Dim ordersCnt As Integer = uow.Query(Of Order)().Count()
			If ordersCnt > 0 Then
				Return
			End If
			Dim names = New KeyValuePair(Of String, String)((firstNames.Length * lastNames.Length) - 1){}
			For i As Integer = 0 To (firstNames.Length * lastNames.Length) - 1
				Dim j As Integer = Random.Next(i + 1)
				names(i) = names(j)
				names(j) = New KeyValuePair(Of String, String)(firstNames(i \ lastNames.Length), lastNames(i Mod lastNames.Length))
			Next i
			For Each t In names
				CreateCustomer(uow, t.Key, t.Value)
			Next t
			uow.CommitChanges()
		End Sub

		Private Sub CreateCustomer(ByVal uow As UnitOfWork, ByVal firstName As String, ByVal lastName As String)
			Dim customer As New Customer(uow)
			customer.FirstName = firstName
			customer.LastName = lastName
			For i As Integer = 0 To 9
				Dim order As New Order(uow)
				order.ProductName = productNames(Random.Next(productNames.Length))
				order.OrderDate = New Date(Random.Next(2014, 2024), Random.Next(1, 12), Random.Next(1, 28))
				order.Freight = Random.Next(1000) / 100D
				order.Customer = customer
			Next i
		End Sub
	End Module
End Namespace
