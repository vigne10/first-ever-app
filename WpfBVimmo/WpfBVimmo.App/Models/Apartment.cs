using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfBVimmo.Models
{
    public class Apartment : Building
    {
        private const int MIN_FLOOR = 0;
        private const int MAX_FLOOR = 250;

        private int _floor;
        private bool _elevator;
        private bool _sharedGarden;
        private bool _sharedTerrace;

        public Apartment() { } //end empty constructor

        public Apartment(Status status, int id, string country, string city, string address, int addressNumber, int area, 
            int numberOfRooms, int numberOfBedrooms, int numberOfBathrooms, int numberOfWC, bool privateGarden, 
            bool privateTerrace, bool sharedPool, bool cellar, int indoorParking, int outdoorParking, int floor, 
            bool elevator, bool sharedGarden, bool sharedTerrace) : base(status, id, country, city, address, addressNumber, 
                area, numberOfRooms, numberOfBedrooms, numberOfBathrooms, numberOfWC, privateGarden, privateTerrace, 
                sharedPool, cellar, indoorParking, outdoorParking)
        {
            Floor = floor;
            Elevator = elevator;
            SharedGarden = sharedGarden;
            SharedTerrace = sharedTerrace;
        }//end constructor

        public int Floor 
        { 
            get { return _floor; } 
            set 
            {
                if (CheckNumberEntry(value, MIN_FLOOR, MAX_FLOOR))
                {
                    _floor = value;
                    OnPropertyChanged(nameof(Floor));
                }
            } 
        }

        public bool Elevator 
        { 
            get { return _elevator; } 
            set 
            { 
                _elevator = value;
                OnPropertyChanged(nameof(Elevator));
            }
        }

        public bool SharedGarden 
        { 
            get { return _sharedGarden; } 
            set 
            { 
                _sharedGarden = value;
                OnPropertyChanged(nameof(SharedGarden));
            }
        }

        public bool SharedTerrace
        {
            get { return _sharedTerrace; }
            set
            {
                _sharedTerrace = value;
                OnPropertyChanged(nameof(SharedTerrace));
            }
        }

    }//end class
}//end namespace
