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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            gunaAdvenceTileButton1.Visible = true;
            gunaAdvenceTileButton2.Visible = true;
            gunaAdvenceTileButton3.Visible = true;
            gunaAdvenceTileButton4.Visible = true;
         //

            gunaAdvenceTileButton1.Image = System.Drawing.Image.FromFile(@"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\water_32px.png");
            gunaAdvenceTileButton2.Image = System.Drawing.Image.FromFile(@"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\cola_50px.png");
            gunaAdvenceTileButton3.Image = System.Drawing.Image.FromFile(@"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\caffie_30px.png");
            gunaAdvenceTileButton4.Image = System.Drawing.Image.FromFile(@"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\tea_30px.png");

        
        }

        private void gunaGradientTileButton4_Click(object sender, EventArgs e)
        {

        }

        private void gunaControlBox2_Click(object sender, EventArgs e)
        {

        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flowLayoutPanel1,gunaVScrollBar1, true);
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan2 = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flowLayoutPanel2, gunaVScrollBar2, true);
           
          //  var product1 = new UserControl1();
          //product1.nametag = "asdq";
          //  var product2 = new UserControl1();
          //  product2.nametag = "asgv vrg dq";
          //  var product3 = new UserControl1();
          //  product3.nametag = "asde efrdq";
          //  var product4 = new UserControl1();
          //  product4.nametag = "asdq";
          //  var product5 = new UserControl1();
          //  product5.nametag = "asd gtbh gbq";
          //  var product6 = new UserControl1();
          //  product6.nametag = "asdq";
          //  var product7 = new UserControl1();
          //  product7.nametag = "asdq";
        
            // flowLayoutPanel1.Controls.Add(new UserControl1());
            //flowLayoutPanel1.Controls.Add(product1);
            //flowLayoutPanel1.Controls.Add(product2);
            //flowLayoutPanel1.Controls.Add(product3);
            //flowLayoutPanel1.Controls.Add(product4);
            //flowLayoutPanel1.Controls.Add(product5);
            //flowLayoutPanel1.Controls.Add(product6);
            //flowLayoutPanel1.Controls.Add(product7);




            // flowLayoutPanel1.Controls.Add(deneme);



        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
