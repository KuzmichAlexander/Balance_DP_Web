using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.IO;
using balance_dp.Models;
using System.Linq;

namespace BookShop.Models
{
    public class SecurityMethods
    {
        private DPContext DpDataBase = new DPContext();

        public static string GetSHA1Hash(string str)
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(str));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public static RegistrationData DBWrapper(UserRegistrition ri)
        {
            RegistrationData rd = new RegistrationData();
            rd.Login = ri.Login;
            rd.Name = ri.Name;
            rd.Password = SecurityMethods.GetSHA1Hash(ri.Password);

            return rd;
        }

        public static string CreateToken(RegistrationData rd)
        {
            string obj = JsonSerializer.Serialize<RegistrationData>(rd);
            string token = SecurityMethods.GetSHA1Hash(obj);

            return token;
        }

        public static void LogRegister(RegistrationData rd)
        {
            string userdata = JsonSerializer.Serialize<RegistrationData>(rd);
            using (StreamWriter sw = new StreamWriter(@"log.txt"))
            {
                sw.WriteLine(userdata);
            }
        }

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
