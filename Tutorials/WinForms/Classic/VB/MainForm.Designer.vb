<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class MainForm
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ribbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.skinRibbonGalleryBarItem = New DevExpress.XtraBars.SkinRibbonGalleryBarItem()
        Me.barSubItemNavigation = New DevExpress.XtraBars.BarSubItem()
        Me.ordersBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.customersBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ribbonPageView = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.ribbonPageGroupNavigation = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.ribbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.ribbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.dockManager = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.dockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.dockPanel_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.accordionControl = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.mainAccordionGroup = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.customersAccordionControlElement = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.ordersAccordionControlElement = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.tabbedView = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
        Me.documentManager = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        CType(Me.ribbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dockManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dockPanel.SuspendLayout()
        Me.dockPanel_Container.SuspendLayout()
        CType(Me.accordionControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabbedView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.documentManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ribbonControl
        '
        Me.ribbonControl.ExpandCollapseItem.Id = 0
        Me.ribbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl.ExpandCollapseItem, Me.ribbonControl.SearchEditItem, Me.skinRibbonGalleryBarItem, Me.barSubItemNavigation, Me.ordersBarButtonItem, Me.customersBarButtonItem})
        Me.ribbonControl.Location = New System.Drawing.Point(0, 0)
        Me.ribbonControl.MaxItemId = 48
        Me.ribbonControl.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always
        Me.ribbonControl.Name = "ribbonControl"
        Me.ribbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.ribbonPageView})
        Me.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013
        Me.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.ribbonControl.Size = New System.Drawing.Size(790, 162)
        Me.ribbonControl.StatusBar = Me.ribbonStatusBar
        Me.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'skinRibbonGalleryBarItem
        '
        Me.skinRibbonGalleryBarItem.Id = 14
        Me.skinRibbonGalleryBarItem.Name = "skinRibbonGalleryBarItem"
        '
        'barSubItemNavigation
        '
        Me.barSubItemNavigation.Caption = "Navigation"
        Me.barSubItemNavigation.Id = 15
        Me.barSubItemNavigation.ImageOptions.ImageUri.Uri = "NavigationBar"
        Me.barSubItemNavigation.ImageOptions.SvgImage = CType(resources.GetObject("barSubItemNavigation.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.barSubItemNavigation.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ordersBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.customersBarButtonItem)})
        Me.barSubItemNavigation.Name = "barSubItemNavigation"
        '
        'ordersBarButtonItem
        '
        Me.ordersBarButtonItem.Caption = "Orders"
        Me.ordersBarButtonItem.Id = 46
        Me.ordersBarButtonItem.Name = "ordersBarButtonItem"
        '
        'customersBarButtonItem
        '
        Me.customersBarButtonItem.Caption = "Customers"
        Me.customersBarButtonItem.Id = 47
        Me.customersBarButtonItem.Name = "customersBarButtonItem"
        '
        'ribbonPageView
        '
        Me.ribbonPageView.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ribbonPageGroupNavigation, Me.ribbonPageGroup})
        Me.ribbonPageView.Name = "ribbonPageView"
        Me.ribbonPageView.Text = "View"
        '
        'ribbonPageGroupNavigation
        '
        Me.ribbonPageGroupNavigation.ItemLinks.Add(Me.barSubItemNavigation)
        Me.ribbonPageGroupNavigation.Name = "ribbonPageGroupNavigation"
        Me.ribbonPageGroupNavigation.Text = "Module"
        '
        'ribbonPageGroup
        '
        Me.ribbonPageGroup.AllowTextClipping = False
        Me.ribbonPageGroup.ItemLinks.Add(Me.skinRibbonGalleryBarItem)
        Me.ribbonPageGroup.Name = "ribbonPageGroup"
        Me.ribbonPageGroup.ShowCaptionButton = False
        Me.ribbonPageGroup.Text = "Appearance"
        '
        'ribbonStatusBar
        '
        Me.ribbonStatusBar.Location = New System.Drawing.Point(0, 573)
        Me.ribbonStatusBar.Name = "ribbonStatusBar"
        Me.ribbonStatusBar.Ribbon = Me.ribbonControl
        Me.ribbonStatusBar.Size = New System.Drawing.Size(790, 26)
        '
        'dockManager
        '
        Me.dockManager.Form = Me
        Me.dockManager.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.dockPanel})
        Me.dockManager.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane"})
        '
        'dockPanel
        '
        Me.dockPanel.Controls.Add(Me.dockPanel_Container)
        Me.dockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.dockPanel.ID = New System.Guid("a045df26-1503-4d9a-99c1-a531310af22b")
        Me.dockPanel.Location = New System.Drawing.Point(0, 162)
        Me.dockPanel.Name = "dockPanel"
        Me.dockPanel.OriginalSize = New System.Drawing.Size(200, 200)
        Me.dockPanel.Size = New System.Drawing.Size(200, 411)
        Me.dockPanel.Text = "Navigation"
        '
        'dockPanel_Container
        '
        Me.dockPanel_Container.Controls.Add(Me.accordionControl)
        Me.dockPanel_Container.Location = New System.Drawing.Point(3, 30)
        Me.dockPanel_Container.Name = "dockPanel_Container"
        Me.dockPanel_Container.Size = New System.Drawing.Size(193, 378)
        Me.dockPanel_Container.TabIndex = 0
        '
        'accordionControl
        '
        Me.accordionControl.AllowItemSelection = True
        Me.accordionControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.accordionControl.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.mainAccordionGroup})
        Me.accordionControl.Location = New System.Drawing.Point(0, 0)
        Me.accordionControl.Name = "accordionControl"
        Me.accordionControl.Size = New System.Drawing.Size(193, 378)
        Me.accordionControl.TabIndex = 0
        Me.accordionControl.Text = "accordionControl"
        '
        'mainAccordionGroup
        '
        Me.mainAccordionGroup.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.customersAccordionControlElement, Me.ordersAccordionControlElement})
        Me.mainAccordionGroup.Expanded = True
        Me.mainAccordionGroup.HeaderVisible = False
        Me.mainAccordionGroup.Name = "mainAccordionGroup"
        Me.mainAccordionGroup.Text = "mainGroup"
        '
        'customersAccordionControlElement
        '
        Me.customersAccordionControlElement.Name = "customersAccordionControlElement"
        Me.customersAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.customersAccordionControlElement.Text = "Customers"
        '
        'ordersAccordionControlElement
        '
        Me.ordersAccordionControlElement.Name = "ordersAccordionControlElement"
        Me.ordersAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.ordersAccordionControlElement.Text = "Orders"
        '
        'tabbedView
        '
        Me.tabbedView.DocumentProperties.AllowFloat = False
        '
        'documentManager
        '
        Me.documentManager.MdiParent = Me
        Me.documentManager.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always
        Me.documentManager.View = Me.tabbedView
        Me.documentManager.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.tabbedView})
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 599)
        Me.Controls.Add(Me.dockPanel)
        Me.Controls.Add(Me.ribbonStatusBar)
        Me.Controls.Add(Me.ribbonControl)
        Me.IsMdiContainer = True
        Me.Name = "MainForm"
        Me.Ribbon = Me.ribbonControl
        Me.StatusBar = Me.ribbonStatusBar
        Me.Text = "XPO Tutorial"
        CType(Me.ribbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dockManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dockPanel.ResumeLayout(False)
        Me.dockPanel_Container.ResumeLayout(False)
        CType(Me.accordionControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabbedView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.documentManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private ribbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Private ribbonPageView As DevExpress.XtraBars.Ribbon.RibbonPage
    Private ribbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Private ribbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Private skinRibbonGalleryBarItem As DevExpress.XtraBars.SkinRibbonGalleryBarItem
    Private dockManager As DevExpress.XtraBars.Docking.DockManager
    Private dockPanel As DevExpress.XtraBars.Docking.DockPanel
    Private dockPanel_Container As DevExpress.XtraBars.Docking.ControlContainer
    Private accordionControl As DevExpress.XtraBars.Navigation.AccordionControl
    Private ribbonPageGroupNavigation As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Private WithEvents ordersBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Private WithEvents customersBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Private barSubItemNavigation As DevExpress.XtraBars.BarSubItem
    Private WithEvents ordersAccordionControlElement As DevExpress.XtraBars.Navigation.AccordionControlElement
    Private WithEvents customersAccordionControlElement As DevExpress.XtraBars.Navigation.AccordionControlElement
    Private mainAccordionGroup As DevExpress.XtraBars.Navigation.AccordionControlElement
    Private tabbedView As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Private documentManager As DevExpress.XtraBars.Docking2010.DocumentManager
End Class