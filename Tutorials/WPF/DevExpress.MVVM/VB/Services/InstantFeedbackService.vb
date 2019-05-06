Imports DevExpress.Mvvm.UI
Imports DevExpress.Xpf.Grid
Imports System
Imports System.Threading.Tasks
Imports System.Windows

Namespace WpfApplicationMvvm.Services
	Public NotInheritable Class InstantFeedbackService
		Inherits ServiceBase
		Implements IInstantFeedbackService

		Public Shared KeyFieldNameProperty As DependencyProperty = DependencyProperty.Register("KeyFieldName", GetType(String), GetType(InstantFeedbackService))
		Public Property KeyFieldName() As String
			Get
				Return DirectCast(GetValue(KeyFieldNameProperty), String)
			End Get
			Set(ByVal value As String)
				SetValue(KeyFieldNameProperty, value)
			End Set
		End Property
		Private Sub Guard()
			If String.IsNullOrWhiteSpace(KeyFieldName) Then
				Throw New InvalidOperationException("The InstantFeedbackService is not initialized. The KeyFieldName property is not assigned")
			End If
		End Sub
		Private Function IInstantFeedbackService_GetFocusedRowKey() As Object Implements IInstantFeedbackService.GetFocusedRowKey
			Guard()
			Dim grid As GridControl = CType(AssociatedObject, GridControl)
			Return grid.GetFocusedRowCellValue(KeyFieldName)
		End Function
		Private Async Function IInstantFeedbackService_SetFocusedRowByKeyAsync(ByVal focusedObjectKey As Object) As Task Implements IInstantFeedbackService.SetFocusedRowByKeyAsync
			Guard()
			Dim grid As GridControl = CType(AssociatedObject, GridControl)
			grid.View.FocusedRowHandle = Await grid.FindRowByValueAsync(KeyFieldName, focusedObjectKey)
		End Function
	End Class
	Public Interface IInstantFeedbackService
		Function GetFocusedRowKey() As Object
		Function SetFocusedRowByKeyAsync(ByVal focusedObjectKey As Object) As Task
	End Interface
End Namespace
