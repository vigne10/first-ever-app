using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBVimmo.Models
{
    public class House : Building
    {

        private const int LAND_AREA_MIN = 0;
        private const int LAND_AREA_MAX = 2000;
        private const int NUMBER_OF_FLOOR_MIN = 0;
        private const int NUMBER_OF_FLOOR_MAX = 250;

        private int _landArea;
        private int _numberOfFloor;
        private bool _attic;
        private bool _privatePool;

        public House() { }//end empty constructor

        public House(Status status, int id, string country, string city, string address, int addressNumber, int area, 
            int numberOfRooms, int numberOfBedrooms, int numberOfBathrooms, int numberOfWC, bool privateGarden, 
            bool privateTerrace, bool sharedPool, bool cellar, int indoorParking, int outdoorParking, int landArea, 
            int numberOfFloor, bool attic, bool privatePool) : base(status, id, country, city, address, addressNumber, 
                area, numberOfRooms, numberOfBedrooms, numberOfBathrooms, numberOfWC, privateGarden, privateTerrace, 
                sharedPool, cellar, indoorParking, outdoorParking)
        {
            LandArea = landArea;
            NumberOfFloor = numberOfFloor;
            Attic = attic;
            PrivatePool = privatePool;
        }//end constructor

        public int LandArea 
        { 
            get { return _landArea; } 
            set 
            {
                if (CheckNumberEntry(value, LAND_AREA_MIN, LAND_AREA_MAX))
                {
                    _landArea = value;
                    OnPropertyChanged(nameof(LandArea));
                }
            }
        }
        
        public int NumberOfFloor 
        { 
            get { return _numberOfFloor; } 
            set 
            {
                if (CheckNumberEntry(value, NUMBER_OF_FLOOR_MIN, NUMBER_OF_FLOOR_MAX))
                {
                    _numberOfFloor = value;
                    OnPropertyChanged(nameof(NumberOfFloor));
                }
            }
        }

        public bool Attic 
        { 
            get { return _attic; } 
            set 
            { 
                _attic = value;
                OnPropertyChanged(nameof(Attic));
            }
        }

        public bool PrivatePool
        {
            get { return _privatePool; }
            set
            {
                _privatePool = value;
                OnPropertyChanged(nameof(PrivatePool));
            }
        }


    }//end class
}//end namespace
