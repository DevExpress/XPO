Imports System

Namespace AspNetMvcApplication.Models
	Public Class OrderViewModel
		Public Property Oid() As Integer
		Public Property ProductName() As String
		Public Property OrderDate() As Date
		Public Property Freight() As Decimal
		Public Property CustomerId() As Integer
	End Class
End Namespace
