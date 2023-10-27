using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBVimmo.Models;
using WpfBVimmo.Utilities.DataAccess;

namespace WpfBVimmo.ViewModels
{
    public class NewBuildingVM
    {
        public NewBuildingVM(Building building, BuildingCollection buildingCollection, DataAccess dataAccess)
        {
            BuildingInProgress = building;
            BuildingCollection = buildingCollection;
            DataAccess = dataAccess;
        }

        public Building BuildingInProgress { get; set; }

        public DataAccess DataAccess { get; set; }

        public BuildingCollection BuildingCollection { get; set; }

        /// <summary>
        /// Function used to change status of a building
        /// </summary>
        public void ChangeStatut()
        {
            int max = Enum.GetValues(typeof(Building.Status)).Cast<int>().Max();
            if ((int)BuildingInProgress.ActualStatus < max)
            {
                BuildingInProgress.ActualStatus += 1;
            }
            else if ((int)BuildingInProgress.ActualStatus >= max)
            {
                BuildingInProgress.ActualStatus = 0;
            }
        }
    }//end class
}//end namespace
