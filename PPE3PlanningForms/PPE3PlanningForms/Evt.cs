using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE3PlanningForms
{
    public class Evt
    {
        int id_evt;
        private string description;
        private int duree;
        private Terrain leTerrain;
        private List<Membre> lesMembres;
        private Membre animation;

        public Evt()
        {
            this.Id_evt = 0;
            this.Description = "";
            this.Duree = 0; 
        }
        public Evt(int id_evt, string description, int duree, Terrain t, Membre m)
        {
            this.Id_evt = id_evt;
            this.Description = description;
            this.Duree = duree;
            this.leTerrain = t;
            lesMembres = new List<Membre>();
            this.Animation = m;
        }

        public int Id_evt { get => id_evt; set => id_evt = value; }
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
