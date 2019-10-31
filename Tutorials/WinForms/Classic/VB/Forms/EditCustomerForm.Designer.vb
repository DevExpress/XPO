<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditCustomerForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CustomersLayoutControl = New DevExpress.XtraDataLayout.DataLayoutControl()
        Me.btnReload = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.FirstNameTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LastNameTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.ItemForFirstName = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForLastName = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.customerXPBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
        CType(Me.CustomersLayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomersLayoutControl.SuspendLayout()
        CType(Me.FirstNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LastNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForFirstName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForLastName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.customerXPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomersLayoutControl
        '
        Me.CustomersLayoutControl.Controls.Add(Me.btnReload)
        Me.CustomersLayoutControl.Controls.Add(Me.btnSave)
        Me.CustomersLayoutControl.Controls.Add(Me.FirstNameTextEdit)
        Me.CustomersLayoutControl.Controls.Add(Me.LastNameTextEdit)
        Me.CustomersLayoutControl.DataSource = Me.customerXPBindingSource
        Me.CustomersLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomersLayoutControl.Location = New System.Drawing.Point(0, 0)
        Me.CustomersLayoutControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CustomersLayoutControl.Name = "CustomersLayoutControl"
        Me.CustomersLayoutControl.Root = Me.Root
        Me.CustomersLayoutControl.Size = New System.Drawing.Size(338, 330)
        Me.CustomersLayoutControl.TabIndex = 0
        Me.CustomersLayoutControl.Text = "DataLayoutControl1"
        '
        'btnReload
        '
        Me.btnReload.Location = New System.Drawing.Point(123, 289)
        Me.btnReload.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(98, 27)
        Me.btnReload.StyleController = Me.CustomersLayoutControl
        Me.btnReload.TabIndex = 1
        Me.btnReload.Text = "&Reload"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(225, 289)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(99, 27)
        Me.btnSave.StyleController = Me.CustomersLayoutControl
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Save"
        '
        'FirstNameTextEdit
        '
        Me.FirstNameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.customerXPBindingSource, "FirstName", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FirstNameTextEdit.Location = New System.Drawing.Point(79, 14)
        Me.FirstNameTextEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FirstNameTextEdit.Name = "FirstNameTextEdit"
        Me.FirstNameTextEdit.Size = New System.Drawing.Size(245, 22)
        Me.FirstNameTextEdit.StyleController = Me.CustomersLayoutControl
        Me.FirstNameTextEdit.TabIndex = 4
        '
        'LastNameTextEdit
        '
        Me.LastNameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.customerXPBindingSource, "LastName", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LastNameTextEdit.Location = New System.Drawing.Point(79, 40)
        Me.LastNameTextEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LastNameTextEdit.Name = "LastNameTextEdit"
        Me.LastNameTextEdit.Size = New System.Drawing.Size(245, 22)
        Me.LastNameTextEdit.StyleController = Me.CustomersLayoutControl
        Me.LastNameTextEdit.TabIndex = 5
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(338, 330)
        Me.Root.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AllowDrawBackground = False
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.ItemForFirstName, Me.ItemForLastName, Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem1, Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "autoGeneratedGroup0"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(314, 306)
        '
        'ItemForFirstName
        '
        Me.ItemForFirstName.Control = Me.FirstNameTextEdit
        Me.ItemForFirstName.Location = New System.Drawing.Point(0, 0)
        Me.ItemForFirstName.Name = "ItemForFirstName"
        Me.ItemForFirstName.Size = New System.Drawing.Size(314, 26)
        Me.ItemForFirstName.Text = "First Name"
        Me.ItemForFirstName.TextSize = New System.Drawing.Size(62, 16)
        '
        'ItemForLastName
        '
        Me.ItemForLastName.Control = Me.LastNameTextEdit
        Me.ItemForLastName.Location = New System.Drawing.Point(0, 26)
        Me.ItemForLastName.Name = "ItemForLastName"
        Me.ItemForLastName.Size = New System.Drawing.Size(314, 26)
        Me.ItemForLastName.Text = "Last Name"
        Me.ItemForLastName.TextSize = New System.Drawing.Size(62, 16)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnSave
        Me.LayoutControlItem1.Location = New System.Drawing.Point(211, 275)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(103, 31)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 52)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(314, 223)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 275)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(109, 31)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnReload
        Me.LayoutControlItem2.Location = New System.Drawing.Point(109, 275)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(102, 31)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'customerXPBindingSource
        '
        Me.customerXPBindingSource.DisplayableProperties = "FirstName;LastName"
        Me.customerXPBindingSource.ObjectType = GetType(WinFormsApplication.XpoTutorial.Customer)
        '
        'EditCustomerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 330)
        Me.Controls.Add(Me.CustomersLayoutControl)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "EditCustomerForm"
        Me.Text = "Edit Customer"
        CType(Me.CustomersLayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomersLayoutControl.ResumeLayout(False)
        CType(Me.FirstNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LastNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForFirstName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForLastName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.customerXPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CustomersLayoutControl As DevExpress.XtraDataLayout.DataLayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents FirstNameTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LastNameTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents ItemForFirstName As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForLastName As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents btnReload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents customerXPBindingSource As DevExpress.Xpo.XPBindingSource
End Class
