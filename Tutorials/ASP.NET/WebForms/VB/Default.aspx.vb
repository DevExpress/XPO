Imports System
Imports DevExpress.Web
Imports DevExpress.Xpo

Namespace AspNetWebFormsApplication
	Partial Public Class _Default
		Inherits System.Web.UI.Page

		Private xpoSession As Session

		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			xpoSession = New Session(XpoDefault.DataLayer)
			CustomerDataSource.Session = xpoSession
			OrderDataSource.Session = xpoSession
		End Sub

		Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs)
			xpoSession.Dispose()
		End Sub

		Protected Sub btnEditOrders_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim customerId = CType((TryCast(sender, ASPxButton)).Parent, GridViewDataItemTemplateContainer).KeyValue
			CustomerIdHiddenField.Value = customerId.ToString()
			OrderPopup.ShowOnPageLoad = True
			OrderGrid.DataBind()
		End Sub

		Protected Sub btnNewCustomer_Click(ByVal sender As Object, ByVal e As EventArgs)
			CustomerGrid.AddNewRow()
		End Sub

		Protected Sub btnNewOrder_Click(ByVal sender As Object, ByVal e As EventArgs)
			OrderGrid.AddNewRow()
		End Sub

		Protected Sub CustomerGrid_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs)
			e.NewValues("Oid") = 0
		End Sub

		Protected Sub OrderGrid_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs)
			e.NewValues("Oid") = 0
			e.NewValues("Customer!Key") = Convert.ToInt32(CustomerIdHiddenField.Value)
		End Sub

		Protected Sub OrderGrid_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
			Session("OrderListCustomerOid") = CustomerIdHiddenField.Value
		End Sub
	End Class
End Namespace