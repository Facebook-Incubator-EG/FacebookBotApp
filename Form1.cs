using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mmosoft.Facebook.Sdk;
using MySql.Data.MySqlClient;

namespace FacebookTopluPaylasim
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        public static string id="";
        public static string sifre = "";


        public static void naber()
        {
            MessageBox.Show("Şimdilik MySQL veritabanına bilgileri elinle girebilir misin :(");
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var id=WebBrowser.

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //facebook id şifreyi aldık
            id = textBox1.Text;
            sifre = textBox2.Text;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gonderipaylas gdr = new gonderipaylas();
            gdr.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
