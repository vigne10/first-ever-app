using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
    /// Interaction logic for NewBuilding.xaml
    /// </summary>
    public partial class NewBuildingWindow : Window
    {

        public NewBuildingWindow(Building building, BuildingCollection buildingCollection, DataAccess dataAccess)
        {
            NewBuilVM = new NewBuildingVM(building, buildingCollection, dataAccess);
            DataContext = NewBuilVM;
            InitializeComponent();
        }

        public NewBuildingVM NewBuilVM { get; set; }

        private void ButtonChangeStatut_Click(object sender, RoutedEventArgs e)
        {
            NewBuilVM.ChangeStatut();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce bâtiment ? Cette action est irréversible", "Confirmation", MessageBoxButtons.OKCancel);
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                NewBuilVM.DataAccess.DeleteBuilding(NewBuilVM.BuildingInProgress, NewBuilVM.BuildingCollection);
                this.Close();
            }
        }

        private void ButtonSaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            if (NewBuilVM.BuildingInProgress.City != null && NewBuilVM.BuildingInProgress.Country != null && 
                NewBuilVM.BuildingInProgress.Address != null)
            {
                NewBuilVM.BuildingInProgress.RemoveEndingSpaceAndHyphen();
                if (NewBuilVM.BuildingCollection.DoubleCheck(NewBuilVM.BuildingInProgress))
                {
                    this.Close();
                }
            }
            else
            {
                System.Windows.MessageBox.Show($"Veuillez rentrer des informations concernant le bâtiment", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
