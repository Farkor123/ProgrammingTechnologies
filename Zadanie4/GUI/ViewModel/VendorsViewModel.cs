using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarstwaUslug;

namespace GUI.ViewModel
{
    class VendorsViewModel : INotifyPropertyChanged
    {
        private DataRepository dataHandle;

        private WarstwaDanych.Vendor _selectedItem;
        public WarstwaDanych.Vendor SelectedItem {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ICommand SaveChanges { get; set; }
        public ICommand CreateVendor { get; set; }
        public ICommand DeleteVendor { get; set; }

        public VendorsViewModel()
        {
            dataHandle = new DataRepository();
            VendorList = new ObservableCollection<WarstwaDanych.Vendor>(dataHandle.GetAllVendors());

            VendorList.CollectionChanged += (ob, e) =>
            {
                OnPropertyChanged("VendorList");
            };
            
            SaveChanges = new RelayCommand(e =>
            {
                dataHandle.SubmitChanges();
            });
            CreateVendor = new RelayCommand(e =>
            {
                VendorList.Add(dataHandle.CreateVendor());
                SelectedItem = VendorList.Last();
            });
            DeleteVendor = new RelayCommand(e =>
            {
                dataHandle.DeleteVendor(SelectedItem);
                VendorList.Remove(SelectedItem);
            });
        }

        public ObservableCollection<WarstwaDanych.Vendor> VendorList
        {
            get;
            set;
        }
        public event PropertyChangedEventHandler PropertyChanged = null;

        virtual protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
