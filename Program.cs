using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Corm
{
    class Program
    {
        static void Main(string[] args)
        {

            MySqlConnection con = new MySqlConnection("Server=;Database=tahmkench;Uid=;Pwd=;");

            try
            {
                con.Open();
            } catch
            {
                Console.WriteLine("Não foi possivel abrir a conexão.");
            }

            User u = new User(con);

            u.find(1);
            
        }
    }
}
