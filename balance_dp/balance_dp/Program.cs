using balance_dp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace balance_dp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            string sw = new System.IO.StreamReader("log.txt", true).ReadToEnd();
            var dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DPInputData>(sw.ToString());
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
