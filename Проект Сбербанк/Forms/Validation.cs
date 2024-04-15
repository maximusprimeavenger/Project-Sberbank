﻿using System;
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
    public partial class Validation : Form
    {
        Database database = new Database();
        public Validation()
        {
            InitializeComponent();
        }

        private void button_Trans_Click(object sender, EventArgs e)
        {
            int attempts = 3;
            int cardPin = Convert.ToInt32(numericUpDown1.Value);
            int pin = 0;
            var queryCheckPin = $"select bank_card_pin from bank_card where bank_card_number = '{DataStorage.bankCard}'";
            SqlCommand command = new SqlCommand(queryCheckPin, database.GetConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                pin = Convert.ToInt32(reader[0]);
            reader.Close();
            if (cardPin == pin)
            {
                MessageBox.Show("Операция подтверждена", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                DataStorage.attempts = attempts;
            }
            else
            {
                MessageBox.Show("Ошибка. Неверный PIN", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (attempts > 0)
                    attempts--;
                else
                {
                    DataStorage.attempts = attempts;
                    MessageBox.Show("У Вас закончились попытки", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Validation_Load(object sender, EventArgs e)
        {

        }

        Point lastpoint;
        private void Validation_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void Validation_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
    }
}
