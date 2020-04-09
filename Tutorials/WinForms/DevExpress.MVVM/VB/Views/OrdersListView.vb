Imports System.Windows.Forms
Imports DevExpress.Utils.MVVM.UI
Imports DevExpress.XtraGrid.Views.Grid
Imports WinFormsApplication.Services
Imports WinFormsApplication.ViewModels

Namespace WinFormsApplication.Views
	<ViewType("OrderListView")>
	Partial Public Class OrdersListView
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm

		Public Sub New()
			InitializeComponent()
			If Not mvvmContext1.IsDesignMode Then
				InitializeBindings()
			End If
		End Sub
		Private Sub InitializeBindings()
			mvvmContext1.RegisterService(New InstantFeedbackService(ordersGridView))
			'
			Dim fluentApi = mvvmContext1.OfType(Of OrderListViewModel)()
			fluentApi.SetBinding(ordersGridControl, Function(bs) bs.DataSource, Function(x) x.Orders)
			fluentApi.WithEvent(Of RowClickEventArgs)(ordersGridView, NameOf(ordersGridView.RowClick)).EventToCommand(Sub(x) x.Edit(), Function(args As RowClickEventArgs) args.Clicks = 2 AndAlso args.Button = MouseButtons.Left)
			fluentApi.BindCommand(btnNew, Sub(x) x.Add())
			fluentApi.BindCommand(btnDelete, Sub(x) x.Delete())
		End Sub
	End Class
End Namespace
