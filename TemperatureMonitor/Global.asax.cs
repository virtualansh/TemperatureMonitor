using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Routing;
using TemperatureMonitor.Models;

namespace TemperatureMonitor
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            CityRepository.Initialize(new DataCollection(new List<IMonitoredCity>()), WebConfigurationManager.ConnectionStrings["TemperatureMonitor"].ConnectionString);
            Repository.Initialize(WebConfigurationManager.ConnectionStrings["TemperatureMonitor"].ConnectionString);
        }
    }
}