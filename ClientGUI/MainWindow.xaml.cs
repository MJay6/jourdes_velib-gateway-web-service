using System.Windows;
using System.Windows.Controls;
using ClientGUI.ServiceReference;

namespace ClientGUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceClient intermediaryWebService = new ServiceClient();

        public MainWindow()
        {
            InitializeComponent();
            
            foreach (string name in intermediaryWebService.GetCities())
            {
                CitySelection.Items.Add(name);
            }
        }

        private void CitySelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StationSelection.Items.Clear();
            StationName.Content = "";
            StationDetails.Text = "Aucune station sélectionnée";
            foreach (string station in intermediaryWebService.GetStations(e.AddedItems[0].ToString().Split(',')[0]))
            {
                StationSelection.Items.Add(station);
            }
        }

        private void StationSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0)
            {
                return;
            }
            intermediaryWebService.RefreshStations(CitySelection.SelectedItem.ToString().Split(',')[0]);
            StationName.Content = e.AddedItems[0].ToString().Split('\n')[0];
            StationDetails.Text = intermediaryWebService.GetInfoAbout(e.AddedItems[0].ToString().Split('\n')[0], CitySelection.SelectedItem.ToString().Split(',')[0]);
        }

        private void StationDetails_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
