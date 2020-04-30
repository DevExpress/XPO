Imports System
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid

Namespace WinFormsApplication.Services
	Public Interface IInstantFeedbackService
		Function GetFocusedRowKey() As Object
		Sub SetFocusedRowByKey(ByVal focusedObjectKey As Object)
	End Interface
	'
	Public NotInheritable Class InstantFeedbackService
		Implements IInstantFeedbackService

		Private ReadOnly gridView As GridView
		Private ReadOnly keyFieldName As String
		Public Sub New(ByVal gridView As GridView, Optional ByVal keyFieldName As String = "Oid")
			Me.gridView = gridView
			Me.keyFieldName = keyFieldName
			If gridView Is Nothing Then
				Throw New InvalidOperationException("The InstantFeedbackService is not initialized. The gridView property is not assigned")
			End If
			If String.IsNullOrWhiteSpace(keyFieldName) Then
				Throw New InvalidOperationException("The InstantFeedbackService is not initialized. The keyFieldName property is not assigned")
			End If
		End Sub
		Private Function IInstantFeedbackService_GetFocusedRowKey() As Object Implements IInstantFeedbackService.GetFocusedRowKey
			Return gridView.GetFocusedRowCellValue(keyFieldName)
		End Function
		Private Sub IInstantFeedbackService_SetFocusedRowByKey(ByVal focusedObjectKey As Object) Implements IInstantFeedbackService.SetFocusedRowByKey
			gridView.FocusedRowHandle = gridView.DataController.FindRowByValue(keyFieldName, focusedObjectKey, New OperationCompleted(Sub(t) gridView.FocusedRowHandle = CInt(Math.Truncate(t))))
		End Sub
	End Class
End Namespace
