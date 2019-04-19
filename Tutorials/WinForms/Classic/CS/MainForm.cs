using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using WinFormsApplication.Forms;

namespace WinFormsApplication {
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            OrdersListForm ordersList = new OrdersListForm();
            ordersList.MdiParent = this;
            ordersList.WindowState = FormWindowState.Maximized;
            ordersList.Show();
        }
    }
}
