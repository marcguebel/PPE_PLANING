using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE3PlanningForms
{
    public class Evt
    {
        private string description;
        private int duree;
        private Terrain leTerrain;
        private List<Membre> lesInscris;
        private Membre animation;

        public Evt()
        {
            this.Description = "";
            this.Duree = 0; 
        }
        public Evt(string description, int duree, Terrain t, Membre m)
        {
            this.Description = description;
            this.Duree = duree;
            this.leTerrain = t;
            LesInscris = new List<Membre>();
            this.Animation = m;
        }

        public int Duree { get => duree; set => duree = value; }
        public string Description { get => description; set => description = value; }
        public Membre Animation { get => animation; set => animation = value; }

        public string ChangerAnimation(Membre m)
        {
            //changement d'animation si absent

            this.Animation = m;
            return this.Animation.Nom;
        }
    }
}
