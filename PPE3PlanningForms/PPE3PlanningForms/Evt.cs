using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE3PlanningForms
{
    class Evt
    {
        private string description;
        private int duree;

        public Evt()
        {
            this.description = "";
            this.Duree = 0;
        }
        public Evt(string description, int duree)
        {
            this.description = description;
            this.Duree = duree;
        }

        public int Duree { get => duree; set => duree = value; }
    }
}
