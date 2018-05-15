using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Corm
{
    class Corm
    {

        private MySqlConnection con;

        public string table;
        private Dictionary<int, string> cols = new Dictionary<int, string>();

        public Corm(MySqlConnection _con)
        {
            this.con = _con;
            this.table = this.GetType().Name.ToLower() + "s";

            // Setup table variables

            MySqlCommand cmd = new MySqlCommand("DESCRIBE " + this.table, this.con);
            MySqlDataReader reader = cmd.ExecuteReader();
            int row = 0;
            while (reader.Read())
            {
                this.cols.Add(row, reader["Field"].ToString());
                row++;
            }
        }

        /*
         * @param {int} id
         * @returns {MySqlDataReader}
         */ 
        public MySqlDataReader find(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + this.table + " WHERE id = '"+id+"'", this.con);
            return cmd.ExecuteReader();
        }



    }
}
