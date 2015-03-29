using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using TemperatureMonitor.Models;

namespace TemperatureMonitor.Controllers
{
    [EnableCors(origins: "http://localhost:39175", headers: "*", methods: "*")]
    public class TemperatureController : ApiController
    {
        // private ICityRepository _cityRepository = new CityRepository(new DataCollection(new List<ICity>()));

        public async Task<IHttpActionResult> Get(int cityID)
        {
            string cityName = await CityRepository.GetName(cityID);
            if (cityName == null)
            {
                return Ok(HttpStatusCode.NotFound);
            }
            float temperature = await HTTPRequestHandler.getTemperatureFromWorldWeather(cityName);
            return Ok(temperature);
        }

        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<IMonitoredCity> monitoredCities = await MonitoredCityRepository.GetAll();
            foreach (MonitoredCity city in monitoredCities)
            {
                city.LatestTemperature = await HTTPRequestHandler.getTemperatureFromWorldWeather(city.Name);
                await MonitoredCityRepository.Update(city);
            }
            return Ok(MonitoredCityRepository.GetAll());
        }

        public async Task<IHttpActionResult> Post([FromBody]City city)
        {
            float temperature = await HTTPRequestHandler.getTemperatureFromWorldWeather(city.Name);

            IMonitoredCity monitoredCity = new MonitoredCity(city.Id, city.Name, 60, temperature);
            await MonitoredCityRepository.Add(monitoredCity);
            return Ok(monitoredCity);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IHttpActionResult> Delete([FromBody]IMonitoredCity monitoredCity)
        {
            System.Console.WriteLine("Inside Delete");
           bool isDeleted = await MonitoredCityRepository.Delete(monitoredCity);
           return Ok();
           //if (isDeleted == true)
           //{
           //    return Ok();
           //}
           //else
           //{
           //    return BadRequest();
           //}
        }


    }
}
