Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB.Exceptions
Imports DevExpress.XtraEditors
Imports WinFormsApplication.XpoTutorial

Public Class EditOrderForm
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal orderID As Nullable(Of Integer))
        Me.New()
        fOrderID = orderID
    End Sub
    Private fOrderID As Nullable(Of Integer)
    Public ReadOnly Property OrderID() As Nullable(Of Integer)
        Get
            Return fOrderID
        End Get
    End Property
    Private fUnitOfWork As UnitOfWork
    Protected ReadOnly Property UnitOfWork() As UnitOfWork
        Get
            Return fUnitOfWork
        End Get
    End Property
    Private Sub EditCustomerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reload()
    End Sub

    Private Sub Reload()
        fUnitOfWork = New UnitOfWork()
        If OrderID.HasValue Then
            OrdersBindingSource.DataSource = UnitOfWork.GetObjectByKey(Of Order)(OrderID.Value)
        Else
            OrdersBindingSource.DataSource = New Order(UnitOfWork)
        End If
        CustomersBindingSource.DataSource = New XPCollection(Of Customer)(UnitOfWork)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            UnitOfWork.CommitChanges()
            fOrderID = CType(OrdersBindingSource.DataSource, Order).Oid
            Close()
        Catch ex As LockingException
            XtraMessageBox.Show(Me, "The record was modified or deleted. Click Reload and try again.", "XPO Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub BtnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Reload()
    End Sub
End Class