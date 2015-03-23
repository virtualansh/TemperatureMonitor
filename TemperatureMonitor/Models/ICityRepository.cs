using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Models
{
    public interface ICityRepository
    {
        bool Add(IMonitoredCity city);
        bool Remove(int cityID);
    }
}
