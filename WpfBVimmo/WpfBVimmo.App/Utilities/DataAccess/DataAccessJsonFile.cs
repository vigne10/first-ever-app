using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBVimmo.Models;
using WpfBVimmo.Utilities.Interfaces;

namespace WpfBVimmo.Utilities.DataAccess
{
    public class DataAccessJsonFile : DataAccess, IDataAccess
    {
        public DataAccessJsonFile(string filePath) : base(filePath)
        {
        }

        public DataAccessJsonFile(string filePath, string[] extensions) : base(filePath, extensions)
        {
        }

        public override BuildingCollection GetDatas()
        {
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                BuildingCollection bCollection = new BuildingCollection();
                //settings are necessary to get also specific properties of the derivated class
                //and not only common properties of the base class (User)
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling
                    = TypeNameHandling.All
                };
                bCollection = JsonConvert.DeserializeObject<BuildingCollection>(jsonFile, settings);
                if(bCollection == null)
                {
                    bCollection = new BuildingCollection();
                }
                return bCollection;
            }
            else
            {
                //Console.WriteLine("GetUsersDatas File doesnt exist");
                return null;
            }
        }//end GetAllDatas

        public override void UpdateAllDatas(BuildingCollection buildingCollection)
        {
            if (IsValidAccessPath)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling
                    = TypeNameHandling.All
                };
                string json = JsonConvert.SerializeObject(buildingCollection, Formatting.Indented, settings);
                File.WriteAllText(AccessPath, json);
                System.Windows.MessageBox.Show("Sauvegarde effectuée");
            }
            else
            {
                Console.WriteLine("UpdateAllDatas error can't update datasource file");
            }
        }//end UpdateAllUsersDatas

        public override void DeleteBuilding(Building b, BuildingCollection buildingCollection)
        {
            buildingCollection.Remove(b);
        }//end DeleteBuilding

    }//end class

}//end namespace
