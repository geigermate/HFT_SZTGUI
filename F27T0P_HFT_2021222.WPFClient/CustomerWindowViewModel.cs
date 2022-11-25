using F27T0P_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace F27T0P_HFT_2021222.WPFClient
{
    class CustomerWindowViewModel : ObservableRecipient
    {
        public RestCollection<Customer> Customers { get; set; }

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (value != null)
                {
                    selectedCustomer = new Customer()
                    {
                        Id = value.Id,
                        Name = value.Name
                    };
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CreateCustomer { get; set; }
        public ICommand DeleteCustomer { get; set; }
        public ICommand UpdateCustomer { get; set; }

        public CustomerWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Customers = new RestCollection<Customer>("http://localhost:42137/", "customer");

                CreateCustomer = new RelayCommand(
                    () =>
                    {
                        Customers.Add(new Customer()
                        {
                            Name = SelectedCustomer.Name
                        });
                    });

                DeleteCustomer = new RelayCommand(
                    () =>
                    {
                        Customers.Delete(SelectedCustomer.Id);
                    },
                    () => { return SelectedCustomer != null; });

                UpdateCustomer = new RelayCommand(
                    () => { Customers.Update(SelectedCustomer); });

                SelectedCustomer = new Customer();
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    }
}
