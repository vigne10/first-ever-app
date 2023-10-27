using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBVimmo.Models;

namespace WpfBVimmo.Utilities.Interfaces
{
    interface IDataAccess
    {

        string AccessPath { get; set; }

        BuildingCollection GetDatas();

        void UpdateAllDatas(BuildingCollection buildingCollection);

        void DeleteBuilding (Building b, BuildingCollection buildingCollection);

    }//end interface
}//end namespace
