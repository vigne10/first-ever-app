using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfBVimmo.Models;
using WpfBVimmo.Utilities.DataAccess;

namespace WpfBVimmo.ViewModels
{
    public class BuildingTypeChoiceVM
    {
        private const string PIC_DIR = @"pictures\";
        public BuildingTypeChoiceVM(BuildingCollection buildingCollection, DataAccess dataAccess)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string path = Path.Combine(projectDirectory, PIC_DIR);
            BuildingCollection = buildingCollection;
            DataAccess = dataAccess;
            BuildingTypeList = new List<TypeBuildingCombo>();
            BuildingTypeList.Add(new TypeBuildingCombo("Appartement", path + "Apartment.jpg"));
            BuildingTypeList.Add(new TypeBuildingCombo("Maison", path + "House.jpg"));
        }

        public List<TypeBuildingCombo> BuildingTypeList { get; set; }

        public TypeBuildingCombo SelectedBuildingType { get; set; }

        public BuildingCollection BuildingCollection { get; set; }

        public DataAccess DataAccess { get; set; }

        /// <summary>
        /// Function that creates a building of a derived class based on the choice made in the ComboBox
        /// </summary>
        /// <returns>A new building of a derived class based on the choice made in the ComboBox</returns>
        public Building CreateNewBuilding()
        {
            if (SelectedBuildingType.Name == "Appartement")
            {
                return new Apartment();
            }
            else
            {
                return new House();
            }
        }//end CreateNewBuilding

        /// <summary>
        /// Function used to give an identifier to a new building based on the maximum identifier in datas
        /// </summary>
        /// <returns>Max id + 1</returns>
        public int BuildId()
        {
            if (BuildingCollection.Count() == 0)
            {
                return 1;
            }
            else
            {
                List<Building> buildingList = BuildingCollection.ToList();
                Building buildingWithMaxId = buildingList.Find(u => u.BuildingID == buildingList.Max(x => x.BuildingID));
                return buildingWithMaxId.BuildingID + 1;
            }

        }//end BuildId

    }//end class
}//end namespace
