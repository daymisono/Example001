using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MariahDBExample001
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyConString = "SERVER=localhost; DATABASE=destinyecm; UID=ghostone; PASSWORD=ghostone;";
            MySqlConnection connecntion = new MySqlConnection(MyConString);
            MySqlCommand command = connecntion.CreateCommand();
            MySqlDataReader Reader;
            command.CommandText = "select * from XProcessInfo";
            connecntion.Open();
            Reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();

            while (Reader.Read())
            {
                string thisrow = "";
                for(int i = 0; i < Reader.FieldCount; i++)
                    thisrow += Reader.GetValue(i).ToString() + ",";
                sb.AppendLine(thisrow);
            }
            connecntion.Close();

            Console.WriteLine(sb.ToString());
        }
    }
}
