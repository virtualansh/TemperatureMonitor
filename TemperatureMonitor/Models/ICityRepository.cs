using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Models
{
    interface ICityRepository
    {
        string GetName(int Id);
        void Initialize(SqlConnection SqlConnection);

    }
}
