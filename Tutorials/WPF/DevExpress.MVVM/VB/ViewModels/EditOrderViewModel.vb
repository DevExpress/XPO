Imports DevExpress.Mvvm
Imports DevExpress.Xpo
Imports System.Collections
Imports XpoTutorial
Imports System.Linq
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Xpo.DB.Exceptions

Namespace WpfApplicationMvvm.ViewModels
	Public Class EditOrderViewModel
		Inherits ViewModelBase

		Public Property CurrentItem() As Order
			Get
				Return GetProperty(Function() CurrentItem)
			End Get
			Set(ByVal value As Order)
				SetProperty(Function() CurrentItem, value)
			End Set
		End Property
		Private privateUnitOfWork As NestedUnitOfWork
		Protected Property UnitOfWork() As NestedUnitOfWork
			Get
				Return privateUnitOfWork
			End Get
			Private Set(ByVal value As NestedUnitOfWork)
				privateUnitOfWork = value
			End Set
		End Property
		Public Property Customers() As ICollection
			Get
				Return GetProperty(Function() Customers)
			End Get
			Set(ByVal value As ICollection)
				SetProperty(Function() Customers, value)
			End Set
		End Property
		Protected ReadOnly Property MessageBoxService() As IMessageBoxService
			Get
				Return GetService(Of IMessageBoxService)()
			End Get
		End Property
		Protected ReadOnly Property DocumentManagerService() As IDocumentManagerService
			Get
				Return GetService(Of IDocumentManagerService)()
			End Get
		End Property
		Protected Overrides Sub OnParameterChanged(ByVal parameter As Object)
			Dim customer As Customer = TryCast(parameter, Customer)
			Dim order As Order = TryCast(parameter, Order)
			If customer IsNot Nothing Then
				SetCurrentItem(customer)
			ElseIf order IsNot Nothing Then
				SetCurrentItem(order)
			Else
				ResetCurrentItem()
			End If
		End Sub
		Private Sub ResetCurrentItem()
			UnitOfWork = Nothing
			CurrentItem = Nothing
			Customers = Nothing
		End Sub
		Protected Sub SetCurrentItem(ByVal order As Order)
			UnitOfWork = order.Session.BeginNestedUnitOfWork()
			CurrentItem = UnitOfWork.GetNestedObject(order)
			LoadCustomers()
		End Sub
		Protected Sub SetCurrentItem(ByVal customer As Customer)
			UnitOfWork = customer.Session.BeginNestedUnitOfWork()
			CurrentItem = New Order(UnitOfWork)
			CurrentItem.Customer = UnitOfWork.GetNestedObject(customer)
			LoadCustomers()
		End Sub
		Private Async Sub LoadCustomers()
			Customers = Await UnitOfWork.Query(Of Customer)().Select(Function(c) New With {Key c.Oid, Key c.ContactName}).OrderBy(Function(c) c.ContactName).ToListAsync()
		End Sub
		<Command>
		Public Sub Save()
			Try
				UnitOfWork.CommitChanges()
			Catch e1 As LockingException
				MessageBoxService.ShowMessage("The object was modified int another window. Please reload data.", "XPO Tutorial", MessageButton.OK, MessageIcon.Stop)
				Return
			End Try
			DocumentManagerService.ActiveDocument.Close()
		End Sub
		<Command>
		Public Sub Cancel()
			DocumentManagerService.ActiveDocument.Close()
		End Sub
		<Command>
		Public Sub Reload()
			Dim isNewObject As Boolean = UnitOfWork.IsNewObject(CurrentItem)
			If isNewObject Then
				Dim customer As Customer = UnitOfWork.GetParentObject(CurrentItem.Customer)
				SetCurrentItem(customer)
			Else
				Dim order As Order = UnitOfWork.GetParentObject(CurrentItem)
				SetCurrentItem(order)
			End If
		End Sub
	End Class
End Namespace
