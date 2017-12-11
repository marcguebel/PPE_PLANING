using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PPE3PlanningForms
{
    class DAOEvt
    {
        private MySqlConnection conn;

        public DAOEvt()
        {

            string myConnectionString = "server=172.17.0.6;uid=anthony;pwd=btssio;database=ppe3;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }

        public void CreerEvt(Evt e)
        {
            string requete = "insert into evenement VALUES (" + e.Description + "','" + e.Duree + "' )";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }

        public void SupprimerEvt(int id_evt)
        {
            string requete = "delete from evenement where id=" + id_evt;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }

        public List<Evt> VoirEvt()
        {
            List<Evt> lesEvenement = new List<Evt>();
            string requete = "select * from evenement";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Evt e = new Evt(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString(),
                 rdr[2].ToString(), Convert.ToInt16(rdr[3].ToString()), rdr[4].ToString(), Convert.ToDouble(rdr[5].ToString()));               
                lesEvenement.Add(e);
            }
            rdr.Close();
            return lesEvenement;
        }
    }
}
