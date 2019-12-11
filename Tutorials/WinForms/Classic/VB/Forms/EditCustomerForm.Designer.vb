	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Public Class EditCustomerForm
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(EditCustomerForm))
			Me.CustomerLayoutControl = New DevExpress.XtraDataLayout.DataLayoutControl()
			Me.FirstNameTextEdit = New DevExpress.XtraEditors.TextEdit()
			Me.CustomerBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
			Me.LastNameTextEdit = New DevExpress.XtraEditors.TextEdit()
			Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.ItemForFirstName = New DevExpress.XtraLayout.LayoutControlItem()
			Me.ItemForLastName = New DevExpress.XtraLayout.LayoutControlItem()
			Me.emptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
			Me.ribbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.btnSave = New DevExpress.XtraBars.BarButtonItem()
			Me.btnReload = New DevExpress.XtraBars.BarButtonItem()
			Me.btnClose = New DevExpress.XtraBars.BarButtonItem()
			Me.ribbonPageHome = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.ribbonStatusBar2 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
			Me.ribbonPage3 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			CType(Me.CustomerLayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.CustomerLayoutControl.SuspendLayout()
			CType(Me.FirstNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.LastNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForFirstName, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ItemForLastName, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' CustomerLayoutControl
			' 
			Me.CustomerLayoutControl.Controls.Add(Me.FirstNameTextEdit)
			Me.CustomerLayoutControl.Controls.Add(Me.LastNameTextEdit)
			Me.CustomerLayoutControl.DataSource = Me.CustomerBindingSource
			Me.CustomerLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.CustomerLayoutControl.Location = New System.Drawing.Point(0, 162)
			Me.CustomerLayoutControl.Name = "CustomerLayoutControl"
			Me.CustomerLayoutControl.Root = Me.Root
			Me.CustomerLayoutControl.Size = New System.Drawing.Size(506, 221)
			Me.CustomerLayoutControl.TabIndex = 0
			Me.CustomerLayoutControl.Text = "dataLayoutControl1"
			' 
			' FirstNameTextEdit
			' 
			Me.FirstNameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.CustomerBindingSource, "FirstName", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
			Me.FirstNameTextEdit.Location = New System.Drawing.Point(66, 12)
			Me.FirstNameTextEdit.Name = "FirstNameTextEdit"
			Me.FirstNameTextEdit.Size = New System.Drawing.Size(428, 20)
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
			Me.LastNameTextEdit.Size = New System.Drawing.Size(428, 20)
			Me.LastNameTextEdit.StyleController = Me.CustomerLayoutControl
			Me.LastNameTextEdit.TabIndex = 5
			' 
			' Root
			' 
			Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.Root.GroupBordersVisible = False
			Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlGroup1})
			Me.Root.Name = "Root"
			Me.Root.Size = New System.Drawing.Size(506, 221)
			Me.Root.TextVisible = False
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.AllowDrawBackground = False
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.ItemForFirstName, Me.ItemForLastName, Me.emptySpaceItem2})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "autoGeneratedGroup0"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(486, 201)
			' 
			' ItemForFirstName
			' 
			Me.ItemForFirstName.Control = Me.FirstNameTextEdit
			Me.ItemForFirstName.Location = New System.Drawing.Point(0, 0)
			Me.ItemForFirstName.Name = "ItemForFirstName"
			Me.ItemForFirstName.Size = New System.Drawing.Size(486, 24)
			Me.ItemForFirstName.Text = "First Name"
			Me.ItemForFirstName.TextSize = New System.Drawing.Size(51, 13)
			' 
			' ItemForLastName
			' 
			Me.ItemForLastName.Control = Me.LastNameTextEdit
			Me.ItemForLastName.Location = New System.Drawing.Point(0, 24)
			Me.ItemForLastName.Name = "ItemForLastName"
			Me.ItemForLastName.Size = New System.Drawing.Size(486, 24)
			Me.ItemForLastName.Text = "Last Name"
			Me.ItemForLastName.TextSize = New System.Drawing.Size(51, 13)
			' 
			' emptySpaceItem2
			' 
			Me.emptySpaceItem2.AllowHotTrack = False
			Me.emptySpaceItem2.Location = New System.Drawing.Point(0, 48)
			Me.emptySpaceItem2.Name = "emptySpaceItem2"
			Me.emptySpaceItem2.Size = New System.Drawing.Size(486, 153)
			Me.emptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
			' 
			' ribbonPage2
			' 
			Me.ribbonPage2.Name = "ribbonPage2"
			Me.ribbonPage2.Text = "ribbonPage2"
			' 
			' ribbonControl1
			' 
			Me.ribbonControl1.ExpandCollapseItem.Id = 0
			Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.ribbonControl1.SearchEditItem, Me.btnSave, Me.btnReload, Me.btnClose})
			Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
			Me.ribbonControl1.MaxItemId = 4
			Me.ribbonControl1.Name = "ribbonControl1"
			Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPageHome})
			Me.ribbonControl1.Size = New System.Drawing.Size(506, 162)
			Me.ribbonControl1.StatusBar = Me.ribbonStatusBar2
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
			' ribbonStatusBar2
			' 
			Me.ribbonStatusBar2.Location = New System.Drawing.Point(0, 383)
			Me.ribbonStatusBar2.Name = "ribbonStatusBar2"
			Me.ribbonStatusBar2.Ribbon = Me.ribbonControl1
			Me.ribbonStatusBar2.Size = New System.Drawing.Size(506, 26)
			Me.ribbonStatusBar2.Visible = False
			' 
			' ribbonPage3
			' 
			Me.ribbonPage3.Name = "ribbonPage3"
			Me.ribbonPage3.Text = "ribbonPage3"
			' 
			' EditCustomerForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(506, 409)
			Me.Controls.Add(Me.CustomerLayoutControl)
			Me.Controls.Add(Me.ribbonStatusBar2)
			Me.Controls.Add(Me.ribbonControl1)
			Me.Name = "EditCustomerForm"
			Me.Ribbon = Me.ribbonControl1
			Me.StatusBar = Me.ribbonStatusBar2
			Me.Text = "Edit Customer"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.EditCustomerForm_Load);
			CType(Me.CustomerLayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
			Me.CustomerLayoutControl.ResumeLayout(False)
			CType(Me.FirstNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.LastNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForFirstName, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ItemForLastName, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

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
		Private emptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
		Private ribbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonPageHome As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private ribbonStatusBar2 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
		Private ribbonPage3 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private WithEvents btnSave As DevExpress.XtraBars.BarButtonItem
		Private WithEvents btnReload As DevExpress.XtraBars.BarButtonItem
		Private WithEvents btnClose As DevExpress.XtraBars.BarButtonItem
	End Class