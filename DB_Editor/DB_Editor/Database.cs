using DB_Editor;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class Database
    {
        private static MySqlConnection connection;
        private Database()
        {
        }

        public static List<EasybaseTime> get()
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from timeData";

            MySqlDataReader reader = cmd.ExecuteReader();

            List<EasybaseTime> times = new List<EasybaseTime>();

            while (reader.Read())
            {
                string compNr = reader.GetString("companyNr");
                string empNr = reader.GetString("empNr");
                DateTime tDate = reader.GetDateTime("tDate");
                string isComing = reader.GetString("isComing");
                DateTime? exported = null;
                int x = reader.GetOrdinal("exported");

                if (!reader.IsDBNull(x))
                    exported = reader.GetDateTime(x);

                times.Add(new EasybaseTime(compNr, empNr, tDate, isComing, exported));
            }
            connection.Close();
            return times;
        }

        public static List<EasybaseTime> get(string companyNr)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from timeData WHERE companyNr = @compNr";
            cmd.Parameters.AddWithValue("@compNr", companyNr);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<EasybaseTime> times = new List<EasybaseTime>();

            while (reader.Read())
            {
                string compNr = reader.GetString("companyNr");
                string empNr = reader.GetString("empNr");
                DateTime tDate = reader.GetDateTime("tDate");
                string isComing = reader.GetString("isComing");
                DateTime? exported = null;
                int x = reader.GetOrdinal("exported");

                if (!reader.IsDBNull(x))
                    exported = reader.GetDateTime(x);

                times.Add(new EasybaseTime(compNr, empNr, tDate, isComing, exported));
            }
            connection.Close();
            return times;
        }

        public static List<EasybaseTime> get(string companyNr, string employeeNr)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from timeData WHERE companyNr = @compNr and empNr = @empNr";
            cmd.Parameters.AddWithValue("@compNr", companyNr);
            cmd.Parameters.AddWithValue("@empNr", employeeNr);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<EasybaseTime> times = new List<EasybaseTime>();

            while (reader.Read())
            {
                string compNr = reader.GetString("companyNr");
                string empNr = reader.GetString("empNr");
                DateTime tDate = reader.GetDateTime("tDate");
                string isComing = reader.GetString("isComing");
                DateTime? exported = null;
                int x = reader.GetOrdinal("exported");

                if (!reader.IsDBNull(x))
                    exported = reader.GetDateTime(x);

                times.Add(new EasybaseTime(compNr, empNr, tDate, isComing, exported));
            }
            connection.Close();
            return times;
        }

        public static int update(EasybaseTime editedTime)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE timeData SET exported = @newExported WHERE companyNr = @companyNr and empNr = @empNr and tdate = @tDate";
            cmd.Parameters.AddWithValue("@companyNr", editedTime.compNr);
            cmd.Parameters.AddWithValue("@empNr", editedTime.empNr);
            cmd.Parameters.AddWithValue("@tDate", editedTime.tDate);
            cmd.Parameters.AddWithValue("@newExported", editedTime.exported);
            int numRowsUpdated = cmd.ExecuteNonQuery();
            connection.Close();
            return numRowsUpdated;
        }

        public static MySqlConnection connect(string server, string database, string userId, string password)
        {
            string connectionString = "Server=" + server + "; Database=" + database + "; User Id=" + userId + "; Password=" + password + ";";

            try
            {
                connection = new MySqlConnection(connectionString);
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
