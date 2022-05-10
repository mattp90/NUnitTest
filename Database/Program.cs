using System;
using System.Linq;
using AquardensDatabase.Entity;
using Microsoft.Extensions.Configuration;

namespace AquardensDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var conn = Configuration.GetConnectionString("local");

            using (EFContext db = new EFContext(conn))
            {
                var a = db.Listino.ToList();
            }

            Console.WriteLine("Hello World!");
            Console.WriteLine("Type any key to exit...");
            Console.ReadKey();
        }
    }
}