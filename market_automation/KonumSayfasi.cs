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
    public partial class KonumSayfasi : Form
    {
        public KonumSayfasi()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection(ServerControl.baglanti_string);
        private void Location_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            connection.Open();
            OleDbCommand data = new OleDbCommand("select * from evbilgisi where userID='"+GirisEkrani.ID+"'", connection);
            OleDbDataReader read = data.ExecuteReader();
            while (read.Read())
            {
                int id = Convert.ToInt32(read["ID"]);
                string ev_adi = read["evadi"].ToString();
                checkedListBox1.Items.Add(ev_adi);

            }
            connection.Close();

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            gunaShadowPanel2.Visible = false;
            gunaShadowPanel2.Visible = true;
        }
        public static string ev_konum;

        //TEK SEÇİM KONTROLÜ
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && checkedListBox1.CheckedItems.Count > 0)
            {
                checkedListBox1.ItemCheck -= checkedListBox1_ItemCheck;
                checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);
                checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            }
            ev_konum = checkedListBox1.SelectedItem.ToString();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if(gunaTextBox1.Text.Equals(null) && gunaTextBox2.Text.Equals(null) && gunaTextBox3.Text.Equals(null) && gunaTextBox4.Text.Equals(null) && gunaTextBox5.Text.Equals(null) && gunaTextBox6.Text.Equals(null) && gunaTextBox7.Text.Equals(null))
            { 
            using (connection)
            {
                connection.Open();

                OleDbCommand komut = new OleDbCommand("INSERT INTO [evbilgisi] " + "([userID],[evadi],[il],[ilce],[mahalle],[cadde_sokak],[apart_no],[daire]) " + "VALUES(@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8)", connection);

                komut.Parameters.AddWithValue("@value1", GirisEkrani.ID);
                komut.Parameters.AddWithValue("@value2", gunaTextBox1.Text);
                komut.Parameters.AddWithValue("@value3", gunaTextBox2.Text);
                komut.Parameters.AddWithValue("@value4", gunaTextBox3.Text);
                komut.Parameters.AddWithValue("@value5", gunaTextBox4.Text);
                komut.Parameters.AddWithValue("@value6", gunaTextBox5.Text);
                komut.Parameters.AddWithValue("@value7", gunaTextBox6.Text);
                komut.Parameters.AddWithValue("@value8", gunaTextBox7.Text);

                komut.ExecuteNonQuery();

                MessageBox.Show("ADRESİNİZ BAŞARIYLA EKLENMİŞTİR,LİSTE EKRANINA YÖNLENDİRİLİYORSUNUZ");
               
                
                connection.Close();
                Location_Load(sender, e);
                gunaShadowPanel2.Visible = true;
                gunaShadowPanel2.Visible = false;
                this.Close();
            }
            }
            else
            {
                MessageBox.Show("LÜTFEN BÜTÜN ALANLARI DOLDURUNUZ");
            }
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            gunaShadowPanel2.Visible = true;
            gunaShadowPanel2.Visible = false;
        }

        private void gunaShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
