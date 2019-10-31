namespace WinFormsApplication.Forms {
    partial class EditCustomerForm {
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
            this.CustomerLayoutControl = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.FirstNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.customerXPBindingSource = new DevExpress.Xpo.XPBindingSource(this.components);
            this.LastNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForFirstName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLastName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerLayoutControl)).BeginInit();
            this.CustomerLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerXPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerLayoutControl
            // 
            this.CustomerLayoutControl.Controls.Add(this.btnReload);
            this.CustomerLayoutControl.Controls.Add(this.btnSave);
            this.CustomerLayoutControl.Controls.Add(this.FirstNameTextEdit);
            this.CustomerLayoutControl.Controls.Add(this.LastNameTextEdit);
            this.CustomerLayoutControl.DataSource = this.customerXPBindingSource;
            this.CustomerLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerLayoutControl.Location = new System.Drawing.Point(0, 0);
            this.CustomerLayoutControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CustomerLayoutControl.Name = "CustomerLayoutControl";
            this.CustomerLayoutControl.Root = this.Root;
            this.CustomerLayoutControl.Size = new System.Drawing.Size(338, 330);
            this.CustomerLayoutControl.TabIndex = 0;
            this.CustomerLayoutControl.Text = "dataLayoutControl1";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(110, 291);
            this.btnReload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(105, 27);
            this.btnReload.StyleController = this.CustomerLayoutControl;
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "&Reload";
            this.btnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(219, 291);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 27);
            this.btnSave.StyleController = this.CustomerLayoutControl;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FirstNameTextEdit
            // 
            this.FirstNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerXPBindingSource, "FirstName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FirstNameTextEdit.Location = new System.Drawing.Point(77, 12);
            this.FirstNameTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FirstNameTextEdit.Name = "FirstNameTextEdit";
            this.FirstNameTextEdit.Size = new System.Drawing.Size(249, 22);
            this.FirstNameTextEdit.StyleController = this.CustomerLayoutControl;
            this.FirstNameTextEdit.TabIndex = 4;
            // 
            // customerXPBindingSource
            // 
            this.customerXPBindingSource.DisplayableProperties = "FirstName;LastName";
            this.customerXPBindingSource.ObjectType = typeof(XpoTutorial.Customer);
            // 
            // LastNameTextEdit
            // 
            this.LastNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerXPBindingSource, "LastName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LastNameTextEdit.Location = new System.Drawing.Point(77, 38);
            this.LastNameTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LastNameTextEdit.Name = "LastNameTextEdit";
            this.LastNameTextEdit.Size = new System.Drawing.Size(249, 22);
            this.LastNameTextEdit.StyleController = this.CustomerLayoutControl;
            this.LastNameTextEdit.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(338, 330);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForFirstName,
            this.ItemForLastName,
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(318, 310);
            // 
            // ItemForFirstName
            // 
            this.ItemForFirstName.Control = this.FirstNameTextEdit;
            this.ItemForFirstName.Location = new System.Drawing.Point(0, 0);
            this.ItemForFirstName.Name = "ItemForFirstName";
            this.ItemForFirstName.Size = new System.Drawing.Size(318, 26);
            this.ItemForFirstName.Text = "First Name";
            this.ItemForFirstName.TextSize = new System.Drawing.Size(62, 16);
            // 
            // ItemForLastName
            // 
            this.ItemForLastName.Control = this.LastNameTextEdit;
            this.ItemForLastName.Location = new System.Drawing.Point(0, 26);
            this.ItemForLastName.Name = "ItemForLastName";
            this.ItemForLastName.Size = new System.Drawing.Size(318, 26);
            this.ItemForLastName.Text = "Last Name";
            this.ItemForLastName.TextSize = new System.Drawing.Size(62, 16);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.Location = new System.Drawing.Point(207, 279);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(111, 31);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(318, 227);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 279);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(98, 31);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnReload;
            this.layoutControlItem2.Location = new System.Drawing.Point(98, 279);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(109, 31);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // EditCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 330);
            this.Controls.Add(this.CustomerLayoutControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditCustomerForm";
            this.Text = "Edit Customer";
            this.Load += new System.EventHandler(this.EditCustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerLayoutControl)).EndInit();
            this.CustomerLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerXPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl CustomerLayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit FirstNameTextEdit;
        private DevExpress.XtraEditors.TextEdit LastNameTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFirstName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastName;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.Xpo.XPBindingSource customerXPBindingSource;
    }
}
