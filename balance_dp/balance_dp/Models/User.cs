using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace balance_dp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Token { get; set; }
    }

    public class FrontUser
    {
        public FrontUser(RegistrationData? user)
        {
            if (user != null)
            {
                this.Token = user.Token;
                this.Name = user.Name;
                this.Id = user.Id;
            }
            
        }
        public bool isAuth { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }




}
