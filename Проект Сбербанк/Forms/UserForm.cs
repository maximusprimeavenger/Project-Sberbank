using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Проект_Сбербанк.Classes;


namespace Проект_Сбербанк.Forms
{
    public partial class UserForm : Form
    {
        Point lastpoint;
   


        Database database = new Database();
        public UserForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            RefreshData();

        }

        private void RefreshData()
        {
            var queryPIB = $"select concat(client_last_name, ' ' , client_first_name, ' ' , client_middle_name), client_phone_number, client_email from client where id_client = '{DataStorage.idClient}'";
            SqlCommand commandPIB = new SqlCommand(queryPIB, database.GetConnection());
            database.openConnection();
            SqlDataReader reader = commandPIB.ExecuteReader();
            while (reader.Read())
            {
                labelSurname.Text += reader[0].ToString();
                labelMobile.Text += reader[1].ToString();
                labelAdress.Text += reader[2].ToString();
            }
            reader.Close();
        }

        private void ClearFields()
        {
            labelSurname.Text = string.Empty;
            labelMobile.Text = string.Empty;
            labelAdress.Text = string.Empty;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshData();
        }

        private void buttonMobilePhone_Click(object sender, EventArgs e)
        {
            MobilePhone mobila = new MobilePhone();
            mobila.Show();
        }

        private void buttonAdress_Click(object sender, EventArgs e)
        {
            Adress adr = new Adress();
            adr.Show();
        }

        private void buttonPassword_Click(object sender, EventArgs e)
        {
            Password pass = new Password();
            pass.Show();
        }


        private void UserForm_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void UserForm_MouseDown_1(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
    }
}
