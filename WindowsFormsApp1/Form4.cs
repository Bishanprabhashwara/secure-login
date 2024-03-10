using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public static string EncodeText(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }
        public static string DecodeText(string encStr)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(encStr));
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = EncodeText(textBox2.Text);
            
            using (loginEntities db = new loginEntities())
            {
                log al = new log() { username = user, pword = pass };
                db.logs.Add(al);
                await db.SaveChangesAsync();
            }
            textBox2.Text = "";
            textBox1.Text = "";

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
