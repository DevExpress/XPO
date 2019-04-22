Imports System.Linq
Imports DevExpress.Xpo
Imports AspNetMvcApplication.Models
Imports XpoTutorial
Imports System.Web.Mvc

Namespace AspNetMvcApplication.Controllers

    Public Class OrderController
        Inherits BaseController

        <ValidateInput(False)>
        Public Function OrderListPartial(ByVal customerOid As Integer) As ActionResult
            Dim model = UnitOfWork.Query(Of Customer)().Select(Function(t) New CustomerViewModel() With {
                .Oid = t.Oid,
                .FirstName = t.FirstName,
                .LastName = t.LastName,
                .Orders = t.Orders.Select(Function(o) New OrderViewModel() With {
                    .Oid = o.Oid,
                    .OrderDate = o.OrderDate,
                    .ProductName = o.ProductName,
                    .Freight = o.Freight,
                    .CustomerId = o.Customer.Oid
                }).ToList()
            }).FirstOrDefault(Function(t) t.Oid = customerOid)
            ViewData("CustomersList") = UnitOfWork.Query(Of Customer)().Select(Function(t) New CustomerViewModel() With {
                .Oid = t.Oid,
                .FirstName = t.FirstName,
                .LastName = t.LastName
            }).OrderBy(Function(t) t.FirstName).ThenBy(Function(t) t.LastName).ToList()
            Return PartialView("OrderListPartial", model)
        End Function


        <HttpPost, ValidateInput(False)>
        Public Function AddOrder(ByVal customerOid As Integer, ByVal model As OrderViewModel) As ActionResult
            If ModelState.IsValid Then
                SafeExecute(Sub()
                                Dim order = New Order(UnitOfWork) With {
                                    .OrderDate = model.OrderDate,
                                    .ProductName = model.ProductName,
                                    .Freight = model.Freight,
                                    .Customer = UnitOfWork.GetObjectByKey(Of Customer)(model.CustomerId)
                                }
                                UnitOfWork.CommitChanges()
                            End Sub)
            Else
                ViewData("EditError") = "Please, correct all errors."
            End If
            Return OrderListPartial(customerOid)
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function UpdateOrder(ByVal customerOid As Integer, ByVal model As OrderViewModel) As ActionResult
            If ModelState.IsValid Then
                SafeExecute(Sub()
                                Dim order = UnitOfWork.GetObjectByKey(Of Order)(model.Oid)
                                order.OrderDate = model.OrderDate
                                order.ProductName = model.ProductName
                                order.Freight = model.Freight
                                order.Customer = UnitOfWork.GetObjectByKey(Of Customer)(model.CustomerId)
                                UnitOfWork.CommitChanges()
                            End Sub)
            Else
                ViewData("EditError") = "Please, correct all errors."
            End If
            Return OrderListPartial(customerOid)
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function DeleteOrder(ByVal customerOid As Integer, ByVal Oid As Integer) As ActionResult
            SafeExecute(Sub()
                            Dim order = UnitOfWork.GetObjectByKey(Of Order)(Oid)
                            order.Delete()
                            UnitOfWork.CommitChanges()
                        End Sub)
            Return OrderListPartial(customerOid)
        End Function
    End Class
End Namespace