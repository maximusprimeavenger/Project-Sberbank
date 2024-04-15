using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Проект_Сбербанк.Classes;
using System.Data.SqlClient;

namespace Проект_Сбербанк.Forms
{
    public partial class SendToForm : Form
    {
        Database database = new Database();
        Random rand = new Random();
        SqlDataAdapter adapter = new SqlDataAdapter();  
        DataTable table = new DataTable();

        public SendToForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void SendToForm_Load(object sender, EventArgs e)
        {
            textBoxDestinationCard.Text = DataStorage.bankCard;
            textBoxCard.Text = DataStorage.cardNumber;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Trans_Click(object sender, EventArgs e)
        {
            double dolar = 44.997;
            double euro = 48.794;
            var cardNumber = textBoxCard.Text;
            var cardCVV = textBoxCVV.Text;
            var cardDate = textBoxCardTo.Text;
            var destinationCard = textBoxDestinationCard.Text;
            double sum = Convert.ToDouble(TextBoxSum.Text);
            double sum1;
            double q = dolar / euro;
            double w = euro / dolar;
            var cardCurrency = "";
            var cardCurrency2 = "";
            var cardCVVCheck = "";
            var cardDateCheck = "";
            double cardBalanceCheck = 0;
            bool error = false;
            var passport = textBoxPass.Text;


            var queryCheckCard = $"select bank_card_cvv_code, CONCAT(FORMAT(bank_card_date, '%M'), '/', FORMAT(bank_card_date, '%y')), bank_card_balance, bank_card_currency from bank_card where bank_card_number = '{cardNumber}'";
            SqlCommand commandCheckCard = new SqlCommand(queryCheckCard, database.GetConnection());
            database.openConnection();
            SqlDataReader reader = commandCheckCard.ExecuteReader();
            while (reader.Read())
            {
                cardCVVCheck = reader[0].ToString();
                cardDateCheck = reader[1].ToString();
                cardBalanceCheck = Convert.ToDouble(reader[2].ToString());
                cardCurrency = reader[3].ToString();
            }
            reader.Close();
            if (cardCVV != cardCVVCheck)
            {
                MessageBox.Show("Ошибка. Некорректно введен СVV-код", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            if (cardDate != cardDateCheck)
            {
                MessageBox.Show("Ошибка. Некорректно введена дата карты", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            var queryCheckCardNumber = $"select id_bank_card, bank_card_currency from bank_card where bank_card_number = '{destinationCard}'";
            SqlCommand commandCheckCardNumber = new SqlCommand(queryCheckCardNumber, database.GetConnection());
            adapter.SelectCommand = commandCheckCardNumber;
            adapter.Fill(table);
            SqlDataReader reader1 = commandCheckCardNumber.ExecuteReader();

            while (reader1.Read())
            {
                cardCurrency2 = reader1[1].ToString();
            }
            reader1.Close();
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Ошибка. Некорректные данные карты получателя", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            if (Convert.ToDouble(sum) < 1.00)
            {
                MessageBox.Show("Ошибка. Минимальная сумма перевода 1.00 KZT", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            if (cardNumber == destinationCard)
            {
                MessageBox.Show("Ошибка. Вы не можете перевести средства на эту карту", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            if (sum > cardBalanceCheck)
            { 
                MessageBox.Show("Ошибка. Недостаточно средств для совершения операции", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                error = true;
            }
            if (error == false)
            {
                DataStorage.bankCard = textBoxCard.Text;
                Validation valid = new Validation();
                valid.ShowDialog();

                if (DataStorage.attempts > 0)
                {
                    DateTime transactionTime = DateTime.Now;
                    var transactionNumber = "p";
                    for (int i = 0; i < 10; i++)
                    {
                        transactionNumber += Convert.ToString(rand.Next(0, 10));
                    }
                    var queryTransaction1 = $"";
                    var queryTransaction2 = $"";

                    if (cardCurrency == "KZT" && cardCurrency2 == "USD")
                    {
                        sum1 = sum / dolar;
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum1}' where bank_card_number = '{destinationCard}'";
                    }

                    else if (cardCurrency == "KZT" && cardCurrency2 == "EUR")
                    {
                        sum1 = sum/euro;
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum1}' where bank_card_number = '{destinationCard}'";
                    }
                    else if (cardCurrency == "EUR" && cardCurrency2 == "KZT")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum*euro}' where bank_card_number = '{destinationCard}'";
                    }

                    else if (cardCurrency == "USD" && cardCurrency2 == "KZT")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum*dolar}'  where bank_card_number = '{destinationCard}'";
                    }
                    
                    else if (cardCurrency == "USD" && cardCurrency2 == "EUR")
                    {
                        q = dolar / euro;
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum*q}' where bank_card_number = '{destinationCard}'";
                    }
                    else if (cardCurrency == "EUR" && cardCurrency2 == "USD")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum*w}' where bank_card_number = '{destinationCard}'";
                    }
                    else
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum}' where bank_card_number = '{destinationCard}'";
                    }

                    var querytransaction3 = $"insert into transactions(transaction_type, transaction_destination, transaction_date, transaction_number, transaction_value, id_bank_card) values('Transaction', '{destinationCard}', '{transactionTime}', '{transactionNumber}', '{sum}', (select id_bank_card from bank_card where bank_card_number = '{cardNumber}'))";
                    var querytransaction4 = $"insert into project(account_number, category_contribution, passport_details, current_deposit_amount, last_transaction_date) values('{DataStorage.idClient}','Transaction', '{passport}', '{sum}', '{transactionTime}')";
                    var command1 = new SqlCommand(queryTransaction1, database.GetConnection());
                    var command2 = new SqlCommand(queryTransaction2, database.GetConnection());
                    var command3 = new SqlCommand(querytransaction3, database.GetConnection());
                    var command4 = new SqlCommand(querytransaction4, database.getConnection());
                    database.OpenConnection();
                    database.openConnection();
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                    command4.ExecuteNonQuery();
                    database.CloseConnection();
                    database.closeConnection();

                    Close();
                }
            }

        }
        Point lastpoint;
        private void SendToForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void SendToForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }
    }  
}
