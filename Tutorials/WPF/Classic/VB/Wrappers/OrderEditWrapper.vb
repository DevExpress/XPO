Imports System
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports XpoTutorial
Imports System.Collections.Generic
Imports System.Linq

Namespace WpfApplication.Wrappers

	Friend Class OrderEditWrapper
		Implements INotifyPropertyChanged

		Public Sub New(ByVal order As Order)
			Me.Order = order
			DirectCast(order, IEditableObject).BeginEdit()
		End Sub

		Private fOrder As Order
		Public Property Order() As Order
			Get
				Return fOrder
			End Get
			Set(ByVal value As Order)
				fOrder = value
				OnPropertyChanged(NameOf(Customer))
			End Set
		End Property

		Public ReadOnly Property CustomerList() As IList(Of Customer)
			Get
				Dim customers = Order.Session.Query(Of Customer)().OrderBy(Function(t) t.FirstName).ThenBy(Function(t) t.LastName).ToList()
				If Not customers.Contains(Order.Customer) Then
					customers.Add(Order.Customer)
				End If
				Return customers
			End Get
		End Property

		Public Sub Reload()
			DirectCast(Order, IEditableObject).CancelEdit()
			DirectCast(Order, IEditableObject).BeginEdit()
		End Sub

		Public Sub EndEdit()
			DirectCast(Order, IEditableObject).EndEdit()
		End Sub

		Public Sub CancelEdit()
			DirectCast(Order, IEditableObject).CancelEdit()
		End Sub

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Private Sub OnPropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
	End Class
End Namespace
