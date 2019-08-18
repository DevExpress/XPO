Imports System
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports XpoTutorial
Imports System.Threading.Tasks
Imports System.Collections.ObjectModel
Imports System.Collections.Generic

Namespace WpfApplication.Wrappers
	Friend Class CustomerEditWrapper
		Implements INotifyPropertyChanged

		Private unitOfWork As UnitOfWork
		Private ReadOnly customerOid? As Integer

		Public Sub New()
			unitOfWork = New UnitOfWork(XpoDefault.DataLayer)
			Customer = New Customer(unitOfWork)
		End Sub

		Public Sub New(ByVal customerOid As Integer)
			Me.customerOid = customerOid
			unitOfWork = New UnitOfWork(XpoDefault.DataLayer)
			Customer = unitOfWork.GetObjectByKey(Of Customer)(customerOid)
		End Sub

		Private fCustomer As Customer
		Public Property Customer() As Customer
			Get
				Return fCustomer
			End Get
			Set(ByVal value As Customer)
				fCustomer = value
				OrderList = fCustomer.Orders
				OnPropertyChanged(NameOf(Customer))
			End Set
		End Property

		Private fOrderList As IList(Of Order)
		Public Property OrderList() As IList(Of Order)
			Get
				Return fOrderList
			End Get
			Set(ByVal value As IList(Of Order))
				fOrderList = value
				OnPropertyChanged(NameOf(OrderList))
			End Set
		End Property

		Private fSelectedOrder As Order
		Public Property SelectedOrder() As Order
			Get
				Return fSelectedOrder
			End Get
			Set(ByVal value As Order)
				fSelectedOrder = value
				IsOrderSelected = (value IsNot Nothing)
				OnPropertyChanged(NameOf(SelectedOrder))
			End Set
		End Property

		Private fIsOrderSelected As Boolean
		Public Property IsOrderSelected() As Boolean
			Get
				Return fIsOrderSelected
			End Get
			Set(ByVal value As Boolean)
				fIsOrderSelected = value
				OnPropertyChanged(NameOf(IsOrderSelected))
			End Set
		End Property

		Public Function CreateNewOrder() As Order
			Dim order As New Order(unitOfWork)
			order.Customer = Customer
			SelectedOrder = order
			Return order
		End Function

		Public Sub DeleteSelectedOrder()
			If SelectedOrder IsNot Nothing Then
				unitOfWork.Delete(selectedOrder_Renamed)
			End If
		End Sub

		Public Async Function ReloadAsync() As Task
			If Me.customerOid.HasValue Then
				unitOfWork = New UnitOfWork(XpoDefault.DataLayer)
				Customer = Await unitOfWork.GetObjectByKeyAsync(Of Customer)(customerOid)
			End If
		End Function

		Public Function SaveAsync() As Task
			Return unitOfWork.CommitChangesAsync()
		End Function

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Private Sub OnPropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
	End Class
End Namespace