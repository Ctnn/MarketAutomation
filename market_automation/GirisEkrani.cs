using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market_automation
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        static string baglanti_string = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yigit\source\repos\market_automation\market_automation\bin\Debug\my_datebase.accdb";
        public static string name, surname, ID,username,password,gender;
        OleDbConnection connection = new OleDbConnection(baglanti_string);

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            if(gunaTextBox3.Text.Equals(null)|| gunaTextBox4.Text.Equals(null)|| gunaTextBox5.Text.Equals(null)|| gunaTextBox6.Text.Equals(null)|| gunaTextBox7.Text.Equals(null))
            {
                MessageBox.Show("Lütfen bütün kutuları doldurunuz.");
            }
            using (connection)
            {
                connection.Open();

                OleDbCommand komut = new OleDbCommand("INSERT INTO [kullanicibilgi] " + "([kullanici_adi],[kullanici_sifre],[ad],[soyad],[telefonno],[cinsiyet]) " + "VALUES(@value1,@value2,@value3,@value4,@value5,@value6)", connection);
                komut.Parameters.AddWithValue("@value1", gunaTextBox3.Text);
                komut.Parameters.AddWithValue("@value2", gunaTextBox4.Text);
                komut.Parameters.AddWithValue("@value3", gunaTextBox5.Text);
                komut.Parameters.AddWithValue("@value4", gunaTextBox6.Text);
                komut.Parameters.AddWithValue("@value5", gunaTextBox7.Text);
                komut.Parameters.AddWithValue("@value6", gunaComboBox1.SelectedItem.ToString());
                MessageBox.Show("Kaydınız başarıyla gerçekleşmiştir, giriş yapabilirsiniz.");    
                komut.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {
            gunaShadowPanel2.Visible = false;
            gunaShadowPanel1.Visible = true;
            
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            gunaShadowPanel2.Visible = true;
            gunaShadowPanel1.Visible = false; 
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            WelcomePage wel = new WelcomePage();
            wel.Show();
            this.Close();   
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if(WelcomePage.rank.Equals("musteri"))
            {

            
              OleDbConnection connection = new OleDbConnection(baglanti_string);
              connection.Open();
              OleDbCommand data = new OleDbCommand("select * from kullanicibilgi where kullanici_adi='" + gunaTextBox1.Text+ "'and kullanici_sifre='" + gunaTextBox2.Text + "'  ", connection);
              OleDbDataReader read = data.ExecuteReader();
              while (read.Read())
              {
                  ///////////////DEĞER ALMA//////////////////////////////
                  username =  read["kullanici_adi"].ToString();
                password = read["kullanici_sifre"].ToString();
                ID = read["ID"].ToString();
                name = read["ad"].ToString();
                surname = read["soyad"].ToString();
                gender = read["cinsiyet"].ToString();

            }
            if (username == gunaTextBox1.Text && password == gunaTextBox2.Text)
            {
                Form1 formnext = new Form1();
                formnext.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Yanlış Giriş Yaptınız Lütfen Tekrar Deneyiniz.");
            }
            connection.Close();
            }
            else
            {
              
             
                connection.Open();
                OleDbCommand data = new OleDbCommand("select * from yetkilibilgi where kullanici_adi='" + gunaTextBox1.Text + "'and kullanici_sifre='" + gunaTextBox2.Text + "'  ", connection);
                OleDbDataReader read = data.ExecuteReader();
                while (read.Read())
                {
                    ///////////////DEĞER ALMA//////////////////////////////
                    username = read["kullanici_adi"].ToString();
                    password = read["kullanici_sifre"].ToString();
                }
                if (username == gunaTextBox1.Text && password == gunaTextBox2.Text)
                {
                    AdminPanel formnext = new AdminPanel();
                    formnext.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Yanlış giriş yaptınız lütfen tekrar deneyiniz.");
                }
                connection.Close();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            gunaShadowPanel1.Visible = true;
            gunaShadowPanel2.Visible = false;
            
            gunaComboBox1.SelectedIndex = 0;
            if(WelcomePage.rank.Equals("yetkili"))
            {
                gunaButton2.Visible = false;
                gunaLinkLabel1.Visible = false;
                gunaLabel1.Visible = false;
                gunaWinSwitch1.Visible = false;
            }
            
            
        }
    }
    }
