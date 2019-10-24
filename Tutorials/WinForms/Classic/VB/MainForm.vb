Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Navigation
Imports WinFormsApplication.XpoTutorial
Imports DevExpress.Xpo

Partial Public Class MainForm
    Public Sub New()
        ConnectionHelper.Connect(False)
        Using uow As New UnitOfWork()
            DemoDataHelper.Seed(uow)
        End Using
        InitializeComponent()
        customersAccordionControlElement.Tag = GetType(CustomersListForm).Name
        customersBarButtonItem.Tag = GetType(CustomersListForm).Name
        ordersAccordionControlElement.Tag = GetType(OrdersListForm).Name
        ordersBarButtonItem.Tag = GetType(OrdersListForm).Name
        SetAccordionSelectedElement(CStr(customersAccordionControlElement.Tag))
    End Sub

    Private Sub TabbedView_DocumentActivated(sender As Object, e As DocumentEventArgs) Handles tabbedView.DocumentActivated
        SetAccordionSelectedElement(e.Document.ControlName)
    End Sub
    Private Sub accordionControl_SelectedElementChanged(ByVal sender As Object, ByVal e As SelectedElementChangedEventArgs) Handles accordionControl.SelectedElementChanged
        If e.Element Is Nothing Then
            Return
        End If
        Dim controlName As String = CStr(e.Element.Tag)
        Dim document As BaseDocument = tabbedView.Documents.FindFirst(Function(d) d.ControlName = controlName)
        If document Is Nothing Then
            document = tabbedView.AddDocument(e.Element.Text, controlName)
        End If
        tabbedView.Controller.Activate(document)
    End Sub
    Private Sub barButtonNavigation_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles ordersBarButtonItem.ItemClick, customersBarButtonItem.ItemClick
        SetAccordionSelectedElement(CStr(e.Item.Tag))
    End Sub
    Private Sub SetAccordionSelectedElement(ByVal controlTypeName As String)
        accordionControl.SelectedElement = accordionControl.GetElements() _
            .Single(Function(e) CStr(e.Tag) = controlTypeName)
    End Sub
    Private Sub tabbedView_QueryControl(sender As Object, e As Docking2010.Views.QueryControlEventArgs) Handles tabbedView.QueryControl
        Select Case e.Document.ControlName
            Case GetType(CustomersListForm).Name
                e.Control = New CustomersListForm
            Case GetType(OrdersListForm).Name
                e.Control = New OrdersListForm
            Case Else
                Throw New ArgumentException("Unknown control name " & e.Document.ControlName)
        End Select
    End Sub
End Class
