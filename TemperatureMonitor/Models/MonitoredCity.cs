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
            CityID = cityID;
            CityName = cityName;
            SensingPeriod = sensingPeriod;
            LatestTemperature = latestTemperature;
        }

        public int CityID { get; set; }

        public string CityName { get; set; }

        public int SensingPeriod { get; set; }

        public float LatestTemperature { get; set; }
    }
}