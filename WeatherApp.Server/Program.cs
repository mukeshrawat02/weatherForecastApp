using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace WeatherApp.Server
{
    class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:3000/";
            Console.WriteLine("Starting Web Server...");
            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Server running at {0} - press Enter to quit. ", baseAddress);
                Console.ReadLine();
            }
        }
    }
}
