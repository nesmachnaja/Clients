using clients.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clients.Services
{
    public class ClientServices
    {
        public IEnumerable<ClientProfile> GetClient()
        {
            List<ClientProfile> clientProfiles = new List<ClientProfile>();
            var connection = Form1.Connection(Form1.SerName, Form1.DBname);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM "+Form1.DBname;
            SqlDataReader reader = command.ExecuteReader();
            do
            {
                while (reader.Read())
                {
                    for (int i = 1; i<9; i++)
                    {
                        clientProfiles.Add((ClientProfile)reader.GetValue(i).ToString());
                    }
                }
            } while (reader.NextResult());
            return clientProfiles;
        }

        private DataSet ReadData(SqlConnection connection)
        {
            DataSet dataSet = new DataSet();
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM "+Form1.DBname;
            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet);
            connection.Close();
            return dataSet;
        }

        public void UpdateDB(SqlConnection connection)
        {
            connection.Open();
            DataSet dataSet = new DataSet();
            dataSet = ReadData(connection);
            string passport = "Паспорт";
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM "+Form1.DBname, connection);

            adapter.UpdateCommand = new SqlCommand("UPDATE " + Form1.DBname + " SET " + ClientProfile.Doc + " = " + passport + " WHERE " + ClientProfile.Age + " >14");

            adapter.UpdateCommand.Parameters.Add(passport, SqlDbType.NChar, 10, ClientProfile.Doc);

            adapter.UpdateCommand.Connection = connection;

            adapter.Update(dataSet.Tables[0]);
            connection.Close();
        }

        public void SavePerson(SqlConnection connection)
        {
            connection.Open();
            DataSet dataSet = new DataSet();
            dataSet = ReadData(connection);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM " + Form1.DBname, connection);

            SqlCommand id = new SqlCommand("SELECT COUNT(*) FROM " + Form1.DBname);
            int number = (int)id.ExecuteScalar() + 1;
            adapter.UpdateCommand = new SqlCommand("UPDATE " + Form1.DBname + " SET " +
                ClientProfile.FirstName + " = " + Form2.textBox2.Text + ", " +
                ClientProfile.MiddleName + " = " + Form2.textBox3.Text + ", " +
                ClientProfile.LastName + " = " + Form2.textBox1.Text + ", " +
                ClientProfile.Age + " = " + Form2.textBox4.Text + ", " +
                ClientProfile.Phone + " = " + Form2.textBox7.Text + ", " +
                ClientProfile.EMail + " = " + Form2.textBox6.Text + ", " +
                ClientProfile.Doc + " = " + Form2.textBox5.Text + ", " +
                "WHERE " + ClientProfile.ClientId + " = SELECT * FROM " + number);

            adapter.UpdateCommand.Parameters.Add(Form2.textBox2.Text, SqlDbType.NChar, 10, ClientProfile.FirstName);
            adapter.UpdateCommand.Parameters.Add(Form2.textBox3.Text, SqlDbType.NChar, 10, ClientProfile.MiddleName);
            adapter.UpdateCommand.Parameters.Add(Form2.textBox1.Text, SqlDbType.NChar, 10, ClientProfile.LastName);
            adapter.UpdateCommand.Parameters.Add(Form2.textBox4.Text, SqlDbType.NChar, 10, ClientProfile.Age);
            adapter.UpdateCommand.Parameters.Add(Form2.textBox7.Text, SqlDbType.NChar, 10, ClientProfile.Phone);
            adapter.UpdateCommand.Parameters.Add(number, SqlDbType.Int, 10, ClientProfile.ClientId);

            adapter.UpdateCommand.Connection = connection;

            adapter.Update(dataSet.Tables[0]);
            connection.Close();
        }


}
}
