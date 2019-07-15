Imports System
Imports System.Collections.Generic
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports XpoTutorial
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Collections.ObjectModel

Namespace WpfApplication.Wrappers

	Friend Class CustomerListWrapper
		Implements INotifyPropertyChanged

		Private unitOfWork As UnitOfWork

		Public Sub New()
			unitOfWork = New UnitOfWork(XpoDefault.DataLayer)
			CustomerList = unitOfWork.Query(Of Customer)().OrderByDescending(Function(t) t.Oid).ToObservableCollection()
		End Sub

		Public Async Function ReloadAsync() As Task
			Dim currentItem As Customer = SelectedCustomer
			unitOfWork = New UnitOfWork(XpoDefault.DataLayer)
			CustomerList = Await unitOfWork.Query(Of Customer)().OrderByDescending(Function(t) t.Oid).ToObservableCollectionAsync()
			If currentItem IsNot Nothing Then
				SelectedCustomer = Await unitOfWork.Query(Of Customer)().FirstOrDefaultAsync(Function(t) t.Oid = currentItem.Oid)
			Else
				SelectedCustomer = Nothing
			End If
		End Function

		Public Async Function DeleteSelectedCustomerAsync() As Task
			If SelectedCustomer IsNot Nothing Then
				unitOfWork.Delete(selectedCustomer_Renamed)
				Await unitOfWork.CommitChangesAsync()
				Await ReloadAsync()
			End If
		End Function

'INSTANT VB NOTE: The field customerList was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private customerList_Renamed As ObservableCollection(Of Customer)
		Public Property CustomerList() As ObservableCollection(Of Customer)
			Get
				Return customerList_Renamed
			End Get
			Set(ByVal value As ObservableCollection(Of Customer))
				customerList_Renamed = value
				OnPropertyChanged(NameOf(CustomerList))
			End Set
		End Property

'INSTANT VB NOTE: The field selectedCustomer was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private selectedCustomer_Renamed As Customer
		Public Property SelectedCustomer() As Customer
			Get
				Return selectedCustomer_Renamed
			End Get
			Set(ByVal value As Customer)
				selectedCustomer_Renamed = value
				IsCustomerSelected = (value IsNot Nothing)
				OnPropertyChanged(NameOf(SelectedCustomer))
			End Set
		End Property

'INSTANT VB NOTE: The field isCustomerSelected was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private isCustomerSelected_Renamed As Boolean
		Public Property IsCustomerSelected() As Boolean
			Get
				Return isCustomerSelected_Renamed
			End Get
			Set(ByVal value As Boolean)
				isCustomerSelected_Renamed = value
				OnPropertyChanged(NameOf(IsCustomerSelected))
			End Set
		End Property

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Private Sub OnPropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
	End Class
End Namespace