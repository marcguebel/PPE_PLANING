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

            string myConnectionString = "server=127.0.0.1;uid=root;pwd=;database=ppe_planing;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }

        public void CreerEvt(int IdTerrain, int IdAnimateur, float HeureDebut, float HeureFin, string Description, string Date)
        {
            string requete = "insert into evenement (Id_Terrain, Id_Animateur, Heure_Debut, Heure_Fin, Description, date_Evt) VALUES ('" + IdTerrain + "', '" + IdAnimateur + "', '" + HeureDebut + "', '" + HeureFin + "', '" + Description + "', '" + Date + "')";
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
            MySqlDataReader rdr = cmd.ExecuteReader();
            string result = "";
            while (rdr.Read())
            {
                result = result + rdr["Description"].ToString() + "\r\n De " + rdr["Heure_Debut"].ToString() + "h a " + rdr["Heure_Fin"].ToString() + "h sur le terrain : " + rdr["Id_Terrain"].ToString() + "\r\n";
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




        public List<Terrain> TerrainDispo(float heure_debut, float heure_fin, string date)
        { 
            List<Terrain> lesTerrains = new List<Terrain>();
            string requete = "select distinct terrain.id, terrain.Nom from terrain,evenement where (evenement.Date_Evt = '"+ date +"' AND terrain.Id not in (select evenement.Id_Terrain from evenement where('" + heure_debut  + "' between Heure_Debut and Heure_Fin)OR('"+ heure_fin + "' between Heure_Debut and Heure_Fin))) OR NOT EXISTS (select Date_Evt from evenement where Date_Evt = '"+ date +"')";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Terrain t = new Terrain(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString());
                lesTerrains.Add(t);
            }
            rdr.Close();
            return lesTerrains;
        }

        public List<Membre> AnimateurDispo(float heure_debut, float heure_fin, string date)
        {
            List<Membre> lesAnimateurs = new List<Membre>();
            string requete = "select distinct membre.Id, membre.Nom, membre.Nom from  evenement, membre where (evenement.Date_Evt = '"+ date +"') AND membre.Nom not in (select membre.Nom from membre, evenement where (membre.Id = evenement.Id_Animateur) AND ('"+ heure_debut +"' between Heure_Debut and Heure_Fin) OR ('"+ heure_fin +"' between Heure_Debut and Heure_Fin)) OR NOT EXISTS (select evenement.Id_Animateur from evenement where Date_Evt = '"+ date +"')";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Membre m = new Membre(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString(), rdr[1].ToString());
                lesAnimateurs.Add(m);
            }
            rdr.Close();
            return lesAnimateurs;
        }

        public int RecupIdTerrain(string nom_terrain)
        {
            int IdTerrain = 0;
            string requete = "select terrain.id, terrain.Nom from terrain where terrain.nom = '"+ nom_terrain +"'";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Terrain m = new Terrain(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString());
                IdTerrain = m.Id_terrain;
            }
            rdr.Close();
            return IdTerrain;
        }

        public int RecupIdAnimateur(string nom_animateur)
        {
            int IdAnimateur = 0;
            string requete = "select membre.id, membre.Nom, membre.Prenom from membre where membre.nom = '" + nom_animateur + "'";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Membre m = new Membre(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString());
                IdAnimateur = m.Id_membre;
            }
            rdr.Close();
            return IdAnimateur;
        }
    }
}
