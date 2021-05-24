using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuppressMapClientErrorsIssue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var argsList = new List<string>(args);

            if (!argsList.Any(a => "--SuppressMapClientErrors".Equals(a, StringComparison.OrdinalIgnoreCase)))
            {
                Console.Write("Suppress client error mappings? (y/n) ");
                switch (Console.ReadKey().KeyChar)
                {
                    case 'y':
                        argsList.Add("--SuppressMapClientErrors");
                        argsList.Add("True");
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }

            if (!argsList.Any(a => "--EnableDeveloperExceptions".Equals(a, StringComparison.OrdinalIgnoreCase)))
            {
                Console.Write("Enable developer exceptions? (y/n) ");
                switch (Console.ReadKey().KeyChar)
                {
                    case 'y':
                        argsList.Add("--EnableDeveloperExceptions");
                        argsList.Add("True");
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }

            CreateHostBuilder(argsList.ToArray()).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder =>
                       {
                           webBuilder.UseStartup<Startup>();
                       });
        }
    }
}
