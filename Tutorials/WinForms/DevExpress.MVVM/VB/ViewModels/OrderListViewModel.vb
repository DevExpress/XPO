Imports System.ComponentModel
Imports DevExpress.Data.Filtering
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Xpo
Imports WinFormsApplication.Services
Imports XpoTutorial

Namespace WinFormsApplication.ViewModels
	Public Class OrderListViewModel
		Public Sub New()
			Orders = New XPInstantFeedbackView(GetType(Order), New ServerViewProperty() {
				New ServerViewProperty("Oid","Oid"),
				New ServerViewProperty("OrderDate", SortDirection.Ascending, New OperandProperty("OrderDate")),
				New ServerViewProperty("ProductName", "ProductName")
			}, Nothing)
		End Sub
		Private privateOrders As IListSource
		Public Overridable Property Orders() As IListSource
			Get
				Return privateOrders
			End Get
			Protected Set(ByVal value As IListSource)
				privateOrders = value
			End Set
		End Property
		Protected ReadOnly Property InstantFeedbackService() As IInstantFeedbackService
			Get
				Return Me.GetService(Of IInstantFeedbackService)()
			End Get
		End Property
		Private Sub ReloadCore()
			DirectCast(Orders, XPInstantFeedbackView).Refresh()
		End Sub
		Public Sub Reload(Optional ByVal recordToFocus? As Integer = Nothing)
			If InstantFeedbackService Is Nothing Then
				ReloadCore()
			Else
				Dim focusedObjectKey As Object = InstantFeedbackService.GetFocusedRowKey()
				ReloadCore()
				InstantFeedbackService.SetFocusedRowByKey(focusedObjectKey)
			End If
		End Sub
		Public Async Sub Delete()
			Using uow As New UnitOfWork()
				Dim key As Object = InstantFeedbackService.GetFocusedRowKey()
				Dim order As Order = uow.GetObjectByKey(Of Order)(key)
				uow.Delete(order)
				Await uow.CommitChangesAsync()
			End Using
			Reload()
		End Sub
		Public Sub Edit()
			CreateDocument(DirectCast(InstantFeedbackService.GetFocusedRowKey(), Integer))
		End Sub
		Public Sub Add()
			CreateDocument(-1)
		End Sub
		'
		Protected ReadOnly Property DocumentManagerService() As IDocumentManagerService
			Get
				Return Me.GetService(Of IDocumentManagerService)()
			End Get
		End Property
		Protected Sub CreateDocument(ByVal orderId As Integer)
			Dim id = New ViewID(GetType(Order), orderId)
			Dim document As IDocument = DocumentManagerService.FindDocumentByIdOrCreate(id, Function(svc)
				Dim doc = svc.CreateDocument("EditOrderView", orderId, Me)
				doc.Id = id
				doc.Title = String.Format("Edit Order {0}", orderId)
				Return doc
			End Function)
			document.Show()
		End Sub
	End Class
End Namespace
