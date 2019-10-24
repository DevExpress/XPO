namespace WinFormsApplication {
    partial class OrdersListForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.OrdersGridControl = new DevExpress.XtraGrid.GridControl();
            this.OrdersInstantFeedbackView = new DevExpress.Xpo.XPInstantFeedbackView(this.components);
            this.OrdersGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdersGridControl
            // 
            this.OrdersGridControl.DataSource = this.OrdersInstantFeedbackView;
            this.OrdersGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersGridControl.Location = new System.Drawing.Point(0, 162);
            this.OrdersGridControl.MainView = this.OrdersGridView;
            this.OrdersGridControl.Name = "OrdersGridControl";
            this.OrdersGridControl.Size = new System.Drawing.Size(800, 262);
            this.OrdersGridControl.TabIndex = 0;
            this.OrdersGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.OrdersGridView});
            // 
            // OrdersInstantFeedbackView
            // 
            this.OrdersInstantFeedbackView.ObjectType = typeof(XpoTutorial.Order);
            this.OrdersInstantFeedbackView.Properties.AddRange(new DevExpress.Xpo.ServerViewProperty[] {
            new DevExpress.Xpo.ServerViewProperty("Oid", DevExpress.Xpo.SortDirection.None, "[Oid]"),
            new DevExpress.Xpo.ServerViewProperty("Product Name", DevExpress.Xpo.SortDirection.None, "[ProductName]"),
            new DevExpress.Xpo.ServerViewProperty("Order Date", DevExpress.Xpo.SortDirection.None, "[OrderDate]"),
            new DevExpress.Xpo.ServerViewProperty("Freight", DevExpress.Xpo.SortDirection.None, "[Freight]")});
            this.OrdersInstantFeedbackView.ResolveSession += new System.EventHandler<DevExpress.Xpo.ResolveSessionEventArgs>(this.OrdersInstantFeedbackView_ResolveSession);
            this.OrdersInstantFeedbackView.DismissSession += new System.EventHandler<DevExpress.Xpo.ResolveSessionEventArgs>(this.OrdersInstantFeedbackView_DismissSession);
            // 
            // OrdersGridView
            // 
            this.OrdersGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOid,
            this.colProductName,
            this.colOrderDate,
            this.colFreight});
            this.OrdersGridView.GridControl = this.OrdersGridControl;
            this.OrdersGridView.Name = "OrdersGridView";
            this.OrdersGridView.OptionsBehavior.Editable = false;
            this.OrdersGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.OrdersGridView_RowClick);
            // 
            // colOid
            // 
            this.colOid.FieldName = "Oid";
            this.colOid.Name = "colOid";
            // 
            // colProductName
            // 
            this.colProductName.FieldName = "Product Name";
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 0;
            // 
            // colOrderDate
            // 
            this.colOrderDate.FieldName = "Order Date";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.Visible = true;
            this.colOrderDate.VisibleIndex = 1;
            // 
            // colFreight
            // 
            this.colFreight.FieldName = "Freight";
            this.colFreight.Name = "colFreight";
            this.colFreight.Visible = true;
            this.colFreight.VisibleIndex = 2;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnNew,
            this.btnDelete});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(800, 162);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Id = 1;
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnNew_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Id = 2;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDelete_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.MergeOrder = 1;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Edit";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 424);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(800, 26);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // OrdersListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OrdersGridControl);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "OrdersListForm";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Orders";
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl OrdersGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView OrdersGridView;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.Xpo.XPInstantFeedbackView OrdersInstantFeedbackView;
        private DevExpress.XtraGrid.Columns.GridColumn colOid;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFreight;
    }
}

