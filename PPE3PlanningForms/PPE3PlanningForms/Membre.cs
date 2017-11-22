using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE3PlanningForms
{
    public class Membre
    {
        int id_membre;
        string nom;
        string prenom;

        public int Id_membre { get => id_membre; set => id_membre = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
    }
}
