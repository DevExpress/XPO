Imports System.Collections.Generic

Namespace AspNetMvcApplication.Models
	Public Class CustomerViewModel
		Public Property Oid() As Integer
		Public Property FirstName() As String
		Public Property LastName() As String
		Public ReadOnly Property ContactName() As String
			Get
				Return String.Concat(FirstName, " ", LastName)
			End Get
		End Property
		Public Property Orders() As List(Of OrderViewModel)
	End Class
End Namespace
