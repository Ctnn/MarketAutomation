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
    public partial class KullaniciDetay : Form
    {
        public KullaniciDetay()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection(ServerKontrol.baglanti_string);
        private void UserDetail_Load(object sender, EventArgs e)
        {
            gunaDataGridView1.Rows.Clear();
            connection.Open();
            OleDbCommand data = new OleDbCommand("select * from kullanicibilgi ", connection);
            OleDbDataReader read = data.ExecuteReader();
            while (read.Read())
            {
                int id = Convert.ToInt32(read["ID"]);
                string ad = read["ad"].ToString();
                string soyad= read["soyad"].ToString();
                string kullanici_adi = read["kullanici_adi"].ToString();
                string password = read["kullanici_sifre"].ToString();
                string gender = read["cinsiyet"].ToString();
                string phone = read["telefonno"].ToString();
               
              
              
   
                gunaDataGridView1.Rows.Add(id,ad,soyad, kullanici_adi, password,gender,phone);


            }
            connection.Close();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            var tutucu = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["ID"].Value.ToString();
            var tutucu2 = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["AD"].Value.ToString();
            var tutucu3 = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["SOYAD"].Value.ToString();
            var tutucu4 = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["KULLANICIADI"].Value.ToString();
            var tutucu5 = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["SIFRE"].Value.ToString();
            var tutucu6 = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["CINSIYET"].Value.ToString();
            var tutucu7 = (string)gunaDataGridView1.Rows[Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Index)].Cells["TELEFONNO"].Value.ToString();
       
            var connection_str = "UPDATE kullanicibilgi SET [ad] = ?, [soyad] = ?,[kullanici_adi] = ?, [kullanici_sifre] = ?,[cinsiyet] = ?, [telefonno] = ? WHERE [ID] = ?";
            OleDbCommand data = new OleDbCommand(connection_str, connection);
            data.Parameters.AddWithValue("@ad", tutucu2);
            data.Parameters.AddWithValue("@soyad", tutucu3);
            data.Parameters.AddWithValue("@kullanici_adi", tutucu4);
            data.Parameters.AddWithValue("@kullanici_sifre", tutucu5);
            data.Parameters.AddWithValue("@cinsiyet", tutucu6);
            data.Parameters.AddWithValue("@telefonno", tutucu7);
            data.Parameters.AddWithValue("@ID", tutucu);
            connection.Open();
            data.ExecuteNonQuery();
            connection.Close();
            UserDetail_Load(sender, e);
            System.Windows.MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir.");
        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = gunaDataGridView1.Rows[index];
            if (selectedRow.Cells[0].Value != null)
            {
                gunaTextBox4.Text = selectedRow.Cells[0].Value.ToString();
                gunaTextBox3.Text = selectedRow.Cells[0].Value.ToString();
            }
            else
            {
                System.Windows.MessageBox.Show("Lütfen Boş Alanlara Tıklamayınız.");
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            connection.Open();
            if (System.Windows.MessageBox.Show("Bu kişiyi silmek istediğinize emin misiniz ? ", "Soru", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                OleDbCommand veri = new OleDbCommand("delete from kullanicibilgi where ID=" + Convert.ToInt32(gunaTextBox3.Text), connection);
                veri.ExecuteNonQuery();
                System.Windows.MessageBox.Show("Üye başarıyla silinmiştir.");
                connection.Close();
                UserDetail_Load(sender, e);

            }
        
            connection.Close(); //Bunun nedeni sorulan soruya hayır dersek else'e girmeyeceği için hatadan kaçıyoruz.
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            AdminPanel panel = new AdminPanel();
            this.Hide();
            panel.Show();
        }
    }
}
