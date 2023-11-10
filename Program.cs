using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using System;

namespace WebAPI_Http.sys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" #### Executando a WEb API com HTTP.sys ####\n");
            //CreateWebHostBuilder(args).Build().Run();
            BuildWebHost(args).Run();
        }

        //    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //WebHost.CreateDefaultBuilder(args)
        //    .UseStartup<Startup>()
        //    .UseHttpSys(options =>
        //    {
        //        // The following options are set to default values.
        //        options.Authentication.Schemes = AuthenticationSchemes.None;
        //        options.Authentication.AllowAnonymous = true;
        //        options.MaxConnections = null;
        //        options.MaxRequestBodySize = 30000000;
        //        options.UrlPrefixes.Add("http://localhost:7000");
        //    });

        public static IWebHost BuildWebHost(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .UseHttpSys(options =>
                    {
                        options.Authentication.Schemes = AuthenticationSchemes.NTLM;
                        options.Authentication.AllowAnonymous = true;
                        options.MaxConnections = 100;
                        options.MaxRequestBodySize = 30000000;
                        options.UrlPrefixes.Add("http://localhost:7000");
                    })
            .Build();
    }
}
