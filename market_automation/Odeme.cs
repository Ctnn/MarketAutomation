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
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
   
        }

        private void Payment_Load(object sender, EventArgs e)
        {
          
        }
        OleDbConnection connection = new OleDbConnection(ServerControl.baglanti_string);
        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            if(gunaTextBox1.Text==null||maskedTextBox1.MaskFull == false|| maskedTextBox2.MaskFull == false || maskedTextBox3.MaskFull == false  || gunaCheckBox1.Enabled== false)
            {
                MessageBox.Show("Lütfen bütün alanları doldurunuz..");
            }
            else
            {

            
                using (connection)
                {
                    connection.Open();

                    OleDbCommand cmd1 = new OleDbCommand("INSERT INTO [odemebilgileri] " + "([userID],[kart_numarasi],[kart_tarih],[kart_adi],[cvc_kodu]) " + "VALUES(@value1,@value2,@value3,@value4,@value5)", connection);
                    cmd1.Parameters.AddWithValue("@value1", GirisEkrani.ID);
                    cmd1.Parameters.AddWithValue("@value2", gunaTextBox1.Text);
                    cmd1.Parameters.AddWithValue("@value3", maskedTextBox1.Text);
                    cmd1.Parameters.AddWithValue("@value4", maskedTextBox2.Text);
                    cmd1.Parameters.AddWithValue("@value5", maskedTextBox3.Text);
                    MessageBox.Show("Kart eklemesi başarıyla gerçekleşmiştir, sekme kapatılıyor...");
                    cmd1.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                }

            }
        }

      
    }
}
