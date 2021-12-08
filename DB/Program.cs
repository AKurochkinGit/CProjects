using System;
using System.Data;
using System.Data.OleDb;

namespace DB
{
    class Program
    {
        static void Main(string[] args)
        {
          
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0 ;" +
                                           "Data Source = online_shop.mdb";
                OleDbConnection OnlineShop = new OleDbConnection(connectionString);
                OnlineShop.Open();
                DataTable OrderTable = new DataTable();
                DateTime now = DateTime.Today;
                DateTime beginDate = new DateTime(2012, 7, 1);

                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT КодКурьера, COUNT(*) FROM Заказ WHERE КодСостояния = 4 AND ДатаЗаказа BETWEEN format('" + beginDate.ToString() + "','DD.MM.YYYY') AND format('" + now.ToString() + "','DD.MM.YYYY') GROUP BY КодКурьера", OnlineShop);
                adapter.Fill(OrderTable);
                foreach (DataRow row in OrderTable.Rows)
                {
                    var cells = row.ItemArray;

                    Console.Write("Доставлено заказов у курьера  " + cells[0].ToString() + ":" + "" +
                        "\t");
                    for (int i = 1; i < cells.Length; i++)
                    {
                        Console.Write(cells[i].ToString() + "\t");
                        Console.WriteLine();
                    }
                }

            }
        }
}


       
    