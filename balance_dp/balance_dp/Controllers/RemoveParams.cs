using balance_dp.Models;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace balance_dp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveParams : ControllerBase
    {
        private DPContext DpDataBase = new DPContext();

        [HttpPost]
        public bool Post(DeleteData dd)
        {
            string token = Request.Headers["Authorization"];

            int userid = new SecurityMethods().ParseToken(token);

            DPInputData a = DpDataBase.Inputs.First(p => p.NAME == dd.ParamsName && p.UserId == userid);
            DpDataBase.Inputs.Remove(a);
            DpDataBase.SaveChanges();

            return true;
        }


        public class DeleteData
        {
            public string ParamsName { get; set; }
        }
     }
}
