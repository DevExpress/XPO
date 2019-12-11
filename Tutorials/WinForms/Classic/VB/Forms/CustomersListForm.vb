Imports System
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraGrid.Views.Grid
Imports WinFormsApplication.XpoTutorial

Partial Public Class CustomersListForm
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    Public Sub New()
        InitializeComponent()
    End Sub
    Private privateSession As Session
    Protected Property Session() As Session
        Get
            Return privateSession
        End Get
        Private Set(ByVal value As Session)
            privateSession = value
        End Set
    End Property
    Private Sub CustomersListForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Reload()
    End Sub

    Private Sub CustomersGridView_RowClick(ByVal sender As Object, ByVal e As RowClickEventArgs) Handles CustomersGridView.RowClick
        If e.Clicks = 2 Then
            e.Handled = True
            Dim customerID As Integer = DirectCast(CustomersGridView.GetRowCellValue(e.RowHandle, colOid), Integer)
            ShowEditForm(customerID)
        End If
    End Sub

    Private Sub ShowEditForm(ByVal customerID? As Integer)
        Dim form = New EditCustomerForm(customerID)
        AddHandler form.FormClosed, Sub(s, e)
                                        If form.CustomerID.HasValue Then
                                            Reload()
                                            CustomersGridView.FocusedRowHandle = CustomersGridView.LocateByValue("Oid", form.CustomerID.Value)
                                        End If
                                    End Sub
        Dim documentManager = DevExpress.XtraBars.Docking2010.DocumentManager.FromControl(MdiParent)
        If documentManager IsNot Nothing Then
            documentManager.View.AddDocument(form)
        Else
            Try
                form.ShowDialog()
            Finally
                form.Dispose()
            End Try
        End If
    End Sub

    Private Sub Reload()
        Session = New Session()
        CustomersBindingSource.DataSource = New XPCollection(Of Customer)(Session)
    End Sub

    Private Sub BtnNew_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnNew.ItemClick
        ShowEditForm(Nothing)
    End Sub

    Private Sub BtnDelete_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnDelete.ItemClick
        Dim focusedObject As Object = CustomersGridView.GetFocusedRow()
        Session.Delete(focusedObject)
    End Sub
End Class
