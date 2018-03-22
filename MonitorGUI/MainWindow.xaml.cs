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
using MonitorGUI.MonitorServiceReference;

namespace MonitorGUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MonitorServiceClient client;

        public MainWindow()
        {
            InitializeComponent();
            this.client = new MonitorServiceClient();
            NbRequests.Content = client.GetNbRequest();
            NbCacheRequests.Content = client.GetNbCacheRequest();
            CurrentCacheExpirationTime.Content = client.GetCacheExpirationTime();
        }

        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentCacheExpirationTime.Content = client.SetCacheExpirationTime(int.Parse(CacheExpirationTimeSetter.Text));
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            NbRequests.Content = client.GetNbRequest();
            NbCacheRequests.Content = client.GetNbCacheRequest();
        }
    }
}
