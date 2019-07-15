Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Linq
Imports System.Threading.Tasks
Imports DevExpress.Xpo

Namespace WpfApplication
	Friend Module CollectionExtensionMethods

		<System.Runtime.CompilerServices.Extension> _
		Public Async Function ToObservableCollectionAsync(Of T)(ByVal source As IQueryable(Of T)) As Task(Of ObservableCollection(Of T))
			Return New ObservableCollection(Of T)(Await source.ToListAsync())
		End Function

		<System.Runtime.CompilerServices.Extension> _
		Public Function ToObservableCollection(Of T)(ByVal source As IQueryable(Of T)) As ObservableCollection(Of T)
			Return New ObservableCollection(Of T)(source.ToList())
		End Function

		<System.Runtime.CompilerServices.Extension> _
		Public Function ToObservableCollection(Of T)(ByVal source As IEnumerable(Of T)) As ObservableCollection(Of T)
			Dim observable = New ObservableCollection(Of T)(source.ToList())
			Dim observableSource = TryCast(source, INotifyCollectionChanged)
			If observableSource IsNot Nothing Then
				SetupINotifyCollectionChangedEvents(observableSource, observable)
			End If
			Return observable
		End Function

		Private Sub SetupINotifyCollectionChangedEvents(Of T)(ByVal source As INotifyCollectionChanged, ByVal target As IList(Of T))
			AddHandler source.CollectionChanged, Sub(s, e)
				Select Case e.Action
					Case NotifyCollectionChangedAction.Add
						For Each item As T In e.NewItems
							target.Add(item)
						Next item
					Case NotifyCollectionChangedAction.Remove
						For Each item As T In e.OldItems
							target.Remove(item)
						Next item
					Case NotifyCollectionChangedAction.Replace
						For i As Integer = e.OldStartingIndex To e.OldItems.Count - 1
							target(i) = CType(e.NewItems(i), T)
						Next i
					Case NotifyCollectionChangedAction.Move, NotifyCollectionChangedAction.Reset
						target.Clear()
						For Each item As T In target
							target.Add(item)
						Next item
				End Select
			End Sub
		End Sub
	End Module
End Namespace
