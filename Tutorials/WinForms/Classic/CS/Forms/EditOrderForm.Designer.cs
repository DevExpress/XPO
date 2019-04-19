namespace WinFormsApplication.Forms {
    partial class EditOrderForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.ProductNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.OrdersBindingSource = new DevExpress.Xpo.XPBindingSource(this.components);
            this.OrderDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.FreightCalcEdit = new DevExpress.XtraEditors.CalcEdit();
            this.CustomerEditor = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForProductName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOrderDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFreight = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreightCalcEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerEditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOrderDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFreight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnSave,
            this.btnClose,
            this.btnRefresh});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(800, 162);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.CausesValidation = true;
            this.btnSave.Enabled = false;
            this.btnSave.Id = 1;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 2;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Id = 3;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Edit";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.ProductNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.OrderDateDateEdit);
            this.dataLayoutControl1.Controls.Add(this.FreightCalcEdit);
            this.dataLayoutControl1.Controls.Add(this.CustomerEditor);
            this.dataLayoutControl1.DataSource = this.OrdersBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 162);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1126, 140, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(800, 284);
            this.dataLayoutControl1.TabIndex = 2;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // ProductNameTextEdit
            // 
            this.ProductNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrdersBindingSource, "ProductName", true));
            this.ProductNameTextEdit.Location = new System.Drawing.Point(82, 12);
            this.ProductNameTextEdit.MenuManager = this.ribbonControl1;
            this.ProductNameTextEdit.Name = "ProductNameTextEdit";
            this.ProductNameTextEdit.Size = new System.Drawing.Size(706, 20);
            this.ProductNameTextEdit.StyleController = this.dataLayoutControl1;
            this.ProductNameTextEdit.TabIndex = 4;
            // 
            // OrdersBindingSource
            // 
            this.OrdersBindingSource.DisplayableProperties = "ProductName;OrderDate;Freight;Customer!Key";
            this.OrdersBindingSource.ObjectType = typeof(XpoTutorial.Order);
            // 
            // OrderDateDateEdit
            // 
            this.OrderDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrdersBindingSource, "OrderDate", true));
            this.OrderDateDateEdit.EditValue = null;
            this.OrderDateDateEdit.Location = new System.Drawing.Point(82, 36);
            this.OrderDateDateEdit.MenuManager = this.ribbonControl1;
            this.OrderDateDateEdit.Name = "OrderDateDateEdit";
            this.OrderDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.OrderDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.OrderDateDateEdit.Size = new System.Drawing.Size(706, 20);
            this.OrderDateDateEdit.StyleController = this.dataLayoutControl1;
            this.OrderDateDateEdit.TabIndex = 5;
            // 
            // FreightCalcEdit
            // 
            this.FreightCalcEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrdersBindingSource, "Freight", true));
            this.FreightCalcEdit.Location = new System.Drawing.Point(82, 60);
            this.FreightCalcEdit.MenuManager = this.ribbonControl1;
            this.FreightCalcEdit.Name = "FreightCalcEdit";
            this.FreightCalcEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.FreightCalcEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.FreightCalcEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FreightCalcEdit.Properties.Mask.EditMask = "G";
            this.FreightCalcEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.FreightCalcEdit.Size = new System.Drawing.Size(706, 20);
            this.FreightCalcEdit.StyleController = this.dataLayoutControl1;
            this.FreightCalcEdit.TabIndex = 6;
            // 
            // CustomerEditor
            // 
            this.CustomerEditor.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrdersBindingSource, "Customer!Key", true));
            this.CustomerEditor.Location = new System.Drawing.Point(82, 84);
            this.CustomerEditor.MenuManager = this.ribbonControl1;
            this.CustomerEditor.Name = "CustomerEditor";
            this.CustomerEditor.Properties.Appearance.Options.UseTextOptions = true;
            this.CustomerEditor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CustomerEditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CustomerEditor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContactName", "Contact Name")});
            this.CustomerEditor.Properties.DisplayMember = "ContactName";
            this.CustomerEditor.Properties.NullText = "";
            this.CustomerEditor.Properties.ValueMember = "Oid";
            this.CustomerEditor.Size = new System.Drawing.Size(706, 20);
            this.CustomerEditor.StyleController = this.dataLayoutControl1;
            this.CustomerEditor.TabIndex = 7;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 284);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForProductName,
            this.ItemForOrderDate,
            this.ItemForFreight,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(780, 264);
            // 
            // ItemForProductName
            // 
            this.ItemForProductName.Control = this.ProductNameTextEdit;
            this.ItemForProductName.Location = new System.Drawing.Point(0, 0);
            this.ItemForProductName.Name = "ItemForProductName";
            this.ItemForProductName.Size = new System.Drawing.Size(780, 24);
            this.ItemForProductName.Text = "Product Name";
            this.ItemForProductName.TextSize = new System.Drawing.Size(67, 13);
            // 
            // ItemForOrderDate
            // 
            this.ItemForOrderDate.Control = this.OrderDateDateEdit;
            this.ItemForOrderDate.Location = new System.Drawing.Point(0, 24);
            this.ItemForOrderDate.Name = "ItemForOrderDate";
            this.ItemForOrderDate.Size = new System.Drawing.Size(780, 24);
            this.ItemForOrderDate.Text = "Order Date";
            this.ItemForOrderDate.TextSize = new System.Drawing.Size(67, 13);
            // 
            // ItemForFreight
            // 
            this.ItemForFreight.Control = this.FreightCalcEdit;
            this.ItemForFreight.Location = new System.Drawing.Point(0, 48);
            this.ItemForFreight.Name = "ItemForFreight";
            this.ItemForFreight.Size = new System.Drawing.Size(780, 24);
            this.ItemForFreight.Text = "Freight";
            this.ItemForFreight.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.CustomerEditor;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem1.Name = "ItemForCustomer!Key";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 192);
            this.layoutControlItem1.Text = "Customer";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(67, 13);
            // 
            // EditOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 446);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "EditOrderForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Edit Order";
            this.Load += new System.EventHandler(this.EditOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreightCalcEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerEditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOrderDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFreight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit ProductNameTextEdit;
        private DevExpress.XtraEditors.DateEdit OrderDateDateEdit;
        private DevExpress.XtraEditors.CalcEdit FreightCalcEdit;
        private DevExpress.XtraEditors.LookUpEdit CustomerEditor;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOrderDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFreight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.Xpo.XPBindingSource OrdersBindingSource;
    }
}