using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace balance_dp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadParamsController : ControllerBase
    {
        // GET: api/<ThreadParamsController>
        [HttpGet] // Контроллер для отправки входных параметров :)
        public string Get()
        {
            string res = System.IO.File.ReadAllText("data/data.json");
            return res;
        }
    }
}
