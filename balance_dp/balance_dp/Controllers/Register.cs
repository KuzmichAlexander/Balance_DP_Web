using System.Linq;
using balance_dp.Models;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace balance_dp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Register : Controller
    {
        private DPContext db = new DPContext();

        // POST api/<AuthController>
        [HttpPost]
        public string Post(UserRegistrition ur)
        {
            //Если такой логин уже зареган
            if (db.Users.FirstOrDefault(user => user.Login == ur.Login) != null)
            {
                return "Такой логин уже существует";
            }
            
            RegistrationData rd = SecurityMethods.DBWrapper(ur);
            
            rd.Token = SecurityMethods.CreateToken(rd);

            db.Users.Add(rd);
            db.SaveChanges();

            return "Пользователь успешно создан";
        }
    }
}