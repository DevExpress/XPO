<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OrdersListForm
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.OrdersGridControl = New DevExpress.XtraGrid.GridControl()
        Me.OrdersInstantFeedbackView = New DevExpress.Xpo.XPInstantFeedbackView(Me.components)
        Me.OrdersGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colOid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProductName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFreight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnNew = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        CType(Me.OrdersGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdersGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OrdersGridControl
        '
        Me.OrdersGridControl.DataSource = Me.OrdersInstantFeedbackView
        Me.OrdersGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OrdersGridControl.Location = New System.Drawing.Point(0, 143)
        Me.OrdersGridControl.MainView = Me.OrdersGridView
        Me.OrdersGridControl.Name = "OrdersGridControl"
        Me.OrdersGridControl.Size = New System.Drawing.Size(800, 276)
        Me.OrdersGridControl.TabIndex = 0
        Me.OrdersGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.OrdersGridView})
        '
        'OrdersInstantFeedbackView
        '
        Me.OrdersInstantFeedbackView.ObjectType = GetType(WinFormsApplication.XpoTutorial.Order)
        Me.OrdersInstantFeedbackView.Properties.AddRange(New DevExpress.Xpo.ServerViewProperty() {New DevExpress.Xpo.ServerViewProperty("Oid", DevExpress.Xpo.SortDirection.None, "[Oid]"), New DevExpress.Xpo.ServerViewProperty("Product Name", DevExpress.Xpo.SortDirection.None, "[ProductName]"), New DevExpress.Xpo.ServerViewProperty("Order Date", DevExpress.Xpo.SortDirection.None, "[OrderDate]"), New DevExpress.Xpo.ServerViewProperty("Freight", DevExpress.Xpo.SortDirection.None, "[Freight]")})
        '
        'OrdersGridView
        '
        Me.OrdersGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colOid, Me.colProductName, Me.colOrderDate, Me.colFreight})
        Me.OrdersGridView.GridControl = Me.OrdersGridControl
        Me.OrdersGridView.Name = "OrdersGridView"
        Me.OrdersGridView.OptionsBehavior.Editable = False
        '
        'colOid
        '
        Me.colOid.FieldName = "Oid"
        Me.colOid.Name = "colOid"
        '
        'colProductName
        '
        Me.colProductName.FieldName = "Product Name"
        Me.colProductName.Name = "colProductName"
        Me.colProductName.Visible = True
        Me.colProductName.VisibleIndex = 0
        '
        'colOrderDate
        '
        Me.colOrderDate.FieldName = "Order Date"
        Me.colOrderDate.Name = "colOrderDate"
        Me.colOrderDate.Visible = True
        Me.colOrderDate.VisibleIndex = 1
        '
        'colFreight
        '
        Me.colFreight.FieldName = "Freight"
        Me.colFreight.Name = "colFreight"
        Me.colFreight.Visible = True
        Me.colFreight.VisibleIndex = 2
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.btnNew, Me.btnDelete})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 3
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.Size = New System.Drawing.Size(800, 143)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        '
        'btnNew
        '
        Me.btnNew.Caption = "New"
        Me.btnNew.Id = 1
        Me.btnNew.Name = "btnNew"
        '
        'btnDelete
        '
        Me.btnDelete.Caption = "Delete"
        Me.btnDelete.Id = 2
        Me.btnDelete.Name = "btnDelete"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Home"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnNew)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnDelete)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Edit"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 419)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(800, 31)
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'OrdersListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.OrdersGridControl)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Name = "OrdersListForm"
        Me.Ribbon = Me.RibbonControl1
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "Form1"
        CType(Me.OrdersGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdersGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OrdersGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents OrdersGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents btnNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OrdersInstantFeedbackView As DevExpress.Xpo.XPInstantFeedbackView
    Friend WithEvents colOid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFreight As DevExpress.XtraGrid.Columns.GridColumn
End Class
