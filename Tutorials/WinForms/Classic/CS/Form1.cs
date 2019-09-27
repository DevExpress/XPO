using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using XpoTutorial;

namespace WinFormsApplication {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Session session = new Session();
            CustomersBindingSource.DataSource = new XPCollection<Customer>(session);
        }
    }
}
