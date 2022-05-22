using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market_automation
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
           
          
        }
        private string us1_image;
        private string us1_name=null;
        private string us1_price;
       

        public UserControl1(string image,string name, string price)
        {
            this.nametag = name;
           
        }
        
       public string nametag
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
        public string pricetag
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
        public string pathtag
        {
            get
            {
                return null;

            }

            set
            {
                
                this.BackgroundImage = Image.FromFile(value);


            }
        }
     
        private void UserControl1_Click(object sender, EventArgs e)
        {
            if(gunaGradientButton1.Visible==false)
            {
                gunaGradientButton1.Visible = true;
                gunaLinePanel1.Visible = true;
            }
            else if(gunaGradientButton1.Visible==true)
            {
                gunaGradientButton1.Visible = false;
                gunaLinePanel1.Visible = false;
            }
        }

        private void gunaLinePanel1_Click(object sender, EventArgs e)
        {
            if (gunaGradientButton1.Visible == false)
            {
                gunaGradientButton1.Visible = true;
                gunaLinePanel1.Visible = true;
            }
            else if (gunaGradientButton1.Visible == true)
            {
                gunaGradientButton1.Visible = false;
                gunaLinePanel1.Visible = false;
            }
        }

        private void gunaLinePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
