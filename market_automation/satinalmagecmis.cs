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
    public partial class satinalmagecmis : Form
    {
        public satinalmagecmis()
        {
            InitializeComponent();
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            Form1 git= new Form1();
            this.Hide();
            git.Show();
        }
        OleDbConnection connection = new OleDbConnection(ServerKontrol.baglanti_string);
        private void satinalmagecmis_Load(object sender, EventArgs e)
        {
            gunaDataGridView1.Rows.Clear();
            connection.Open();
            OleDbCommand data = new OleDbCommand("select * from satinalmagecmis where userID='" + GirisEkrani.ID + "'", connection);
            OleDbDataReader read = data.ExecuteReader();
            while (read.Read())
            {
                string urun_ad = read["urun_ad"].ToString();
                string urun_ucret = read["urun_ucret"].ToString();
                string odeme_kart = read["odeme_kart"].ToString();
                string adres_konum = read["adres_konum"].ToString();
                gunaDataGridView1.Rows.Add( urun_ad, urun_ucret, odeme_kart, adres_konum);
            }
            connection.Close();
        }
    }
}
