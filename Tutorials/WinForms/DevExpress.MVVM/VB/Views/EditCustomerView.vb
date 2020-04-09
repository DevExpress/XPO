Imports DevExpress.Utils.MVVM.UI
Imports DevExpress.XtraEditors
Imports WinFormsApplication.ViewModels

Namespace WinFormsApplication.Views
	<ViewType("EditCustomerView")>
	Partial Public Class EditCustomerView
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
			If Not mvvmContext1.IsDesignMode Then
				InitializeBindings()
			End If
		End Sub
		Private Sub InitializeBindings()
			Dim fluentApi = mvvmContext1.OfType(Of EditCustomerViewModel)()
			fluentApi.SetBinding(CustomerBindingSource, Function(bs) bs.DataSource, Function(x) x.Customer)
			'
			fluentApi.BindCommand(btnSave, Sub(x) x.Save())
			fluentApi.BindCommand(btnReload, Sub(x) x.Reload())
		End Sub
	End Class
End Namespace
