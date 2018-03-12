using IWS_VelibWS;
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

namespace ClientGUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Service intermediaryWebService = new Service();

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
            StationName.Content = e.AddedItems[0].ToString().Split('\n')[0];
            StationDetails.Text = intermediaryWebService.GetInfoAbout(e.AddedItems[0].ToString().Split('\n')[0], CitySelection.SelectedItem.ToString().Split(',')[0]);
        }

        private void StationDetails_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
