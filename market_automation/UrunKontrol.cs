using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace market_automation
{
    public partial class UrunKontrol : Form
    {
        public UrunKontrol()
        {
            InitializeComponent();
        }
      
        private void urunListele(string tip)
        {
            string tip_texti = "select * from "+ tip +" ";
            gunaDataGridView1.Rows.Clear();
            baglanti.Open();
            OleDbCommand data = new OleDbCommand(tip_texti, baglanti);
            OleDbDataReader read = data.ExecuteReader();
            while (read.Read())
            {
                int id = Convert.ToInt32(read["ID"]);
                string urun_ad = read["urun_ad"].ToString();
                string urun_fiyat = read["urun_fiyat"].ToString();
                string urun_tip= read["urun_tip"].ToString();
                string urun_resim = read["urun_resim"].ToString();
                gunaDataGridView1.Rows.Add(id, urun_ad,urun_fiyat,urun_tip,urun_resim);

            }
            baglanti.Close();
        }

        OleDbConnection baglanti = new OleDbConnection(ServerKontrol.baglanti_string);
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            urunListele("icecek");
            urun = "icecek";
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            urunListele("saglikli");
            urun = "saglikli";
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            urunListele("suturunleri");
            urun = "suturunleri";
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            urunListele("kahvalti");
            urun = "kahvalti";
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            urunListele("atistirmalik");
            urun = "atistirmalik";
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (System.Windows.MessageBox.Show("Ürünü silmek istediğinize emin misiniz ? ", "Soru", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                OleDbCommand veri = new OleDbCommand("delete from "+urun+" where ID=" + Convert.ToInt32(gunaTextBox6.Text), baglanti);
                veri.ExecuteNonQuery();
                System.Windows.MessageBox.Show("Ürün silinmiştir.");
                baglanti.Close();
                urunListele(urun);
             
                

            }
            baglanti.Close(); //Bunun nedeni sorulan soruya hayır dersek else'e girmeyeceği için hatadan kaçıyoruz.
        }

        private void UrunKontrol_Load(object sender, EventArgs e)
        {
            gunaComboBox1.Items.Add("kahvalti");
            gunaComboBox1.Items.Add("suturunleri");
            gunaComboBox1.Items.Add("icecek");
            gunaComboBox1.Items.Add("saglikli");
            gunaComboBox1.Items.Add("atistirmalik");
        }
        public string urun;
        private void gunaButton8_Click(object sender, EventArgs e)
        {
            var keep =  (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["ID"].Value.ToString();
            var keep2 = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["UrunAdi"].Value.ToString();
            var keep3 = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["UrunFiyati"].Value.ToString();
            var keep4 = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["UrunTipi"].Value.ToString();
            var baglanti_string = "UPDATE "+urun+ " SET [urun_ad] = ?, [urun_fiyat] = ?, [urun_tip] = ? WHERE [ID] = ?";
            OleDbCommand veri = new OleDbCommand(baglanti_string, baglanti);
            veri.Parameters.AddWithValue("@urun_ad", keep2);
            veri.Parameters.AddWithValue("@urun_fiyat", keep3);
            veri.Parameters.AddWithValue("@urun_tip", keep4);
            veri.Parameters.AddWithValue("@ID", keep);
            baglanti.Open();
            veri.ExecuteNonQuery();
            baglanti.Close();
            System.Windows.MessageBox.Show("Ürünler Başarıyla Güncellenmiştir.");
            gunaDataGridView1.Refresh();
        }

        private void gunaDataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = gunaDataGridView1.Rows[index];
            if (selectedRow.Cells[0].Value != null)
            {
                gunaTextBox5.Text = selectedRow.Cells[0].Value.ToString();
                gunaTextBox6.Text = selectedRow.Cells[0].Value.ToString();
            }
            else
            {
                System.Windows.MessageBox.Show("Lütfen Boş Alanlara Tıklamayınız.");
            }
        }
        OpenFileDialog resimac = new OpenFileDialog();
        private void gunaButton6_Click(object sender, EventArgs e)
        {
        
            resimac.ShowDialog();
            string a = resimac.SafeFileName;
            gunaTextBox4.Text = a;
            resimac.Title = "Lütfen Resim Seçimi Yapınız";
            resimac.Filter = "JPEG File |*.jpeg|PNG File |*.png|BITMAP File |*.bmp";
            resimac.ShowDialog();
            gunaTextBox4.Text = resimac.FileName;
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            var kontrol = gunaTextBox1.Text != null || gunaComboBox2.SelectedItem != null||gunaTextBox3.Text != null||gunaTextBox4.Text != null||gunaTextBox5.Text != null||gunaTextBox6.Text != null||gunaComboBox1.SelectedItem!=null;
            if (kontrol)
            {

            using (baglanti)
            {
                baglanti.Open();
                    string uzanti = gunaTextBox4.Text;
                    System.Windows.MessageBox.Show(uzanti);
            //    OleDbCommand data = new OleDbCommand("INSERT INTO ["+gunaComboBox1.Text+"]( VALUES(@value1,@value2,@value3,@value4)", baglanti);
                    OleDbCommand data= new OleDbCommand("INSERT INTO " + gunaComboBox1.Text + "(urun_ad,urun_fiyat,urun_tip,urun_resim) values(@value1,@value2,@value3,@value4)", baglanti);
                data.Parameters.AddWithValue("@value1", gunaTextBox1.Text);
                data.Parameters.AddWithValue("@value2", gunaComboBox2.SelectedItem);
                data.Parameters.AddWithValue("@value3", gunaTextBox3.Text);
                data.Parameters.AddWithValue("@value4", uzanti);
                data.ExecuteNonQuery();
                baglanti.Close();
                 System.Windows.MessageBox.Show("Ürün Başarıyla Eklenmiştir");
            }
            }
        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(gunaComboBox1.SelectedIndex == 0)
            {
                gunaComboBox2.Items.Clear();
                gunaComboBox2.Items.Add("Yumurta");
                gunaComboBox2.Items.Add("Zeytin");
                gunaComboBox2.Items.Add("Sarkuteri");
                gunaComboBox2.Items.Add("Et");
            }
            else if(gunaComboBox1.SelectedIndex ==1)
            {
                gunaComboBox2.Items.Clear();
                gunaComboBox2.Items.Add("Su");
                gunaComboBox2.Items.Add("Kahve");
                gunaComboBox2.Items.Add("Cay");
                gunaComboBox2.Items.Add("Gazlı");
             
            }
            else if (gunaComboBox1.SelectedIndex ==2)
            {
                gunaComboBox2.Items.Clear();
                gunaComboBox2.Items.Add("Süt");
                gunaComboBox2.Items.Add("Peynir");
                gunaComboBox2.Items.Add("Yoğurt");
            }
            else if (gunaComboBox1.SelectedIndex ==3)
            {
                gunaComboBox2.Items.Clear();
                gunaComboBox2.Items.Add("Meyve");
                gunaComboBox2.Items.Add("Sebze");
            }
            else if(gunaComboBox1.SelectedIndex == 4)
            {
                gunaComboBox2.Items.Clear();
                gunaComboBox2.Items.Add("Cips");
                gunaComboBox2.Items.Add("Çikolata");
                gunaComboBox2.Items.Add("Bisküit");
                gunaComboBox2.Items.Add("Dondurma");
            }


        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            AdminPanel git = new AdminPanel();
            this.Hide();
            git.Show();
        }
    }
}
