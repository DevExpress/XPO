Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports System.Linq

Namespace WpfApplicationMvvm.ViewModels
	Public Class MainViewModel
		Inherits ViewModelBase

		Protected ReadOnly Property DocumentManagerService() As IDocumentManagerService
			Get
				Return GetService(Of IDocumentManagerService)()
			End Get
		End Property
		<Command>
		Public Sub CreateDocument()
			Dim doc As IDocument = DocumentManagerService.CreateDocument("CustomerListView", Nothing, Me)
			doc.Id = String.Format("DocId_{0}", DocumentManagerService.Documents.Count())
			doc.Title = "Customers"
			doc.Show()
		End Sub
	End Class
End Namespace
