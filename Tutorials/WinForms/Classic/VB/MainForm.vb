Imports System
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraBars.Ribbon
Imports System.Linq
Imports WinFormsApplication.XpoTutorial
Imports DevExpress.Xpo

Partial Public Class MainForm
    Inherits RibbonForm

    Public Sub New()
        ConnectionHelper.Connect(False)
        Using uow As New UnitOfWork()
            DemoDataHelper.Seed(uow)
        End Using
        InitializeComponent()
        AddHandler tabbedView.DocumentActivated, AddressOf TabbedView_DocumentActivated
        AddHandler tabbedView.DocumentClosed, AddressOf TabbedView_DocumentClosed
        AddHandler tabbedView.QueryControl, AddressOf TabbedView_QueryControl
        customersAccordionControlElement.Tag = NameOf(CustomersListForm)
        ordersAccordionControlElement.Tag = NameOf(OrdersListForm)
        ActivateDocument("Customers", NameOf(CustomersListForm))
    End Sub

    Private Sub TabbedView_QueryControl(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs)
        Select Case e.Document.ControlName
            Case NameOf(CustomersListForm)
                e.Control = New CustomersListForm()
            Case NameOf(OrdersListForm)
                e.Control = New OrdersListForm()
            Case Else
                Throw New ArgumentException($"Unknown control name {e.Document.ControlName}")
        End Select
    End Sub

    Private Sub TabbedView_DocumentActivated(ByVal sender As Object, ByVal e As DocumentEventArgs)
        accordionControl.SelectedElement = accordionControl.GetElements().Single(Function(t) CStr(t.Tag) = e.Document.ControlName)
        If ribbonControl.MergedPages.Count > 0 Then
            ribbonControl.SelectedPage = ribbonControl.MergedPages(0)
        End If
    End Sub

    Private Sub TabbedView_DocumentClosed(ByVal sender As Object, ByVal e As DocumentEventArgs)
        If tabbedView.Documents.Count = 0 Then
            accordionControl.SelectedElement = Nothing
        End If
    End Sub
    Private Sub ActivateDocument(ByVal caption As String, ByVal controlName As String)
        Dim document As BaseDocument = tabbedView.Documents.FindFirst(Function(d) d.ControlName = controlName)
        If document Is Nothing Then
            document = tabbedView.AddDocument(caption, controlName)
        End If
        tabbedView.Controller.Activate(document)
    End Sub

    Private Sub customersAccordionControlElement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles customersAccordionControlElement.Click
        ActivateDocument("Customers", NameOf(CustomersListForm))
    End Sub

    Private Sub ordersAccordionControlElement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ordersAccordionControlElement.Click
        ActivateDocument("Orders", NameOf(OrdersListForm))
    End Sub

    Private Sub customersBarButtonItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles customersBarButtonItem.ItemClick
        ActivateDocument("Customers", NameOf(CustomersListForm))
    End Sub

    Private Sub ordersBarButtonItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles ordersBarButtonItem.ItemClick
        ActivateDocument("Orders", NameOf(OrdersListForm))
    End Sub
End Class