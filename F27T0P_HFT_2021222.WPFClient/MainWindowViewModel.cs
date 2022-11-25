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

    }
}
