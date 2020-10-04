using clients.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clients
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        Form1 form1 = new Form1();

        public static string DBname => textBox2.Text;
        public static string SerName => textBox1.Text;

        public static SqlConnection Connection(string SerName, string DBname)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = @"Data Source=" + SerName + ";Initial Catalog=" + DBname + ";Integrated Security=True"
            };
            connection.Open();
            return connection;
        }

        private void CreateConnection(string SerName, string DBname)
        {
            if ((SerName != "") & (DBname != ""))
            {
                try
                {
                    Connection(SerName,DBname);
                    OpenNewForm();
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой данных. Проверьте правильность введённых данных");
                }
            }
            else
            {
                MessageBox.Show("Введите имя сервера и базы данных!");
            }   
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateConnection(textBox1.Text, textBox2.Text);
        }

        private void OpenNewForm()
        {
            this.Visible = false;
            Form2 form2 = new Form2
            {
                Visible = true
            };
            form2.Text = DBname;
        }



        public IEnumerable<ClientProfile> GetClient()
        {
            List<ClientProfile> clientProfiles = new List<ClientProfile>();
            var connection = Connection(SerName, DBname);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM " + DBname;
            SqlDataReader reader = command.ExecuteReader();
            do
            {
                while (reader.Read())
                {
                    for (int i = 1; i < 9; i++)
                    {
                        clientProfiles.Add((ClientProfile)reader.GetValue(i).ToString());
                    }
                }
            } while (reader.NextResult());
            return clientProfiles;
        }

    }
}
