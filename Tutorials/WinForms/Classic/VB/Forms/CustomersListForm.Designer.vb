	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Public Class CustomersListForm
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(CustomersListForm))
			Me.CustomersBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
			Me.CustomersGridControl = New DevExpress.XtraGrid.GridControl()
			Me.CustomersGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colOid = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colContactName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.btnNew = New DevExpress.XtraBars.BarButtonItem()
			Me.btnDelete = New DevExpress.XtraBars.BarButtonItem()
			Me.ribbonPageHome = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.ribbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
			Me.ribbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.CustomersGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.CustomersGridView, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' CustomersBindingSource
			' 
			Me.CustomersBindingSource.DisplayableProperties = "Oid;ContactName"
			Me.CustomersBindingSource.ObjectType = GetType(XpoTutorial.Customer)
			' 
			' CustomersGridControl
			' 
			Me.CustomersGridControl.DataSource = Me.CustomersBindingSource
			Me.CustomersGridControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.CustomersGridControl.Location = New System.Drawing.Point(0, 162)
			Me.CustomersGridControl.MainView = Me.CustomersGridView
			Me.CustomersGridControl.Name = "CustomersGridControl"
			Me.CustomersGridControl.Size = New System.Drawing.Size(800, 262)
			Me.CustomersGridControl.TabIndex = 0
			Me.CustomersGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.CustomersGridView})
			' 
			' CustomersGridView
			' 
			Me.CustomersGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colOid, Me.colContactName})
			Me.CustomersGridView.GridControl = Me.CustomersGridControl
			Me.CustomersGridView.Name = "CustomersGridView"
			Me.CustomersGridView.OptionsBehavior.Editable = False
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CustomersGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.CustomersGridView_RowClick);
			' 
			' colOid
			' 
			Me.colOid.FieldName = "Oid"
			Me.colOid.Name = "colOid"
			' 
			' colContactName
			' 
			Me.colContactName.FieldName = "ContactName"
			Me.colContactName.Name = "colContactName"
			Me.colContactName.Visible = True
			Me.colContactName.VisibleIndex = 0
			' 
			' ribbonControl1
			' 
			Me.ribbonControl1.ExpandCollapseItem.Id = 0
			Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.ribbonControl1.SearchEditItem, Me.btnNew, Me.btnDelete})
			Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
			Me.ribbonControl1.MaxItemId = 3
			Me.ribbonControl1.Name = "ribbonControl1"
			Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPageHome})
			Me.ribbonControl1.Size = New System.Drawing.Size(800, 162)
			Me.ribbonControl1.StatusBar = Me.ribbonStatusBar1
			' 
			' btnNew
			' 
			Me.btnNew.Caption = "New" & vbCrLf & "Customer"
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
			' ribbonPageHome
			' 
			Me.ribbonPageHome.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.ribbonPageGroup1})
			Me.ribbonPageHome.MergeOrder = 1
			Me.ribbonPageHome.Name = "ribbonPageHome"
			Me.ribbonPageHome.Text = "Home"
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
			' CustomersListForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(800, 450)
			Me.Controls.Add(Me.CustomersGridControl)
			Me.Controls.Add(Me.ribbonStatusBar1)
			Me.Controls.Add(Me.ribbonControl1)
			Me.Name = "CustomersListForm"
			Me.Ribbon = Me.ribbonControl1
			Me.StatusBar = Me.ribbonStatusBar1
			Me.Text = "Customers"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.CustomersListForm_Load);
			CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.CustomersGridControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.CustomersGridView, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private CustomersBindingSource As DevExpress.Xpo.XPBindingSource
		Private CustomersGridControl As DevExpress.XtraGrid.GridControl
		Private WithEvents CustomersGridView As DevExpress.XtraGrid.Views.Grid.GridView
		Private colOid As DevExpress.XtraGrid.Columns.GridColumn
		Private colContactName As DevExpress.XtraGrid.Columns.GridColumn
		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonPageHome As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private ribbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
		Private ribbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private WithEvents btnNew As DevExpress.XtraBars.BarButtonItem
		Private WithEvents btnDelete As DevExpress.XtraBars.BarButtonItem
	End Class
