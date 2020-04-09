Imports DevExpress.XtraBars.Ribbon
Imports WinFormsApplication.ViewModels

Namespace WinFormsApplication
	Partial Public Class MainView
		Inherits RibbonForm

		Public Sub New()
			InitializeComponent()
			If Not mvvmContext1.IsDesignMode Then
				InitializeBindings()
			End If
		End Sub
		Private Sub InitializeBindings()
			Dim fluentApi = mvvmContext1.OfType(Of MainViewModel)()
			fluentApi.WithEvent(Me, NameOf(Load)).EventToCommand(Sub(x) x.ShowCustomers())
			'
			fluentApi.BindCommand(customersBarButtonItem, Sub(x) x.ShowCustomers())
			fluentApi.BindCommand(customersAccordionControlElement, Sub(x) x.ShowCustomers())
			fluentApi.BindCommand(ordersBarButtonItem, Sub(x) x.ShowOrders())
			fluentApi.BindCommand(ordersAccordionControlElement, Sub(x) x.ShowOrders())
		End Sub
	End Class
End Namespace
