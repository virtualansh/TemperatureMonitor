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
        static async Task processHTTPRequest(string url, string parameters)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.Constants.JSON));
                HttpResponseMessage response = await client.GetAsync(parameters);
                if (response.IsSuccessStatusCode)
                {

                    //var responseContent = await response.Content.ReadAsAsync<>();

                }


            }
        }
    }
}