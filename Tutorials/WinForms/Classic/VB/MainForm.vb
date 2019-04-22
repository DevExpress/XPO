Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms
Imports WinFormsApplication.Forms

Namespace WinFormsApplication
	Partial Public Class MainForm
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			Dim ordersList As New OrdersListForm()
			ordersList.MdiParent = Me
			ordersList.WindowState = FormWindowState.Maximized
			ordersList.Show()
		End Sub
	End Class
End Namespace
