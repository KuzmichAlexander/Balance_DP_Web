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
        [HttpGet] // Контроллер для отправки входных параметров :)
        public string[] Get()
        {
            string token = Request.Headers["Authorization"];
            int id = ParseToken(token);
            if (id < 0)
            {
                return DpDataBase.Inputs.Where(p => p.Id == 1).Select(x => x.NAME).ToArray();
            }

            return DpDataBase.Inputs.Where(p => p.UserId == id || p.Id == 1).Select(x=> x.NAME).ToArray();
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            var a = DpDataBase.Inputs
                .Include(p => p.InputIndicators)
                .ThenInclude(p => p.CastIron)

                  .Include(p => p.InputData2)
                .ThenInclude(p => p.flus)
                .ThenInclude(p => p.Limestone)
                 .Include(p => p.InputData2)
                .ThenInclude(p => p.flus)
                .ThenInclude(p => p.Quartzite)
                 .Include(p => p.InputData2)
                .ThenInclude(p => p.flus)
                .ThenInclude(p => p.Reserve)
                 .Include(p => p.InputData2)
                .ThenInclude(p => p.flus)
                .ThenInclude(p => p.Slug)
                 .Include(p => p.InputData2)
                .ThenInclude(p => p.flus)
                .ThenInclude(p => p.Fluospat)



                .Include(p => p.InputData2)
                .ThenInclude(p => p.flus)

                .Include(p => p.InputIndicators)
                .ThenInclude(p => p.CockParam)
                .ThenInclude(p => p.CocksAsh)

                .Include(p => p.InputIndicators)
                .ThenInclude(p => p.CockParam)
                .ThenInclude(p => p.CocksComposit)

                 .Include(p => p.InputIndicators)
                .ThenInclude(p => p.BlastFur)

                .Include(p => p.InputIndicators)
                .ThenInclude(p => p.blowing)

                 .Include(p => p.InputIndicators)
                .ThenInclude(p => p.zhrm)

                 .Include(p => p.InputIndicators)
                .ThenInclude(p => p.slag)

                 .Include(p => p.InputIndicators)
                .ThenInclude(p => p.FurnaceGas)


                 .Include(p => p.InputData2)
                .ThenInclude(p => p.materialCons)



                .Where(p => p.NAME == id)
                .ToList();

            string str1 = JsonConvert.SerializeObject(a.ElementAt(0));
            var obj1 = JsonConvert.DeserializeObject<DPFrontend>(str1);

            return JsonConvert.SerializeObject(obj1);
        }

        [HttpPost] // Контроллер для принятия и сейва входных параметров :)
        public bool Post(SaveParams sp)
        {

            if (DpDataBase.Inputs.Select(x => x.NAME).ToList().Contains(sp.name))
            {
                return false;
            }
            string token = Request.Headers["Authorization"];
            int userid = ParseToken(token);

            var dataInput = new DPInputData()
            {
                UserId = userid,
                NAME = sp.name,
                InputIndicators = sp.dpi.InputIndicators,
                InputData2 = sp.dpi.InputData2
            };

            DpDataBase.Inputs.Add(dataInput);
            DpDataBase.SaveChanges();
            return true;
        }
        //ИЗМЕНЕНИЕ ДАННЫХ В БД
       [HttpPatch]
        public bool Patch(SaveParams sp)
        { 
            DPInputData  a = DpDataBase.Inputs.First(p => p.NAME == sp.name);
                a.NAME = sp.name;
                a.InputIndicators = sp.dpi.InputIndicators;
                a.InputData2 = sp.dpi.InputData2;         
            DpDataBase.Inputs.Attach(a);
            DpDataBase.SaveChanges();
            return true;
        }
        [HttpDelete]
        public bool Delete(string name) 
        {
            DPInputData a = DpDataBase.Inputs.First(p => p.NAME == name);
            DpDataBase.Inputs.Remove(a);
            return true;
        }

        [NonAction]
        public int ParseToken(string token)
        {
            var trueUser = DpDataBase.Users.FirstOrDefault(user => user.Token == token);

            if (trueUser == null)
            {
                return -1;
            }

            return trueUser.Id;
        }

    }
}
