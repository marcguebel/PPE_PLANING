using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE3PlanningForms
{
    public class Terrain
    {
        private int id_terrain;
        private string nom;
        List<Terrain> leTerrain;

        public int Id_terrain { get => id_terrain; set => id_terrain = value; }
        public string Nom { get => nom; set => nom = value; }

        public Terrain (int id_terrain, string nom)
        {
            this.Id_terrain = id_terrain;
            this.Nom = nom;
        }
    }


}
