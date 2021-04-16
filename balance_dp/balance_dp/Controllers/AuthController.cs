using balance_dp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BookShop.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace balance_dp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DPContext db = new DPContext();

        // POST api/<AuthController>
        [HttpPost]
        public FrontUser Post(UserAuth user)
        {
            var trueuser = db.Users.FirstOrDefault(dbUser => user.Login == dbUser.Login && SecurityMethods.GetSHA1Hash(user.Password) == dbUser.Password);
            if (trueuser == null)
            {
                FrontUser fr = new FrontUser(trueuser);
                fr.isAuth = false;
                return fr;
            }
            FrontUser ddd = new FrontUser(trueuser);
            ddd.isAuth = true;
            return ddd;

        }
        [HttpGet]
        public FrontUser Get()
        {
            string token = Request.Headers["Authorization"];
            var trueuser = db.Users.First(dbUser => dbUser.Token == token);
            

            return new FrontUser(trueuser);
        }
    }
}
