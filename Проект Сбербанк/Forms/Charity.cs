using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Проект_Сбербанк.Classes;

namespace Проект_Сбербанк.Forms
{
    public partial class Charity : Form
    {

        Database database = new Database();
        DataTable table = new DataTable();
        Random rand = new Random();
        SqlDataAdapter adapter = new SqlDataAdapter();
        public Charity()
        {
            InitializeComponent();
        }

        private void Charity_Load(object sender, EventArgs e)
        {
            TextBoxCard.Text = DataStorage.cardNumber;
            var queryChooseOperator = $"select id_service, serviceName from clientServices where serviceType = 'Charity'";
            SqlDataAdapter commandChooseOperaot = new SqlDataAdapter(queryChooseOperator, database.GetConnection());
            database.openConnection();
            DataTable operators = new DataTable();
            commandChooseOperaot.Fill(operators);
            comboBox1.DataSource = operators;
            comboBox1.ValueMember = "id_service";
            comboBox1.DisplayMember = "serviceName";
            database.closeConnection();
        }

        private void button_Pay_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата сохранения";
            var PersonalAccount = textBoxPersonalAccount.Text;
            double sum = Convert.ToDouble(textBoxSum.Text);
            var cardNumber = TextBoxCard.Text;
            var cardCVV = textBoxCVV.Text;
            var cardDate = textBoxCardTo.Text;
            var cardCVVCheck = "";
            var cardDateCheck = "";
            double cardBalanceCheck = 0;
            var passport = textBox1.Text;
            bool error = false;
            string cardCurrency = "";

            if (!Regex.IsMatch(textBoxPersonalAccount.Text, "^[0-9]{10}$"))
            {
                MessageBox.Show("Введите корректно ваш номер лицевого счета", caption, btn, ico);
                textBoxPersonalAccount.Select();
                return;
            }
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
            if (cardCurrency != "KZT")
            {
                MessageBox.Show("Оплата коммунальных услуг может производиться только в тенге", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            if (cardCVV != cardCVVCheck)
            {
                MessageBox.Show("Ошибка. Некорректно введен CVV-код", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            if (cardDate != cardDateCheck)
            {
                MessageBox.Show("Ошибка. Некорректно введена дата карты", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            if (sum > cardBalanceCheck)
            {
                MessageBox.Show("Ошибка. Недостаточно средств для совершения операции", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            if (error == false)
            {
                DataStorage.bankCard = TextBoxCard.Text;
                Validation validation = new Validation();
                validation.ShowDialog();
                if (DataStorage.attempts > 0)
                {
                    DateTime transactionDate = DateTime.Now;
                    var transactionNumber = "P";
                    for (int i = 0; i < 10; i++)
                    {
                        transactionNumber += Convert.ToString(rand.Next(0, 10));
                    }
                    var queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                    var queryTransaction2 = $"insert into transactions (transaction_type, transaction_destination, transaction_date, transaction_number, transaction_value, id_bank_card) values ('Charity Payments', '{comboBox1.GetItemText(comboBox1.SelectedItem)}', '{transactionDate}', '{transactionNumber}', '{sum}', (select id_bank_card from bank_card where bank_card_number = '{cardNumber}'))";
                    var queryTransaction3 = $"update clientServices set serviceBalance = serviceBalance + '{sum}' where serviceName = '{comboBox1.GetItemText(comboBox1.SelectedItem)}' and serviceType = 'Charity'";
                    var queryTransaction4 = $"insert into clientPersonalAccount (personal_account, id_service, id_client) values('{textBoxPersonalAccount.Text}', (select id_service from clientServices where serviceName = '{comboBox1.GetItemText(comboBox1.SelectedItem)}'), '{DataStorage.idClient}')";
                    var queryTransaction5 = $"insert into project(account_number, category_contribution, passport_details, current_deposit_amount, last_transaction_date) values('{DataStorage.idClient}', 'Charity Payments', '{passport}', '{sum}', '{transactionDate}')";
                    var command1 = new SqlCommand(queryTransaction1, database.GetConnection());
                    var command2 = new SqlCommand(queryTransaction2, database.GetConnection());
                    var command3 = new SqlCommand(queryTransaction3, database.GetConnection());
                    var command4 = new SqlCommand(queryTransaction4, database.GetConnection());
                    var command5 = new SqlCommand(queryTransaction5, database.getConnection());
                    database.openConnection();
                    database.OpenConnection();
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                    command4.ExecuteNonQuery();
                    command5.ExecuteNonQuery();
                    database.closeConnection();
                    database.CloseConnection();
                    Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Point lastpoint;
        private void Charity_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void Charity_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
    }
}
