using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TemperatureMonitor.Models
{
    public static class CityRepository //: ICityRepository
    {
        private static IDataCollection _cities;
        private static SqlConnection _result;

        //public CityRepository(IDataCollection dataCollection)
       // {
       //     _cities = dataCollection;
       // }
        public static void Initialize(IDataCollection dataCollection, string sqlConnection)
        {
            _cities = dataCollection;
            _result = new SqlConnection(sqlConnection);
        }

        public static bool Add(IMonitoredCity city)
        {
            return _cities.Add(city);

        }

        public static bool Remove(int cityID)
        {
            return _cities.Remove(cityID);


        }

        
       
            
        
    }
}