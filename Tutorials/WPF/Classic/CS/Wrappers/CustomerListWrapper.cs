﻿using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using System.ComponentModel;
using XpoTutorial;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfApplication.Wrappers {

    public class CustomerListWrapper : INotifyPropertyChanged {

        UnitOfWork unitOfWork;

        public CustomerListWrapper() {
            unitOfWork = new UnitOfWork(XpoDefault.DataLayer);
            CustomerList = unitOfWork.Query<Customer>().OrderByDescending(t => t.Oid).ToObservableCollection();
        }

        public async Task ReloadAsync() {
            Customer currentItem = SelectedCustomer;
            unitOfWork = new UnitOfWork(XpoDefault.DataLayer);
            CustomerList = await unitOfWork.Query<Customer>().OrderByDescending(t => t.Oid).ToObservableCollectionAsync();
            if(currentItem != null) {
                SelectedCustomer = await unitOfWork.Query<Customer>().FirstOrDefaultAsync(t => t.Oid == currentItem.Oid);
            } else {
                SelectedCustomer = null;
            }
        }

        public async Task DeleteSelectedCustomerAsync() {
            if(SelectedCustomer != null) {
                unitOfWork.Delete(SelectedCustomer);
                await unitOfWork.CommitChangesAsync();
                await ReloadAsync();
            }
        }

        ObservableCollection<Customer> fCustomerList;
        public ObservableCollection<Customer> CustomerList {
            get {
                return fCustomerList;
            }
            set {
                fCustomerList = value;
                OnPropertyChanged(nameof(CustomerList));
            }
        }

        Customer fSelectedCustomer;
        public Customer SelectedCustomer {
            get {
                return fSelectedCustomer;
            }
            set {
                fSelectedCustomer = value;
                IsCustomerSelected = (value != null);
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        bool fIsCustomerSelected;
        public bool IsCustomerSelected {
            get {
                return fIsCustomerSelected;
            }
            set {
                fIsCustomerSelected = value;
                OnPropertyChanged(nameof(IsCustomerSelected));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
