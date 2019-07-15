Imports System
Imports DevExpress.Xpf.Core
Imports WpfApplication.Wrappers
Imports XpoTutorial

Namespace WpfApplication
	''' <summary>
	''' Interaction logic for OrderEditWindow.xaml
	''' </summary>
	Partial Public Class OrderEditWindow
		Inherits ThemedWindow

		Private ReadOnly model As OrderEditWrapper

		Public Sub New(ByVal order As Order)
			InitializeComponent()
			model = New OrderEditWrapper(order)
			DataContext = model
		End Sub

		Private Sub ButtonSave_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			DialogResult = True
		End Sub

		Private Sub ButtonCancel_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			DialogResult = False
		End Sub

		Private Sub ButtonReload_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			model.Reload()
		End Sub

		Private Sub ThemedWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
			If DialogResult.Equals(True) Then
				model.EndEdit()
			Else
				model.CancelEdit()
			End If
		End Sub
	End Class
End Namespace
