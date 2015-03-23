using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemperatureMonitor.Models
{
    public class DataCollection: IDataCollection
    {
        private ICollection<IMonitoredCity> _monitoredCities;
        private object _lockObject;

        public DataCollection(ICollection<IMonitoredCity> monitoredCities)
        {
            _monitoredCities = monitoredCities;
            _lockObject = new object();
        }

        public bool Add(IMonitoredCity city)
        {
            lock (_lockObject)
            {
                _monitoredCities.Add(city);
            }

             return true;
        }
            
        public bool Remove(int cityID)
        {
            lock (_lockObject)
            {
                IMonitoredCity city = _monitoredCities.FirstOrDefault(c => c.CityID == cityID);
                _monitoredCities.Remove(city);
            }

            return true;
            
        }
    }
}