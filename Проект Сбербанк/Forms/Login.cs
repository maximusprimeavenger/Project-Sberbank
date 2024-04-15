using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Проект_Сбербанк.Classes;

namespace Проект_Сбербанк.Forms
{
    public partial class Login : Form
    {
        Database database = new Database();
        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Login_Load(object sender, EventArgs e)
        {

            textBoxPassword.PasswordChar = '*';
            textBoxNumbers.Select();
            textBoxNumbers.MaxLength = 50;
            textBoxPassword.MaxLength = 50;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_button_MouseEnter(object sender, EventArgs e)
        {
            close_button.ForeColor = Color.Red;
        }

        private void close_button_MouseLeave(object sender, EventArgs e)
        {
            close_button.ForeColor = Color.White;
        }

        Point lastpoint;

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNumbers.Text) && !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                string querystring = $"select * FROM client WHERE client_phone_number = '{textBoxNumbers.Text}' AND client_password = '{textBoxPassword.Text}'";
                string queryGetId = $"select id_client FROM client WHERE client_phone_number = '{textBoxNumbers.Text}'";
                var commandGetId = new SqlCommand(queryGetId, database.GetConnection());

                database.openConnection();
                SqlDataReader reader = commandGetId.ExecuteReader();
                while (reader.Read())
                {
                    DataStorage.idClient = reader[0].ToString();
                }
                reader.Close();

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand(querystring, database.GetConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    textBoxNumbers.Clear();
                    textBoxPassword.Clear();
                    checkBox1.Checked = false;
                    Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    form1 = null;
                    Show();
                    textBoxNumbers.Select();
                }
                else
                {
                    MessageBox.Show("Имя пользователя или пароль неверны", "Попробуйте ещё раз!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBoxNumbers.Focus();
                    textBoxNumbers.SelectAll();

                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя или пароль", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxNumbers.Select();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sign_up frm_sign = new sign_up();
            frm_sign.Show();
            this.Hide();
        }


    }
}
