Namespace WinFormsApplication.Views
	Partial Public Class CustomersListView
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
			Me.CustomersBindingSource = New DevExpress.Xpo.XPBindingSource(Me.components)
			Me.CustomersGridControl = New DevExpress.XtraGrid.GridControl()
			Me.CustomersGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colOid = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colContactName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.btnNew = New DevExpress.XtraBars.BarButtonItem()
			Me.btnDelete = New DevExpress.XtraBars.BarButtonItem()
			Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.ribbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
			Me.ribbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.mvvmContext1 = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
			CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.CustomersGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.CustomersGridView, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).BeginInit()
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
			Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPage1})
			Me.ribbonControl1.Size = New System.Drawing.Size(800, 162)
			Me.ribbonControl1.StatusBar = Me.ribbonStatusBar1
			' 
			' btnNew
			' 
			Me.btnNew.Caption = "New"
			Me.btnNew.Id = 1
			Me.btnNew.Name = "btnNew"
			' 
			' btnDelete
			' 
			Me.btnDelete.Caption = "Delete"
			Me.btnDelete.Id = 2
			Me.btnDelete.Name = "btnDelete"
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
			Me.ribbonPageGroup1.Text = "Edit"
			' 
			' ribbonStatusBar1
			' 
			Me.ribbonStatusBar1.Location = New System.Drawing.Point(0, 424)
			Me.ribbonStatusBar1.Name = "ribbonStatusBar1"
			Me.ribbonStatusBar1.Ribbon = Me.ribbonControl1
			Me.ribbonStatusBar1.Size = New System.Drawing.Size(800, 26)
			' 
			' ribbonPage2
			' 
			Me.ribbonPage2.Name = "ribbonPage2"
			Me.ribbonPage2.Text = "ribbonPage2"
			' 
			' mvvmContext1
			' 
			Me.mvvmContext1.ContainerControl = Me
			Me.mvvmContext1.ViewModelType = GetType(WinFormsApplication.ViewModels.CustomerListViewModel)
			' 
			' CustomersListView
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(800, 450)
			Me.Controls.Add(Me.CustomersGridControl)
			Me.Controls.Add(Me.ribbonStatusBar1)
			Me.Controls.Add(Me.ribbonControl1)
			Me.Name = "CustomersListView"
			Me.Ribbon = Me.ribbonControl1
			Me.StatusBar = Me.ribbonStatusBar1
			Me.Text = "Customers"
			CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.CustomersGridControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.CustomersGridView, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private CustomersBindingSource As DevExpress.Xpo.XPBindingSource
		Private CustomersGridControl As DevExpress.XtraGrid.GridControl
		Private CustomersGridView As DevExpress.XtraGrid.Views.Grid.GridView
		Private colOid As DevExpress.XtraGrid.Columns.GridColumn
		Private colContactName As DevExpress.XtraGrid.Columns.GridColumn
		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private ribbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
		Private ribbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private btnNew As DevExpress.XtraBars.BarButtonItem
		Private btnDelete As DevExpress.XtraBars.BarButtonItem
		Private mvvmContext1 As DevExpress.Utils.MVVM.MVVMContext
	End Class
End Namespace

