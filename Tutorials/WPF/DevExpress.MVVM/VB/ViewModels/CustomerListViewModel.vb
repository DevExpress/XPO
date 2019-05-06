Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Xpo
Imports System
Imports System.ComponentModel
Imports XpoTutorial
Imports System.Linq
Imports WpfApplicationMvvm.Services

Namespace WpfApplicationMvvm.ViewModels
	Public Class CustomerListViewModel
		Inherits ViewModelBase

		Public Property Customers() As IListSource
			Get
				Return GetProperty(Function() Customers)
			End Get
			Private Set(ByVal value As IListSource)
				SetProperty(Function() Customers, value)
			End Set
		End Property
		Protected ReadOnly Property DocumentManagerService() As IDocumentManagerService
			Get
				Return GetService(Of IDocumentManagerService)()
			End Get
		End Property
		Protected ReadOnly Property InstantFeedbackService() As IInstantFeedbackService
			Get
				Return GetService(Of IInstantFeedbackService)()
			End Get
		End Property
		Protected Overrides Sub OnInitializeInRuntime()
			MyBase.OnInitializeInRuntime()
			Reload()
		End Sub
		Protected Sub CreateDocument(ByVal arg As Integer)
			Dim doc As IDocument = DocumentManagerService.FindDocument(arg, Me)
			If doc Is Nothing Then
				doc = DocumentManagerService.CreateDocument("EditCustomerView", arg, Me)
				doc.Id = String.Format("DocId_{0}", DocumentManagerService.Documents.Count())
				doc.Title = String.Format("Edit Customer {0}", arg)
			End If
			doc.Show()
		End Sub
		<Command>
		Public Sub Reload()
			If InstantFeedbackService Is Nothing Then
				ReloadCore()
			Else
				Dim focusedObjectKey As Object = InstantFeedbackService.GetFocusedRowKey()
				ReloadCore()
				InstantFeedbackService.SetFocusedRowByKeyAsync(focusedObjectKey)
			End If
		End Sub
		<Command>
		Public Async Sub Delete()
			Using uow As New UnitOfWork()
				Dim key As Object = InstantFeedbackService.GetFocusedRowKey()
				Dim customer As Customer = uow.GetObjectByKey(Of Customer)(key)
				uow.Delete(customer)
				Await uow.CommitChangesAsync()
			End Using
			Reload()
		End Sub
		<Command>
		Public Sub Edit()
			Dim key As Object = InstantFeedbackService.GetFocusedRowKey()
			CreateDocument(DirectCast(key, Integer))
		End Sub
		<Command>
		Public Sub Add()
			CreateDocument(-1)
		End Sub
		Private Sub ReloadCore()
			Dim old As IDisposable = DirectCast(Customers, IDisposable)
            Customers = New XPInstantFeedbackSource(GetType(Customer), "Oid;ContactName", Nothing, Sub(e) e.Session = New Session(), Sub(e) e.Session.Session.Dispose())
            If old IsNot Nothing Then
				old.Dispose()
			End If
		End Sub
	End Class
End Namespace
