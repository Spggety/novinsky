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
    public partial class Main : Form
    {
        private string userName;
        private MySqlConnection connect;
        public Main()
        {
            try
            {
                MySqlConnection connect;
                connect = Connect.GetConnection();
                connect.Open();
                string sql = "select 1;";
                MySqlCommand command = new MySqlCommand(sql, connect);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    connect.Close();
                    InitializeComponent();
                }

            }
            catch
            {
                MessageBox.Show("Нет связи с БД!", "Ошибка подключения");
            }


        }








        int lCount = 0;

        private void btnReg_Click(object sender, EventArgs e)
        {
            int prepod = 0;
            if (checkBoxPrepod.Checked)
            {
                prepod = 1;
            }
            else
            {
                prepod = 0;
            }

            connect.Open();
            string err = "";
            try
            {
                if (textBoxLogin.Text != "" && textBoxSurname.Text != "" && textBoxName.Text != "" && textBoxMiddleName.Text != "" && textBoxPass1.Text != "" && textBoxPass2.Text != "")
                {
                    string sql = "SELECT * FROM users;";
                    MySqlCommand command = new MySqlCommand(sql, connect);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (textBoxPass1.Text.Length < 6)
                        {
                            err = "Короткий пароль!";
                            break;
                        }
                        if (textBoxLogin.Text == reader[4].ToString())
                        {
                            err = "Логин занят!";
                            break;
                        }

                        if (textBoxPass1.Text != textBoxPass2.Text)
                        {
                            err = "Пароли не совпадают";
                            break;
                        }
                    }
                    connect.Close();
                    if (err != "")
                        MessageBox.Show(err);
                    else

                    {
                        connect.Open();
                        Meth.BdUpdate("INSERT INTO `ivan_novinsky`.`users` (`login`, `surname`, `name`, `middlename`, `password`, `role`) VALUES ('" + textBoxLogin.Text + "', '" + textBoxSurname.Text + "', '" + textBoxName.Text + "', '" + textBoxMiddleName.Text + "', '" + textBoxPass1.Text + "', '" + prepod + "');");
                        MessageBox.Show("Удачная регистрация! Вы можете войти в систему через вкладку авторизации!");
                        connect.Close();
                    }
                }
                else
                    MessageBox.Show("Ошибка заполнения!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connect.Close();
            }
        }

        public static void Test(TabPage tabPage)
        {
            int y = 70;
            int x = 45;
            MySqlConnection connect;
            connect = Connect.GetConnection();
            connect.Open();
            string sql = "SELECT Max(id) FROM ivan_novinsky.document";
            MySqlCommand command = new MySqlCommand(sql, connect);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int max = Convert.ToInt32(reader.GetValue(0).ToString());
            reader.Close();
            connect.Close();
            for (int a = 1; a < max + 1; a++)
            {
                x = x;
                y = y + 20;
                Label lbl = new Label();
                lbl.Name = lbl.ToString() + a.ToString();
                tabPage.Controls.Add(lbl);

                connect = Connect.GetConnection();
                connect.Open();
                sql = "SELECT * FROM ivan_novinsky.document where id = '" + a + "'";

                string item1 = "11";
                string item2 = "22";
                string item3 = "33";
                string item4 = "44";
                string item5 = "55";
                command = new MySqlCommand(sql, connect);
                reader = command.ExecuteReader();
                reader.Read();

                item1 = reader.GetValue(0).ToString();
                item2 = reader.GetValue(3).ToString();
                item3 = reader.GetValue(2).ToString();
                item4 = reader.GetValue(1).ToString();
                reader.Close();
                connect.Close();

                lbl.Text = item1;
                objectsAdd.LabelName(lbl, x, y, lbl.Text);

                Label lbl2 = new Label();
                lbl2.Text = item2;
                objectsAdd.LabelName(lbl2, 240, y, lbl2.Text);

                Label lbl3 = new Label();
                lbl3.Text = item3;
                objectsAdd.LabelName(lbl3, 420, y, lbl3.Text);

                Label lbl4 = new Label();
                lbl4.Text = item4;
                objectsAdd.LabelName(lbl4, 540, y, lbl4.Text);

                tabPage.Controls.Add(lbl2);
                tabPage.Controls.Add(lbl3);
                tabPage.Controls.Add(lbl4);
            }
        }
        public static void Test2 (TabPage tabPage,FlowLayoutPanel flp,FlowLayoutPanel flp2, FlowLayoutPanel flp3, FlowLayoutPanel flp4)
        {
            int y = 70;
            int x = 45;
            MySqlConnection connect;
            connect = Connect.GetConnection();
            connect.Open();
            string sql = "SELECT Max(id) FROM ivan_novinsky.document";
            MySqlCommand command = new MySqlCommand(sql, connect);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int max = Convert.ToInt32(reader.GetValue(0).ToString());
            reader.Close();
            connect.Close();
            for (int a = 1; a < max + 1; a++)
            {
                x = x;
                y = y + 20;
                Label lbl = new Label();
                lbl.Name = lbl.ToString() + a.ToString();
                flp.Controls.Add(lbl);

                connect = Connect.GetConnection();
                connect.Open();
                sql = "SELECT * FROM ivan_novinsky.document where id = '" + a + "'";

                string item1 = "11";
                string item2 = "22";
                string item3 = "33";
                string item4 = "44";
                string item5 = "55";
                command = new MySqlCommand(sql, connect);
                reader = command.ExecuteReader();
                reader.Read();

                item1 = reader.GetValue(0).ToString();
                item2 = reader.GetValue(3).ToString();
                item3 = reader.GetValue(2).ToString();
                item4 = reader.GetValue(1).ToString();
                reader.Close();
                connect.Close();

                lbl.Text = item1;
                objectsAdd.LabelName(lbl, x, y, lbl.Text);

                Label lbl2 = new Label();
                lbl2.Text = item2;
                objectsAdd.LabelName(lbl2, 240, y, lbl2.Text);

                Label lbl3 = new Label();
                lbl3.Text = item3;
                objectsAdd.LabelName(lbl3, 420, y, lbl3.Text);

                Label lbl4 = new Label();
                lbl4.Text = item4;
                objectsAdd.LabelName(lbl4, 540, y, lbl4.Text);

                flp2.Controls.Add(lbl2);
                flp3.Controls.Add(lbl3);
                flp4.Controls.Add(lbl4);
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Test2(tabPage3, flowLayoutPanel2, flowLayoutPanel3, flowLayoutPanel4, flowLayoutPanel5);
            connect = Connect.GetConnection();
            Meth.BdCombo("SELECT * from ivan_novinsky.new_view;", comboBox4, 1, 0);
            Meth.BdCombo("SELECT * FROM ivan_novinsky.specialty;", comboBox5, 1, 0);
            Meth.BdCombo("SELECT * FROM ivan_novinsky.course;", comboBox6, 2, 0);
            Meth.BdCombo("SELECT tag FROM course;", comboBox2, 0, 0);
        }


        private void btnComStudents_Click(object sender, EventArgs e)
        {

            Meth.BdUpdate("INSERT INTO `ivan_novinsky`.`students` (`users_id`, `group_id`) VALUES ((select  id from new_view where name = '" + userName + "'), '" + comboBox1.Text + "');");
            MessageBox.Show("Успешно!");
        }
        private void checkBoxPrepod_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            try
            {
                Meth.BdCombo("" +
               "SELECT DISTINCT specialty.name FROM `group` INNER JOIN course_has_specialty ON `group`.specialty_id = course_has_specialty.specialty_id INNER JOIN course ON course_has_specialty.course_id = course.id INNER JOIN specialty ON `group`.specialty_id = specialty.id AND course_has_specialty.specialty_id = specialty.id WHERE course.tag = '" + comboBox2.Text + "'" +
               "", comboBox3, 0, 0);
            }
            catch
            {
                MessageBox.Show("Групп на этом курсе нет!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.Clear();
                Meth.BdCombo("" +
                    "SELECT  `group`.id FROM `group` INNER JOIN course_has_specialty ON `group`.specialty_id = course_has_specialty.specialty_id INNER JOIN course ON course_has_specialty.course_id = course.id INNER JOIN specialty ON `group`.specialty_id = specialty.id AND course_has_specialty.specialty_id = specialty.id WHERE course.tag = '" + comboBox2.Text + "'  and specialty.`name` = '" + comboBox3.Text + "';", comboBox1, 0, 0);
            }
            catch
            {
                MessageBox.Show("Групп на этом курсе нет!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            userName = comboBox4.Text;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}