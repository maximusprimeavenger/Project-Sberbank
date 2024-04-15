using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Проект_Сбербанк.Classes
{
    internal class Database
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=MAX;Initial Catalog=MobileBank;Integrated Security=True");
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=MAX;Initial Catalog=project;Integrated Security=True");


        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open(); 
            }
        }

        public void OpenConnection()
        {
        if (sqlConnection1.State == System.Data.ConnectionState.Closed)
         {
           sqlConnection1.Open();
          }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public void CloseConnection()
        {
            if (sqlConnection1.State == System.Data.ConnectionState.Open)
            {
                sqlConnection1.Close();
            }
       }
        public SqlConnection GetConnection()
        {
           return sqlConnection;
        }
        public SqlConnection getConnection()
       {
           return sqlConnection1;
       }
    }
}
