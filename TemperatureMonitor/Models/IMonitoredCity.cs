using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Models
{
    public interface IMonitoredCity
    {
        int Id { get; set;}
        string Name { get; set;}
        int SensingPeriod { get; set; }
        float LatestTemperature { get; set; }

        int CityId { get; set; }
    }
}
