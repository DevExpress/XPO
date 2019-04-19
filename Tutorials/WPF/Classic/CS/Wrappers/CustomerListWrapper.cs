using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using System.ComponentModel;
using XpoTutorial;
using System.Linq;
using System.Threading.Tasks;

namespace WpfApplication.Wrappers {

    class CustomerListWrapper : INotifyPropertyChanged {

        UnitOfWork unitOfWork;

        public CustomerListWrapper() {
            unitOfWork = new UnitOfWork(XpoDefault.DataLayer);
            customerList.DataSource = unitOfWork.Query<Customer>().OrderByDescending(t => t.Oid).ToList();
        }

        public async Task ReloadAsync() {
            Customer currentItem = SelectedCustomer;
            unitOfWork = new UnitOfWork(XpoDefault.DataLayer);
            customerList.DataSource = await unitOfWork.Query<Customer>().OrderByDescending(t => t.Oid).ToListAsync();
            if(currentItem != null) {
                SelectedCustomer = await unitOfWork.Query<Customer>().FirstOrDefaultAsync(t => t.Oid == currentItem.Oid);
            } else {
                SelectedCustomer = null;
            }
        }

        public async Task DeleteSelectedCustomerAsync() {
            if(SelectedCustomer != null) {
                SelectedCustomer.Delete();
                await unitOfWork.CommitChangesAsync();
                await ReloadAsync();
            }
        }

        readonly XPBindingSource customerList = new XPBindingSource();
        public XPBindingSource CustomerList {
            get {
                return customerList;
            }
        }

        Customer selectedCustomer;
        public Customer SelectedCustomer {
            get {
                return selectedCustomer;
            }
            set {
                selectedCustomer = value;
                IsCustomerSelected = (value != null);
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        bool isCustomerSelected;
        public bool IsCustomerSelected {
            get {
                return isCustomerSelected;
            }
            set {
                isCustomerSelected = value;
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