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
        customersBarButtonItem.Tag = GetType(CustomersListForm).Name
        customersAccordionControlElement.Tag = customersBarButtonItem.Tag
        ordersBarButtonItem.Tag = GetType(OrdersListForm).Name
        ordersAccordionControlElement.Tag = ordersBarButtonItem.Tag
        SetAccordionSelectedElement(DirectCast(customersAccordionControlElement.Tag, String))
    End Sub

    Private Sub TabbedView_QueryControl(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs)
        If e.Document.ControlName = GetType(CustomersListForm).Name Then
            e.Control = New CustomersListForm()
        ElseIf e.Document.ControlName = GetType(OrdersListForm).Name Then
            e.Control = New OrdersListForm()
        Else
            Throw New ArgumentException($"Unknown control name {e.Document.ControlName}")
        End If
    End Sub

    Private Sub TabbedView_DocumentActivated(ByVal sender As Object, ByVal e As DocumentEventArgs)
        SetAccordionSelectedElement(e.Document.ControlName)
        If ribbonControl.MergedPages.Count > 0 Then
            ribbonControl.SelectedPage = ribbonControl.MergedPages(0)
        End If
    End Sub
    Private Sub TabbedView_DocumentClosed(ByVal sender As Object, ByVal e As DocumentEventArgs)
        If tabbedView.Documents.Count = 0 Then
            accordionControl.SelectedElement = Nothing
        End If
    End Sub
    Private Sub accordionControl_SelectedElementChanged(ByVal sender As Object, ByVal e As SelectedElementChangedEventArgs) Handles accordionControl.SelectedElementChanged
        If e.Element Is Nothing Then
            Return
        End If
        Dim controlName As String = DirectCast(e.Element.Tag, String)
        Dim document As BaseDocument = tabbedView.Documents.FindFirst(Function(d) d.ControlName = controlName)
        If document Is Nothing Then
            document = tabbedView.AddDocument(e.Element.Text, controlName)
        End If
        tabbedView.Controller.Activate(document)
    End Sub
    Private Sub barButtonNavigation_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles ordersBarButtonItem.ItemClick, customersBarButtonItem.ItemClick
        SetAccordionSelectedElement(DirectCast(e.Item.Tag, String))
    End Sub
    Private Sub SetAccordionSelectedElement(ByVal controlTypeName As String)
        accordionControl.SelectedElement = accordionControl.GetElements().Single(Function(e) CStr(e.Tag) = controlTypeName)
    End Sub
End Class