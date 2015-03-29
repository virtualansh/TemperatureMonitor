using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using System.Web;

namespace TemperatureMonitor.Models
{
    public static class MonitoredCityRepository //: ICityRepository
    {
        private static IDataCollection _cities;
        private static SqlConnection _sqlConnection;

        public static void Initialize(IDataCollection dataCollection, string sqlConnection)
        {
            _cities = dataCollection;
            _sqlConnection = new SqlConnection(sqlConnection);
        }

        public static async Task<bool> Add(IMonitoredCity city)
        {
            System.Console.WriteLine("iN MONIOR CITY REPOSITORY ADD");
            var insertId = await _sqlConnection.InsertAsync(city);
            city.Id = insertId.Value;
            return true;
        }

        public static async Task<bool> Delete(IMonitoredCity monitoredCity)
        {
           int rowsAffected = await _sqlConnection.DeleteAsync<MonitoredCity>(monitoredCity.CityId);
           return (rowsAffected < 1? false : true);
        }

        public static async Task<bool> Update(IMonitoredCity monitoredCity)
        {
            await _sqlConnection.UpdateAsync(monitoredCity);
            return true;
        }

        public static async Task<bool> Exists(int cityID)
        {
            IMonitoredCity monitoredCity = await _sqlConnection.GetAsync<MonitoredCity>(cityID);
            if (monitoredCity != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static async Task<IEnumerable<IMonitoredCity>> GetAll()
        {
            IEnumerable<IMonitoredCity> monitoredCities = await _sqlConnection.GetListAsync<MonitoredCity>();
            if (monitoredCities != null)
            {
                return monitoredCities;
            }
            else
            {
                return null;
            }

        }





    }
}