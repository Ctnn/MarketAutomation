using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace market_automation
{
    
    public class ServerKontrol
    {
        public class MyData
        {
            public string Isim { get; set; }
            public string Fiyat { get; set; }
            public string Uzantı { get; set; }
            public string UrunTipi { get; set; }
        }
        public int sayim=0;
        
        public static string baglanti_string = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yigit\source\repos\market_automation\market_automation\bin\Debug\my_datebase.accdb";
           public List<MyData> BilgiAl(string urun_tipi)
        {
            OleDbConnection baglanti = new OleDbConnection(baglanti_string);
            OleDbCommand komut =baglanti.CreateCommand();
            baglanti.Open();
            OleDbCommand bilgi= new OleDbCommand("select * from "+urun_tipi , baglanti);
            OleDbDataReader oku = bilgi.ExecuteReader();
            List<MyData> list = new List<MyData>();
            while (oku.Read())
            {
                MyData list_data = new MyData();
                list_data.Isim = (string)oku["urun_ad"];
                list_data.Fiyat = (string)oku["urun_fiyat"];
                list_data.Uzantı = (string)oku["urun_resim"];
                list_data.UrunTipi = (string)oku["urun_tip"];
                list.Add(list_data);
                sayim++;
            }
            baglanti.Close();
            return list;
        }

    }
}
