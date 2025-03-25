using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffanDhanseHackathon.Utility
{
    static class DbUtil
    {
        static IConfiguration _iConfiguration;

        static DbUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())//settting the path to applications current directory
                        .AddJsonFile("appsettings.json");//load the configuration setting from this json file
            _iConfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return _iConfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}