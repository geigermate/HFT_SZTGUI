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
    class GpuTypeWindowViewModel : ObservableRecipient
    {
        public RestCollection<GpuType> GpuTypes { get; set; }

        private GpuType selectedGpuType;

        public GpuType SelectedGpuType
        {
            get { return selectedGpuType; }
            set
            {
                if (value != null)
                {
                    selectedGpuType = new GpuType()
                    {
                        Id = value.Id,
                        Name = value.Name
                    };
                    OnPropertyChanged();

                    (DeleteGpuType as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateGpuType { get; set; }
        public ICommand DeleteGpuType { get; set; }
        public ICommand UpdateGpuType { get; set; }

        public GpuTypeWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                GpuTypes = new RestCollection<GpuType>("http://localhost:42137/", "gputype");

                CreateGpuType = new RelayCommand(
                    () => { GpuTypes.Add(new GpuType() { Name = SelectedGpuType.Name }); });

                UpdateGpuType = new RelayCommand(
                    () =>
                {
                    GpuTypes.Update(SelectedGpuType);
                });

                DeleteGpuType = new RelayCommand(
                    () =>
                {
                    GpuTypes.Delete(SelectedGpuType.Id);
                },
                () => { return SelectedGpuType != null; });

                SelectedGpuType = new GpuType();
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
