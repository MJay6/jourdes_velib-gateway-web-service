using System;
using System.Windows;
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
            try
            {
                ErrorLabel.Content = "";
                CurrentCacheExpirationTime.Content = client.SetCacheExpirationTime(int.Parse(CacheExpirationTimeSetter.Text));
            }
            catch (FormatException)
            {
                ErrorLabel.Content = "Veuillez rentrer un entier valide.";
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            NbRequests.Content = client.GetNbRequest();
            NbCacheRequests.Content = client.GetNbCacheRequest();
            CacheMonitoring.Items.Clear();
            foreach (var i in client.GetCachedCities())
            {
                CacheMonitoring.Items.Add(i);
            }
        }
    }
}
