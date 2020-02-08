using DB_Editor;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class Database
    {
        private Database()
        {
        }

        public static List<EasybaseTime> get(string server, string database, string userId, string password, string companynr)
        {
            MySqlCommand cmd = connect(server, database, userId, password).CreateCommand();
            cmd.CommandText = "SELECT * from timeData WHERE companyNr = @compNr";
            cmd.Parameters.AddWithValue("@compNr", companynr);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<EasybaseTime> times = new List<EasybaseTime>();

            while (reader.Read())
            {
                string empNr = reader.GetString("empNr");
                DateTime tDate = reader.GetDateTime("tDate");
                string isComing = reader.GetString("isComing");
                DateTime? exported = null;
                int x = reader.GetOrdinal("exported");

                if (!reader.IsDBNull(x))
                    exported = reader.GetDateTime(x);
   
                times.Add(new EasybaseTime(empNr, tDate, isComing, exported));
            }
            return times;
        }

        private static MySqlConnection connect(string server, string database, string userId, string password)
        {
            string connectionString = "Server=" + server + "; Database=" + database + "; User Id=" + userId + "; Password=" + password + ";";

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
