﻿namespace balance_dp.Models
{
    public class FrontUser
    {
        public FrontUser(RegistrationData? user)
        {
            if (user != null)
            {
                this.Token = user.Token;
                this.Name = user.Name;
                this.Id = user.Id;
                this.isAuth = true;
            }
            
        }
        public bool isAuth { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
