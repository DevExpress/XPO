Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Navigation
Imports WinFormsApplication.XpoTutorial
Imports DevExpress.Xpo
Imports System.Globalization

Partial Public Class MainForm
    Private Const OrdersFormName As String = "Orders"
    Private Const CustomersFormName As String = "Customers"
    Private OrdersForm As Form
    Private CustomersForm As Form
    Public Sub New()
        ConnectionHelper.Connect(False)
        Using uow As New UnitOfWork()
            DemoDataHelper.Seed(uow)
        End Using
        InitializeComponent()
        CustomersForm = CreateForm(CustomersFormName)
        OrdersForm = CreateForm(OrdersFormName)
        accordionControl.SelectedElement = ordersAccordionControlElement
    End Sub

    Private Sub TabbedView_DocumentActivated(sender As Object, e As DocumentEventArgs) Handles tabbedView.DocumentActivated
        SetAccordionSelectedElement(e.Document.Caption)
    End Sub

    Private Function CreateForm(ByVal name As String) As Form
        Dim result As Form = Nothing
        Select Case name
            Case OrdersFormName
                result = New OrdersListForm
            Case CustomersFormName
                result = New CustomersListForm
            Case Else
                Dim msg As String = String.Format(CultureInfo.CurrentUICulture, "Unknown view name: {0}", name)
                Throw New ArgumentException(msg)
        End Select
        Return result
    End Function
    Private Sub accordionControl_SelectedElementChanged(ByVal sender As Object, ByVal e As SelectedElementChangedEventArgs) Handles accordionControl.SelectedElementChanged
        If e.Element Is Nothing Then
            Return
        End If
        Dim form As Form = Nothing
        Select Case e.Element.Text
            Case OrdersFormName
                form = OrdersForm
            Case CustomersFormName
                form = CustomersForm
        End Select
        If form IsNot Nothing Then
            tabbedView.AddDocument(form)
            tabbedView.ActivateDocument(form)
        End If
    End Sub
    Private Sub barButtonNavigation_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles employeesBarButtonItem.ItemClick, customersBarButtonItem.ItemClick
        SetAccordionSelectedElement(e.Item.Caption)
    End Sub
    Private Sub SetAccordionSelectedElement(ByVal name As String)
        Select Case name
            Case OrdersFormName
                accordionControl.SelectedElement = ordersAccordionControlElement
            Case CustomersFormName
                accordionControl.SelectedElement = customersAccordionControlElement
        End Select
    End Sub
    Private Sub TabbedView_DocumentClosed(ByVal sender As Object, ByVal e As DocumentEventArgs) Handles tabbedView.DocumentClosed
        RecreateForms(e)
    End Sub
    Private Sub RecreateForms(ByVal e As DocumentEventArgs)
        Select Case e.Document.Caption
            Case OrdersFormName
                OrdersForm = CreateForm(OrdersFormName)
            Case CustomersFormName
                CustomersForm = CreateForm(CustomersFormName)
        End Select
    End Sub
End Class
