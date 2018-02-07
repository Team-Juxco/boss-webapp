using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVC5App.Models
{
    public class Helpers
    {
        public static string GetRDSConnection()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig["ebdb"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["bossdb"];
            string password = appConfig["waffles.191"];
            string hostname = appConfig["aaoiljp2hsri1p.coagiw8yxfuv.us-west-1.rds.amazonaws.com"];
            string port = appConfig["3306"];

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
}