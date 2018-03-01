using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools
{
    public class OurSql : IDisposable
    {
        private MySqlConnection sql;
        // hardcoded database information here:
        private static string connectionString = "server=ebdb.coagiw8yxfuv.us-west-1.rds.amazonaws.com;database=ebdb;uid=bossdb;pwd=donuts.916;";

        public OurSql()
        {
            // automatically open the sql connection
            sql = new MySqlConnection(connectionString);
            sql.Open();

            // match sql timezone
            // TODO: allow the website to set the time zone?
            var utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = sql;
            var prefix = (utcOffset.TotalHours >= 0) ? "+" : "";
            cmd.CommandText = "SET time_zone = '" + prefix + utcOffset.TotalHours + ":" + utcOffset.Minutes + "'";
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }

        public MySqlDataReader Query(string query)
        {
            // basic wrapper around query
            MySqlCommand cmd = new MySqlCommand(query, sql);
            return cmd.ExecuteReader();
        }

        public void Replace(string tableName, Dictionary<string, string> values)
        {
            // wrap parameterized non-queries

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = sql;

            // build up replace command string
            string keyString = string.Join(", ", values.Select(x => x.Key).ToArray());
            string valueString = string.Join(", ", values.Select(x => "@" + x.Key).ToArray());
            string updateString = string.Join(", ", values.Select(x => x.Key + "=@" + x.Key));
            cmd.CommandText = "INSERT INTO " + tableName + " (" + keyString + ") VALUES(" + valueString + ") " +
            "ON DUPLICATE KEY UPDATE " + updateString + ";";

            cmd.Prepare();

            // add parameters according to passed in values
            foreach (var key in values.Keys)
            {
                cmd.Parameters.AddWithValue("@" + key, values[key]);
            }

            // execute
            cmd.ExecuteNonQuery();

            // TODO: add logging here
        }

        public void Dispose()
        {
            sql.Close();
            sql.Dispose();
        }
    }
}