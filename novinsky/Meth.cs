using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace novinsky
{
    class Meth
    {
        public static void BdCombo2(string a, Label Label)
        {


            MySqlConnection connect;
            connect = Connect.GetConnection();
            connect.Open();
            string sql = a;
            MySqlCommand command = new MySqlCommand(sql, connect);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Label.Text = reader.ToString();
            }
            connect.Close();
        }
        public static void BdCombo(string a, ComboBox Combobox, int s, int l)
        {

            
                MySqlConnection connect; 
                connect = Connect.GetConnection();
                connect.Open();
                string sql = a;
                MySqlCommand command = new MySqlCommand(sql, connect);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Combobox.Items.Add(reader[s].ToString());
                }
                Combobox.SelectedIndex = l;
                connect.Close();
        }
        public static void BdUpdate(string query)
        {

            if (query == "")
            {
                MessageBox.Show("Вы ничего не ввели", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection connect;
                connect = Connect.GetConnection();
                try
                {
                    connect.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

