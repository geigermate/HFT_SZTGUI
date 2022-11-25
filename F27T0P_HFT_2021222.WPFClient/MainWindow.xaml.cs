using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace F27T0P_HFT_2021222.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBrandWindow(object sender, RoutedEventArgs e)
        {
            BrandWindow bw = new BrandWindow();
            bw.Show();
        }

        private void OpenGpuTypeWindow(object sender, RoutedEventArgs e)
        {
            GpuTypeWindow gw = new GpuTypeWindow();
            gw.Show();
        }

        private void OpenCustomerWindow(object sender, RoutedEventArgs e)
        {
            CustomerWindow cw = new CustomerWindow();
            cw.Show();
        }
    }
}
