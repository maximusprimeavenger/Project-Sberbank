using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Проект_Сбербанк.Classes;
using System.Windows.Forms;

namespace Проект_Сбербанк.Forms
{
    public partial class AddBankCard : Form
    {
        Database database = new Database();
        Random rand = new Random();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public AddBankCard()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        Point lastpoint;


        private void AddBankCard_Load(object sender, EventArgs e)
        {
            comboBoxCard.SelectedIndex = 0;
            comboBoxCurrency.SelectedIndex = 0;
            comboBoxPaySystem.SelectedIndex = 0;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            var cardType = comboBoxCard.GetItemText(comboBoxCard.SelectedItem);
            var currency = comboBoxCurrency.GetItemText(comboBoxCurrency.SelectedItem);
            var PaySystem = comboBoxPaySystem.GetItemText(comboBoxPaySystem.SelectedItem);
            var CardNumber = "";
            var CardPin = numericUpDown1.Value;
            var CVVCode = "";
            bool IsCardFree = false;
            DateTime dateTime = DateTime.Now;
            var CardDate = dateTime.AddYears(4);

            for(int i=0;i<3; i++)
            {
                CVVCode += Convert.ToString(rand.Next(0, 10));
            }
            do
            {
                if (PaySystem == "Visa")
                {
                    CardNumber += "4";
                    for (int i = 0; i < 15; i++)
                    {
                        CardNumber += Convert.ToString(rand.Next(0, 10));
                    }

                }
                else
                {
                    CardNumber += "5";
                    for (int i = 0; i < 15; i++)
                    {
                        CardNumber += Convert.ToString(rand.Next(0, 10));
                    }
                }
                var queryCheckCardNumber = $"select * from bank_card where bank_card_number = '{CardNumber}'";
                SqlCommand command = new SqlCommand(queryCheckCardNumber, database.GetConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    IsCardFree = true;
                }
            } while (IsCardFree == false) ;

            var QueryAddNewCard = $"insert into bank_card(bank_card_type, bank_card_number, bank_card_cvv_code, bank_card_currency, bank_card_paymentSystem, bank_card_date, id_client, bank_card_pin) values('{cardType}', '{CardNumber}','{CVVCode}','{currency}','{PaySystem}','{CardDate}', '{DataStorage.idClient}', '{CardPin}')";
            SqlCommand commandAddNewCard = new SqlCommand(QueryAddNewCard, database.GetConnection());
            database.openConnection();
            commandAddNewCard.ExecuteNonQuery();
            database.closeConnection();
            MessageBox.Show("Карта успешно создана!", "Данные сохранены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void AddBankCard_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void AddBankCard_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
    }
}
