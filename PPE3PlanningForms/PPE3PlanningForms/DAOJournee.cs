using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE3PlanningForms
{
    class DAOJournee
    {
        private MySqlConnection conn;
        public DAOJournee()
        {
            string myConnectionString = "server=172.17.0.6;uid=anthony;pwd=btssio;database=ppe3;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }

        public void AjoutJournee(Journee j)
        {
            string requete = "insert into membre VALUES (" + j.Numero + "','" + j.Debut+ "','" + j.Fin + "' )";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
