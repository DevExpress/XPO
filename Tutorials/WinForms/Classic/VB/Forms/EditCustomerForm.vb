Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB.Exceptions
Imports DevExpress.XtraEditors
Imports WinFormsApplication.XpoTutorial

Public Class EditCustomerForm
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal customerID As Nullable(Of Integer))
        Me.New()
        fCustomerID = customerID
    End Sub
    Private fCustomerID As Nullable(Of Integer)
    Public ReadOnly Property CustomerID() As Nullable(Of Integer)
        Get
            Return fCustomerID
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
        If CustomerID.HasValue Then
            CustomersBindingSource.DataSource = UnitOfWork.GetObjectByKey(Of Customer)(CustomerID.Value)
        Else
            CustomersBindingSource.DataSource = New Customer(UnitOfWork)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            UnitOfWork.CommitChanges()
            fCustomerID = CType(CustomersBindingSource.DataSource, Customer).Oid
            Close()
        Catch ex As LockingException
            XtraMessageBox.Show(Me, "The record was modified or deleted. Click Reload and try again.", "XPO Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub BtnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Reload()
    End Sub
End Class