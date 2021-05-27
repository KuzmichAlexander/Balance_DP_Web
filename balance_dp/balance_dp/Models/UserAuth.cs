namespace balance_dp.Models
{
    public class UserAuth
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public class UserRegistrition
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class RegistrationData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
