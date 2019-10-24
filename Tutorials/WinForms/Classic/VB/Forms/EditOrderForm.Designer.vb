<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditOrderForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.OrderLayoutControl = New DevExpress.XtraDataLayout.DataLayoutControl()
        Me.btnReload = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.ProductNameTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.OrdersBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
        Me.OrderDateDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.FreightCalcEdit = New DevExpress.XtraEditors.CalcEdit()
        Me.LookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForProductName = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForOrderDate = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForFreight = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CustomersBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
        CType(Me.OrderLayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OrderLayoutControl.SuspendLayout
        CType(Me.ProductNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FreightCalcEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForProductName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForFreight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout
        '
        'OrderLayoutControl
        '
        Me.OrderLayoutControl.Controls.Add(Me.btnReload)
        Me.OrderLayoutControl.Controls.Add(Me.btnSave)
        Me.OrderLayoutControl.Controls.Add(Me.ProductNameTextEdit)
        Me.OrderLayoutControl.Controls.Add(Me.OrderDateDateEdit)
        Me.OrderLayoutControl.Controls.Add(Me.FreightCalcEdit)
        Me.OrderLayoutControl.Controls.Add(Me.LookUpEdit1)
        Me.OrderLayoutControl.DataSource = Me.OrdersBindingSource
        Me.OrderLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OrderLayoutControl.Location = New System.Drawing.Point(0, 0)
        Me.OrderLayoutControl.Name = "OrderLayoutControl"
        Me.OrderLayoutControl.Root = Me.Root
        Me.OrderLayoutControl.Size = New System.Drawing.Size(290, 268)
        Me.OrderLayoutControl.TabIndex = 0
        Me.OrderLayoutControl.Text = "DataLayoutControl1"
        '
        'btnReload
        '
        Me.btnReload.Location = New System.Drawing.Point(102, 234)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(86, 22)
        Me.btnReload.StyleController = Me.OrderLayoutControl
        Me.btnReload.TabIndex = 1
        Me.btnReload.Text = "&Reload"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(192, 234)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 22)
        Me.btnSave.StyleController = Me.OrderLayoutControl
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Save"
        '
        'ProductNameTextEdit
        '
        Me.ProductNameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrdersBindingSource, "ProductName", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ProductNameTextEdit.Location = New System.Drawing.Point(82, 12)
        Me.ProductNameTextEdit.Name = "ProductNameTextEdit"
        Me.ProductNameTextEdit.Size = New System.Drawing.Size(196, 20)
        Me.ProductNameTextEdit.StyleController = Me.OrderLayoutControl
        Me.ProductNameTextEdit.TabIndex = 6
        '
        'OrdersBindingSource
        '
        Me.OrdersBindingSource.DisplayableProperties = "ProductName;OrderDate;Freight;Customer!Key"
        Me.OrdersBindingSource.ObjectType = GetType(WinFormsApplication.XpoTutorial.Order)
        '
        'OrderDateDateEdit
        '
        Me.OrderDateDateEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrdersBindingSource, "OrderDate", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.OrderDateDateEdit.EditValue = Nothing
        Me.OrderDateDateEdit.Location = New System.Drawing.Point(82, 36)
        Me.OrderDateDateEdit.Name = "OrderDateDateEdit"
        Me.OrderDateDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OrderDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OrderDateDateEdit.Size = New System.Drawing.Size(196, 20)
        Me.OrderDateDateEdit.StyleController = Me.OrderLayoutControl
        Me.OrderDateDateEdit.TabIndex = 7
        '
        'FreightCalcEdit
        '
        Me.FreightCalcEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrdersBindingSource, "Freight", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FreightCalcEdit.Location = New System.Drawing.Point(82, 60)
        Me.FreightCalcEdit.Name = "FreightCalcEdit"
        Me.FreightCalcEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.FreightCalcEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.FreightCalcEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FreightCalcEdit.Properties.Mask.EditMask = "G"
        Me.FreightCalcEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.FreightCalcEdit.Size = New System.Drawing.Size(196, 20)
        Me.FreightCalcEdit.StyleController = Me.OrderLayoutControl
        Me.FreightCalcEdit.TabIndex = 8
        '
        'LookUpEdit1
        '
        Me.LookUpEdit1.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.OrdersBindingSource, "Customer!Key", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LookUpEdit1.Location = New System.Drawing.Point(82, 84)
        Me.LookUpEdit1.Name = "LookUpEdit1"
        Me.LookUpEdit1.Properties.Appearance.Options.UseTextOptions = True
        Me.LookUpEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit1.Properties.DataSource = Me.CustomersBindingSource
        Me.LookUpEdit1.Properties.DisplayMember = "ContactName"
        Me.LookUpEdit1.Properties.NullText = ""
        Me.LookUpEdit1.Properties.ValueMember = "Oid"
        Me.LookUpEdit1.Size = New System.Drawing.Size(196, 20)
        Me.LookUpEdit1.StyleController = Me.OrderLayoutControl
        Me.LookUpEdit1.TabIndex = 9
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(290, 268)
        Me.Root.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AllowDrawBackground = False
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.ItemForProductName, Me.ItemForOrderDate, Me.ItemForFreight, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "autoGeneratedGroup0"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(270, 248)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnSave
        Me.LayoutControlItem1.Location = New System.Drawing.Point(180, 222)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(90, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 96)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(270, 126)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 222)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(90, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnReload
        Me.LayoutControlItem2.Location = New System.Drawing.Point(90, 222)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(90, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'ItemForProductName
        '
        Me.ItemForProductName.Control = Me.ProductNameTextEdit
        Me.ItemForProductName.Location = New System.Drawing.Point(0, 0)
        Me.ItemForProductName.Name = "ItemForProductName"
        Me.ItemForProductName.Size = New System.Drawing.Size(270, 24)
        Me.ItemForProductName.Text = "Product Name"
        Me.ItemForProductName.TextSize = New System.Drawing.Size(67, 13)
        '
        'ItemForOrderDate
        '
        Me.ItemForOrderDate.Control = Me.OrderDateDateEdit
        Me.ItemForOrderDate.Location = New System.Drawing.Point(0, 24)
        Me.ItemForOrderDate.Name = "ItemForOrderDate"
        Me.ItemForOrderDate.Size = New System.Drawing.Size(270, 24)
        Me.ItemForOrderDate.Text = "Order Date"
        Me.ItemForOrderDate.TextSize = New System.Drawing.Size(67, 13)
        '
        'ItemForFreight
        '
        Me.ItemForFreight.Control = Me.FreightCalcEdit
        Me.ItemForFreight.Location = New System.Drawing.Point(0, 48)
        Me.ItemForFreight.Name = "ItemForFreight"
        Me.ItemForFreight.Size = New System.Drawing.Size(270, 24)
        Me.ItemForFreight.Text = "Freight"
        Me.ItemForFreight.TextSize = New System.Drawing.Size(67, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.LookUpEdit1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem3.Name = "ItemForCustomer!Key"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(270, 24)
        Me.LayoutControlItem3.Text = "Customer"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(67, 13)
        '
        'CustomersBindingSource
        '
        Me.CustomersBindingSource.DisplayableProperties = "Oid;ContactName"
        Me.CustomersBindingSource.ObjectType = GetType(WinFormsApplication.XpoTutorial.Customer)
        '
        'EditOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 268)
        Me.Controls.Add(Me.OrderLayoutControl)
        Me.Name = "EditOrderForm"
        Me.Text = "Edit Order"
        CType(Me.OrderLayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OrderLayoutControl.ResumeLayout(False)
        CType(Me.ProductNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FreightCalcEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForProductName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForFreight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OrdersBindingSource As DevExpress.Xpo.XPBindingSource
    Friend WithEvents OrderLayoutControl As DevExpress.XtraDataLayout.DataLayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents btnReload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ProductNameTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents OrderDateDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents FreightCalcEdit As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents LookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ItemForProductName As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForOrderDate As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForFreight As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CustomersBindingSource As DevExpress.Xpo.XPBindingSource
End Class
