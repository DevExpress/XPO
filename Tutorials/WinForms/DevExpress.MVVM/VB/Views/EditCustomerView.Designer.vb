Namespace WinFormsApplication.Views
	Partial Public Class EditCustomerView
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
			Me.CustomerLayoutControl = New DevExpress.XtraDataLayout.DataLayoutControl()
			Me.btnReload = New DevExpress.XtraEditors.SimpleButton()
			Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
			Me.FirstNameTextEdit = New DevExpress.XtraEditors.TextEdit()
			Me.CustomerBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
			Me.LastNameTextEdit = New DevExpress.XtraEditors.TextEdit()
			Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.ItemForFirstName = New DevExpress.XtraLayout.LayoutControlItem()
			Me.ItemForLastName = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.emptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
			Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.mvvmContext1 = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
			CType(Me.CustomerLayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.CustomerLayoutControl.SuspendLayout()
			CType(Me.FirstNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.LastNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForFirstName, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForLastName, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' CustomerLayoutControl
			' 
			Me.CustomerLayoutControl.Controls.Add(Me.btnReload)
			Me.CustomerLayoutControl.Controls.Add(Me.btnSave)
			Me.CustomerLayoutControl.Controls.Add(Me.FirstNameTextEdit)
			Me.CustomerLayoutControl.Controls.Add(Me.LastNameTextEdit)
			Me.CustomerLayoutControl.DataSource = Me.CustomerBindingSource
			Me.CustomerLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.CustomerLayoutControl.Location = New System.Drawing.Point(0, 0)
			Me.CustomerLayoutControl.Name = "CustomerLayoutControl"
			Me.CustomerLayoutControl.Root = Me.Root
			Me.CustomerLayoutControl.Size = New System.Drawing.Size(290, 268)
			Me.CustomerLayoutControl.TabIndex = 0
			Me.CustomerLayoutControl.Text = "dataLayoutControl1"
			' 
			' btnReload
			' 
			Me.btnReload.Location = New System.Drawing.Point(95, 234)
			Me.btnReload.Name = "btnReload"
			Me.btnReload.Size = New System.Drawing.Size(89, 22)
			Me.btnReload.StyleController = Me.CustomerLayoutControl
			Me.btnReload.TabIndex = 1
			Me.btnReload.Text = "&Reload"
			' 
			' btnSave
			' 
			Me.btnSave.Location = New System.Drawing.Point(188, 234)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New System.Drawing.Size(90, 22)
			Me.btnSave.StyleController = Me.CustomerLayoutControl
			Me.btnSave.TabIndex = 1
			Me.btnSave.Text = "&Save"
			' 
			' FirstNameTextEdit
			' 
			Me.FirstNameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.CustomerBindingSource, "FirstName", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
			Me.FirstNameTextEdit.Location = New System.Drawing.Point(66, 12)
			Me.FirstNameTextEdit.Name = "FirstNameTextEdit"
			Me.FirstNameTextEdit.Size = New System.Drawing.Size(212, 20)
			Me.FirstNameTextEdit.StyleController = Me.CustomerLayoutControl
			Me.FirstNameTextEdit.TabIndex = 4
			' 
			' CustomerBindingSource
			' 
			Me.CustomerBindingSource.DisplayableProperties = "FirstName;LastName"
			Me.CustomerBindingSource.ObjectType = GetType(XpoTutorial.Customer)
			' 
			' LastNameTextEdit
			' 
			Me.LastNameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.CustomerBindingSource, "LastName", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
			Me.LastNameTextEdit.Location = New System.Drawing.Point(66, 36)
			Me.LastNameTextEdit.Name = "LastNameTextEdit"
			Me.LastNameTextEdit.Size = New System.Drawing.Size(212, 20)
			Me.LastNameTextEdit.StyleController = Me.CustomerLayoutControl
			Me.LastNameTextEdit.TabIndex = 5
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
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.ItemForFirstName, Me.ItemForLastName, Me.layoutControlItem1, Me.emptySpaceItem2, Me.emptySpaceItem1, Me.layoutControlItem2})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "autoGeneratedGroup0"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(270, 248)
			' 
			' ItemForFirstName
			' 
			Me.ItemForFirstName.Control = Me.FirstNameTextEdit
			Me.ItemForFirstName.Location = New System.Drawing.Point(0, 0)
			Me.ItemForFirstName.Name = "ItemForFirstName"
			Me.ItemForFirstName.Size = New System.Drawing.Size(270, 24)
			Me.ItemForFirstName.Text = "First Name"
			Me.ItemForFirstName.TextSize = New System.Drawing.Size(51, 13)
			' 
			' ItemForLastName
			' 
			Me.ItemForLastName.Control = Me.LastNameTextEdit
			Me.ItemForLastName.Location = New System.Drawing.Point(0, 24)
			Me.ItemForLastName.Name = "ItemForLastName"
			Me.ItemForLastName.Size = New System.Drawing.Size(270, 24)
			Me.ItemForLastName.Text = "Last Name"
			Me.ItemForLastName.TextSize = New System.Drawing.Size(51, 13)
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.btnSave
			Me.layoutControlItem1.Location = New System.Drawing.Point(176, 222)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(94, 26)
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem1.TextVisible = False
			' 
			' emptySpaceItem2
			' 
			Me.emptySpaceItem2.AllowHotTrack = False
			Me.emptySpaceItem2.Location = New System.Drawing.Point(0, 48)
			Me.emptySpaceItem2.Name = "emptySpaceItem2"
			Me.emptySpaceItem2.Size = New System.Drawing.Size(270, 174)
			Me.emptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
			' 
			' emptySpaceItem1
			' 
			Me.emptySpaceItem1.AllowHotTrack = False
			Me.emptySpaceItem1.Location = New System.Drawing.Point(0, 222)
			Me.emptySpaceItem1.Name = "emptySpaceItem1"
			Me.emptySpaceItem1.Size = New System.Drawing.Size(83, 26)
			Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.btnReload
			Me.layoutControlItem2.Location = New System.Drawing.Point(83, 222)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(93, 26)
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem2.TextVisible = False
			' 
			' mvvmContext1
			' 
			Me.mvvmContext1.ContainerControl = Me
			Me.mvvmContext1.ViewModelType = GetType(WinFormsApplication.ViewModels.EditCustomerViewModel)
			' 
			' EditCustomerView
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(290, 268)
			Me.Controls.Add(Me.CustomerLayoutControl)
			Me.Name = "EditCustomerView"
			Me.Text = "Edit Customer"
			CType(Me.CustomerLayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
			Me.CustomerLayoutControl.ResumeLayout(False)
			CType(Me.FirstNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.LastNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForFirstName, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForLastName, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private CustomerBindingSource As DevExpress.Xpo.XPBindingSource
		Private CustomerLayoutControl As DevExpress.XtraDataLayout.DataLayoutControl
		Private Root As DevExpress.XtraLayout.LayoutControlGroup
		Private FirstNameTextEdit As DevExpress.XtraEditors.TextEdit
		Private LastNameTextEdit As DevExpress.XtraEditors.TextEdit
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private ItemForFirstName As DevExpress.XtraLayout.LayoutControlItem
		Private ItemForLastName As DevExpress.XtraLayout.LayoutControlItem
		Private btnSave As DevExpress.XtraEditors.SimpleButton
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private emptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
		Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
		Private btnReload As DevExpress.XtraEditors.SimpleButton
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
		Private mvvmContext1 As DevExpress.Utils.MVVM.MVVMContext
	End Class
End Namespace
