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
    public partial class SatisBelgesi : Form
    {
        public SatisBelgesi()
        {
            InitializeComponent();
        }

        private void SalePage_Load(object sender, EventArgs e)
        {
            gunaLabel6.Text = KonumSayfasi.ev_konum;
            gunaLabel5.Text = KartSec.secilen_kart;
            gunaLabel2.Text = Form1.toplam_fiyat.ToString();
        }
        OleDbConnection baglanti = new OleDbConnection(ServerControl.baglanti_string);
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            var kontrol =gunaLabel2.Text!=null||gunaLabel5.Text!=null||gunaLabel6.Text!=null;
            if (kontrol)
            {
                using (baglanti)
                {
                    for(int i=0;i<Form1.gecmis_adtutucu.Count;i++)
                    {    
                    baglanti.Open();
                    OleDbCommand data = new OleDbCommand("INSERT INTO satinalmagecmis (userID,urun_ad,urun_ucret,toplam_ucret,odeme_kart,adres_konum) values(@value1,@value2,@value3,@value4,@value5,@value6)", baglanti);
                    data.Parameters.AddWithValue("@value1", GirisEkrani.ID.ToString());
                    data.Parameters.AddWithValue("@value2", Form1.gecmis_adtutucu[i]);
                    data.Parameters.AddWithValue("@value3", Form1.gecmis_urunfiyatutucu[i]);
                    data.Parameters.AddWithValue("@value4", Form1.toplam_fiyat);
                    data.Parameters.AddWithValue("@value5", KartSec.secilen_kart);
                    data.Parameters.AddWithValue("@value6", KonumSayfasi.ev_konum);
                    data.ExecuteNonQuery();
                    baglanti.Close();
                  
                    }
                    System.Windows.MessageBox.Show("Satın Alma İşlemi Başarıyla Tamamlanmıştır.");
                    Form1 uzanti = new Form1();
                    uzanti.ekran_sifirla();
                    this.Close();
                }
            }
        }
    }
}
