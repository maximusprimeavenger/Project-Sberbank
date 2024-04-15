using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Data.SqlClient;
using Проект_Сбербанк.Classes;

namespace Проект_Сбербанк.Forms
{
    public partial class Adress : Form
    {
        Database database = new Database();
        public Adress()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Adr_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата сохранения";
            if (!Regex.IsMatch(textBoxAdress.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Пожалуйста, введите вашу почту", caption, btn, ico);
                textBoxAdress.Select();
                return;
            }
            var mail = textBoxAdress.Text;
            var changeMailQuery = $"update client set client_email = '{mail}' where id_client = '{DataStorage.idClient}'";
            var command = new SqlCommand(changeMailQuery, database.GetConnection());
            database.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Ваша почта успешно изменена!");
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }

            database.closeConnection();
        }


        Point lastpoint;
        private void Adress_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void Adress_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
    }
}
