using Microsoft.AspNetCore.Mvc;
using balance_dp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace balance_dp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateDP : ControllerBase
    {
        [HttpPost]
        public ResultHeat Post([FromBody] DPInputData dt)
        {
            var result = new ResultHeat();
            result = Calculate.Calculator(dt);
            
            return result;
        }
    }
}
