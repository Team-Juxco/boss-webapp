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
        }

        public MySqlDataReader Query(string query)
        {
            // basic wrapper around query
            MySqlCommand cmd = new MySqlCommand(query, sql);
            return cmd.ExecuteReader();
        }

        public void Command(string tableAndColumns, string[] values)
        {
            // wrap parameterized non-queries

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = sql;

            // build up command text according to the number of values passed in as an array
            string commandText = "INSERT INTO " + tableAndColumns + " VALUES(";
            for (int i = 0; i < values.Length; i++)
            {
                commandText += "@" + i;
                if (i != (values.Length - 1)) { commandText += ", "; }
            }
            commandText += ")";
            cmd.CommandText = commandText;

            cmd.Prepare();

            // add parameters according to passed in values
            for (int i = 0; i < values.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + i, values[i]);
            }

            // execute
            cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            sql.Close();
            sql.Dispose();
        }
    }
}