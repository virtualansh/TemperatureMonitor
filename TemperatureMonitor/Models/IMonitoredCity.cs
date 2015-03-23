using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Models
{
    public interface IMonitoredCity
    {
        int CityID { get; set;}
        string CityName { get; set;}
        int SensingPeriod { get; set; }
        float LatestTemperature { get; set; }

    }
}
