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
    class BrandWindowViewModel : ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }

        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    //SetProperty(ref selectedBrand, value);
                    selectedBrand = new Brand()
                    {
                        BrandId = value.BrandId,
                        BrandName = value.BrandName
                    };
                    OnPropertyChanged();
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }

        public BrandWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Brands = new RestCollection<Brand>("http://localhost:42137/", "brand", "hub");

                CreateBrandCommand = new RelayCommand(
                    () =>
                    {
                        Brands.Add(new Brand() { BrandName = SelectedBrand.BrandName });
                    });

                UpdateBrandCommand = new RelayCommand(
                    () =>
                    {
                        Brands.Update(SelectedBrand);
                    });

                DeleteBrandCommand = new RelayCommand(
                    () =>
                    {
                        Brands.Delete(SelectedBrand.BrandId);
                    },

                    () => { return SelectedBrand != null; });

                SelectedBrand = new Brand();
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
