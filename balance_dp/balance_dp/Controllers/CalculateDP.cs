using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using balance_dp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace balance_dp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateDP : ControllerBase
    {
        public class test
        {
            public int a { get; set; }
        }

        // POST api/<CalculateDP>
        [HttpPost]
        public ResultHeat Post(test t)
        {
            var a = new ResultHeat();
            return a;
        }
    }
}
