using System;
using DevExpress.Xpo;
using System.ComponentModel;
using XpoTutorial;
using System.Threading.Tasks;

namespace WpfApplication.Wrappers
{
    class CustomerEditWrapper : INotifyPropertyChanged
    {
        UnitOfWork unitOfWork;
        readonly int? customerOid;

        public CustomerEditWrapper()
        {
            unitOfWork = new UnitOfWork(XpoDefault.DataLayer);
            Customer = new Customer(unitOfWork);
        }

        public CustomerEditWrapper(int customerOid)
        {
            this.customerOid = customerOid;
            unitOfWork = new UnitOfWork(XpoDefault.DataLayer);
            Customer = unitOfWork.GetObjectByKey<Customer>(customerOid);
        }

        Customer customer;
        public Customer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
                orderList.DataSource = customer.Orders;
                OnPropertyChanged(nameof(Customer));
            }
        }

        readonly XPBindingSource orderList = new XPBindingSource();
        public XPBindingSource OrderList
        {
            get
            {
                return orderList;
            }
        }

        Order selectedOrder;
        public Order SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                selectedOrder = value;
                IsOrderSelected = (value != null);
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        bool isOrderSelected;
        public bool IsOrderSelected
        {
            get
            {
                return isOrderSelected;
            }
            set
            {
                isOrderSelected = value;
                OnPropertyChanged(nameof(IsOrderSelected));
            }
        }

        public Order CreateNewOrder()
        {
            Order order = new Order(unitOfWork);
            order.Customer = Customer;
            SelectedOrder = order;
            return order;
        }

        public void DeleteSelectedOrder()
        {
            if (SelectedOrder != null)
            {
                SelectedOrder.Delete();
            }
        }

        public async Task ReloadAsync()
        {
            if (this.customerOid.HasValue)
            {
                unitOfWork = new UnitOfWork(XpoDefault.DataLayer);
                Customer = await unitOfWork.GetObjectByKeyAsync<Customer>(customerOid);
            }
        }

        public Task SaveAsync()
        {
            return unitOfWork.CommitChangesAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
