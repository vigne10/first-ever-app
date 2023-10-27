using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using WpfBVimmo.Models;
using WpfBVimmo.Utilities.Interfaces;

namespace WpfBVimmo.Utilities.DataAccess
{
    public abstract class DataAccess : IDataAccess
    {

        private string _accessPath;

        public DataAccess(string filePath)
        {
            AccessPath = filePath;
        }

        public DataAccess(string filePath, string[] extensions)
        {

            Extensions = new List<string>(extensions.ToList());
            AccessPath = filePath;

        }

        /// <summary>
        /// AccessPath file to the data source
        /// </summary>
        public virtual string AccessPath
        {
            get => _accessPath;
            set
            {
                if (CheckAccessPath(value))
                {
                    _accessPath = value;
                }
            }
        }

        /// <summary>
        /// List of authorized extensions .txt, csv, .Json, .xml ...for the AccessPath file
        /// </summary>
        private List<string> Extensions { get; set; }

        /// <summary>
        /// Continue to check AccessPath even after constructor (in the case of the file may be moved, renamed or deleted)
        /// </summary>
        public bool IsValidAccessPath => CheckAccessPath(AccessPath);

        /// <summary>
        /// Collect datas from the database and create house and apartment collection
        /// </summary>
        /// <returns>buildingCollection</returns>
        public abstract BuildingCollection GetDatas();

        /// <summary>
        /// Update database datas
        /// </summary>
        public abstract void UpdateAllDatas(BuildingCollection buildingCollection);

        /// <summary>
        /// Function to delete a building in datas
        /// </summary>
        public abstract void DeleteBuilding(Building b, BuildingCollection buildingCollection);

        /// <summary>
        /// Check AccessPath to the data source file. File path must exist and if
        /// extensions are specified, the extension file must match to one of them
        /// </summary>
        /// <returns>true if valid path and extension file</returns>
        private bool CheckAccessPath(string tryPath)
        {
            if (File.Exists(tryPath))
            {
                if (Extensions?.Any() ?? false)
                {
                    string pattern = "";
                    foreach (string ext in Extensions)
                    {
                        pattern += ext + "|";
                    }
                    pattern = pattern.Substring(0, pattern.Length - 1);
                    //check extension file
                    if (!Regex.IsMatch(tryPath, pattern + "$")) //pattern exemple = ".txt|.csv$"
                    {
                        MessageBox.Show($"L'extension du fichier {tryPath} n'est pas valide, extensions attendues: " +
                            $"{ pattern}", "Erreur de fichier", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show($"Le fichier {tryPath} n'existe pas", "Erreur de fichier",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }

        }//end CheckAccessPath

        /// <summary>
        /// This function automatically adds 1 house and 1 apartment to the launch of the application if the data is empty
        /// </summary>
        /// <returns>returns a building collection with 1 house and 1 apartment</returns>
        public BuildingCollection StartWithNoData()
        {
            BuildingCollection buildingCollection = new BuildingCollection();
            Apartment appart = new Apartment(0, 1, "Belgique", "Mons", "Rue Du Parc", 5, 55, 6, 2, 1, 1, false, true, false, false, 0, 2, 2, true, false, false);
            buildingCollection.Add(appart);

            House house = new House(0, 2, "Belgique", "Binche", "Rue Du Chene", 18, 120, 8, 3, 2, 2, true, true, false, true, 1, 2, 160, 3, true, true);
            buildingCollection.Add(house);

            return buildingCollection;
        }

    }//end class
}//end namespace
