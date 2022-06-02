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
    public partial class KartSec : Form
    {
        public KartSec()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(ServerControl.baglanti_string);
        private void SelectCard_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            baglanti.Open();
            OleDbCommand veri = new OleDbCommand("select * from odemebilgileri where userID='"+GirisEkrani.ID.ToString() +"'", baglanti);
            OleDbDataReader oku = veri.ExecuteReader();
            while (oku.Read())
            {
                string card_adi = oku["kart_adi"].ToString();
                checkedListBox1.Items.Add(card_adi);
            }
            baglanti.Close();
        }
        public static string secilen_kart;
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && checkedListBox1.CheckedItems.Count > 0)
            {
                checkedListBox1.ItemCheck -= checkedListBox1_ItemCheck;
                checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);
                checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            }
            secilen_kart = checkedListBox1.SelectedItem.ToString();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
