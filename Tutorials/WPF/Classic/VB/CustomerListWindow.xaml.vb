Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Core
Imports WpfApplication.Wrappers

Namespace WpfApplication

	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class CustomerListWindow
		Inherits ThemedWindow

		Private model As CustomerListWrapper
		Public Sub New()
			InitializeComponent()
			model = New CustomerListWrapper()
			DataContext = model
		End Sub

		Private Async Sub ButtonAddCustomer_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			Dim editWindow = New CustomerEditWindow() With {.Owner = Me}
			If editWindow.ShowDialog() = True Then
				Await model.ReloadAsync()
			End If
		End Sub

		Private Async Sub ButtonEditCustomer_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			Await EditSelectedCustomerAsync()
		End Sub

		Private Async Sub ButtonDeleteCustomer_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			Await model.DeleteSelectedCustomerAsync()
		End Sub

		Private Async Sub ButtonReload_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			Await model.ReloadAsync()
		End Sub

		Private Async Sub TableView_RowDoubleClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.RowDoubleClickEventArgs)
			Await EditSelectedCustomerAsync()
		End Sub

		Private Async Function EditSelectedCustomerAsync() As Task
			Dim editWindow = New CustomerEditWindow(model.SelectedCustomer.Oid) With {.Owner = Me}
			If editWindow.ShowDialog() = True Then
				Await model.ReloadAsync()
			End If
		End Function
	End Class
End Namespace