namespace WinFormsApplication {
    partial class Form1 {
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
            this.CustomersBindingSource = new DevExpress.Xpo.XPBindingSource(this.components);
            this.CustomersGridControl = new DevExpress.XtraGrid.GridControl();
            this.CustomersGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomersBindingSource
            // 
            this.CustomersBindingSource.DisplayableProperties = "Oid;ContactName";
            this.CustomersBindingSource.ObjectType = typeof(XpoTutorial.Customer);
            // 
            // CustomersGridControl
            // 
            this.CustomersGridControl.DataSource = this.CustomersBindingSource;
            this.CustomersGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomersGridControl.Location = new System.Drawing.Point(0, 0);
            this.CustomersGridControl.MainView = this.CustomersGridView;
            this.CustomersGridControl.Name = "CustomersGridControl";
            this.CustomersGridControl.Size = new System.Drawing.Size(800, 450);
            this.CustomersGridControl.TabIndex = 0;
            this.CustomersGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CustomersGridView});
            // 
            // CustomersGridView
            // 
            this.CustomersGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOid,
            this.colContactName});
            this.CustomersGridView.GridControl = this.CustomersGridControl;
            this.CustomersGridView.Name = "CustomersGridView";
            this.CustomersGridView.OptionsBehavior.Editable = false;
            // 
            // colOid
            // 
            this.colOid.FieldName = "Oid";
            this.colOid.Name = "colOid";
            // 
            // colContactName
            // 
            this.colContactName.FieldName = "ContactName";
            this.colContactName.Name = "colContactName";
            this.colContactName.Visible = true;
            this.colContactName.VisibleIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CustomersGridControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Xpo.XPBindingSource CustomersBindingSource;
        private DevExpress.XtraGrid.GridControl CustomersGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView CustomersGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colOid;
        private DevExpress.XtraGrid.Columns.GridColumn colContactName;
    }
}

