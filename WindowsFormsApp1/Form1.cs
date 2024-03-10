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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static int count = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void countmeth(int val)
        {
            count = count + val;
            
            if(count>=3)
            {
                Application.Exit();
            }
        }
        public static string DecodeText(string encStr)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(encStr));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Contains("select"))
                {
                throw new Exception("Security error");
            }
            if (textBox1.Text.Contains("delete"))
            {
                throw new Exception("Security error");
            }
            if (textBox1.Text.Contains("insert"))
            {
                throw new Exception("Security error");
            }
            if (textBox1.Text.Contains("="))
            {
                throw new Exception("Security error");
            }
            Form1 f1 = new Form1();
            f1.countmeth(1);
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=login;Integrated Security=True"))
                {
                    connection.Open();


                    using (SqlCommand command = new SqlCommand("SELECT pword FROM log where username='" + textBox1.Text + "'", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);



                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string pass = reader["pword"].ToString();
                                    string p1 = DecodeText(pass);

                                    if (textBox2.Text.Equals(p1))
                                    {
                                        Form5 f5 = new Form5();
                                        f5.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Wrong password or user name");
                                        count++;
                                        

                                    }


                                }

                            }
                        }

                        connection.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Wrong password or user name");
            }
            
        }
    }
}
