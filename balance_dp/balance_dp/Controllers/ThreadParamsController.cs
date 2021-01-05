using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using balance_dp.Models;
using Microsoft.AspNetCore.Http.Features;
using System.Text.Json;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace balance_dp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadParamsController : ControllerBase
    {
        private string path = @"data/data.json";
        // GET: api/<ThreadParamsController>
        [HttpGet] // Контроллер для отправки входных параметров :)
        public string Get()
        {
            string res = System.IO.File.ReadAllText(path);
            return res;
        }
        [HttpPost] // Контроллер для принятия и сейва входных параметров :)
        public bool Post(SaveParams sp)
        {
            string res = System.Text.Json.JsonSerializer.Serialize<DPInputData>(sp.dpi);
            try
            {
                System.IO.File.Delete(path);
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.WriteLine(res);
                }
                return true;
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(@"log.txt", true))
                {
                    sw.WriteLine($"Не удалось записать входные параметры в файл \n Время получения {DateTime.Now.Date} \n По причине {ex} ");
                }
                return false;
            }
            
        }
    }
}
