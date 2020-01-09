	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Public Class OrdersListForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(OrdersListForm))
			Me.OrdersGridControl = New DevExpress.XtraGrid.GridControl()
			Me.OrdersInstantFeedbackView = New DevExpress.Xpo.XPInstantFeedbackView(Me.components)
			Me.OrdersGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colOid = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colProductName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colOrderDate = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colFreight = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.btnNew = New DevExpress.XtraBars.BarButtonItem()
			Me.btnDelete = New DevExpress.XtraBars.BarButtonItem()
			Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.ribbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
			Me.ribbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			CType(Me.OrdersGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.OrdersGridView, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' OrdersGridControl
			' 
			Me.OrdersGridControl.DataSource = Me.OrdersInstantFeedbackView
			Me.OrdersGridControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.OrdersGridControl.Location = New System.Drawing.Point(0, 162)
			Me.OrdersGridControl.MainView = Me.OrdersGridView
			Me.OrdersGridControl.Name = "OrdersGridControl"
			Me.OrdersGridControl.Size = New System.Drawing.Size(800, 262)
			Me.OrdersGridControl.TabIndex = 0
			Me.OrdersGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.OrdersGridView})
			' 
			' OrdersInstantFeedbackView
			' 
			Me.OrdersInstantFeedbackView.ObjectType = GetType(XpoTutorial.Order)
			Me.OrdersInstantFeedbackView.Properties.AddRange(New DevExpress.Xpo.ServerViewProperty() {
				New DevExpress.Xpo.ServerViewProperty("Oid", DevExpress.Xpo.SortDirection.None, "[Oid]"),
				New DevExpress.Xpo.ServerViewProperty("Product Name", DevExpress.Xpo.SortDirection.None, "[ProductName]"),
				New DevExpress.Xpo.ServerViewProperty("Order Date", DevExpress.Xpo.SortDirection.None, "[OrderDate]"),
				New DevExpress.Xpo.ServerViewProperty("Freight", DevExpress.Xpo.SortDirection.None, "[Freight]")
			})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OrdersInstantFeedbackView.ResolveSession += new System.EventHandler<DevExpress.Xpo.ResolveSessionEventArgs>(this.OrdersInstantFeedbackView_ResolveSession);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OrdersInstantFeedbackView.DismissSession += new System.EventHandler<DevExpress.Xpo.ResolveSessionEventArgs>(this.OrdersInstantFeedbackView_DismissSession);
			' 
			' OrdersGridView
			' 
			Me.OrdersGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colOid, Me.colProductName, Me.colOrderDate, Me.colFreight})
			Me.OrdersGridView.GridControl = Me.OrdersGridControl
			Me.OrdersGridView.Name = "OrdersGridView"
			Me.OrdersGridView.OptionsBehavior.Editable = False
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OrdersGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.OrdersGridView_RowClick);
			' 
			' colOid
			' 
			Me.colOid.FieldName = "Oid"
			Me.colOid.Name = "colOid"
			' 
			' colProductName
			' 
			Me.colProductName.FieldName = "Product Name"
			Me.colProductName.Name = "colProductName"
			Me.colProductName.Visible = True
			Me.colProductName.VisibleIndex = 0
			' 
			' colOrderDate
			' 
			Me.colOrderDate.FieldName = "Order Date"
			Me.colOrderDate.Name = "colOrderDate"
			Me.colOrderDate.Visible = True
			Me.colOrderDate.VisibleIndex = 1
			' 
			' colFreight
			' 
			Me.colFreight.FieldName = "Freight"
			Me.colFreight.Name = "colFreight"
			Me.colFreight.Visible = True
			Me.colFreight.VisibleIndex = 2
			' 
			' ribbonControl1
			' 
			Me.ribbonControl1.ExpandCollapseItem.Id = 0
			Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.ribbonControl1.SearchEditItem, Me.btnNew, Me.btnDelete})
			Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
			Me.ribbonControl1.MaxItemId = 3
			Me.ribbonControl1.Name = "ribbonControl1"
			Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPage1})
			Me.ribbonControl1.Size = New System.Drawing.Size(800, 162)
			Me.ribbonControl1.StatusBar = Me.ribbonStatusBar1
			' 
			' btnNew
			' 
			Me.btnNew.Caption = "New" & vbCrLf & "Order"
			Me.btnNew.Id = 1
			Me.btnNew.ImageOptions.SvgImage = (CType(resources.GetObject("btnNew.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage))
			Me.btnNew.Name = "btnNew"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnNew_ItemClick);
			' 
			' btnDelete
			' 
			Me.btnDelete.Caption = "Delete"
			Me.btnDelete.Id = 2
			Me.btnDelete.ImageOptions.SvgImage = (CType(resources.GetObject("btnDelete.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage))
			Me.btnDelete.Name = "btnDelete"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDelete_ItemClick);
			' 
			' ribbonPage1
			' 
			Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.ribbonPageGroup1})
			Me.ribbonPage1.MergeOrder = 1
			Me.ribbonPage1.Name = "ribbonPage1"
			Me.ribbonPage1.Text = "Home"
			' 
			' ribbonPageGroup1
			' 
			Me.ribbonPageGroup1.ItemLinks.Add(Me.btnNew)
			Me.ribbonPageGroup1.ItemLinks.Add(Me.btnDelete)
			Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
			Me.ribbonPageGroup1.Text = "General"
			' 
			' ribbonStatusBar1
			' 
			Me.ribbonStatusBar1.Location = New System.Drawing.Point(0, 424)
			Me.ribbonStatusBar1.Name = "ribbonStatusBar1"
			Me.ribbonStatusBar1.Ribbon = Me.ribbonControl1
			Me.ribbonStatusBar1.Size = New System.Drawing.Size(800, 26)
			Me.ribbonStatusBar1.Visible = False
			' 
			' ribbonPage2
			' 
			Me.ribbonPage2.Name = "ribbonPage2"
			Me.ribbonPage2.Text = "ribbonPage2"
			' 
			' OrdersListForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(800, 450)
			Me.Controls.Add(Me.OrdersGridControl)
			Me.Controls.Add(Me.ribbonStatusBar1)
			Me.Controls.Add(Me.ribbonControl1)
			Me.Name = "OrdersListForm"
			Me.Ribbon = Me.ribbonControl1
			Me.StatusBar = Me.ribbonStatusBar1
			Me.Text = "Orders"
			CType(Me.OrdersGridControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.OrdersGridView, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region
		Private OrdersGridControl As DevExpress.XtraGrid.GridControl
		Private WithEvents OrdersGridView As DevExpress.XtraGrid.Views.Grid.GridView
		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private ribbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
		Private ribbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private WithEvents btnNew As DevExpress.XtraBars.BarButtonItem
		Private WithEvents btnDelete As DevExpress.XtraBars.BarButtonItem
		Private WithEvents OrdersInstantFeedbackView As DevExpress.Xpo.XPInstantFeedbackView
		Private colOid As DevExpress.XtraGrid.Columns.GridColumn
		Private colProductName As DevExpress.XtraGrid.Columns.GridColumn
		Private colOrderDate As DevExpress.XtraGrid.Columns.GridColumn
		Private colFreight As DevExpress.XtraGrid.Columns.GridColumn
	End Class

