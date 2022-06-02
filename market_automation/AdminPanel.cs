using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market_automation
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void gunaGradientTileButton2_Click(object sender, EventArgs e)
        {
            AdminYetki next = new AdminYetki();
            next.Show();
            this.Close();
                 
        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            KullaniciDetay user = new KullaniciDetay();
            this.Hide();
            user.Show();
        }

        private void gunaGradientTileButton3_Click(object sender, EventArgs e)
        {
            UrunKontrol urun = new UrunKontrol();
            this.Hide();
            urun.Show();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
