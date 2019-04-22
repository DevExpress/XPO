Namespace WinFormsApplication.Forms
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
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.btnSave = New DevExpress.XtraBars.BarButtonItem()
			Me.btnClose = New DevExpress.XtraBars.BarButtonItem()
			Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
			Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.ribbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.dataLayoutControl1 = New DevExpress.XtraDataLayout.DataLayoutControl()
			Me.ProductNameTextEdit = New DevExpress.XtraEditors.TextEdit()
			Me.OrdersBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
			Me.OrderDateDateEdit = New DevExpress.XtraEditors.DateEdit()
			Me.FreightCalcEdit = New DevExpress.XtraEditors.CalcEdit()
			Me.CustomerEditor = New DevExpress.XtraEditors.LookUpEdit()
			Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.ItemForProductName = New DevExpress.XtraLayout.LayoutControlItem()
			Me.ItemForOrderDate = New DevExpress.XtraLayout.LayoutControlItem()
			Me.ItemForFreight = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataLayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.dataLayoutControl1.SuspendLayout()
			CType(Me.ProductNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.OrderDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.OrderDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.FreightCalcEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.CustomerEditor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForProductName, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForFreight, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' ribbonControl1
			' 
			Me.ribbonControl1.ExpandCollapseItem.Id = 0
			Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.ribbonControl1.SearchEditItem, Me.btnSave, Me.btnClose, Me.btnRefresh})
			Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
			Me.ribbonControl1.MaxItemId = 4
			Me.ribbonControl1.Name = "ribbonControl1"
			Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPage1})
			Me.ribbonControl1.Size = New System.Drawing.Size(800, 162)
			' 
			' btnSave
			' 
			Me.btnSave.Caption = "Save"
			Me.btnSave.CausesValidation = True
			Me.btnSave.Enabled = False
			Me.btnSave.Id = 1
			Me.btnSave.Name = "btnSave"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
			' 
			' btnClose
			' 
			Me.btnClose.Caption = "Close"
			Me.btnClose.Id = 2
			Me.btnClose.Name = "btnClose"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
			' 
			' btnRefresh
			' 
			Me.btnRefresh.Caption = "Refresh"
			Me.btnRefresh.Enabled = False
			Me.btnRefresh.Id = 3
			Me.btnRefresh.Name = "btnRefresh"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
			' 
			' ribbonPage1
			' 
			Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.ribbonPageGroup1})
			Me.ribbonPage1.Name = "ribbonPage1"
			Me.ribbonPage1.Text = "Home"
			' 
			' ribbonPageGroup1
			' 
			Me.ribbonPageGroup1.ItemLinks.Add(Me.btnSave)
			Me.ribbonPageGroup1.ItemLinks.Add(Me.btnClose)
			Me.ribbonPageGroup1.ItemLinks.Add(Me.btnRefresh)
			Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
			Me.ribbonPageGroup1.Text = "Edit"
			' 
			' ribbonPage2
			' 
			Me.ribbonPage2.Name = "ribbonPage2"
			Me.ribbonPage2.Text = "ribbonPage2"
			' 
			' dataLayoutControl1
			' 
			Me.dataLayoutControl1.Controls.Add(Me.ProductNameTextEdit)
			Me.dataLayoutControl1.Controls.Add(Me.OrderDateDateEdit)
			Me.dataLayoutControl1.Controls.Add(Me.FreightCalcEdit)
			Me.dataLayoutControl1.Controls.Add(Me.CustomerEditor)
			Me.dataLayoutControl1.DataSource = Me.OrdersBindingSource
			Me.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.dataLayoutControl1.Location = New System.Drawing.Point(0, 162)
			Me.dataLayoutControl1.Name = "dataLayoutControl1"
			Me.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1126, 140, 650, 400)
			Me.dataLayoutControl1.Root = Me.Root
			Me.dataLayoutControl1.Size = New System.Drawing.Size(800, 284)
			Me.dataLayoutControl1.TabIndex = 2
			Me.dataLayoutControl1.Text = "dataLayoutControl1"
			' 
			' ProductNameTextEdit
			' 
			Me.ProductNameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrdersBindingSource, "ProductName", True))
			Me.ProductNameTextEdit.Location = New System.Drawing.Point(82, 12)
			Me.ProductNameTextEdit.MenuManager = Me.ribbonControl1
			Me.ProductNameTextEdit.Name = "ProductNameTextEdit"
			Me.ProductNameTextEdit.Size = New System.Drawing.Size(706, 20)
			Me.ProductNameTextEdit.StyleController = Me.dataLayoutControl1
			Me.ProductNameTextEdit.TabIndex = 4
			' 
			' OrdersBindingSource
			' 
			Me.OrdersBindingSource.DisplayableProperties = "ProductName;OrderDate;Freight;Customer!Key"
			Me.OrdersBindingSource.ObjectType = GetType(XpoTutorial.Order)
			' 
			' OrderDateDateEdit
			' 
			Me.OrderDateDateEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrdersBindingSource, "OrderDate", True))
			Me.OrderDateDateEdit.EditValue = Nothing
			Me.OrderDateDateEdit.Location = New System.Drawing.Point(82, 36)
			Me.OrderDateDateEdit.MenuManager = Me.ribbonControl1
			Me.OrderDateDateEdit.Name = "OrderDateDateEdit"
			Me.OrderDateDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.OrderDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.OrderDateDateEdit.Size = New System.Drawing.Size(706, 20)
			Me.OrderDateDateEdit.StyleController = Me.dataLayoutControl1
			Me.OrderDateDateEdit.TabIndex = 5
			' 
			' FreightCalcEdit
			' 
			Me.FreightCalcEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrdersBindingSource, "Freight", True))
			Me.FreightCalcEdit.Location = New System.Drawing.Point(82, 60)
			Me.FreightCalcEdit.MenuManager = Me.ribbonControl1
			Me.FreightCalcEdit.Name = "FreightCalcEdit"
			Me.FreightCalcEdit.Properties.Appearance.Options.UseTextOptions = True
			Me.FreightCalcEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
			Me.FreightCalcEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.FreightCalcEdit.Properties.Mask.EditMask = "G"
			Me.FreightCalcEdit.Properties.Mask.UseMaskAsDisplayFormat = True
			Me.FreightCalcEdit.Size = New System.Drawing.Size(706, 20)
			Me.FreightCalcEdit.StyleController = Me.dataLayoutControl1
			Me.FreightCalcEdit.TabIndex = 6
			' 
			' CustomerEditor
			' 
			Me.CustomerEditor.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrdersBindingSource, "Customer!Key", True))
			Me.CustomerEditor.Location = New System.Drawing.Point(82, 84)
			Me.CustomerEditor.MenuManager = Me.ribbonControl1
			Me.CustomerEditor.Name = "CustomerEditor"
			Me.CustomerEditor.Properties.Appearance.Options.UseTextOptions = True
			Me.CustomerEditor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
			Me.CustomerEditor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.CustomerEditor.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() { New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContactName", "Contact Name")})
			Me.CustomerEditor.Properties.DisplayMember = "ContactName"
			Me.CustomerEditor.Properties.NullText = ""
			Me.CustomerEditor.Properties.ValueMember = "Oid"
			Me.CustomerEditor.Size = New System.Drawing.Size(706, 20)
			Me.CustomerEditor.StyleController = Me.dataLayoutControl1
			Me.CustomerEditor.TabIndex = 7
			' 
			' Root
			' 
			Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.Root.GroupBordersVisible = False
			Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlGroup1})
			Me.Root.Name = "Root"
			Me.Root.Size = New System.Drawing.Size(800, 284)
			Me.Root.TextVisible = False
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.AllowDrawBackground = False
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.ItemForProductName, Me.ItemForOrderDate, Me.ItemForFreight, Me.layoutControlItem1})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "autoGeneratedGroup0"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(780, 264)
			' 
			' ItemForProductName
			' 
			Me.ItemForProductName.Control = Me.ProductNameTextEdit
			Me.ItemForProductName.Location = New System.Drawing.Point(0, 0)
			Me.ItemForProductName.Name = "ItemForProductName"
			Me.ItemForProductName.Size = New System.Drawing.Size(780, 24)
			Me.ItemForProductName.Text = "Product Name"
			Me.ItemForProductName.TextSize = New System.Drawing.Size(67, 13)
			' 
			' ItemForOrderDate
			' 
			Me.ItemForOrderDate.Control = Me.OrderDateDateEdit
			Me.ItemForOrderDate.Location = New System.Drawing.Point(0, 24)
			Me.ItemForOrderDate.Name = "ItemForOrderDate"
			Me.ItemForOrderDate.Size = New System.Drawing.Size(780, 24)
			Me.ItemForOrderDate.Text = "Order Date"
			Me.ItemForOrderDate.TextSize = New System.Drawing.Size(67, 13)
			' 
			' ItemForFreight
			' 
			Me.ItemForFreight.Control = Me.FreightCalcEdit
			Me.ItemForFreight.Location = New System.Drawing.Point(0, 48)
			Me.ItemForFreight.Name = "ItemForFreight"
			Me.ItemForFreight.Size = New System.Drawing.Size(780, 24)
			Me.ItemForFreight.Text = "Freight"
			Me.ItemForFreight.TextSize = New System.Drawing.Size(67, 13)
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.CustomerEditor
			Me.layoutControlItem1.Location = New System.Drawing.Point(0, 72)
			Me.layoutControlItem1.Name = "ItemForCustomer!Key"
			Me.layoutControlItem1.Size = New System.Drawing.Size(780, 192)
			Me.layoutControlItem1.Text = "Customer"
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(67, 13)
			' 
			' EditOrderForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(800, 446)
			Me.Controls.Add(Me.dataLayoutControl1)
			Me.Controls.Add(Me.ribbonControl1)
			Me.Name = "EditOrderForm"
			Me.Ribbon = Me.ribbonControl1
			Me.Text = "Edit Order"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.EditOrderForm_Load);
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataLayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.dataLayoutControl1.ResumeLayout(False)
			CType(Me.ProductNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.OrderDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.OrderDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.FreightCalcEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.CustomerEditor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForProductName, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForFreight, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private ribbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private WithEvents btnSave As DevExpress.XtraBars.BarButtonItem
		Private WithEvents btnClose As DevExpress.XtraBars.BarButtonItem
		Private dataLayoutControl1 As DevExpress.XtraDataLayout.DataLayoutControl
		Private Root As DevExpress.XtraLayout.LayoutControlGroup
		Private ProductNameTextEdit As DevExpress.XtraEditors.TextEdit
		Private OrderDateDateEdit As DevExpress.XtraEditors.DateEdit
		Private FreightCalcEdit As DevExpress.XtraEditors.CalcEdit
		Private CustomerEditor As DevExpress.XtraEditors.LookUpEdit
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private ItemForProductName As DevExpress.XtraLayout.LayoutControlItem
		Private ItemForOrderDate As DevExpress.XtraLayout.LayoutControlItem
		Private ItemForFreight As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
		Private OrdersBindingSource As DevExpress.Xpo.XPBindingSource
	End Class
End Namespace