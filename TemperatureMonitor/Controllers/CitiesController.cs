using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using TemperatureMonitor.Models;

namespace TemperatureMonitor.Controllers
{
    [EnableCors(origins: "http://localhost:39175", headers: "*", methods: "*")]
    public class CitiesController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            var result = await CityRepository.GetAll();
            return Ok(result.OrderBy(c => c.Name));
        }
    }
}
