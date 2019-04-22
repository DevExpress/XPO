Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports AspNetMvcApplication.Models
Imports DevExpress.Xpo
Imports XpoTutorial

Namespace AspNetMvcApplication.Controllers

    Public Class CustomerController
        Inherits BaseController

        <ValidateInput(False)>
        Public Function CustomerListPartial() As ActionResult
            Dim model = UnitOfWork.Query(Of Customer)().Select(Function(t) New CustomerViewModel() With {
                .Oid = t.Oid,
                .FirstName = t.FirstName,
                .LastName = t.LastName
            })
            Return PartialView("CustomerListPartial", model)
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function AddCustomer(ByVal model As CustomerViewModel) As ActionResult
            If ModelState.IsValid Then
                SafeExecute(Sub()
                                Dim customer = New Customer(UnitOfWork) With {
                                    .FirstName = model.FirstName,
                                    .LastName = model.LastName
                                }
                                UnitOfWork.CommitChanges()
                            End Sub)
            Else
                ViewData("EditError") = "Please, correct all errors."
            End If
            Return CustomerListPartial()
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function UpdateCustomer(ByVal model As CustomerViewModel) As ActionResult
            If ModelState.IsValid Then
                SafeExecute(Sub()
                                Dim customer = UnitOfWork.GetObjectByKey(Of Customer)(model.Oid)
                                customer.FirstName = model.FirstName
                                customer.LastName = model.LastName
                                UnitOfWork.CommitChanges()
                            End Sub)
            Else
                ViewData("EditError") = "Please, correct all errors."
            End If
            Return CustomerListPartial()
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function DeleteCustomer(ByVal Oid As Integer) As ActionResult
            SafeExecute(Sub()
                            Dim customer = UnitOfWork.GetObjectByKey(Of Customer)(Oid)
                            customer.Delete()
                            UnitOfWork.CommitChanges()
                        End Sub)
            Return CustomerListPartial()
        End Function
    End Class
End Namespace