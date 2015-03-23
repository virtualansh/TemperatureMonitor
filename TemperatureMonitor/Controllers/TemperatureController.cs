using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using TemperatureMonitor.Models;

namespace TemperatureMonitor.Controllers
{
    public class TemperatureController : ApiController
    {
       // private ICityRepository _cityRepository = new CityRepository(new DataCollection(new List<ICity>()));

        public async Task<IHttpActionResult> Get(string cityName)
        {
            //worldweatheronlineuri
            string url = "http://api2.worldweatheronline.com";
            //worldweatheronlineparams 
            string parameters = "free/v2/weather.ashx?q=" + cityName + "&format=json&num_of_days=1&key=40346cc0be1227b023f5fb6ab276d";
            string response = await processHTTPRequest(url, parameters);
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response);
            return Ok(new { Temperature = data.data.current_condition[0].temp_C });

        }

        public IHttpActionResult Post(MonitoredCity city)
        {
            //_cityRepository.Add(city);
            CityRepository.Add(city);
            return Ok();
        }
        public IHttpActionResult Delete(int cityID)
        {
         //   _cityRepository.Remove(cityID);
            CityRepository.Remove(cityID);
            return Ok();
        }

        static async Task<string> processHTTPRequest(string url, string parameters)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.Constants.JSON));
                HttpResponseMessage response = await client.GetAsync(parameters);
                if (response.IsSuccessStatusCode)
                {

                    string responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;

                }
                return response.StatusCode.ToString();


            }
        }
    }
}
