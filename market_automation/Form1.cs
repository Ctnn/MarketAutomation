using Guna.UI.WinForms;
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
        public delegate void delPassData(Label labels);
        public Form1()
        {
            InitializeComponent();
        }
        static string atama;
        public Form1(int change)
        {
            InitializeComponent();
            atama = change.ToString();
            this.LabelText = atama;
            
              
        }
     

        private string konum1="a",konum2 = "a", konum3 = "a", konum4 = "a";
        private string main_menu;
        private void konumDegisimi(params string[] konum)
        {

            if (konum.Length == 2)
            {
                gunaAdvenceTileButton1.Image = System.Drawing.Image.FromFile(konum[0]);
                gunaAdvenceTileButton2.Image = System.Drawing.Image.FromFile(konum[1]);
                
            }
            else if (konum.Length == 3)
            {
                gunaAdvenceTileButton1.Image = System.Drawing.Image.FromFile(konum[0]);
                gunaAdvenceTileButton2.Image = System.Drawing.Image.FromFile(konum[1]);
                gunaAdvenceTileButton3.Image = System.Drawing.Image.FromFile(konum[2]);


            }
            else
            {
                gunaAdvenceTileButton1.Image = System.Drawing.Image.FromFile(konum[0]);
                gunaAdvenceTileButton2.Image = System.Drawing.Image.FromFile(konum[1]);
                gunaAdvenceTileButton3.Image = System.Drawing.Image.FromFile(konum[2]);
                gunaAdvenceTileButton4.Image = System.Drawing.Image.FromFile(konum[3]);
            }
        }
        private void ButonDegisimi(params bool[] bools)
        {
                gunaAdvenceTileButton1.Visible = bools[0];
                gunaAdvenceTileButton2.Visible = bools[1];
                gunaAdvenceTileButton3.Visible = bools[2];
                gunaAdvenceTileButton4.Visible = bools[3];       
        }
        private void butonlabelDegisimi(params string[] label)
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
       
        public List<UserControl1> UrunGetir(string urun_tip)
        {
  
            flowLayoutPanel1.Controls.Clear();
            ServerKontrol cs = new ServerKontrol();
            var result = cs.BilgiAl(urun_tip);
            List<UserControl1> mylist = new List<UserControl1>();
            for (int i = 0; i < cs.sayim; i++)
            {
                var tutucu = new UserControl1();
                tutucu.nametag = result[i].Isim;
                tutucu.pricetag = result[i].Fiyat;
                tutucu.pathtag = result[i].Uzantı;
                mylist.Add(tutucu);
                flowLayoutPanel1.Controls.Add(tutucu);
                tutucu.Click += new EventHandler(ListeElemanEkle);
            }
        
            return mylist;

        }
        //OVERLOAD KULLANILDI.
        public List<UserControl1> UrunGetir(string urun_tipi,string altmenu)
        {
           
            flowLayoutPanel1.Controls.Clear();
            ServerKontrol cs = new ServerKontrol();
            var result = cs.BilgiAl(urun_tipi);
            List<UserControl1> mylist = new List<UserControl1>();
            for (int i = 0; i < cs.sayim; i++)
            {
                if (result[i].UrunTipi == altmenu)
                {
                    var tutucu = new UserControl1();
                    tutucu.nametag = result[i].Isim;
                    tutucu.pricetag = result[i].Fiyat;
                    tutucu.pathtag = result[i].Uzantı;
                    mylist.Add(tutucu);
                    flowLayoutPanel1.Controls.Add(tutucu);
                    tutucu.Click += new EventHandler(ListeElemanEkle);

                }
            }
            return mylist;
        }

        public static int toplam_fiyat;
        public static List<string> gecmis_adtutucu=new List<string>();
        public static List<string> gecmis_urunfiyatutucu = new List<string>();


        //NOT= BURADAN SEPETE ATMAYI UNUTMA

        public void ListeElemanEkle(object sender, EventArgs e)
        {
          
             var tutucu = new UserControl2();
             List<UserControl2> mylist2 = new List<UserControl2>();
             tutucu.isimetiketi = ((UserControl1)sender).nametag.ToString();
             tutucu.fiyatetiketi = ((UserControl1)sender).pricetag.ToString();
             mylist2.Add(tutucu);
             flowLayoutPanel2.Controls.Add(tutucu);

             toplam_fiyat= toplam_fiyat +Convert.ToInt32(tutucu.fiyatetiketi);

            gecmis_adtutucu.Add(tutucu.isimetiketi.ToString());
            gecmis_urunfiyatutucu.Add(tutucu.fiyatetiketi.ToString());

        }
  
        public int getlabeldata;
        
        public string LabelText
        {
            get
            {
                return this.gunaLabel5.Text;
            }
            set
            {
               
                atama = value;
               gunaLabel5.Text = atama;
               MessageBox.Show(gunaLabel5.Text);
                gunaLabel5.Refresh();

            }
        }
     
        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            main_menu = "icecek";
            konum1 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\water_32px.png";
            konum2 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\cola_50px.png";
            konum3 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\caffie_30px.png";
            konum4 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\drinks_menu\tea_30px.png";
            konumDegisimi(konum1, konum2, konum3, konum4);
            ButonDegisimi(true, true, true, true);
            butonlabelDegisimi("Su", "Gazlı", "Kahve", "Cay");
            control = UrunGetir(main_menu);
          

        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flowLayoutPanel1,gunaVScrollBar1, true);
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan2 = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flowLayoutPanel2, gunaVScrollBar2, true);
            main_menu = "icecek";
            UrunGetir(main_menu);
            gunaLabel5.Text = LabelText;
            if(GirisEkrani.gender=="Bay")
            {
                gunaLabel1.Text = GirisEkrani.name + " Bey " + " Hoşgeldiniz";
                gunaCirclePictureBox1.Visible = false;
                gunaCirclePictureBox2.Visible = true;
            }
            else if(GirisEkrani.gender=="Bayan")
            {
                gunaLabel1.Text = GirisEkrani.name + " Hanım " + " Hoşgeldiniz";
                gunaCirclePictureBox1.Visible = true;
                gunaCirclePictureBox2.Visible = false;
            }
  
        }
    

        private void gunaGradientTileButton2_Click(object sender, EventArgs e)
        {
            main_menu = "saglikli";
            konum1 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\healthy_menu\Gailan_24px.png";
            konum2= @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\healthy_menu\watermelon_50px.png";
            konumDegisimi(konum1, konum2);
            ButonDegisimi(true, true, false, false);
            butonlabelDegisimi("Sebze", "Meyve");
            control = UrunGetir(main_menu);
        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
            UrunGetir(main_menu,gunaAdvenceTileButton1.Text);
        }



        private void gunaAdvenceTileButton2_Click(object sender, EventArgs e)
        {
            UrunGetir(main_menu, gunaAdvenceTileButton2.Text);
        }

        private void gunaAdvenceTileButton3_Click(object sender, EventArgs e)
        {
            UrunGetir(main_menu, gunaAdvenceTileButton3.Text);
        }

        private void gunaAdvenceTileButton4_Click(object sender, EventArgs e)
        {
            UrunGetir(main_menu, gunaAdvenceTileButton4.Text);
        }

      
        List<UserControl1> control;

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
           
                
        }

      
        private IEnumerable<Control> GetChildren(Control control = null)
        {
            if (control == null) control = flowLayoutPanel1;

            var list = control.Controls.OfType<Control>().ToList();

            foreach (var child in list)
                list.AddRange(GetChildren(child));

            return list;
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if(KonumSayfasi.ev_konum!=null && KartSec.secilen_kart!=null && toplam_fiyat !=null&& flowLayoutPanel1.Controls.Count != 0)
            {
            SatisBelgesi sale = new SatisBelgesi();
            sale.Show();
            }
            else
            {
                MessageBox.Show("Lütfen Gerekli Bilgilerinizi Seçiniz Veya Ürününüzü Ekleyiniz..");
            }
        }


        private void gunaGradientTileButton3_Click(object sender, EventArgs e)
        {
            main_menu = "suturunleri";
            konum1 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\dairy_menu\cheese_26px.png";
            konum2 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\dairy_menu\Kawaii Milk_24px.png";
            konum3 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\dairy_menu\yogurt_24px.png";
            konumDegisimi(konum1, konum2, konum3);
            ButonDegisimi(true, true, true, false);
            butonlabelDegisimi("Peynir", "Yoğurt", "Süt");
           control=UrunGetir(main_menu);
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            Odeme pay = new Odeme();
            pay.Show();
        }

        private void gunaAdvenceButton2_Click_1(object sender, EventArgs e)
        {
            KartSec git = new KartSec();
            git.Show();
        }

        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            satinalmagecmis git = new satinalmagecmis();
            this.Hide();
            git.Show();
        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            KonumSayfasi loc = new KonumSayfasi();
            loc.Show();
        }



        private void gunaGradientTileButton4_Click(object sender, EventArgs e)
        {
            main_menu = "kahvalti";
            konum1 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\breakfast_menu\Egg Carton_24px.png";
            konum2 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\breakfast_menu\Empty Jam Jar_24px.png";
            konum3 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\breakfast_menu\meat_50px.png";
            konum4 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\breakfast_menu\olive_26px.png";
            konumDegisimi(konum1,konum2,konum3,konum4);
            ButonDegisimi(true, true, true, true);
            butonlabelDegisimi("Yumurta", "Zeytin", "Et", "Sarkuteri");
            control = UrunGetir(main_menu);
        }

        private void gunaGradientTileButton5_Click(object sender, EventArgs e)
        {
            main_menu = "atistirmalik";
            konum1 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\snacks_menu\potato_chips_50px.png";
            konum2 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\snacks_menu\chocolate_bar_50px.png";
            konum3 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\snacks_menu\melting_ice_cream_24px.png";
            konum4 = @"C:\Users\yigit\source\repos\market_automation\market_automation\icons\snacks_menu\cookie_50px.png";
            konumDegisimi(konum1, konum2, konum3, konum4);
            ButonDegisimi(true, true, true, true);
            butonlabelDegisimi("Cips", "Çikolata", "Dondurma", "Bisküit");
            control = UrunGetir(main_menu);
        }
        public void ekran_sifirla()
        {
            while (flowLayoutPanel2.Controls.Count > 0)
            {
                flowLayoutPanel2.Controls.RemoveAt(0);
            }
            gecmis_adtutucu.Clear();
            gecmis_urunfiyatutucu.Clear();
            toplam_fiyat = 0;
            MessageBox.Show(gecmis_adtutucu.Count.ToString());
      
        }
    }
}
