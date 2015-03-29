using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TemperatureMonitor.Models
{
    public class MonitoredCity : IMonitoredCity
    {
        public MonitoredCity(int cityID, string cityName, int sensingPeriod = 60, float latestTemperature = 0)
        {
            CityId = cityID;
            Name = cityName;
            SensingPeriod = sensingPeriod;
            LatestTemperature = latestTemperature;
        }
        public MonitoredCity()
        {
        }
     

        public int Id { get; set; }

        public int CityId { get; set; }

        public string Name { get; set; }

        public int SensingPeriod { get; set; }

        public float LatestTemperature { get; set; }
    }
}