using System;
using DevExpress.Web;
using DevExpress.Xpo;

namespace AspNetWebFormsApplication {
    public partial class _Default : System.Web.UI.Page {

        Session xpoSession;

        protected void Page_Init(object sender, EventArgs e) {
            xpoSession = new Session(XpoDefault.DataLayer);
            CustomerDataSource.Session = xpoSession;
            OrderDataSource.Session = xpoSession;
        }

        protected void Page_Unload(object sender, EventArgs e) {
            xpoSession.Dispose();
        }

        protected void btnEditOrders_Click(object sender, EventArgs e) {
            var customerId = ((GridViewDataItemTemplateContainer)(sender as ASPxButton).Parent).KeyValue;
            CustomerIdHiddenField.Value = customerId.ToString();
            OrderPopup.ShowOnPageLoad = true;
            OrderGrid.DataBind();
        }

        protected void btnNewCustomer_Click(object sender, EventArgs e) {
            CustomerGrid.AddNewRow();
        }

        protected void btnNewOrder_Click(object sender, EventArgs e) {
            OrderGrid.AddNewRow();
        }

        protected void CustomerGrid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e) {
            e.NewValues["Oid"] = 0;
        }

        protected void OrderGrid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e) {
            e.NewValues["Oid"] = 0;
            e.NewValues["Customer!Key"] = Convert.ToInt32(CustomerIdHiddenField.Value);
        }

        protected void OrderGrid_BeforePerformDataSelect(object sender, EventArgs e) {
            Session["OrderListCustomerOid"] = CustomerIdHiddenField.Value;
        }
    }
}