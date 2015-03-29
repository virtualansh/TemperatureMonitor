using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using System.Threading.Tasks;

namespace TemperatureMonitor.Models
{
    public static class CityRepository
    {
        private static SqlConnection _sqlConnection;
               
        public static void Initialize(string sqlConnection)
        {
            _sqlConnection = new SqlConnection(sqlConnection);
        }

        public static Task<IEnumerable<City>> GetAll()
        {
            return _sqlConnection.GetListAsync<City>();
        }

        public static async Task<string> GetName(int Id)
        {
           City x = await _sqlConnection.GetAsync<City>(Id);
           return x.Name;
        }
    }
}