using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace market_automation
{
    public partial class AdminYetki : Form
    {
        public AdminYetki()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(ServerKontrol.baglanti_string);
        private void adminperm_Load(object sender, EventArgs e)
        {
            gunaDataGridView1.Rows.Clear();
            
            baglanti.Open();
            OleDbCommand data = new OleDbCommand("select * from yetkilibilgi ", baglanti);
            OleDbDataReader read = data.ExecuteReader();
            while (read.Read())
            {
                int id = Convert.ToInt32(read["ID"]);
                string kullanici_adi = read["kullanici_adi"].ToString();
                string kullanici_sifre = read["kullanici_sifre"].ToString();
                gunaDataGridView1.Rows.Add(id, kullanici_adi, kullanici_sifre);
               
            }
            baglanti.Close();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

            using (baglanti)
            {
                baglanti.Open();
               
                OleDbCommand cmd1 = new OleDbCommand("INSERT INTO [yetkilibilgi] " + "([kullanici_adi],[kullanici_sifre]) " + "VALUES(@value1,@value2)", baglanti);
                cmd1.Parameters.AddWithValue("@value1", gunaTextBox1.Text);
                cmd1.Parameters.AddWithValue("@value2", gunaTextBox2.Text);
                
                cmd1.ExecuteNonQuery();
                baglanti.Close();
                adminperm_Load(sender, e);
            }


        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (System.Windows.MessageBox.Show("Bu kişiyi silmek istediğinize emin misiniz ? ", "Soru", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                OleDbCommand veri = new OleDbCommand("delete from yetkilibilgi where ID=" + Convert.ToInt32(gunaTextBox3.Text), baglanti);
                veri.ExecuteNonQuery();
                System.Windows.MessageBox.Show("Seçtiğiniz yetkili silinmiştir.");
                baglanti.Close();
                adminperm_Load(sender, e);

            }
            baglanti.Close(); //Bunun nedeni sorulan soruya hayır dersek else'e girmeyeceği için hatadan kaçıyoruz.
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            AdminPanel panel = new AdminPanel();
            this.Hide();
            panel.Show();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            var keep = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["ID"].Value.ToString();
            var keep2 = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["KullaniciAdi"].Value.ToString();
            var keep3 = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["Sifre"].Value.ToString();
            System.Windows.MessageBox.Show(keep+keep2+keep3);
            var baglanti_string = "UPDATE yetkilibilgi SET [kullanici_adi] = ?, [kullanici_sifre] = ? WHERE [ID] = ?";
            OleDbCommand bilgi = new OleDbCommand(baglanti_string, baglanti);
            bilgi.Parameters.AddWithValue("@kullanici_adi", keep2);
            bilgi.Parameters.AddWithValue("@kullanici_sifre", keep3);
            bilgi.Parameters.AddWithValue("@ID", keep);
            baglanti.Open();
            bilgi.ExecuteNonQuery();
            baglanti.Close();
            adminperm_Load(sender, e);
            System.Windows.MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleşmiştir.");
           
           
           
                
        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = gunaDataGridView1.Rows[index];
            if(selectedRow.Cells[0].Value != null)
            {
                gunaTextBox3.Text = selectedRow.Cells[0].Value.ToString();
                gunaTextBox4.Text = selectedRow.Cells[0].Value.ToString();
            }
            else
            {
                System.Windows.MessageBox.Show("Lütfen Boş Alanlara Tıklamayınız.");
            }
          
        }

       
    }
}
