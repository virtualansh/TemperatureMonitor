using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Models
{
    public interface IMonitoredCityRepository
    {
        bool Add(IMonitoredCity city);
        bool Remove(int cityID);

        bool Find(int cityID);

        string GetName(int cityID);

        string UpdateTemperature(int cityID, float temperature);
    }
}
