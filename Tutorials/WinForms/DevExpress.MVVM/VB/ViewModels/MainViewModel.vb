Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports XpoTutorial

Namespace WinFormsApplication.ViewModels
	Public Class MainViewModel
		Protected ReadOnly Property DocumentManagerService() As IDocumentManagerService
			Get
				Return Me.GetService(Of IDocumentManagerService)()
			End Get
		End Property
		Public Sub ShowCustomers()
			Dim id = New ViewID(GetType(Customer))
			Dim document As IDocument = DocumentManagerService.FindDocumentByIdOrCreate(id, Function(svc)
				Dim doc = svc.CreateDocument("CustomerListView", Nothing, Me)
				doc.Id = id
				doc.Title = "Customers"
				Return doc
			End Function)
			document.Show()
		End Sub
		Public Sub ShowOrders()
			Dim id = New ViewID(GetType(Order))
			Dim document As IDocument = DocumentManagerService.FindDocumentByIdOrCreate(id, Function(svc)
				Dim doc = svc.CreateDocument("OrderListView", Nothing, Me)
				doc.Id = id
				doc.Title = "Orders"
				Return doc
			End Function)
			document.Show()
		End Sub
	End Class
End Namespace
