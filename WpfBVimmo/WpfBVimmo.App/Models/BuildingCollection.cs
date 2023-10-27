using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfBVimmo.Models
{
    public class BuildingCollection : ObservableCollection<Building>
    {
        /// <summary>
        /// Function that checks if the building does not exist in double in datas
        /// </summary>
        /// <param name="buildingToCheck"></param>
        /// <returns>true if the building does not exist, false if it exist</returns>
        public bool DoubleCheck(Building buildingToCheck)
        {
            List<Building> listOfBuildings = this.ToList();
            List<Building> listOfDuplicateBuilding = new List<Building>();

            foreach (Building b in listOfBuildings)
            {
                if (b.Address != null && b.Country != null && b.City != null)
                {
                    listOfDuplicateBuilding = listOfBuildings.FindAll(u => u.Address == buildingToCheck.Address &&
                    u.Country == buildingToCheck.Country && u.City == buildingToCheck.City && u.AddressNumber == 
                    buildingToCheck.AddressNumber);
                    if (listOfDuplicateBuilding.Count > 1)
                    {
                        MessageBox.Show($"Ce bâtiment existe déjà", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }
                }
            }
            return true;

        }

    }//end class
}//end namespace
