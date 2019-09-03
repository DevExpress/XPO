Imports System
Imports System.Collections.Generic
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports XpoTutorial
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Collections.ObjectModel

Namespace WpfApplication.Wrappers

	Public Class CustomerListWrapper
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

		Private fCustomerList As ObservableCollection(Of Customer)
		Public Property CustomerList() As ObservableCollection(Of Customer)
			Get
				Return fCustomerList
			End Get
			Set(ByVal value As ObservableCollection(Of Customer))
				fCustomerList = value
				OnPropertyChanged(NameOf(CustomerList))
			End Set
		End Property

		Private fSelectedCustomer As Customer
		Public Property SelectedCustomer() As Customer
			Get
				Return fSelectedCustomer
			End Get
			Set(ByVal value As Customer)
				fSelectedCustomer = value
				IsCustomerSelected = (value IsNot Nothing)
				OnPropertyChanged(NameOf(SelectedCustomer))
			End Set
		End Property

		Private fIsCustomerSelected As Boolean
		Public Property IsCustomerSelected() As Boolean
			Get
				Return fIsCustomerSelected
			End Get
			Set(ByVal value As Boolean)
				fIsCustomerSelected = value
				OnPropertyChanged(NameOf(IsCustomerSelected))
			End Set
		End Property

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Private Sub OnPropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
	End Class
End Namespace