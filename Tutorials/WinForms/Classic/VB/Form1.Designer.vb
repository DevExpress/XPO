<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CustomersBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
        Me.CustomersGridControl = New DevExpress.XtraGrid.GridControl()
        Me.CustomersGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colOid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContactName = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomersGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomersGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomersBindingSource
        '
        Me.CustomersBindingSource.DisplayableProperties = "Oid;ContactName"
        Me.CustomersBindingSource.ObjectType = GetType(WinFormsApplication.XpoTutorial.Customer)
        '
        'CustomersGridControl
        '
        Me.CustomersGridControl.DataSource = Me.CustomersBindingSource
        Me.CustomersGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomersGridControl.Location = New System.Drawing.Point(0, 0)
        Me.CustomersGridControl.MainView = Me.CustomersGridView
        Me.CustomersGridControl.Name = "CustomersGridControl"
        Me.CustomersGridControl.Size = New System.Drawing.Size(800, 450)
        Me.CustomersGridControl.TabIndex = 0
        Me.CustomersGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CustomersGridView})
        '
        'CustomersGridView
        '
        Me.CustomersGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colOid, Me.colContactName})
        Me.CustomersGridView.GridControl = Me.CustomersGridControl
        Me.CustomersGridView.Name = "CustomersGridView"
        Me.CustomersGridView.OptionsBehavior.Editable = False
        '
        'colOid
        '
        Me.colOid.FieldName = "Oid"
        Me.colOid.Name = "colOid"
        '
        'colContactName
        '
        Me.colContactName.FieldName = "ContactName"
        Me.colContactName.Name = "colContactName"
        Me.colContactName.Visible = True
        Me.colContactName.VisibleIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CustomersGridControl)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomersGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomersGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CustomersBindingSource As DevExpress.Xpo.XPBindingSource
    Friend WithEvents CustomersGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents CustomersGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colOid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContactName As DevExpress.XtraGrid.Columns.GridColumn
End Class
