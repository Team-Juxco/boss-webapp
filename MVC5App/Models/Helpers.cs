using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVC5App.Models
{
    public class Helpers
    {
        /* Hardcoded AWS RDS database settings */
        public static string RDS_DB_NAME = "ebdb";
        public static string RDS_USERNAME = "bossdb";
        public static string RDS_PASSWORD = "waffles.191";
        public static string RDS_HOSTNAME = "aaoiljp2hsri1p.coagiw8yxfuv.us-west-1.rds.amazonaws.com";
        public static string RDS_PORT = "3306";

        public static string GetRDSConnection()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = RDS_DB_NAME;

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = RDS_USERNAME;
            string password = RDS_PASSWORD;
            string hostname = RDS_HOSTNAME;
            string port = RDS_PORT;

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
}