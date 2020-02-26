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

        public List<EasybaseTime> Get()
        {
            MySqlConnection connection = this.ConnectToDB();
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

        public List<EasybaseTime> Get(string companyNr)
        {
            MySqlConnection connection = this.ConnectToDB();
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

        public List<EasybaseTime> Get(string companyNr, string employeeNr)
        {
            MySqlConnection connection = this.ConnectToDB();
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

        public int Update(EasybaseTime editedTime)
        {
            MySqlConnection connection = this.ConnectToDB();
            MySqlCommand cmd = ConnectToDB().CreateCommand();
            cmd.CommandText = "UPDATE timeData SET exported = @newExported WHERE companyNr = @companyNr and empNr = @empNr and tdate = @tDate";
            cmd.Parameters.AddWithValue("@companyNr", editedTime.compNr);
            cmd.Parameters.AddWithValue("@empNr", editedTime.empNr);
            cmd.Parameters.AddWithValue("@tDate", editedTime.tDate);
            cmd.Parameters.AddWithValue("@newExported", editedTime.exported);
            int numRowsUpdated = cmd.ExecuteNonQuery();
            connection.Close();
            return numRowsUpdated;
        }

        public bool SetUpserver(string server, string database, string userId, string password)
        {
            MySqlConnection conn = Connect(server, userId, password);
            bool created = false;
            if (!(this.DBexists(database, conn)))
            {
                this.CreateDB(database, conn);
                created = true;
            }
            conn.ChangeDatabase(database);
            if (this.CreateTable(conn))
                created = true;
            conn.Close();
            return created;
        }

        private MySqlConnection ConnectToDB()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private MySqlConnection Connect(string server, string userId, string password)
        {
            string connectionString = "server=" + server + ";uid=" + userId + ";pwd=" + password + ";";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private bool CreateDB(string database, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `" + database + "`;", conn);
            cmd.ExecuteNonQuery();
            return true;
        }

        private bool CreateTable(MySqlConnection conn)
        {
            string cmdString = "CREATE TABLE if not exists `timeData` (`companyNr` varchar(50) NOT NULL," +
                " `empNr` varchar(50) NOT NULL, `tDate` datetime  NOT NULL, `isComing`  varchar(1) NOT NULL," +
                " `exported` datetime NULL);";
            bool created = false;
            MySqlCommand cmd = new MySqlCommand(cmdString, conn);

            cmd.ExecuteNonQuery();
            return created;
        }

        private bool DBexists(string database, MySqlConnection connection)
        {
            bool functionReturnValue = false;            
            using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM information_schema.schemata WHERE SCHEMA_NAME=@dbName", connection))
            {
                functionReturnValue = false;
                cmd.Parameters.AddWithValue("@dbName", database);
                if (int.Parse(cmd.ExecuteScalar().ToString()) != 0)
                {
                    functionReturnValue = true;
                }
            }
            return functionReturnValue;
        }
    }
}
