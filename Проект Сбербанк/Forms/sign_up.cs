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
using System.Text.RegularExpressions;
using Проект_Сбербанк.Classes;
using System.Drawing.Text;

namespace Проект_Сбербанк.Forms
{
    public partial class sign_up : Form
    {
        Database database = new Database();
        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';
            textBox_passwordagain.PasswordChar = '*';
            textBox_LastName.Select();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата сохранения";
            if (!Regex.IsMatch(textBox_LastName.Text, "[А-Яа-я]+$"))
            {
                MessageBox.Show("Пожалуйста, введите фамилию повторно!", caption, btn, ico);
                textBox_LastName.Select();
                return;
            }
            if (!Regex.IsMatch(textBox_Name.Text, "[А-Яа-я]+$"))
            {
                MessageBox.Show("Введите имя повторно!", caption, btn, ico);
                textBox_Name.Select();
                return;
            }
            if (!Regex.IsMatch(textBox_MiddleName.Text, "[А-Яа-я]+$"))
            {
                textBox_MiddleName.Select();
                MessageBox.Show("Пожалуйста, введите отчество повторно!", caption, btn, ico);
                return;
            }
            if (string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
            {
                MessageBox.Show("Пожалуйста, введите пол повторно!", caption, btn, ico);
                comboBox1.Select();
                return;
            }
            if (!Regex.IsMatch(textBox_password.Text, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
            {
                MessageBox.Show("Пожалуйста, введите пароль", caption, btn, ico);
                textBox_password.Select();
                return;
            }
            if (!Regex.IsMatch(textBox_passwordagain.Text, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")) 
            {
                MessageBox.Show("Пожалуйста, введите подтверждение пароля", caption, btn, ico);
            textBox_passwordagain.Select();
            return;
            }
            if (textBox_password.Text != textBox_passwordagain.Text)
            {
             MessageBox.Show("Ваш пароль и пароль подтверждения не совпадают", caption, btn, ico);
                textBox_passwordagain.SelectAll();
             return;
            }
            if (!Regex.IsMatch(textBox_mail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
             MessageBox.Show("Пожалуйста, введите вашу почту", caption, btn, ico);
             textBox_mail.Select();
             return;
            }
            if (!Regex.IsMatch(textBox_phone.Text, "^[+][7][7][0-9]{7,14}$"))
            {         
            MessageBox.Show("Пожалуйста, введите номер телефона", caption, btn, ico); 
            textBox_phone.Select();
            return;
            }
            string yourSQL = $"SELECT client_phone_number FROM client WHERE client_phone_number = '" + textBox_phone.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(yourSQL, database.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Номер телефона уже существует. Невозможно зарегистрировать аккаунт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                textBox_phone.SelectAll();
                return;
            }
                DialogResult result;
                result = MessageBox.Show("Вы хотите сохранить запись?", "Сохранение данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string mySQL = string.Empty;
                mySQL += "INSERT INTO client (client_last_name, client_first_name, client_middle_name, client_gender, client_password, client_email, client_phone_number) ";
                mySQL += "VALUES ('" + textBox_LastName.Text + "','" + textBox_Name.Text + "','" + textBox_MiddleName.Text + "',";
                mySQL += "'" + comboBox1.SelectedItem.ToString() + "','" + textBox_password.Text + "','" + textBox_mail.Text + "','" + textBox_phone.Text + "')";
                database.openConnection();
                SqlCommand commandAddNewUser = new SqlCommand(mySQL, database.GetConnection());
                commandAddNewUser.ExecuteNonQuery();
                MessageBox.Show("Запись успешна сохранена", "Данные сохранены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearControls();
                database.closeConnection();
                Login frm_login = new Login();
                this.Hide();
                frm_login.ShowDialog();
            }
        }

        private void clearControls()
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Text = string.Empty;
            }
            foreach (ComboBox comboBox in Controls.OfType<ComboBox>())
            {
                comboBox.SelectedItem = null;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_LastName.Select();
            clearControls();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox_password.UseSystemPasswordChar = true;
                textBox_passwordagain.UseSystemPasswordChar = true;
            }
            else
            {
                textBox_password.UseSystemPasswordChar = false;
                textBox_passwordagain.UseSystemPasswordChar = false;
            }
        }

        Point lastpoint;
        private void sign_up_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void sign_up_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}