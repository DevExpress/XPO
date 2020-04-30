Imports System.ComponentModel
Imports DevExpress.Data.Filtering
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Xpo
Imports WinFormsApplication.Services
Imports XpoTutorial

Namespace WinFormsApplication.ViewModels
	Public Class CustomerListViewModel
		Public Sub New()
			Customers = New XPInstantFeedbackView(GetType(Customer), New ServerViewProperty() {
				New ServerViewProperty("Oid", "Oid"),
				New ServerViewProperty("ContactName", SortDirection.Ascending, New OperandProperty("ContactName"))
			}, Nothing)
		End Sub
		Private privateCustomers As IListSource
		Public Overridable Property Customers() As IListSource
			Get
				Return privateCustomers
			End Get
			Protected Set(ByVal value As IListSource)
				privateCustomers = value
			End Set
		End Property
		Protected ReadOnly Property InstantFeedbackService() As IInstantFeedbackService
			Get
				Return Me.GetService(Of IInstantFeedbackService)()
			End Get
		End Property
		Private Sub ReloadCore()
			DirectCast(Customers, XPInstantFeedbackView).Refresh()
		End Sub
		Public Sub Reload(Optional ByVal recordToFocus? As Integer = Nothing)
			If InstantFeedbackService Is Nothing Then
				ReloadCore()
			Else
				Dim focusedObjectKey As Object = If(recordToFocus.HasValue, recordToFocus.Value, InstantFeedbackService.GetFocusedRowKey())
				ReloadCore()
				InstantFeedbackService.SetFocusedRowByKey(focusedObjectKey)
			End If
		End Sub
		Public Async Sub Delete()
			Using uow As New UnitOfWork()
				Dim key As Object = InstantFeedbackService.GetFocusedRowKey()
				Dim customer As Customer = uow.GetObjectByKey(Of Customer)(key)
				uow.Delete(customer)
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
		Protected Sub CreateDocument(ByVal customerId As Integer)
			Dim id = New ViewID(GetType(Customer), customerId)
			Dim document As IDocument = DocumentManagerService.FindDocumentByIdOrCreate(id, Function(svc)
				Dim doc = svc.CreateDocument("EditCustomerView", customerId, Me)
				doc.Id = id
				doc.Title = String.Format("Edit Customer {0}", customerId)
				Return doc
			End Function)
			document.Show()
		End Sub
	End Class
End Namespace
