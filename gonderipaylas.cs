using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Mmosoft.Facebook.Sdk;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FacebookTopluPaylasim
{
    public partial class gonderipaylas : Form
    {
        int sayi;
        public gonderipaylas()
        {
            InitializeComponent();
        }
        MySqlConnection myConnection = new MySqlConnection("Server=localhost;Database=facebook;Uid=root;Pwd='123456et';AllowUserVariables=True;UseCompression=True");
        int sayac;
        int grupsayisi=0;
        int zaman = 0;
        int i = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            zamanlayici.Enabled = true;
            MySqlCommand myCommand = new MySqlCommand("select * from gruplistesi where id<3  grup_kategori='" + comboBox1.Text + "'", myConnection);
            myConnection.Open();
            MySqlDataReader kayitOkuma = myCommand.ExecuteReader();
            
            while (kayitOkuma.Read())
            {
                naber(kayitOkuma["grup_kimlikleri"].ToString(),textBox1.Text);
                listBox1.Items.Add(kayitOkuma["grup_adı"].ToString()+ " ~~~~~~~~~~~~~~~~ Ekleme Başarılı ✔✔✔✔✔✔");
                sayac += int.Parse(kayitOkuma["grup_uye_sayisi"].ToString());
                grupsayisi += 1;
            }
            myConnection.Close();
            
            lbl_grup_sayisi.Text = grupsayisi.ToString();

            for (int i = 0; i <sayac; i++)
            {
                lbl_gonderi_erisim.Text = i.ToString();
            }

             sayac=0;
             grupsayisi = 0;
             zaman = 0;
           
        }


        public static void naber(string grupid,string mesaj)
        {
       
            try
            {
                
                FacebookClient fc = new FacebookClient(Form1.id, Form1.sifre);
                fc.PostToGroup(groupId: grupid, message: mesaj);
                
            }
            catch (Exception A)
            {

                MessageBox.Show("HataAA" + A.Message);
            }


        }
        
        private void zamanlayici_Tick(object sender, EventArgs e)
        {
            i += 3;
            MySqlCommand myCommand = new MySqlCommand("select * from gruplistesi where @i<id<@i+3 and id  grup_kategori='" + comboBox1.Text + "'", myConnection);
            myCommand.Parameters.AddWithValue("@i",i);
            myConnection.Open();
            MySqlDataReader kayitOkuma = myCommand.ExecuteReader();

            while (kayitOkuma.Read())
            {
                naber(kayitOkuma["grup_kimlikleri"].ToString(), textBox1.Text);
                listBox1.Items.Add(kayitOkuma["grup_adı"].ToString() + " ~~~~~~~~~~~~~~~~ Ekleme Başarılı ✔✔✔✔✔✔");
                sayac += int.Parse(kayitOkuma["grup_uye_sayisi"].ToString());
                grupsayisi += 1;
            }
            myConnection.Close();
            
        }

        private void gonderipaylas_Load(object sender, EventArgs e)
        {
            zamanlayici.Interval = 120000;
            MySqlCommand myCommand = new MySqlCommand("select * from kategoriler", myConnection);
            myConnection.Open();
            MySqlDataReader kayitOkuma = myCommand.ExecuteReader();
            while (kayitOkuma.Read())
            { comboBox1.Items.Add(kayitOkuma["kategori_adi"]).ToString(); }
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            MySqlDataAdapter datapter = new MySqlDataAdapter("select * from gruplistesi where id=1 and grup_kategori='" + comboBox1.Text + "'", myConnection);
            DataSet ds = new DataSet();
            datapter.Fill(ds, "grup_kategori");
            dataGridView1.DataSource = ds.Tables["grup_kategori"];
            myConnection.Close();
            dataGridView1.RowHeadersVisible = false; //Gizlenmesini sağlar 
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            zamanlayici.Stop();
        }
    }
}
