	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Public Class EditOrderForm
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(EditOrderForm))
			Me.OrderLayoutControl = New DevExpress.XtraDataLayout.DataLayoutControl()
			Me.ProductNameTextEdit = New DevExpress.XtraEditors.TextEdit()
			Me.OrderBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
			Me.OrderDateDateEdit = New DevExpress.XtraEditors.DateEdit()
			Me.FreightCalcEdit = New DevExpress.XtraEditors.CalcEdit()
			Me.lookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
			Me.CustomersBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
			Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.emptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
			Me.ItemForProductName = New DevExpress.XtraLayout.LayoutControlItem()
			Me.ItemForOrderDate = New DevExpress.XtraLayout.LayoutControlItem()
			Me.ItemForFreight = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.btnSave = New DevExpress.XtraBars.BarButtonItem()
			Me.btnReload = New DevExpress.XtraBars.BarButtonItem()
			Me.btnClose = New DevExpress.XtraBars.BarButtonItem()
			Me.ribbonPageHome = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.ribbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
			Me.ribbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			CType(Me.OrderLayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.OrderLayoutControl.SuspendLayout()
			CType(Me.ProductNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.OrderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.OrderDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.OrderDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.FreightCalcEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.lookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForProductName, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForFreight, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' OrderLayoutControl
			' 
			Me.OrderLayoutControl.Controls.Add(Me.ProductNameTextEdit)
			Me.OrderLayoutControl.Controls.Add(Me.OrderDateDateEdit)
			Me.OrderLayoutControl.Controls.Add(Me.FreightCalcEdit)
			Me.OrderLayoutControl.Controls.Add(Me.lookUpEdit1)
			Me.OrderLayoutControl.DataSource = Me.OrderBindingSource
			Me.OrderLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.OrderLayoutControl.Location = New System.Drawing.Point(0, 162)
			Me.OrderLayoutControl.Name = "OrderLayoutControl"
			Me.OrderLayoutControl.Root = Me.Root
			Me.OrderLayoutControl.Size = New System.Drawing.Size(350, 138)
			Me.OrderLayoutControl.TabIndex = 0
			Me.OrderLayoutControl.Text = "dataLayoutControl1"
			' 
			' ProductNameTextEdit
			' 
			Me.ProductNameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrderBindingSource, "ProductName", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
			Me.ProductNameTextEdit.Location = New System.Drawing.Point(82, 12)
			Me.ProductNameTextEdit.Name = "ProductNameTextEdit"
			Me.ProductNameTextEdit.Size = New System.Drawing.Size(256, 20)
			Me.ProductNameTextEdit.StyleController = Me.OrderLayoutControl
			Me.ProductNameTextEdit.TabIndex = 6
			' 
			' OrderBindingSource
			' 
			Me.OrderBindingSource.DisplayableProperties = "ProductName;OrderDate;Freight;Customer!Key"
			Me.OrderBindingSource.ObjectType = GetType(XpoTutorial.Order)
			' 
			' OrderDateDateEdit
			' 
			Me.OrderDateDateEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrderBindingSource, "OrderDate", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
			Me.OrderDateDateEdit.EditValue = Nothing
			Me.OrderDateDateEdit.Location = New System.Drawing.Point(82, 36)
			Me.OrderDateDateEdit.Name = "OrderDateDateEdit"
			Me.OrderDateDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.OrderDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.OrderDateDateEdit.Size = New System.Drawing.Size(256, 20)
			Me.OrderDateDateEdit.StyleController = Me.OrderLayoutControl
			Me.OrderDateDateEdit.TabIndex = 7
			' 
			' FreightCalcEdit
			' 
			Me.FreightCalcEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrderBindingSource, "Freight", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
			Me.FreightCalcEdit.Location = New System.Drawing.Point(82, 60)
			Me.FreightCalcEdit.Name = "FreightCalcEdit"
			Me.FreightCalcEdit.Properties.Appearance.Options.UseTextOptions = True
			Me.FreightCalcEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
			Me.FreightCalcEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.FreightCalcEdit.Properties.Mask.EditMask = "G"
			Me.FreightCalcEdit.Properties.Mask.UseMaskAsDisplayFormat = True
			Me.FreightCalcEdit.Size = New System.Drawing.Size(256, 20)
			Me.FreightCalcEdit.StyleController = Me.OrderLayoutControl
			Me.FreightCalcEdit.TabIndex = 8
			' 
			' lookUpEdit1
			' 
			Me.lookUpEdit1.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrderBindingSource, "Customer!Key", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
			Me.lookUpEdit1.Location = New System.Drawing.Point(82, 84)
			Me.lookUpEdit1.Name = "lookUpEdit1"
			Me.lookUpEdit1.Properties.Appearance.Options.UseTextOptions = True
			Me.lookUpEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
			Me.lookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.lookUpEdit1.Properties.DataSource = Me.CustomersBindingSource
			Me.lookUpEdit1.Properties.DisplayMember = "ContactName"
			Me.lookUpEdit1.Properties.NullText = ""
			Me.lookUpEdit1.Properties.ValueMember = "Oid"
			Me.lookUpEdit1.Size = New System.Drawing.Size(256, 20)
			Me.lookUpEdit1.StyleController = Me.OrderLayoutControl
			Me.lookUpEdit1.TabIndex = 9
			' 
			' CustomersBindingSource
			' 
			Me.CustomersBindingSource.DisplayableProperties = "Oid;ContactName"
			Me.CustomersBindingSource.ObjectType = GetType(XpoTutorial.Customer)
			' 
			' Root
			' 
			Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.Root.GroupBordersVisible = False
			Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlGroup1})
			Me.Root.Name = "Root"
			Me.Root.Size = New System.Drawing.Size(350, 138)
			Me.Root.TextVisible = False
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.AllowDrawBackground = False
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.emptySpaceItem2, Me.ItemForProductName, Me.ItemForOrderDate, Me.ItemForFreight, Me.layoutControlItem3})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "autoGeneratedGroup0"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(330, 118)
			' 
			' emptySpaceItem2
			' 
			Me.emptySpaceItem2.AllowHotTrack = False
			Me.emptySpaceItem2.Location = New System.Drawing.Point(0, 96)
			Me.emptySpaceItem2.Name = "emptySpaceItem2"
			Me.emptySpaceItem2.Size = New System.Drawing.Size(330, 22)
			Me.emptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
			' 
			' ItemForProductName
			' 
			Me.ItemForProductName.Control = Me.ProductNameTextEdit
			Me.ItemForProductName.Location = New System.Drawing.Point(0, 0)
			Me.ItemForProductName.Name = "ItemForProductName"
			Me.ItemForProductName.Size = New System.Drawing.Size(330, 24)
			Me.ItemForProductName.Text = "Product Name"
			Me.ItemForProductName.TextSize = New System.Drawing.Size(67, 13)
			' 
			' ItemForOrderDate
			' 
			Me.ItemForOrderDate.Control = Me.OrderDateDateEdit
			Me.ItemForOrderDate.Location = New System.Drawing.Point(0, 24)
			Me.ItemForOrderDate.Name = "ItemForOrderDate"
			Me.ItemForOrderDate.Size = New System.Drawing.Size(330, 24)
			Me.ItemForOrderDate.Text = "Order Date"
			Me.ItemForOrderDate.TextSize = New System.Drawing.Size(67, 13)
			' 
			' ItemForFreight
			' 
			Me.ItemForFreight.Control = Me.FreightCalcEdit
			Me.ItemForFreight.Location = New System.Drawing.Point(0, 48)
			Me.ItemForFreight.Name = "ItemForFreight"
			Me.ItemForFreight.Size = New System.Drawing.Size(330, 24)
			Me.ItemForFreight.Text = "Freight"
			Me.ItemForFreight.TextSize = New System.Drawing.Size(67, 13)
			' 
			' layoutControlItem3
			' 
			Me.layoutControlItem3.Control = Me.lookUpEdit1
			Me.layoutControlItem3.Location = New System.Drawing.Point(0, 72)
			Me.layoutControlItem3.Name = "ItemForCustomer!Key"
			Me.layoutControlItem3.Size = New System.Drawing.Size(330, 24)
			Me.layoutControlItem3.Text = "Customer"
			Me.layoutControlItem3.TextSize = New System.Drawing.Size(67, 13)
			' 
			' ribbonControl1
			' 
			Me.ribbonControl1.ExpandCollapseItem.Id = 0
			Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.ribbonControl1.SearchEditItem, Me.btnSave, Me.btnReload, Me.btnClose})
			Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
			Me.ribbonControl1.MaxItemId = 4
			Me.ribbonControl1.Name = "ribbonControl1"
			Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPageHome})
			Me.ribbonControl1.Size = New System.Drawing.Size(350, 162)
			Me.ribbonControl1.StatusBar = Me.ribbonStatusBar1
			' 
			' btnSave
			' 
			Me.btnSave.Caption = "Save"
			Me.btnSave.Id = 1
			Me.btnSave.ImageOptions.SvgImage = (CType(resources.GetObject("btnSave.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage))
			Me.btnSave.Name = "btnSave"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
			' 
			' btnReload
			' 
			Me.btnReload.Caption = "Reload"
			Me.btnReload.Id = 2
			Me.btnReload.ImageOptions.SvgImage = (CType(resources.GetObject("btnReload.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage))
			Me.btnReload.Name = "btnReload"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
			' 
			' btnClose
			' 
			Me.btnClose.Caption = "Close"
			Me.btnClose.Id = 3
			Me.btnClose.ImageOptions.SvgImage = (CType(resources.GetObject("btnClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage))
			Me.btnClose.Name = "btnClose"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
			' 
			' ribbonPageHome
			' 
			Me.ribbonPageHome.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.ribbonPageGroup1})
			Me.ribbonPageHome.MergeOrder = 1
			Me.ribbonPageHome.Name = "ribbonPageHome"
			Me.ribbonPageHome.Text = "Home"
			' 
			' ribbonPageGroup1
			' 
			Me.ribbonPageGroup1.ItemLinks.Add(Me.btnSave)
			Me.ribbonPageGroup1.ItemLinks.Add(Me.btnReload)
			Me.ribbonPageGroup1.ItemLinks.Add(Me.btnClose, True)
			Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
			Me.ribbonPageGroup1.Text = "Edit"
			' 
			' ribbonStatusBar1
			' 
			Me.ribbonStatusBar1.Location = New System.Drawing.Point(0, 300)
			Me.ribbonStatusBar1.Name = "ribbonStatusBar1"
			Me.ribbonStatusBar1.Ribbon = Me.ribbonControl1
			Me.ribbonStatusBar1.Size = New System.Drawing.Size(350, 26)
			Me.ribbonStatusBar1.Visible = False
			' 
			' ribbonPage2
			' 
			Me.ribbonPage2.Name = "ribbonPage2"
			Me.ribbonPage2.Text = "ribbonPage2"
			' 
			' EditOrderForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(350, 326)
			Me.Controls.Add(Me.OrderLayoutControl)
			Me.Controls.Add(Me.ribbonStatusBar1)
			Me.Controls.Add(Me.ribbonControl1)
			Me.Name = "EditOrderForm"
			Me.Ribbon = Me.ribbonControl1
			Me.StatusBar = Me.ribbonStatusBar1
			Me.Text = "Edit Order"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.EditCustomerForm_Load);
			CType(Me.OrderLayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
			Me.OrderLayoutControl.ResumeLayout(False)
			CType(Me.ProductNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.OrderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.OrderDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.OrderDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.FreightCalcEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.lookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForProductName, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForFreight, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private OrderBindingSource As DevExpress.Xpo.XPBindingSource
		Private OrderLayoutControl As DevExpress.XtraDataLayout.DataLayoutControl
		Private Root As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private emptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
		Private ProductNameTextEdit As DevExpress.XtraEditors.TextEdit
		Private OrderDateDateEdit As DevExpress.XtraEditors.DateEdit
		Private FreightCalcEdit As DevExpress.XtraEditors.CalcEdit
		Private lookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
		Private ItemForProductName As DevExpress.XtraLayout.LayoutControlItem
		Private ItemForOrderDate As DevExpress.XtraLayout.LayoutControlItem
		Private ItemForFreight As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
		Private CustomersBindingSource As DevExpress.Xpo.XPBindingSource
		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonPageHome As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private ribbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
		Private ribbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private WithEvents btnSave As DevExpress.XtraBars.BarButtonItem
		Private WithEvents btnReload As DevExpress.XtraBars.BarButtonItem
		Private WithEvents btnClose As DevExpress.XtraBars.BarButtonItem
	End Class
