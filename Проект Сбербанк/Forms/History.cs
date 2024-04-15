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
    public partial class History : Form
    {
        Database database   =  new Database();
        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            var QueryTransaction = $"select transaction_type ,transaction_destination,transaction_date,transaction_number ,transaction_value from transactions inner join bank_card on transactions.id_bank_card = bank_card.id_bank_card inner join client on client.id_client = bank_card.id_client where client.id_client = '{DataStorage.idClient}'";
            SqlCommand sqlCommand = new SqlCommand(QueryTransaction, database.GetConnection());
            database.openConnection();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                ListViewItem listViewItem = new ListViewItem(reader[0].ToString());
                listViewItem.SubItems.Add(reader[1].ToString());
                listViewItem.SubItems.Add(reader[2].ToString());
                listViewItem.SubItems.Add(reader[3].ToString());
                listViewItem.SubItems.Add(reader[4].ToString());
                listView1.Items.Add(listViewItem);

            }
            reader.Close();
            listView1.Sort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point lastpoint;
        private void History_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void History_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }
    }
}
