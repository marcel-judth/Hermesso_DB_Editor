using DB_Editor;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class Database
    {
        private string connectionString;
        public Database(string server, string database, string userId, string password)
        {
            this.connectionString = "Server=" + server + "; Database=" + database + "; User Id=" + userId + "; Password=" + password + ";";
        }

        public Database()
        {
        }

        public List<EasybaseTime> get()
        {
            MySqlConnection connection = this.connectToDB();
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

        public void setConnData(string server, string database, string userId, string password)
        {
            this.connectionString = "Server=" + server + "; Database=" + database + "; User Id=" + userId + "; Password=" + password + ";";
        }

        public List<EasybaseTime> get(string companyNr)
        {
            MySqlConnection connection = this.connectToDB();
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

        public List<EasybaseTime> get(string companyNr, string employeeNr)
        {
            MySqlConnection connection = this.connectToDB();
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

        public int update(EasybaseTime editedTime)
        {
            MySqlConnection connection = this.connectToDB();
            MySqlCommand cmd = connectToDB().CreateCommand();
            cmd.CommandText = "UPDATE timeData SET exported = @newExported WHERE companyNr = @companyNr and empNr = @empNr and tdate = @tDate";
            cmd.Parameters.AddWithValue("@companyNr", editedTime.compNr);
            cmd.Parameters.AddWithValue("@empNr", editedTime.empNr);
            cmd.Parameters.AddWithValue("@tDate", editedTime.tDate);
            cmd.Parameters.AddWithValue("@newExported", editedTime.exported);
            int numRowsUpdated = cmd.ExecuteNonQuery();
            connection.Close();
            return numRowsUpdated;
        }

        public bool DBexists(string server, string database, string userId, string password)
        {
            bool functionReturnValue = false;

            using (MySqlConnection dbconn = connect(server, userId, password))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM information_schema.schemata WHERE SCHEMA_NAME=@dbName", dbconn))
                {
                    functionReturnValue = false;
                    cmd.Parameters.AddWithValue("@dbName", database);
                    dbconn.Open();
                    if (int.Parse(cmd.ExecuteScalar().ToString()) != 0)
                    {
                        functionReturnValue = true;
                    }
                    dbconn.Close();
                }
            }
            return functionReturnValue;
        }

        public bool createDB(string server, string database, string userId, string password)
        {
            MySqlConnection conn = connect(server, userId, password);

            //use different execute for this command.....see how you get a result from the command. im sorry i had to go to bed
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `" + database + "`;", conn);
            if (int.Parse(cmd.ExecuteScalar().ToString()) != 0)
            {
                return true;
            }
            conn.Close();
            return false;
        }

        public MySqlConnection connectToDB()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public MySqlConnection connect(string server, string userId, string password)
        {
            string connectionString = "server=" + server + ";uid=" + userId + ";pwd=" + password + ";";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
