using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Проект_Сбербанк.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Проект_Сбербанк.Forms
{
  
    public partial class Form1 : Form
    {
        Database database = new Database();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        Point lastpoint;
        private void Form1_Load(object sender, EventArgs e)
        {
            label_cardNumber.BringToFront();
            label_cardNumber.Text = "";
            label7.BringToFront();
            label6.BringToFront();
            label_cardTo.BringToFront();
            label_cardCvv.BringToFront();
            pictureBoxMaster.Visible = false;
            pictureBoxVisa.Visible = false;

            var queryMyCards = $"select id_bank_card, bank_card_number from bank_card where id_client = '{DataStorage.idClient}'";
            SqlDataAdapter commandMyCards = new SqlDataAdapter(queryMyCards, database.GetConnection());
            database.openConnection(); 
            DataTable cards = new DataTable();
            commandMyCards.Fill(cards);
            CardscomboBox.DataSource = cards;
            CardscomboBox.ValueMember = "id_bank_card";
            CardscomboBox.DisplayMember = "bank_card_number";
            database.closeConnection();
            selectBankCard();
        }
        private void label_cardCvv_Click(object sender, EventArgs e)
        {
            if (label_cardCvv.Text == "***")
            {
                label_cardCvv.Text = DataStorage.cardCVV;
            }
            else
            {
                label_cardCvv.Text = "***";
            }
        }
        private void selectBankCard()
        {

            label_cardNumber.Text = "";
            string paymentSystem = "";
            string querySelectCard = $"select bank_card_number, bank_card_cvv_code, CONCAT(FORMAT(bank_card_date, '%M'), '/', FORMAT(bank_card_date,'%y')), bank_card_paymentSystem, bank_card_balance, bank_card_currency from bank_card where bank_card_number = '{CardscomboBox.GetItemText(CardscomboBox.SelectedItem)}'";
            SqlCommand command = new SqlCommand(querySelectCard, database.GetConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
            var cardNumber = reader[0].ToString();
                int tmp = 0;
                int tmp1 = 4;
                for (int m = 0; m < 4; m++)
                {
                    for (int n = tmp; n < tmp1; n++)
                    {

                        label_cardNumber.Text += cardNumber[n].ToString();
                    }
                        label_cardNumber.Text += " ";
                        tmp += 4;
                        tmp1 += 4;
                }
                label_cardCvv.Text = reader[1].ToString();
                label_cardTo.Text = reader[2].ToString();
                paymentSystem = reader[3].ToString();
                balanceLabel.Text = Math.Round(Convert.ToDouble(reader[4]), 2).ToString();
                currencyLabel.Text = reader[5].ToString();
                DataStorage.cardCVV = label_cardCvv.Text;
                label_cardCvv.Text = "***";
            }
            reader.Close();
            if (paymentSystem == "Visa")
            {
                pictureBoxVisa.Visible = true;
                pictureBoxMaster.Visible = false;
            }
             else
             {
                pictureBoxMaster.Visible = true;
                pictureBoxVisa.Visible = false;
             }
        }
        private void button_Add_Click(object sender, EventArgs e)
        {
            AddBankCard frm_sign = new AddBankCard();
            frm_sign.Show();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            var queryMyCards = $"select id_bank_card, bank_card_number from bank_card where id_client = '{DataStorage.idClient}'";
            SqlDataAdapter commandMyCards = new SqlDataAdapter(queryMyCards, database.GetConnection());
            database.openConnection();
            DataTable cards = new DataTable();
            commandMyCards.Fill(cards);
            CardscomboBox.DataSource = cards;
            CardscomboBox.ValueMember = "id_bank_card";
            CardscomboBox.DisplayMember = "bank_card_number";
            database.closeConnection();
            selectBankCard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CardscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectBankCard();
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            SendToForm sendToForm = new SendToForm();
            DataStorage.bankCard = CardtextBox.Text;
            DataStorage.cardNumber = CardscomboBox.GetItemText(CardscomboBox.SelectedItem);
            CardscomboBox.Text = "";
            sendToForm.ShowDialog();
        }

        private void pictureBox_Profile_Click(object sender, EventArgs e)
        {
            UserForm usr = new UserForm();
            usr.Show();
        }

        private void pictureBox_Info_Click(object sender, EventArgs e)
        {
            History hstr = new History();
            hstr.Show();
        }

        private void buttonCommunal_Click(object sender, EventArgs e)
        {
            CommunalPay cmpay = new CommunalPay();
            DataStorage.cardNumber = CardscomboBox.GetItemText(CardscomboBox.SelectedItem);
            cmpay.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Internet internet = new Internet();
            DataStorage.cardNumber = CardscomboBox.GetItemText(CardscomboBox.SelectedItem);
            internet.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Charity charity = new Charity();
            DataStorage.cardNumber = CardscomboBox.GetItemText(CardscomboBox.SelectedItem);
            charity.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Phone phone = new Phone();
            DataStorage.cardNumber = CardscomboBox.GetItemText(CardscomboBox.SelectedItem);
            DataStorage.phoneNumber = textBox1.Text;
            textBox1.Text = "";
           phone.Show();
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
