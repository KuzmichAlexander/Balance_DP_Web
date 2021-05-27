using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using balance_dp.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace balance_dp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateDP : ControllerBase
    {
        // POST api/<CalculateDP>
        [HttpPost]
        public ResultHeat Post([FromBody] DPInputData dt)
        {
            string zap = JsonConvert.SerializeObject(dt);
            Console.WriteLine(zap);
            var result = new ResultHeat();

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("log.txt", true))
            {
                sw.WriteLine(zap);
            }

                result = Calculate.Calculator(dt);
            
            return result;
        }
    }
}
