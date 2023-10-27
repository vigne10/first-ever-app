using WpfBVimmo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WpfBVimmo.Utilities.Interfaces;

namespace WpfBVimmo.Utilities.DataAccess
{
    public class DataAccessSQL : DataAccess, IDataAccess
    {

        public DataAccessSQL(string connString) : base(connString)
        {

            SqlConnection = new SqlConnection(AccessPath);
            SqlConnection.Open();
            Console.WriteLine("Connection to database opened !");
        }
        /// <summary>
        /// Connection String
        /// override because it's not a file -> replaced by the connection string
        /// </summary>
        public override string AccessPath { get; set; }

        /// <summary>
        /// Connection to the database
        /// </summary>
        public SqlConnection SqlConnection { get; set; }

        public override BuildingCollection GetDatas()
        {
            string sql = "SELECT * FROM Building;";
            SqlCommand cmd = new SqlCommand(sql, SqlConnection);
            SqlDataReader dataReader = cmd.ExecuteReader();
            BuildingCollection buildingCollection = new BuildingCollection();

            while (dataReader.Read())
            {
                Building b = GetBuilding(dataReader);
                if (b != null)
                {
                    buildingCollection.Add(b);
                }
            }
            dataReader.Close();
            return buildingCollection;
        }//end GetDatas

