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
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace balance_dp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadParamsController : ControllerBase
    {
        private DPContext DpDataBase = new DPContext();
        // GET: api/<ThreadParamsController>
        [HttpGet] // Контроллер для отправки входных параметров :)
        public string[] Get()
        { 

            
            return DpDataBase.Inputs.Select(x=> x.NAME).ToArray();
        }

        [HttpGet("{id}", Name = "Get")]
        public DPInputData Get(string id)
        {
            var a =  DpDataBase.Inputs.Include(p=> p.InputIndicators).Where(p=> p.NAME == id);
         
            return a.ElementAt(0);
        }

        [HttpPost] // Контроллер для принятия и сейва входных параметров :)
        public bool Post(SaveParams sp)
        {
            //if (DpDataBase.Inputs.Select(x => x.NAME).ToList().Contains(sp.name))
            //{
            //    return false;
            //}
            var dataInput = new DPInputData()
            {
                NAME = sp.name,
                InputIndicators = sp.dpi.InputIndicators,
                InputData2 = sp.dpi.InputData2
            };

            DpDataBase.Inputs.Add(dataInput);
            DpDataBase.SaveChanges();
            return true;
        }
    }
}
