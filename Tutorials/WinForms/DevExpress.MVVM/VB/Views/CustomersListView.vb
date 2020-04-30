Imports System.Windows.Forms
Imports DevExpress.Utils.MVVM.UI
Imports DevExpress.XtraGrid.Views.Grid
Imports WinFormsApplication.Services
Imports WinFormsApplication.ViewModels

Namespace WinFormsApplication.Views
	<ViewType("CustomerListView")>
	Partial Public Class CustomersListView
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm

		Public Sub New()
			InitializeComponent()
			If Not mvvmContext1.IsDesignMode Then
				InitializeBindings()
			End If
		End Sub
		Private Sub InitializeBindings()
			mvvmContext1.RegisterService(New InstantFeedbackService(CustomersGridView))
			'
			Dim fluentApi = mvvmContext1.OfType(Of CustomerListViewModel)()
			fluentApi.SetBinding(CustomersGridControl, Function(bs) bs.DataSource, Function(x) x.Customers)
			fluentApi.WithEvent(Of RowClickEventArgs)(CustomersGridView, NameOf(CustomersGridView.RowClick)).EventToCommand(Sub(x) x.Edit(), Function(args As RowClickEventArgs) args.Clicks = 2 AndAlso args.Button = MouseButtons.Left)
			fluentApi.BindCommand(btnNew, Sub(x) x.Add())
			fluentApi.BindCommand(btnDelete, Sub(x) x.Delete())
		End Sub
	End Class
End Namespace
