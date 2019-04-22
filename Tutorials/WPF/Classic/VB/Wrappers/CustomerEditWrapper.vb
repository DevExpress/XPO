Imports System
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports XpoTutorial
Imports System.Threading.Tasks

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

'INSTANT VB NOTE: The field customer was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private customer_Renamed As Customer
		Public Property Customer() As Customer
			Get
				Return customer_Renamed
			End Get
			Set(ByVal value As Customer)
				customer_Renamed = value
				orderList_Renamed.DataSource = customer_Renamed.Orders
				OnPropertyChanged(NameOf(Customer))
			End Set
		End Property

'INSTANT VB NOTE: The field orderList was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private ReadOnly orderList_Renamed As New XPBindingSource()
		Public ReadOnly Property OrderList() As XPBindingSource
			Get
				Return orderList_Renamed
			End Get
		End Property

'INSTANT VB NOTE: The field selectedOrder was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private selectedOrder_Renamed As Order
		Public Property SelectedOrder() As Order
			Get
				Return selectedOrder_Renamed
			End Get
			Set(ByVal value As Order)
				selectedOrder_Renamed = value
				IsOrderSelected = (value IsNot Nothing)
				OnPropertyChanged(NameOf(SelectedOrder))
			End Set
		End Property

'INSTANT VB NOTE: The field isOrderSelected was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private isOrderSelected_Renamed As Boolean
		Public Property IsOrderSelected() As Boolean
			Get
				Return isOrderSelected_Renamed
			End Get
			Set(ByVal value As Boolean)
				isOrderSelected_Renamed = value
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
				SelectedOrder.Delete()
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
