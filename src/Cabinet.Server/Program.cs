using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Server.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cabinet.Server
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            // when system start the main settings
            var config = new ConfigurationBuilder()
                .AddJsonFile("settings.json", optional:false)
                .Build();

            var csInit = new CabinetSettings(config);

            // data dir should exist or we should create 
           

            // if there's an exception kill app
            if (!Directory.Exists(csInit.DataDir))
            {
               csInit.DirectoryInfo =  Directory.CreateDirectory(csInit.DataDir);
            }
            else
            {
                csInit.DirectoryInfo = new DirectoryInfo(csInit.DataDir);
            }

            CreateHostBuilder(args, csInit).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, CabinetSettings cs) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureServices(services => {
                    services.AddSingleton<CabinetSettings>(cs);
                });
    }
}
