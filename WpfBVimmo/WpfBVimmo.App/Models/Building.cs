using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace WpfBVimmo.Models
{
    public abstract class Building : INotifyPropertyChanged
    {

        private const int ADDRESS_NUMBER_MIN = 1;
        private const int ADDRESS_NUMBER_MAX = 3000;
        private const int AREA_MIN = 0;
        private const int AREA_MAX = 2000;
        private const int NUMBER_OF_ROOMS_MIN = 0;
        private const int NUMBER_OF_ROOMS_MAX = 100;
        private const int NUMBER_OF_BEDROOMS_MIN = 0;
        private const int NUMBER_OF_BEDROOMS_MAX = 20;
        private const int NUMBER_OF_BATHROOMS_MIN = 0;
        private const int NUMBER_OF_BATHROOMS_MAX = 20;
        private const int NUMBER_OF_WC_MIN = 0;
        private const int NUMBER_OF_WC_MAX = 15;
        private const int INDOOR_PARKING_MIN = 0;
        private const int INDOOR_PARKING_MAX = 25;
        private const int OUTDOOR_PARKING_MIN = 0;
        private const int OUTDOOR_PARKING_MAX = 100;


        private Status _actualStatus;
        private int _buildingID;
        private string _country;
        private string _city;
        private string _address;
        private int _addressNumber;
        private int _area;
        private int _numberOfRooms;
        private int _numberOfBedrooms;
        private int _numberOfBathrooms;
        private int _numberOfWC;
        private bool _privateGarden;
        private bool _privateTerrace;
        private bool _sharedPool;
        private bool _cellar;
        private int _indoorParking;
        private int _outdoorParking;

        public event PropertyChangedEventHandler PropertyChanged;

        public Building() 
        {
            AddressNumber = 1; //default address number when a huilding is created
            SetGoodPropertyOn();
        }//end empty constructor

        public Building(Status status, int id, string country, string city, string address, int addressNumber, int area, int numberOfRooms, 
            int numberOfBedrooms, int numberOfBathrooms, int numberOfWC, bool privateGarden, bool privateTerrace, 
            bool sharedPool, bool cellar, int indoorParking, int outdoorParking) 
        {
            ActualStatus = status;
            BuildingID = id;
            Country = country;
            City = city;
            Address = address;
            AddressNumber = addressNumber;
            Area = area;
            NumberOfRooms = numberOfRooms;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            NumberOfWC = numberOfWC;
            PrivateGarden = privateGarden;
            PrivateTerrace = privateTerrace;
            SharedPool = sharedPool;
            Cellar = cellar;
            IndoorParking = indoorParking;
            OutdoorParking = outdoorParking;
            SetGoodPropertyOn();
        }//end constructor

        public bool IsApartment { get; set; } //Used in the NewBuildingWindow to enable or disable some settings
        public bool IsHouse { get; set; } //Used in the NewBuildingWindow to enable or disable some settings

        public Status ActualStatus 
        {
            get { return _actualStatus; } 
            set 
            { 
                _actualStatus = value;
                OnPropertyChanged(nameof(ActualStatus));
            }
        }

        public enum Status
        {
            A_Louer,
            A_Vendre,
            Loué,
            Vendu
        }

        public int BuildingID 
        { 
            get { return _buildingID; } 
            set 
            { 
                _buildingID = value;
                OnPropertyChanged(nameof(BuildingID));
            } 
        }

        public string Country 
        { 
            get { return _country; } 
            set 
            {
                if (CheckStringEntry(value))
                {
                    _country = value;
                    OnPropertyChanged(nameof(Country));
                }
            } 
        }

        public string City 
        { 
            get { return _city; } 
            set 
            {
                if (CheckStringEntry(value))
                {
                    _city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        public string Address 
        { 
            get { return _address; } 
            set 
            {
                if (CheckStringEntry(value))
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }

            }
        }

        public int AddressNumber
        {
            get { return _addressNumber; }
            set
            {
                if (CheckNumberEntry(value, ADDRESS_NUMBER_MIN, ADDRESS_NUMBER_MAX))
                {
                    _addressNumber = (int)value;
                    OnPropertyChanged(nameof(AddressNumber));
                }
                
            }
        }

        public int Area 
        { 
            get { return _area; } 
            set 
            {
                if (CheckNumberEntry(value, AREA_MIN, AREA_MAX))
                {
                    _area = value;
                    OnPropertyChanged(nameof(Area));
                }
            }
        }

        public int NumberOfRooms 
        { 
            get { return _numberOfRooms; } 
            set 
            {
                if (CheckNumberEntry(value, NUMBER_OF_ROOMS_MIN, NUMBER_OF_ROOMS_MAX))
                {
                    _numberOfRooms = value;
                    OnPropertyChanged(nameof(NumberOfRooms));
                } 
            }
        }

        public int NumberOfBedrooms 
        { 
            get { return _numberOfBedrooms; } 
            set 
            {
                if (CheckNumberEntry(value, NUMBER_OF_BEDROOMS_MIN, NUMBER_OF_BEDROOMS_MAX))
                {
                    _numberOfBedrooms = value;
                    OnPropertyChanged(nameof(NumberOfBedrooms));
                }              
            }
        }

        public int NumberOfBathrooms 
        { 
            get { return _numberOfBathrooms; } 
            set 
            {
                if (CheckNumberEntry(value, NUMBER_OF_BATHROOMS_MIN, NUMBER_OF_BATHROOMS_MAX))
                {
                    _numberOfBathrooms = value;
                    OnPropertyChanged(nameof(NumberOfBathrooms));
                }
            }
        }

        public int NumberOfWC 
        { 
            get { return _numberOfWC; } 
            set 
            {
                if (CheckNumberEntry(value, NUMBER_OF_WC_MIN, NUMBER_OF_WC_MAX))
                {
                    _numberOfWC = value;
                    OnPropertyChanged(nameof(NumberOfWC));
                }  
            }
        }

        public bool PrivateGarden 
        { 
            get { return _privateGarden; } 
            set 
            { 
                _privateGarden = value;
                OnPropertyChanged(nameof(PrivateGarden));
            }
        }

        public bool PrivateTerrace 
        { 
            get { return _privateTerrace; } 
            set 
            { 
                _privateTerrace = value;
                OnPropertyChanged(nameof(PrivateTerrace));
            }
        }

        public bool SharedPool 
        { 
            get { return _sharedPool; } 
            set 
            { 
                _sharedPool = value;
                OnPropertyChanged(nameof(SharedPool));
            }
        }

        public bool Cellar 
        { 
            get { return _cellar; } 
            set 
            { 
                _cellar = value;
                OnPropertyChanged(nameof(Cellar));
            }
        }

        public int IndoorParking 
        { 
            get { return _indoorParking; } 
            set 
            {
                if (CheckNumberEntry(value, INDOOR_PARKING_MIN, INDOOR_PARKING_MAX))
                {
                    _indoorParking = value;
                    OnPropertyChanged(nameof(IndoorParking));
                }   
            }
        }

        public int OutdoorParking 
        { 
            get { return _outdoorParking; } 
            set 
            {
                if (CheckNumberEntry(value, OUTDOOR_PARKING_MIN, OUTDOOR_PARKING_MAX))
                {
                    _outdoorParking = value;
                    OnPropertyChanged(nameof(OutdoorParking));
                }     
            }
        }

        /// <summary>
        /// Set the property IsApartment or IsHouse to true when a building is created
        /// </summary>
        private void SetGoodPropertyOn()
        {
            if (this.GetType() == typeof(Apartment))
            {
                IsApartment = true;
            }
            else
            {
                IsHouse = true;
            }
        }

        /// <summary>
        /// Do some input checks
        /// </summary>
        /// <param name="entry">User input</param>
        /// <returns>True if input is ok</returns>
        public static bool CheckStringEntry(string entry)
        {
            if (entry != "")
            {
                //if Entry start with a space or a dash
                if (entry.StartsWith(" ") || entry.StartsWith("-"))
                {
                    MessageBox.Show($"thomas est une puteLa saisie {entry} ne peut commencer par un espace ou un tiret", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                //if Entry contains a double space or a double dash
                if (entry.Contains("  ") || entry.Contains("--"))
                {
                    MessageBox.Show($"La saisie {entry} comporte au moins un double espace ou un double tiret non autorisé", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                //test if there are special characters (outside the alphabet and accented characters) without taking into account a space or a dash
                if (!Regex.IsMatch(entry, @"^[a-zA-ZÀ-ú -]*$"))
                {
                    MessageBox.Show($"La saisie {entry} ne peut comporter de caractères spéciaux", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                //test if start with uppercase
                if (!Regex.IsMatch(entry, @"^[A-Z]+"))
                {
                    MessageBox.Show($"La saisie {entry} doit commencer par une majuscule", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                string[] entryParts = entry.Split('-', ' ');
                foreach (string s in entryParts)
                {
                    if(s != "")
                    {
                        //test if the first letter of each element is a capital letter and the following lowercase letters
                        if (!Regex.IsMatch(s, @"^[A-ZÀ-Ú][a-zà-ú]*$"))
                        {
                            MessageBox.Show($"La saisie {entry} ne correpond pas aux critères. La première lettre de chaque élément qui compose la saisie doit être une majuscule et les suivantes des minuscules.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return false;
                        }
                    }
                }
            }
            return true;
        }//end CheckStringEntry

        /// <summary>
        /// Check if a number is between a min and a max (= is ok)
        /// </summary>
        /// <param name="entry">Number to check</param>
        /// <param name="minValue">Min value</param>
        /// <param name="maxValue">Max value</param>
        /// <returns>true if the number is ok</returns>
        public static bool CheckNumberEntry(int entry, int minValue, int maxValue)
        {
            if(entry >= minValue && entry <= maxValue)
            {
                return true;
            }
            MessageBox.Show($"Veuillez saisir un nombre entre {minValue} et {maxValue}", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }

        /// <summary>
        /// Function called when a building is saved to remove excess spaces and dashes
        /// </summary>
        public void RemoveEndingSpaceAndHyphen()
        {

            this.Address = this.Address.TrimEnd();
            RemoveHyphenAtTheEnd(this.Address);

            this.Country = this.Country.TrimEnd();
            RemoveHyphenAtTheEnd(this.Country);

            this.City = this.City.TrimEnd();
            RemoveHyphenAtTheEnd(this.City);

        }//end RemoveEndingSpaceAndHyphen()

        /// <summary>
        /// Function called by RemoveEndingSpaceAndHyphen() to remove all excess dashes
        /// </summary>
        private void RemoveHyphenAtTheEnd(string s)
        {
            while (s.EndsWith("-"))
            {
                s.Replace("-", "");
            }
        }//end RemoveHyphenAtTheEnd

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }//end OnPropertyChanged


    }//end class
}//end namespace
