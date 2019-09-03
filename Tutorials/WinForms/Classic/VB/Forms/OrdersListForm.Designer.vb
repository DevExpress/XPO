Namespace WinFormsApplication.Forms
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
			Me.OrdersDataGrid = New DevExpress.XtraGrid.GridControl()
			Me.xpInstantFeedbackSource1 = New DevExpress.Xpo.XPInstantFeedbackSource(Me.components)
			Me.OrdersView = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colProductName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colOrderDate = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colFreight = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.btnNew = New DevExpress.XtraBars.BarButtonItem()
			Me.btnEdit = New DevExpress.XtraBars.BarButtonItem()
			Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.ribbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
			CType(Me.OrdersDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.OrdersView, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' OrdersDataGrid
			' 
			Me.OrdersDataGrid.DataSource = Me.xpInstantFeedbackSource1
			Me.OrdersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
			Me.OrdersDataGrid.Location = New System.Drawing.Point(0, 162)
			Me.OrdersDataGrid.MainView = Me.OrdersView
			Me.OrdersDataGrid.Name = "OrdersDataGrid"
			Me.OrdersDataGrid.ShowOnlyPredefinedDetails = True
			Me.OrdersDataGrid.Size = New System.Drawing.Size(819, 364)
			Me.OrdersDataGrid.TabIndex = 0
			Me.OrdersDataGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.OrdersView})
			' 
			' xpInstantFeedbackSource1
			' 
			Me.xpInstantFeedbackSource1.DisplayableProperties = "ProductName;OrderDate;Freight;Customer;Oid"
			Me.xpInstantFeedbackSource1.ObjectType = GetType(XpoTutorial.Order)
			' 
			' OrdersView
			' 
			Me.OrdersView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colProductName, Me.colOrderDate, Me.colFreight, Me.gridColumn1})
			Me.OrdersView.GridControl = Me.OrdersDataGrid
			Me.OrdersView.Name = "OrdersView"
			Me.OrdersView.OptionsBehavior.Editable = False
			' 
			' colProductName
			' 
			Me.colProductName.FieldName = "ProductName"
			Me.colProductName.Name = "colProductName"
			Me.colProductName.Visible = True
			Me.colProductName.VisibleIndex = 0
			' 
			' colOrderDate
			' 
			Me.colOrderDate.FieldName = "OrderDate"
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
			' gridColumn1
			' 
			Me.gridColumn1.Caption = "gridColumn1"
			Me.gridColumn1.FieldName = "Oid"
			Me.gridColumn1.Name = "gridColumn1"
			' 
			' ribbonControl1
			' 
			Me.ribbonControl1.ExpandCollapseItem.Id = 0
			Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.ribbonControl1.SearchEditItem, Me.btnNew, Me.btnEdit, Me.btnRefresh})
			Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
			Me.ribbonControl1.MaxItemId = 4
			Me.ribbonControl1.Name = "ribbonControl1"
			Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPage1})
			Me.ribbonControl1.Size = New System.Drawing.Size(819, 162)
			' 
			' btnNew
			' 
			Me.btnNew.Caption = "New"
			Me.btnNew.Id = 1
			Me.btnNew.Name = "btnNew"
			' 
			' btnEdit
			' 
			Me.btnEdit.Caption = "Edit"
			Me.btnEdit.Enabled = False
			Me.btnEdit.Id = 2
			Me.btnEdit.Name = "btnEdit"
			' 
			' ribbonPage1
			' 
			Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.ribbonPageGroup1})
			Me.ribbonPage1.Name = "ribbonPage1"
			Me.ribbonPage1.Text = "Home"
			' 
			' ribbonPageGroup1
			' 
			Me.ribbonPageGroup1.ItemLinks.Add(Me.btnNew)
			Me.ribbonPageGroup1.ItemLinks.Add(Me.btnEdit)
			Me.ribbonPageGroup1.ItemLinks.Add(Me.btnRefresh)
			Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
			Me.ribbonPageGroup1.Text = "Edit"
			' 
			' ribbonPage2
			' 
			Me.ribbonPage2.Name = "ribbonPage2"
			Me.ribbonPage2.Text = "ribbonPage2"
			' 
			' btnRefresh
			' 
			Me.btnRefresh.Caption = "Refresh"
			Me.btnRefresh.Id = 3
			Me.btnRefresh.Name = "btnRefresh"
			' 
			' OrdersListForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(819, 526)
			Me.Controls.Add(Me.OrdersDataGrid)
			Me.Controls.Add(Me.ribbonControl1)
			Me.Name = "OrdersListForm"
			Me.Ribbon = Me.ribbonControl1
			Me.Text = "Orders"
			CType(Me.OrdersDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.OrdersView, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private OrdersDataGrid As DevExpress.XtraGrid.GridControl
		Private WithEvents OrdersView As DevExpress.XtraGrid.Views.Grid.GridView
		Private colProductName As DevExpress.XtraGrid.Columns.GridColumn
		Private colOrderDate As DevExpress.XtraGrid.Columns.GridColumn
		Private colFreight As DevExpress.XtraGrid.Columns.GridColumn
		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private ribbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private WithEvents btnNew As DevExpress.XtraBars.BarButtonItem
		Private WithEvents btnEdit As DevExpress.XtraBars.BarButtonItem
		Private gridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
		Private xpInstantFeedbackSource1 As DevExpress.Xpo.XPInstantFeedbackSource
		Private WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
	End Class
End Namespace