namespace WinFormsApplication.Forms {
    partial class EditOrderView {
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
            this.OrderLayoutControl = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.ProductNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.OrderBindingSource = new DevExpress.Xpo.XPBindingSource(this.components);
            this.OrderDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.FreightCalcEdit = new DevExpress.XtraEditors.CalcEdit();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.CustomersBindingSource = new DevExpress.Xpo.XPBindingSource(this.components);
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForProductName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOrderDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFreight = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OrderLayoutControl)).BeginInit();
            this.OrderLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreightCalcEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOrderDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFreight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            this.SuspendLayout();
            // 
            // OrderLayoutControl
            // 
            this.OrderLayoutControl.Controls.Add(this.btnReload);
            this.OrderLayoutControl.Controls.Add(this.btnSave);
            this.OrderLayoutControl.Controls.Add(this.ProductNameTextEdit);
            this.OrderLayoutControl.Controls.Add(this.OrderDateDateEdit);
            this.OrderLayoutControl.Controls.Add(this.FreightCalcEdit);
            this.OrderLayoutControl.Controls.Add(this.lookUpEdit1);
            this.OrderLayoutControl.DataSource = this.OrderBindingSource;
            this.OrderLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderLayoutControl.Location = new System.Drawing.Point(0, 0);
            this.OrderLayoutControl.Name = "OrderLayoutControl";
            this.OrderLayoutControl.Root = this.Root;
            this.OrderLayoutControl.Size = new System.Drawing.Size(290, 268);
            this.OrderLayoutControl.TabIndex = 0;
            this.OrderLayoutControl.Text = "dataLayoutControl1";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(102, 234);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(86, 22);
            this.btnReload.StyleController = this.OrderLayoutControl;
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "&Reload";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(192, 234);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 22);
            this.btnSave.StyleController = this.OrderLayoutControl;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            // 
            // ProductNameTextEdit
            // 
            this.ProductNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrderBindingSource, "ProductName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ProductNameTextEdit.Location = new System.Drawing.Point(82, 12);
            this.ProductNameTextEdit.Name = "ProductNameTextEdit";
            this.ProductNameTextEdit.Size = new System.Drawing.Size(196, 20);
            this.ProductNameTextEdit.StyleController = this.OrderLayoutControl;
            this.ProductNameTextEdit.TabIndex = 6;
            // 
            // OrderBindingSource
            // 
            this.OrderBindingSource.DisplayableProperties = "ProductName;OrderDate;Freight;Customer!Key";
            this.OrderBindingSource.ObjectType = typeof(XpoTutorial.Order);
            // 
            // OrderDateDateEdit
            // 
            this.OrderDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrderBindingSource, "OrderDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.OrderDateDateEdit.EditValue = null;
            this.OrderDateDateEdit.Location = new System.Drawing.Point(82, 36);
            this.OrderDateDateEdit.Name = "OrderDateDateEdit";
            this.OrderDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.OrderDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.OrderDateDateEdit.Size = new System.Drawing.Size(196, 20);
            this.OrderDateDateEdit.StyleController = this.OrderLayoutControl;
            this.OrderDateDateEdit.TabIndex = 7;
            // 
            // FreightCalcEdit
            // 
            this.FreightCalcEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrderBindingSource, "Freight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FreightCalcEdit.Location = new System.Drawing.Point(82, 60);
            this.FreightCalcEdit.Name = "FreightCalcEdit";
            this.FreightCalcEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.FreightCalcEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.FreightCalcEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FreightCalcEdit.Properties.Mask.EditMask = "G";
            this.FreightCalcEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.FreightCalcEdit.Size = new System.Drawing.Size(196, 20);
            this.FreightCalcEdit.StyleController = this.OrderLayoutControl;
            this.FreightCalcEdit.TabIndex = 8;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrderBindingSource, "Customer!Key", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookUpEdit1.Location = new System.Drawing.Point(82, 84);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUpEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.DataSource = this.CustomersBindingSource;
            this.lookUpEdit1.Properties.DisplayMember = "ContactName";
            this.lookUpEdit1.Properties.NullText = "";
            this.lookUpEdit1.Properties.ValueMember = "Oid";
            this.lookUpEdit1.Size = new System.Drawing.Size(196, 20);
            this.lookUpEdit1.StyleController = this.OrderLayoutControl;
            this.lookUpEdit1.TabIndex = 9;
            // 
            // CustomersBindingSource
            // 
            this.CustomersBindingSource.DisplayableProperties = "Oid;ContactName";
            this.CustomersBindingSource.ObjectType = typeof(XpoTutorial.Customer);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(290, 268);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.ItemForProductName,
            this.ItemForOrderDate,
            this.ItemForFreight,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(270, 248);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.Location = new System.Drawing.Point(180, 222);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(90, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(270, 126);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 222);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(90, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnReload;
            this.layoutControlItem2.Location = new System.Drawing.Point(90, 222);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(90, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ItemForProductName
            // 
            this.ItemForProductName.Control = this.ProductNameTextEdit;
            this.ItemForProductName.Location = new System.Drawing.Point(0, 0);
            this.ItemForProductName.Name = "ItemForProductName";
            this.ItemForProductName.Size = new System.Drawing.Size(270, 24);
            this.ItemForProductName.Text = "Product Name";
            this.ItemForProductName.TextSize = new System.Drawing.Size(67, 13);
            // 
            // ItemForOrderDate
            // 
            this.ItemForOrderDate.Control = this.OrderDateDateEdit;
            this.ItemForOrderDate.Location = new System.Drawing.Point(0, 24);
            this.ItemForOrderDate.Name = "ItemForOrderDate";
            this.ItemForOrderDate.Size = new System.Drawing.Size(270, 24);
            this.ItemForOrderDate.Text = "Order Date";
            this.ItemForOrderDate.TextSize = new System.Drawing.Size(67, 13);
            // 
            // ItemForFreight
            // 
            this.ItemForFreight.Control = this.FreightCalcEdit;
            this.ItemForFreight.Location = new System.Drawing.Point(0, 48);
            this.ItemForFreight.Name = "ItemForFreight";
            this.ItemForFreight.Size = new System.Drawing.Size(270, 24);
            this.ItemForFreight.Text = "Freight";
            this.ItemForFreight.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lookUpEdit1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "ItemForCustomer!Key";
            this.layoutControlItem3.Size = new System.Drawing.Size(270, 24);
            this.layoutControlItem3.Text = "Customer";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(67, 13);
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(WinFormsApplication.ViewModels.EditOrderViewModel);
            // 
            // EditOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 268);
            this.Controls.Add(this.OrderLayoutControl);
            this.Name = "EditOrderView";
            this.Text = "Edit Order";
            ((System.ComponentModel.ISupportInitialize)(this.OrderLayoutControl)).EndInit();
            this.OrderLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreightCalcEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOrderDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFreight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Xpo.XPBindingSource OrderBindingSource;
        private DevExpress.XtraDataLayout.DataLayoutControl OrderLayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit ProductNameTextEdit;
        private DevExpress.XtraEditors.DateEdit OrderDateDateEdit;
        private DevExpress.XtraEditors.CalcEdit FreightCalcEdit;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOrderDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFreight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.Xpo.XPBindingSource CustomersBindingSource;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
    }
}
