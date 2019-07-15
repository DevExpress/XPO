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

'INSTANT VB NOTE: The field order was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private order_Renamed As Order
		Public Property Order() As Order
			Get
				Return order_Renamed
			End Get
			Set(ByVal value As Order)
				order_Renamed = value
				OnPropertyChanged(NameOf(Customer))
			End Set
		End Property

		Public ReadOnly Property CustomerList() As IList(Of Customer)
			Get
				Dim customers = order_Renamed.Session.Query(Of Customer)().OrderBy(Function(t) t.FirstName).ThenBy(Function(t) t.LastName).ToList()
				If Not customers.Contains(order_Renamed.Customer) Then
					customers.Add(order_Renamed.Customer)
				End If
				Return customers
			End Get
		End Property

		Public Sub Reload()
			DirectCast(order_Renamed, IEditableObject).CancelEdit()
			DirectCast(order_Renamed, IEditableObject).BeginEdit()
		End Sub

		Public Sub EndEdit()
			DirectCast(order_Renamed, IEditableObject).EndEdit()
		End Sub

		Public Sub CancelEdit()
			DirectCast(order_Renamed, IEditableObject).CancelEdit()
		End Sub

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Private Sub OnPropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
	End Class
End Namespace
