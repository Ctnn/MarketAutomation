using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace market_automation
{
    
    public class ServerControl
    {
        public class MyData
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public string Path { get; set; }
            public string ProductType { get; set; }
        }
        public int count=0;
        
        static string connection_str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yigit\source\repos\market_automation\market_automation\bin\Debug\my_datebase.accdb";
           public List<MyData> TakeInfo(string product_type)
        {
            OleDbConnection connection = new OleDbConnection(connection_str);
            OleDbCommand cmd =connection.CreateCommand();
            connection.Open();
            OleDbCommand data= new OleDbCommand("select * from "+product_type , connection);
            OleDbDataReader read = data.ExecuteReader();
            List<MyData> list = new List<MyData>();
            while (read.Read())
            {
                MyData list_data = new MyData();
                list_data.Name = (string)read["product_name"];
                list_data.Price = (string)read["product_price"];
                list_data.Path = (string)read["product_image"];
                list_data.ProductType = (string)read["product_type"];
                list.Add(list_data);
                count++;

            }
            connection.Close();
            return list;
        }
    }
}
