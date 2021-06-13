using System;
using MySql.Data.MySqlClient;

namespace novinsky
{
    class Connect
    {
        public static MySqlConnection GetConnection()
        {

            string host = "localhost";
            int port = 3306;
            string database = "ivan_novinsky";
            string username = "root";
            string password = "123321";

            // Строка подключения
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;
            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
