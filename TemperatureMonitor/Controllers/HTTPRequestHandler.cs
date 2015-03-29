using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TemperatureMonitor.Constants;

namespace TemperatureMonitor.Controllers
{
    public static class HTTPRequestHandler
    {
        public static async Task<float> getTemperatureFromWorldWeather(string cityName)
        {
            //worldweatheronlineuri
            string url = "http://api2.worldweatheronline.com";
            //worldweatheronlineparams 
            string parameters = "free/v2/weather.ashx?q=" + cityName + "&format=json&num_of_days=1&key=40346cc0be1227b023f5fb6ab276d";
            float temperature = await getTemperatureFromThirdParty(url, parameters);
            return temperature;
        }

        private static async Task<float> getTemperatureFromThirdParty(string url, string parameters)
        {
            string response = await processHTTPRequest(url, parameters);
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response);
            return data.data.current_condition[0].temp_C;
        }

        public static async Task<string> processHTTPRequest(string url, string parameters)
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