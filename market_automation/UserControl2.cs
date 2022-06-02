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
    public partial class UserControl2 : UserControl
    {
       
        public UserControl2()
        {
            InitializeComponent();

        }
        public UserControl2(string isim, string fiyat)
        {
            this.isimetiketi = isim;
            this.fiyatetiketi = fiyat;

        }
       
       
        public string isimetiketi
        {
            get
            {
                return gunaLabel1.Text.ToString();

            }

            set
            {
                gunaLabel1.Text = value;
            }
        }
    
        public string fiyatetiketi
        {
            get
            {
                return gunaLabel3.Text.ToString();

            }

            set
            {
                gunaLabel3.Text = value;
            }
        }
       
        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            //SATIN ALMA GEÇMİŞİ İÇİN GEREKLİ OLAN KISIM
            for(int i=0;i<Form1.gecmis_adtutucu.Count;i++)
            {
                if(Form1.gecmis_adtutucu[i]==this.isimetiketi)
                {
                    Form1.gecmis_adtutucu.RemoveAt(i);
                    Form1.gecmis_urunfiyatutucu.RemoveAt(i);
                }
            }
            this.Parent.Controls.Remove(this);
            Form1.toplam_fiyat = Form1.toplam_fiyat - Convert.ToInt32(this.fiyatetiketi);

        }

        private void gunaLinePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
