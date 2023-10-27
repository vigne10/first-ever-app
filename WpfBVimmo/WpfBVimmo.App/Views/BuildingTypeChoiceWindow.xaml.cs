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
using System.Windows.Shapes;
using WpfBVimmo.Models;
using WpfBVimmo.Utilities.DataAccess;
using WpfBVimmo.ViewModels;

namespace WpfBVimmo.Views
{
    /// <summary>
    /// Interaction logic for BuildingTypeChoice.xaml
    /// </summary>
    public partial class BuildingTypeChoiceWindow : Window
    {
        public BuildingTypeChoiceWindow(BuildingCollection buildingCollection, DataAccess dataAccess)
        {
            BuildingTypeVM = new BuildingTypeChoiceVM(buildingCollection, dataAccess);
            DataContext = BuildingTypeVM;
            InitializeComponent();
        }

        private BuildingTypeChoiceVM BuildingTypeVM { get; set; }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxTypesMachine.SelectedItem == null)
            {
                MessageBox.Show($"Veuillez choisir un type de bâtiment", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Building NewBuilding = BuildingTypeVM.CreateNewBuilding();
                NewBuilding.BuildingID = BuildingTypeVM.BuildId();
                if(BuildingTypeVM.BuildingCollection == null)
                {
                    BuildingTypeVM.BuildingCollection = new BuildingCollection();
                }
                BuildingTypeVM.BuildingCollection.Add(NewBuilding);
                this.Close();
                NewBuildingWindow NewBuildingWindow = new NewBuildingWindow(NewBuilding, BuildingTypeVM.BuildingCollection, BuildingTypeVM.DataAccess);
                NewBuildingWindow.Show();
            }  
        }
    }
}
