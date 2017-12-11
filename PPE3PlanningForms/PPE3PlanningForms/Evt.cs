using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE3PlanningForms
{
    public class Evt
    {
        private int id_Evt;
        private string description;
        private string date;
        private double heureDebut;
        private double heureFin;
        private int animateur;
        private int id_Terrain;

        public int Id_Evt { get => id_Evt; set => id_Evt = value; }
        public string Description { get => description; set => description = value; }
        public int Animateur { get => animateur; set => animateur = value; }
        public int Id_Terrain { get => id_Terrain; set => id_Terrain = value; }
        public string Date { get => date; set => date = value; }
        public double HeureDebut { get => heureDebut; set => heureDebut = value; }
        public double HeureFin { get => heureFin; set => heureFin = value; }

        public Evt()
        {
            this.id_Evt = 0;
            this.Description = "";
            this.Date = "00/00/00";
            this.HeureDebut = 00.00;
            this.HeureFin = 23.59;
            this.animateur = 0;
            this.id_Terrain = 1;
        }
        public Evt(int id_evt, string description, string date, double heureDebut, double heureFin, int animateur, int id_Terrain)
        {
            this.id_Evt = id_evt;
            this.Description = description;
            this.Date = date;
            this.HeureDebut = heureDebut;
            this.HeureFin = heureFin;
            this.animateur = animateur;
            this.id_Terrain = id_Terrain;
        }
       

        /*public string ChangerAnimation(Membre m)
        {
            //changement d'animation si absent

            this.Animation = m;
            return this.Animation.Nom;
        }*/
    }
}