        /// <summary>
        /// instanciate a new building from the derivated class in fonction of the type object (House, Apartment, ...) 
        /// contained in the first table column
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>An apartment or a house</returns>
        private Building GetBuilding(SqlDataReader dr)
        {
            string type = dr.GetValue(0).ToString();

            switch (type)
            {
                case "House":
                    return new House(status: (Building.Status)dr.GetInt32(1), id: dr.GetInt32(2), country: dr.GetString(3), 
                        city: dr.GetString(4), address: dr.GetString(5), addressNumber: dr.GetInt32(6), 
                        area: dr.GetInt32(7), numberOfRooms: dr.GetInt32(8), numberOfBedrooms: dr.GetInt32(9), 
                        numberOfBathrooms: dr.GetInt32(10), numberOfWC: dr.GetInt32(11), privateGarden: dr.GetBoolean(12),
                        privateTerrace: dr.GetBoolean(13), sharedPool: dr.GetBoolean(14), cellar: dr.GetBoolean(15), 
                        indoorParking: dr.GetInt32(16), outdoorParking: dr.GetInt32(17), landArea: dr.GetInt32(22),
                        numberOfFloor: dr.GetInt32(23), attic: dr.GetBoolean(24), privatePool: dr.GetBoolean(25)); 
                case "Apartment":
                    return new Apartment(status: (Building.Status)dr.GetInt32(1), id: dr.GetInt32(2), country: dr.GetString(3),
                        city: dr.GetString(4), address: dr.GetString(5), addressNumber: dr.GetInt32(6),
                        area: dr.GetInt32(7), numberOfRooms: dr.GetInt32(8), numberOfBedrooms: dr.GetInt32(9),
                        numberOfBathrooms: dr.GetInt32(10), numberOfWC: dr.GetInt32(11), privateGarden: dr.GetBoolean(12),
                        privateTerrace: dr.GetBoolean(13), sharedPool: dr.GetBoolean(14), cellar: dr.GetBoolean(15),
                        indoorParking: dr.GetInt32(16), outdoorParking: dr.GetInt32(17), floor: dr.GetInt32(18),
                        elevator: dr.GetBoolean(19), sharedGarden: dr.GetBoolean(20), sharedTerrace: dr.GetBoolean(21));
                default:
                    System.Windows.MessageBox.Show($"SELECT sql error, le type {type} n'est pas reconnu", "Erreur de lecture", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
            }
        }//end GetBuilding

        public override void UpdateAllDatas(BuildingCollection buildingCollection)
        {
            try
            {
                string sql = string.Empty;
                foreach (Building b in buildingCollection)
                {
                    //if id user already in databse, update his values, insert in the other case
                    sql = IsInDb(b.BuildingID, "Id", "Building") ? GetSqlUpdate(b) : GetSqlInsert(b);

                    if (!string.IsNullOrEmpty(sql))
                    {
                        //Console.WriteLine(sql);
                        SqlCommand command = new SqlCommand(sql, SqlConnection);
                        command.ExecuteNonQuery();
                    }
                }
                //SqlConnection.Close();
                System.Windows.MessageBox.Show("Sauvegarde effectuée");
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show($"insert or update sql request error {e.Message} ", "Erreur de sauvegarde", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }//end UpdateAllDatas

        /// <summary>
        /// Check if an id is in a table
        /// </summary>
        /// <returns>true if found</returns>
        private bool IsInDb(int id, string idName, string tableName)
        {
            string sql = $"SELECT * FROM {tableName} WHERE {idName} = {id}";
            SqlCommand cmd = new SqlCommand(sql, SqlConnection);
            SqlDataReader dataReader = cmd.ExecuteReader();
            bool inDb = dataReader.HasRows;
            dataReader.Close();
            return inDb;
        }

        /// <summary>
        /// create a sql request updating the user fonction of his type and his internal properties values.
        /// </summary>
        /// <returns>sql UPDATA request</returns>
        private string GetSqlUpdate(Building b)
        {
            string[] strType = b.GetType().ToString().Split('.');
            string type = strType[strType.Length - 1];
            switch (type)
            {
                case "Apartment":
                    Apartment apartment = (Apartment)b;
                    return $"UPDATE Building SET Status={(int)apartment.ActualStatus}, Country='{apartment.Country}', City='{apartment.City}', Address='{apartment.Address}', AddressNumber={apartment.AddressNumber}, Area={apartment.Area}, NumberOfRooms={apartment.NumberOfRooms}, NumberOfBedrooms={apartment.NumberOfBedrooms}, NumberOfBathrooms={apartment.NumberOfBathrooms}, NumberOfWC={apartment.NumberOfWC}, PrivateGarden={BoolSqlConvert(apartment.PrivateGarden)}, PrivateTerrace={BoolSqlConvert(apartment.PrivateTerrace)}, SharedPool={BoolSqlConvert(apartment.SharedPool)}, Cellar={BoolSqlConvert(apartment.Cellar)}, IndoorParking={apartment.IndoorParking}, OutdoorParking={apartment.OutdoorParking}, Floor={apartment.Floor}, Elevator={BoolSqlConvert(apartment.Elevator)}, SharedGarden={BoolSqlConvert(apartment.SharedGarden)}, SharedTerrace={BoolSqlConvert(apartment.SharedTerrace)} WHERE Id={apartment.BuildingID}";
                case "House":
                    House house = (House)b;
                    return $"UPDATE Building SET Status={(int)house.ActualStatus}, Country='{house.Country}', City='{house.City}', Address='{house.Address}', AddressNumber={house.AddressNumber}, Area={house.Area}, NumberOfRooms={house.NumberOfRooms}, NumberOfBedrooms={house.NumberOfBedrooms}, NumberOfBathrooms={house.NumberOfBathrooms}, NumberOfWC={house.NumberOfWC}, PrivateGarden={BoolSqlConvert(house.PrivateGarden)}, PrivateTerrace={BoolSqlConvert(house.PrivateTerrace)}, SharedPool={BoolSqlConvert(house.SharedPool)}, Cellar={BoolSqlConvert(house.Cellar)}, IndoorParking={house.IndoorParking}, OutdoorParking={house.OutdoorParking}, LandArea={house.LandArea}, NumberOfFloor={house.NumberOfFloor}, Attic={BoolSqlConvert(house.Attic)}, PrivatePool={BoolSqlConvert(house.PrivatePool)} WHERE Id={house.BuildingID}";
                default:
                    System.Windows.MessageBox.Show($"insert or update sql error, le type {type} n'est pas reconnu pour {b.BuildingID}", "Erreur de sauvegarde", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
            }

        }
        /// <summary>
        /// create a sql request. Insert the user fonction of his type and his internal properties values.
        /// </summary>
        /// <returns>sql INSERT request</returns>
        private string GetSqlInsert(Building b)
        {
            string[] strType = b.GetType().ToString().Split('.');
            string type = strType[strType.Length - 1];
            switch (type)
            {
                case "Apartment":
                    Apartment apartment = (Apartment)b;
                    return $"INSERT INTO Building (Type, Status, Id, Country, City, Address, AddressNumber, Area, NumberOfRooms, NumberOfBedrooms, NumberOfBathrooms, NumberOfWC, PrivateGarden, PrivateTerrace, SharedPool, Cellar, IndoorParking, OutdoorParking, Floor, Elevator, SharedGarden, SharedTerrace) VALUES('{type}', {(int)apartment.ActualStatus}, {apartment.BuildingID}, '{apartment.Country}', '{apartment.City}', '{apartment.Address}', {apartment.AddressNumber}, {apartment.Area}, {apartment.NumberOfRooms}, {apartment.NumberOfBedrooms}, {apartment.NumberOfBathrooms}, {apartment.NumberOfWC}, {BoolSqlConvert(apartment.PrivateGarden)}, {BoolSqlConvert(apartment.PrivateTerrace)}, {BoolSqlConvert(apartment.SharedPool)}, {BoolSqlConvert(apartment.Cellar)}, {apartment.IndoorParking}, {apartment.OutdoorParking}, {apartment.Floor}, {BoolSqlConvert(apartment.Elevator)}, {BoolSqlConvert(apartment.SharedGarden)}, {BoolSqlConvert(apartment.SharedTerrace)})";
                case "House":
                    House house = (House)b;
                    return $"INSERT INTO Building (Type, Status, Id, Country, City, Address, AddressNumber, Area, NumberOfRooms, NumberOfBedrooms, NumberOfBathrooms, NumberOfWC, PrivateGarden, PrivateTerrace, SharedPool, Cellar, IndoorParking, OutdoorParking, LandArea, NumberOfFloor, Attic, PrivatePool) VALUES('{type}', {(int)house.ActualStatus}, {house.BuildingID}, '{house.Country}', '{house.City}', '{house.Address}', {house.AddressNumber}, {house.Area}, {house.NumberOfRooms}, {house.NumberOfBedrooms}, {house.NumberOfBathrooms}, {house.NumberOfWC}, {BoolSqlConvert(house.PrivateGarden)}, {BoolSqlConvert(house.PrivateTerrace)}, {BoolSqlConvert(house.SharedPool)}, {BoolSqlConvert(house.Cellar)}, {house.IndoorParking}, {house.OutdoorParking}, {house.LandArea}, {house.NumberOfFloor}, {BoolSqlConvert(house.Attic)}, {BoolSqlConvert(house.PrivatePool)})";
                default:
                    System.Windows.MessageBox.Show($"insert or update sql erro, le type {type} n'est pas reconnu", "Erreur de sauvegarde", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
            }

        }
        /// <summary>
        /// change true, false to 1,0 for SQL requests
        /// </summary>
        /// <returns> "0" or "1" </returns>
        private string BoolSqlConvert(bool b)
        {
            return b ? "1" : "0";
        }

        public override void DeleteBuilding(Building b, BuildingCollection buildingCollection)
        {
            buildingCollection.Remove(b);
            if (IsInDb(b.BuildingID, "Id", "Building"))
            {
                string sql = GetSqlDelete(b);
                SqlCommand cmd = new SqlCommand(sql, SqlConnection);
                cmd.ExecuteNonQuery();
            }
        }

        private string GetSqlDelete(Building b)
        {
            return $"DELETE FROM Building WHERE Id={b.BuildingID}";
        }

    }//end class

}//end namespace
