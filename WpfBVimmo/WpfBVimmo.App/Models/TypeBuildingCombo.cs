using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBVimmo.Models
{
    /// <summary>
    /// TypeBuildingCombo allows to create a easy combo box in the window where we have to choose a type of building 
    /// (BuildingTypeChoiceWindow)
    /// </summary>
    public class TypeBuildingCombo
    {
        public TypeBuildingCombo(string name, string imagePath)
        {
            Name = name;
            ImagePath = imagePath;

        }//end constructor

        public string Name { get; set; }
        public string ImagePath { get; set; }

    }//end class
}//end namespace
