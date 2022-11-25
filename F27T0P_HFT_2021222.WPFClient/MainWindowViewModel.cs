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
    class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }

        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                SetProperty(ref selectedBrand, value);
                (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Brands = new RestCollection<Brand>("http://localhost:42137/", "brand");
                CreateBrandCommand = new RelayCommand(
                    () =>
                    {
                        Brands.Add(new Brand() { Name = "Teszt" });
                    });

                UpdateBrandCommand = new RelayCommand(
                    () =>
                    {

                    });

                DeleteBrandCommand = new RelayCommand(
                    () =>
                    {
                        Brands.Delete(SelectedBrand.Id);
                    },
                    () => { return SelectedBrand != null; });
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
