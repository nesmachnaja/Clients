using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clients
{
    public partial class Form2 : Form
    {
        Form1 form1 = new Form1();
        string DBname = Form1.DBname;
        string SerName = Form1.SerName;
        public Form2()
        {
            InitializeComponent();

            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            this.label1.Visible = true;
            this.textBox1.Visible = true;
            this.label2.Visible = true;
            this.textBox2.Visible = true;
            this.label3.Visible = true;
            this.textBox3.Visible = true;
            this.label4.Visible = true;
            this.textBox4.Visible = true;
            this.label5.Visible = true;
            this.textBox5.Visible = true;
            this.label6.Visible = true;
            this.textBox6.Visible = true;
            this.label7.Visible = true;
            this.textBox7.Visible = true;
            button3.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label1.Visible = true;
            this.textBox1.Visible = true;
            SqlCommand command = new SqlCommand("SELECT * FROM " + DBname + "WHERE Family=" + textBox1.Text, Form1.Connection(SerName, DBname));
            string rezult = command.ExecuteScalar().ToString();
           // string tr = command.BeginExecuteReader().ToString();
            MessageBox.Show(rezult);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
