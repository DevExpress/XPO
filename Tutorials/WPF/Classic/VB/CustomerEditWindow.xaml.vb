Imports System
Imports DevExpress.Xpf.Core
Imports WpfApplication.Wrappers
Imports XpoTutorial

Namespace WpfApplication
	''' <summary>
	''' Interaction logic for CustomerEditWindow.xaml
	''' </summary>
	Partial Public Class CustomerEditWindow
		Inherits ThemedWindow

		Private ReadOnly model As CustomerEditWrapper

		Public Sub New()
			InitializeComponent()
			model = New CustomerEditWrapper()
			DataContext = model
		End Sub

		Public Sub New(ByVal customerOid As Integer)
			InitializeComponent()
			model = New CustomerEditWrapper(customerOid)
			DataContext = model
		End Sub

		Private Async Sub ButtonSave_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			Await model.SaveAsync()
			DialogResult = True
		End Sub

		Private Sub ButtonCancel_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			DialogResult = False
		End Sub

		Private Async Sub ButtonReload_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			Await model.ReloadAsync()
		End Sub

		Private Sub ButtonAddOrder_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			Dim order As Order = model.CreateNewOrder()
			Dim editWindow As New OrderEditWindow(order) With {.Owner = Me}
			If Not editWindow.ShowDialog().Equals(True) Then
				model.DeleteSelectedOrder()
			End If
		End Sub

		Private Sub ButtonEditOrder_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			EditSelectedOrder()
		End Sub

		Private Sub ButtonDeleteOrder_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			model.DeleteSelectedOrder()
		End Sub

		Private Sub TableView_RowDoubleClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.RowDoubleClickEventArgs)
			EditSelectedOrder()
		End Sub

		Private Sub EditSelectedOrder()
			Dim editWindow As New OrderEditWindow(model.SelectedOrder) With {.Owner = Me}
			editWindow.ShowDialog()
		End Sub
	End Class
End Namespace
