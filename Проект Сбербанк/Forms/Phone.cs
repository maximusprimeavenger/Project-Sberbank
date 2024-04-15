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
using System.Text.RegularExpressions;

namespace Проект_Сбербанк.Forms
{
    public partial class Phone : Form
    {
        Database database = new Database();
        Random rand = new Random();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Phone()
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Phone_Load(object sender, EventArgs e)
        {
            textBoxNumber.Text = DataStorage.phoneNumber;
            TextBoxCard.Text = DataStorage.cardNumber;
            var queryChooseOperator = $"select id_service, serviceName from clientServices where serviceType = 'Mobile'";
            SqlDataAdapter commandChooseOperaot = new SqlDataAdapter(queryChooseOperator, database.GetConnection());
            database.openConnection();
            DataTable operators = new DataTable();
            commandChooseOperaot.Fill(operators);
            comboBoxOperator.DataSource = operators;
            comboBoxOperator.ValueMember = "id_service";
            comboBoxOperator.DisplayMember = "serviceName";
            database.closeConnection();
        }

        private void button_Pay_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата сохранения";
            string tmp = textBoxNumber.Text;
            string phoneNumberToCheck = String.Concat(tmp[0], tmp[1]);
            string selectedOperator = comboBoxOperator.GetItemText(comboBoxOperator.SelectedItem);
            bool numberCheck = false;
            if (selectedOperator == "Beeline")
            {
                if (phoneNumberToCheck != "05" && phoneNumberToCheck != "71" && phoneNumberToCheck != "77" && phoneNumberToCheck != "76")
                {
                    MessageBox.Show("Введите корректный номер телефона.", caption, btn, ico);
                    numberCheck = true;
                }
            }
            else if (selectedOperator == "Kcell")
            {

                if (phoneNumberToCheck != "78" && phoneNumberToCheck != "75")
                {
                    MessageBox.Show("Введите корректный номер телефона.", caption, btn, ico);
                    numberCheck = true;
                }
            }
            else if (selectedOperator == "Tele2")
            {
                if (phoneNumberToCheck != "07" && phoneNumberToCheck != "47")
                {
                    MessageBox.Show("Введите корректный номер телефона.", caption, btn, ico);
                    numberCheck = true;
                }
            }
            else if (selectedOperator == "Altel")
            {

                if (phoneNumberToCheck != "00" && phoneNumberToCheck != "08")
                {
                    MessageBox.Show("Введите корректный номер телефона.", caption, btn, ico);
                    numberCheck = true;
                }
            }
            else if (selectedOperator == "Activ")
            {
                if (phoneNumberToCheck != "01" && phoneNumberToCheck != "02")
                {
                    MessageBox.Show("Введите корректный номер телефона.", caption, btn, ico);
                    numberCheck = true;
                }
            }

            if (numberCheck == false)
            {
                var phoneNumber = textBoxNumber.Text;
                double sum = Convert.ToDouble(textBoxAmount.Text);
                var cardNumber = TextBoxCard.Text;
                var cardCVV = textBoxCVV.Text;
                var cardDate = textBoxValidity.Text;
                var passport = TextBoxPassport.Text;
                var cardCVVCheck = "";
                var cardDateCheck = "";
                double cardBalanceCheck = 0;
                bool error = false;
                string cardCurrency = "";
                //double commission = ((Convert.ToDouble(sum) * 2) / 100);
                //double totalSum = commission + Convert.ToDouble(sum);

                if (!Regex.IsMatch(textBoxNumber.Text, "^[0-9]{9}$"))
                {
                    MessageBox.Show("Ошибка при вводе номера телефона!", caption, btn, ico);
                    textBoxNumber.Select();
                    return;
                }
                var queryCheckCard = $"select bank_card_cvv_code, CONCAT(FORMAT(bank_card_date, '%M'), '/', FORMAT (bank_card_date, '%y')), bank_card_balance , bank_card_currency from bank_card where bank_card_number = '{cardNumber}'";
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
                    MessageBox.Show("Пополнение мобильного происходит только в тенге!", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (Convert.ToDouble(sum) < 5.00)
                {
                    MessageBox.Show("Ошибка. Минимальная сумма пополнения 5.00 грн.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    validation.Show();

                    if (DataStorage.attempts > 0)
                    {
                        DateTime transactionTime = DateTime.Now;
                        var transactionNumber = "p";
                        for (int i = 0; i < 10; i++)
                        {
                            transactionNumber += Convert.ToString(rand.Next(0, 10));
                        }
                        var queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        var querytransaction2 = $"insert into transactions(transaction_type, transaction_destination, transaction_date, transaction_number, transaction_value, id_bank_card) values('Topping up mobile', '+77{textBoxNumber.Text}', '{transactionTime}', '{transactionNumber}', '{sum}', (select id_bank_card from bank_card where bank_card_number = '{cardNumber}'))";
                        var queryTransaction3 = $"update clientServices set serviceBalance = serviceBalance + '{sum}' where serviceName = '{comboBoxOperator.GetItemText(comboBoxOperator.SelectedItem)}' and serviceType = 'Mobile'";
                        var querytransaction4 = $"insert into project(account_number, category_contribution, passport_details, current_deposit_amount, last_transaction_date) values('{DataStorage.idClient}','Topping up mobile', '{passport}', '{sum}', '{transactionTime}')";

                        var command1 = new SqlCommand(queryTransaction1, database.GetConnection());
                        var command2 = new SqlCommand(querytransaction2, database.GetConnection());
                        var command3 = new SqlCommand(queryTransaction3, database.GetConnection());
                        var command4 = new SqlCommand(querytransaction4, database.getConnection());
                        database.openConnection();
                        database.OpenConnection();
                        command1.ExecuteNonQuery();
                        command2.ExecuteNonQuery();
                        command3.ExecuteNonQuery();
                        command4.ExecuteNonQuery();
                        database.closeConnection();
                        database.CloseConnection();
                        Close();
                    }
                }
            }
        }
        Point lastpoint;
        private void Phone_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void Phone_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
    }
}