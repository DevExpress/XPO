Imports System
Imports System.Web
Imports System.Web.Mvc

Namespace AspNetMvcApplication.Controllers

	Public Class HomeController
		Inherits BaseController

		Public Function Index() As ActionResult
			Return View()
		End Function
	End Class
End Namespace