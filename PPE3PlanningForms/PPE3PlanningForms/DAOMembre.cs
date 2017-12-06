using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PPE3PlanningForms
{
    public class DAOMembre
    {
        private MySqlConnection conn;

        public DAOMembre()
        {

            string myConnectionString = "server=172.17.0.6;uid=anthony;pwd=btssio;database=ppe3;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }
    
        public void AjoutMembre(Membre m)
        {
            string requete = "insert into membre VALUES (" + m.Id_membre + "','" +m.Nom + "','" + m.Prenom + "' )";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }

        public void SupprMembre(int id_membre)
        {
            string requete = "delete from membre where id=" + id_membre;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }

        public List<Membre> VoirMembre()
        {
            List<Membre> lesMembres = new List<Membre>();
            string requete = "select * from membre";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Membre c = new Membre(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString(),
               rdr[2].ToString());
                lesMembres.Add(c);
            }
            rdr.Close();
            return lesMembres
                ;
        }


    }
}
