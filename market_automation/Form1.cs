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
        private string path1,path2, path3, path4;
        private string main_menu;
        private void pathChanges(params string[] path)
        {

            if (path.Length == 2)
            {
                gunaAdvenceTileButton1.Image = System.Drawing.Image.FromFile(path[0]);
                gunaAdvenceTileButton2.Image = System.Drawing.Image.FromFile(path[1]);
                
            }
            else if (path.Length == 3)
            {
                gunaAdvenceTileButton1.Image = System.Drawing.Image.FromFile(path[0]);
                gunaAdvenceTileButton2.Image = System.Drawing.Image.FromFile(path[1]);
                gunaAdvenceTileButton3.Image = System.Drawing.Image.FromFile(path[2]);


            }
            else
            {
                gunaAdvenceTileButton1.Image = System.Drawing.Image.FromFile(path[0]);
                gunaAdvenceTileButton2.Image = System.Drawing.Image.FromFile(path[1]);
                gunaAdvenceTileButton3.Image = System.Drawing.Image.FromFile(path[2]);
                gunaAdvenceTileButton4.Image = System.Drawing.Image.FromFile(path[3]);
            }
        }
        private void buttonChanges(params bool[] bools)
        {
                gunaAdvenceTileButton1.Visible = bools[0];
                gunaAdvenceTileButton2.Visible = bools[1];
                gunaAdvenceTileButton3.Visible = bools[2];
                gunaAdvenceTileButton4.Visible = bools[3];       
        }
        private void buttonlabelChanges(params string[] label)
        {
            if(label.Length == 2)
            {
                gunaAdvenceTileButton1.Text = label[0];
                gunaAdvenceTileButton2.Text = label[1];
               
            }
            else if(label.Length == 3)
            {
                gunaAdvenceTileButton1.Text = label[0];
                gunaAdvenceTileButton2.Text = label[1];
                gunaAdvenceTileButton3.Text = label[2];
               

            }
            else
            {
                gunaAdvenceTileButton1.Text = label[0];
                gunaAdvenceTileButton2.Text = label[1];
                gunaAdvenceTileButton3.Text = label[2];
                gunaAdvenceTileButton4.Text = label[3];
            }
              
        
           
        }
        public void getProduct(string type)
        {

            flowLayoutPanel1.Controls.Clear();
            ServerControl cs = new ServerControl();
            var result = cs.TakeInfo(type);

            for (int i = 0; i < cs.count; i++)
            {
                var tutucu = new UserControl1();
                tutucu.nametag = result[i].Name;
                tutucu.pricetag = result[i].Price;
                flowLayoutPanel1.Controls.Add(tutucu);
            }

        }
        public void getProduct(string type,string submenu)
        {

            flowLayoutPanel1.Controls.Clear();
            ServerControl cs = new ServerControl();
            var result = cs.TakeInfo(type);

            for (int i = 0; i < cs.count; i++)
            {
                if (result[i].ProductType == submenu)
                {
                    var tutucu = new UserControl1();
                    tutucu.nametag = result[i].Name;
                    tutucu.pricetag = result[i].Price;
                    flowLayoutPanel1.Controls.Add(tutucu);
                }
               
            }

        }
        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            main_menu = "drinks";
            path1 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\water_32px.png";
            path2 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\cola_50px.png";
            path3 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\caffie_30px.png";
            path4 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\tea_30px.png";
            pathChanges(path1, path2, path3, path4);
            buttonChanges(true, true, true, true);
            buttonlabelChanges("Water", "Gaseous", "Coffie", "Tea");
            getProduct(main_menu);

           

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flowLayoutPanel1,gunaVScrollBar1, true);
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan2 = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flowLayoutPanel2, gunaVScrollBar2, true);
            main_menu = "drinks";

            

            //for(int i = 0; i < cs.count; i++)
            //{

            //    MessageBox.Show(cs.count.ToString());
            //}








            // flowLayoutPanel1.Controls.Add(deneme);



        }

        private void gunaGradientTileButton2_Click(object sender, EventArgs e)
        {
            main_menu = "healthy";
            path1 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\healthy_menu\Gailan_24px.png";
            path2= @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\healthy_menu\watermelon_50px.png";
            pathChanges(path1, path2);
            buttonChanges(true, true, false, false);
            buttonlabelChanges("Vegetable", "Fruit");
            getProduct(main_menu);
        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
            getProduct(main_menu,gunaAdvenceTileButton1.Text);
        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaAdvenceTileButton2_Click(object sender, EventArgs e)
        {
            getProduct(main_menu, gunaAdvenceTileButton2.Text);
        }

        private void gunaAdvenceTileButton3_Click(object sender, EventArgs e)
        {
            getProduct(main_menu, gunaAdvenceTileButton3.Text);
        }

        private void gunaAdvenceTileButton4_Click(object sender, EventArgs e)
        {
            getProduct(main_menu, gunaAdvenceTileButton4.Text);
        }

        private void gunaGradientTileButton3_Click(object sender, EventArgs e)
        {
            main_menu = "dairyproduct";
            path1 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\dairy_menu\cheese_26px.png";
            path2 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\dairy_menu\Kawaii Milk_24px.png";
            path3 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\dairy_menu\yogurt_24px.png";
            pathChanges(path1, path2, path3);
            buttonChanges(true, true, true, false);
            buttonlabelChanges("Cheese", "Yogurt", "Milk");
            getProduct(main_menu);
        }

        private void gunaGradientTileButton4_Click(object sender, EventArgs e)
        {
            main_menu = "breakfast";
            path1 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\breakfast_menu\Egg Carton_24px.png";
            path2 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\breakfast_menu\Empty Jam Jar_24px.png";
            path3 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\breakfast_menu\meat_50px.png";
            path4 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\breakfast_menu\olive_26px.png";
            pathChanges(path1,path2,path3,path4);
            buttonChanges(true, true, true, true);
            buttonlabelChanges("Egg", "Olive", "Meat", "Delicatessen");
            getProduct(main_menu);
        }

        private void gunaGradientTileButton5_Click(object sender, EventArgs e)
        {
            main_menu = "snacks";
            path1 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\snacks_menu\potato_chips_50px.png";
            path2 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\snacks_menu\chocolate_bar_50px.png";
            path3 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\snacks_menu\melting_ice_cream_24px.png";
            path4 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\snacks_menu\cookie_50px.png";
            pathChanges(path1, path2, path3, path4);
            buttonChanges(true, true, true, true);
            buttonlabelChanges("Chips", "Chocolate", "IceCream", "Biscuit");
            getProduct(main_menu);
        }
    }
}
