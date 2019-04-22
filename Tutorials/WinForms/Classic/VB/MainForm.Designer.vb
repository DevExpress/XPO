Namespace WinFormsApplication
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

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.ribbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
			Me.ribbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.documentManager1 = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
			Me.nativeMdiView1 = New DevExpress.XtraBars.Docking2010.Views.NativeMdi.NativeMdiView(Me.components)
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.documentManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nativeMdiView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' ribbonControl1
			' 
			Me.ribbonControl1.ExpandCollapseItem.Id = 0
			Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem})
			Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
			Me.ribbonControl1.MaxItemId = 1
			Me.ribbonControl1.Name = "ribbonControl1"
			Me.ribbonControl1.Size = New System.Drawing.Size(867, 49)
			Me.ribbonControl1.StatusBar = Me.ribbonStatusBar1
			' 
			' ribbonStatusBar1
			' 
			Me.ribbonStatusBar1.Location = New System.Drawing.Point(0, 524)
			Me.ribbonStatusBar1.Name = "ribbonStatusBar1"
			Me.ribbonStatusBar1.Ribbon = Me.ribbonControl1
			Me.ribbonStatusBar1.Size = New System.Drawing.Size(867, 31)
			' 
			' ribbonPage2
			' 
			Me.ribbonPage2.Name = "ribbonPage2"
			Me.ribbonPage2.Text = "ribbonPage2"
			' 
			' documentManager1
			' 
			Me.documentManager1.MdiParent = Me
			Me.documentManager1.MenuManager = Me.ribbonControl1
			Me.documentManager1.View = Me.nativeMdiView1
			Me.documentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() { Me.nativeMdiView1})
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(867, 555)
			Me.Controls.Add(Me.ribbonStatusBar1)
			Me.Controls.Add(Me.ribbonControl1)
			Me.IsMdiContainer = True
			Me.Name = "MainForm"
			Me.Ribbon = Me.ribbonControl1
			Me.StatusBar = Me.ribbonStatusBar1
			Me.Text = "XPO Tutorial"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.MainForm_Load);
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.documentManager1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nativeMdiView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
		Private ribbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private documentManager1 As DevExpress.XtraBars.Docking2010.DocumentManager
		Private nativeMdiView1 As DevExpress.XtraBars.Docking2010.Views.NativeMdi.NativeMdiView
	End Class
End Namespace

