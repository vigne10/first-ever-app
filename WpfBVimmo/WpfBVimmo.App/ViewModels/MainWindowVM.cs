using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfBVimmo.Models;
using WpfBVimmo.Utilities.DataAccess;

namespace WpfBVimmo.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {

        private const string DATAS_JSON_FILE = "Datas.json";
        private const string CONN_STRING = @"";

        private BuildingCollection _buildingCollection;
        private ICollectionView _apartListView;
        private ICollectionView _houseListView;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVM() 
        {
            StartWithJsonFile();   //uncomment to start with JsonFile
            /*StartWithSQL();*/          //uncomment to start with SQL
        }

        public DataAccess DataAccess { get; set; }

        public Building SelBuilding { get; set; }

        public BuildingCollection BuildingCollection 
        { 
            get { return _buildingCollection; }
            set
            {
                _buildingCollection = value;
                if(value != null)
                {
                    CollectionViewSource alv = new CollectionViewSource();
                    alv.Source = value;
                    ApartListView = alv.View;
                    ApartListView.Filter = ApartFilterMethod;
                    CollectionViewSource hlv = new CollectionViewSource();
                    hlv.Source = value;
                    HouseListView = hlv.View;
                    HouseListView.Filter = HouseFilterMethod;
                }
                OnPropertyChanged(nameof(BuildingCollection));
            }
        } 

        /// <summary>
        /// Used to have the datagrid with apartments only
        /// </summary>
        public ICollectionView ApartListView 
        {
            get { return _apartListView; }
            set
            {
                _apartListView = value;
                OnPropertyChanged(nameof(ApartListView));
            }
        }

        /// <summary>
        /// Used to have the datagrid with houses only
        /// </summary>
        public ICollectionView HouseListView 
        {
            get { return _houseListView; }
            set
            {
                _houseListView = value;
                OnPropertyChanged(nameof(HouseListView));
            }
        }

        /// <summary>
        /// Function used by the ICollectionView ApartListView to have apartments only
        /// </summary>
        private bool ApartFilterMethod(object item) 
        {
            return item is Apartment ? true : false;
        }

        /// <summary>
        /// Function used by the ICollectionView HouseListView to have houses only
        /// </summary>
        private bool HouseFilterMethod(object item)
        {
            return item is House ? true : false;
        }

        /// <summary>
        /// Function used to start with datas in a Json file
        /// </summary>
        private void StartWithJsonFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string path = Path.Combine(projectDirectory, DATAS_JSON_FILE);

            DataAccess = new DataAccessJsonFile(path, new string[] { "json" });
            BuildingCollection = DataAccess.GetDatas();

            /* uncomment the code below if the data is empty and you want to automatically add 1 apartment and 1 house 
             * when launching the application */

            if (BuildingCollection.Count() == 0)
            {
                BuildingCollection = DataAccess.StartWithNoData();
            }


        }//StartWithJsonFile()


        /// <summary>
        /// Function used to start with datas in a database SQL
        /// </summary>
        private void StartWithSQL()
        {
            DataAccess = new DataAccessSQL(CONN_STRING);
            BuildingCollection = DataAccess.GetDatas();

            /* uncomment the code below if the data is empty and you want to automatically add 1 apartment and 1 house 
             * when launching the application */

            //if(BuildingCollection.Count() == 0)
            //{
            //    BuildingCollection = DataAccess.StartWithNoData();
            //}


        }//end StartWithSQL()

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }//end OnPropertyChanged

    }//end class
}//end namespace
