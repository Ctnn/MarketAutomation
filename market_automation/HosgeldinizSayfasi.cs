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
    public partial class HosgeldinizSayfasi : Form
    {
        public HosgeldinizSayfasi()
        {
            InitializeComponent();
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            rank = "musteri";
            GirisEkrani space = new GirisEkrani();
            this.Hide();
            space.Show();
        
        }

        private void gunaCirclePictureBox2_Click(object sender, EventArgs e)
        {
            rank = "yetkili";
            GirisEkrani space = new GirisEkrani();
            this.Hide();
            space.Show();
          
        }
       public static string rank;
        private void WelcomePage_Load(object sender, EventArgs e)
        {

        }
    }
}
