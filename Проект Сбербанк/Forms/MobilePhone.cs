using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект_Сбербанк.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Проект_Сбербанк.Forms
{
    public partial class MobilePhone : Form
    {
        Database database = new Database();
        public MobilePhone()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Num_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата сохранения";
            if (!Regex.IsMatch(textBoxNumber.Text, "^[+][7][7][0-9]{7,14}$"))
            {
                MessageBox.Show("Пожалуйста, введите номер телефона", caption, btn, ico);
                textBoxNumber.Select();
                return;
            }
                var phonenumber = textBoxNumber.Text;
                var changeNumQuery = $"update client set client_phone_number = '{phonenumber}' where id_client = '{DataStorage.idClient}'";
                var command = new SqlCommand(changeNumQuery, database.GetConnection());
                database.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Номер телефона успешно изменен!");
                    Close();
                }
                else
                {
                MessageBox.Show("Ошибка!");
                }
                
                database.closeConnection();
            
        }

        private void MobilePhone_Load(object sender, EventArgs e)
        {

        }
        Point lastpoint;
        private void MobilePhone_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void MobilePhone_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
    }
}
