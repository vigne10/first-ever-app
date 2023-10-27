using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfBVimmo.Models;
using WpfBVimmo.ViewModels;

namespace WpfBVimmo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainVM = new MainWindowVM();
            DataContext = MainVM;
            InitializeComponent();
        }

        public MainWindowVM MainVM;

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            MainVM.DataAccess.UpdateAllDatas(MainVM.BuildingCollection);          
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MenuItemNewBuilding_Click(object sender, RoutedEventArgs e)
        {
            BuildingTypeChoiceWindow BuildingTypeChoiceWindow = new BuildingTypeChoiceWindow(MainVM.BuildingCollection, MainVM.DataAccess);
            BuildingTypeChoiceWindow.Show();
        }

        private void DataGridHouse_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainVM.SelBuilding = (House)DataGridHouse.SelectedItem;
            NewBuildingWindow NewBuildingWindow = new NewBuildingWindow(MainVM.SelBuilding, MainVM.BuildingCollection, MainVM.DataAccess);
            NewBuildingWindow.Show();
        }

        private void DataGridApartment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainVM.SelBuilding = (Apartment)DataGridApartment.SelectedItem;
            NewBuildingWindow NewBuildingWindow = new NewBuildingWindow(MainVM.SelBuilding, MainVM.BuildingCollection, MainVM.DataAccess);
            NewBuildingWindow.Show();
        }
    }//end class
}//end namespace
