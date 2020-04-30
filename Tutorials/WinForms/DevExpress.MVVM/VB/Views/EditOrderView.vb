Imports DevExpress.XtraEditors
Imports WinFormsApplication.ViewModels

Namespace WinFormsApplication.Forms
	Partial Public Class EditOrderView
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
			If Not mvvmContext1.IsDesignMode Then
				InitializeBindings()
			End If
		End Sub
		Private Sub InitializeBindings()
			Dim fluentApi = mvvmContext1.OfType(Of EditOrderViewModel)()
			fluentApi.SetBinding(OrderBindingSource, Function(bs) bs.DataSource, Function(x) x.Order)
			fluentApi.SetBinding(CustomersBindingSource, Function(bs) bs.DataSource, Function(x) x.Customers)
			'
			fluentApi.BindCommand(btnSave, Sub(x) x.Save())
			fluentApi.BindCommand(btnReload, Sub(x) x.Reload())
		End Sub
	End Class
End Namespace
