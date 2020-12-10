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
       

        // POST api/<CalculateDP>
        [HttpPost]
        public float Post(Test1 ts)
        {
            float res = ts.a + ts.b + ts.c;
            return res;
        }

        // PUT api/<CalculateDP>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<CalculateDP>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
