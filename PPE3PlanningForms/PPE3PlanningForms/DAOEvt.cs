using System;
using System.Collections;
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
            string requete = "insert into evenement (Description, date_Evt, Heure_Debut, Heure_Fin, Id_Animateur, Id_Terrain) VALUES (" + e.Description + ", " + e.Date + ", " + e.HeureDebut + ", " + e.HeureFin + ", " + e.Animateur + ", " + e.Id_Terrain + ")";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }

        public void SupprimerEvt(int id_evt)
        {
            string requete = "delete from evenement where id=" + id_evt;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }

        public string EvenementJournee(string date_Evenement)
        {
            string requete = "SELECT * FROM evenement where Date_Evt ='" + date_Evenement+"'";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            //cmd.ExecuteNonQuery();
            MySqlDataReader rdr = cmd.ExecuteReader();
            //ArrayList monResult = new ArrayList();
            string result = "";
            while (rdr.Read())
            {
                //monResult.Add(rdr["Id_Evenement"].ToString());
                result = result + rdr["Description"].ToString() + " de " + rdr["Heure_Debut"].ToString() + " a " + rdr["Heure_Fin"].ToString() + "\r\n";
            }
            rdr.Close();
            EventArgs e = new EventArgs();
            return result;
        }


        public List<Evt> VoirEvt() 
        {
            List<Evt> lesEvenement = new List<Evt>();
            string requete = "select * from evenement";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Evt e = new Evt(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString(), Convert.ToDouble(rdr[3].ToString()), Convert.ToDouble(rdr[4].ToString()), Convert.ToInt16(rdr[5].ToString()), Convert.ToInt16(rdr[6].ToString()));               
                lesEvenement.Add(e);
            }
            rdr.Close();
            return lesEvenement;
        }
    }
}
