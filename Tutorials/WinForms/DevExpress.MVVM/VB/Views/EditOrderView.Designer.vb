Namespace WinFormsApplication.Forms
	Partial Public Class EditOrderView
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
			Me.OrderLayoutControl = New DevExpress.XtraDataLayout.DataLayoutControl()
			Me.btnReload = New DevExpress.XtraEditors.SimpleButton()
			Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
			Me.ProductNameTextEdit = New DevExpress.XtraEditors.TextEdit()
			Me.OrderBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
			Me.OrderDateDateEdit = New DevExpress.XtraEditors.DateEdit()
			Me.FreightCalcEdit = New DevExpress.XtraEditors.CalcEdit()
			Me.lookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
			Me.CustomersBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
			Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.emptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
			Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.ItemForProductName = New DevExpress.XtraLayout.LayoutControlItem()
			Me.ItemForOrderDate = New DevExpress.XtraLayout.LayoutControlItem()
			Me.ItemForFreight = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.mvvmContext1 = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
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
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForProductName, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForFreight, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' OrderLayoutControl
			' 
			Me.OrderLayoutControl.Controls.Add(Me.btnReload)
			Me.OrderLayoutControl.Controls.Add(Me.btnSave)
			Me.OrderLayoutControl.Controls.Add(Me.ProductNameTextEdit)
			Me.OrderLayoutControl.Controls.Add(Me.OrderDateDateEdit)
			Me.OrderLayoutControl.Controls.Add(Me.FreightCalcEdit)
			Me.OrderLayoutControl.Controls.Add(Me.lookUpEdit1)
			Me.OrderLayoutControl.DataSource = Me.OrderBindingSource
			Me.OrderLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.OrderLayoutControl.Location = New System.Drawing.Point(0, 0)
			Me.OrderLayoutControl.Name = "OrderLayoutControl"
			Me.OrderLayoutControl.Root = Me.Root
			Me.OrderLayoutControl.Size = New System.Drawing.Size(290, 268)
			Me.OrderLayoutControl.TabIndex = 0
			Me.OrderLayoutControl.Text = "dataLayoutControl1"
			' 
			' btnReload
			' 
			Me.btnReload.Location = New System.Drawing.Point(102, 234)
			Me.btnReload.Name = "btnReload"
			Me.btnReload.Size = New System.Drawing.Size(86, 22)
			Me.btnReload.StyleController = Me.OrderLayoutControl
			Me.btnReload.TabIndex = 1
			Me.btnReload.Text = "&Reload"
			' 
			' btnSave
			' 
			Me.btnSave.Location = New System.Drawing.Point(192, 234)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New System.Drawing.Size(86, 22)
			Me.btnSave.StyleController = Me.OrderLayoutControl
			Me.btnSave.TabIndex = 1
			Me.btnSave.Text = "&Save"
			' 
			' ProductNameTextEdit
			' 
			Me.ProductNameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrderBindingSource, "ProductName", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
			Me.ProductNameTextEdit.Location = New System.Drawing.Point(82, 12)
			Me.ProductNameTextEdit.Name = "ProductNameTextEdit"
			Me.ProductNameTextEdit.Size = New System.Drawing.Size(196, 20)
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
			Me.OrderDateDateEdit.Size = New System.Drawing.Size(196, 20)
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
			Me.FreightCalcEdit.Size = New System.Drawing.Size(196, 20)
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
			Me.lookUpEdit1.Size = New System.Drawing.Size(196, 20)
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
			Me.Root.Size = New System.Drawing.Size(290, 268)
			Me.Root.TextVisible = False
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.AllowDrawBackground = False
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem1, Me.emptySpaceItem2, Me.emptySpaceItem1, Me.layoutControlItem2, Me.ItemForProductName, Me.ItemForOrderDate, Me.ItemForFreight, Me.layoutControlItem3})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "autoGeneratedGroup0"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(270, 248)
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.btnSave
			Me.layoutControlItem1.Location = New System.Drawing.Point(180, 222)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(90, 26)
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem1.TextVisible = False
			' 
			' emptySpaceItem2
			' 
			Me.emptySpaceItem2.AllowHotTrack = False
			Me.emptySpaceItem2.Location = New System.Drawing.Point(0, 96)
			Me.emptySpaceItem2.Name = "emptySpaceItem2"
			Me.emptySpaceItem2.Size = New System.Drawing.Size(270, 126)
			Me.emptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
			' 
			' emptySpaceItem1
			' 
			Me.emptySpaceItem1.AllowHotTrack = False
			Me.emptySpaceItem1.Location = New System.Drawing.Point(0, 222)
			Me.emptySpaceItem1.Name = "emptySpaceItem1"
			Me.emptySpaceItem1.Size = New System.Drawing.Size(90, 26)
			Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.btnReload
			Me.layoutControlItem2.Location = New System.Drawing.Point(90, 222)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(90, 26)
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem2.TextVisible = False
			' 
			' ItemForProductName
			' 
			Me.ItemForProductName.Control = Me.ProductNameTextEdit
			Me.ItemForProductName.Location = New System.Drawing.Point(0, 0)
			Me.ItemForProductName.Name = "ItemForProductName"
			Me.ItemForProductName.Size = New System.Drawing.Size(270, 24)
			Me.ItemForProductName.Text = "Product Name"
			Me.ItemForProductName.TextSize = New System.Drawing.Size(67, 13)
			' 
			' ItemForOrderDate
			' 
			Me.ItemForOrderDate.Control = Me.OrderDateDateEdit
			Me.ItemForOrderDate.Location = New System.Drawing.Point(0, 24)
			Me.ItemForOrderDate.Name = "ItemForOrderDate"
			Me.ItemForOrderDate.Size = New System.Drawing.Size(270, 24)
			Me.ItemForOrderDate.Text = "Order Date"
			Me.ItemForOrderDate.TextSize = New System.Drawing.Size(67, 13)
			' 
			' ItemForFreight
			' 
			Me.ItemForFreight.Control = Me.FreightCalcEdit
			Me.ItemForFreight.Location = New System.Drawing.Point(0, 48)
			Me.ItemForFreight.Name = "ItemForFreight"
			Me.ItemForFreight.Size = New System.Drawing.Size(270, 24)
			Me.ItemForFreight.Text = "Freight"
			Me.ItemForFreight.TextSize = New System.Drawing.Size(67, 13)
			' 
			' layoutControlItem3
			' 
			Me.layoutControlItem3.Control = Me.lookUpEdit1
			Me.layoutControlItem3.Location = New System.Drawing.Point(0, 72)
			Me.layoutControlItem3.Name = "ItemForCustomer!Key"
			Me.layoutControlItem3.Size = New System.Drawing.Size(270, 24)
			Me.layoutControlItem3.Text = "Customer"
			Me.layoutControlItem3.TextSize = New System.Drawing.Size(67, 13)
			' 
			' mvvmContext1
			' 
			Me.mvvmContext1.ContainerControl = Me
			Me.mvvmContext1.ViewModelType = GetType(WinFormsApplication.ViewModels.EditOrderViewModel)
			' 
			' EditOrderView
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(290, 268)
			Me.Controls.Add(Me.OrderLayoutControl)
			Me.Name = "EditOrderView"
			Me.Text = "Edit Order"
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
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForProductName, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForFreight, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private OrderBindingSource As DevExpress.Xpo.XPBindingSource
		Private OrderLayoutControl As DevExpress.XtraDataLayout.DataLayoutControl
		Private Root As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private btnSave As DevExpress.XtraEditors.SimpleButton
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private emptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
		Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
		Private btnReload As DevExpress.XtraEditors.SimpleButton
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
		Private ProductNameTextEdit As DevExpress.XtraEditors.TextEdit
		Private OrderDateDateEdit As DevExpress.XtraEditors.DateEdit
		Private FreightCalcEdit As DevExpress.XtraEditors.CalcEdit
		Private lookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
		Private ItemForProductName As DevExpress.XtraLayout.LayoutControlItem
		Private ItemForOrderDate As DevExpress.XtraLayout.LayoutControlItem
		Private ItemForFreight As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
		Private CustomersBindingSource As DevExpress.Xpo.XPBindingSource
		Private mvvmContext1 As DevExpress.Utils.MVVM.MVVMContext
	End Class
End Namespace
