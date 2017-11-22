using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE3PlanningForms
{
    public class Journee
    {
        private int numero;
        private static int debut;
        private static int fin;
        private List<Rv> LesRv;

        public static int Debut { get => debut; set => debut = value; }
        public static int Fin { get => fin; set => fin = value; }

        public Journee()
        {
            debut = 9;
            fin = 18;
            this.LesRv = new List<Rv>();
            for (int i = 0; i < 9; i++)
            {
                LesRv.Add(null);
            }

        }

        public int ChercherCreneau(Rv r)
        {
            bool trouve = false;
            int position = -10;
            int i = 0;
            while ((trouve == false) && (i < Journee.Fin - Journee.Debut))
            {
                if (LesRv[i] == null)
                {
                    bool possible = true;
                    int j = i;
                    while ((possible) && (j < r.Duree + i))
                    {
                        if (LesRv[j] != null)
                        {
                            possible = false;
                        }
                        j++;
                    }
                    if (possible)
                    {
                        trouve = true;
                        position = i;
                    }
                }
                i++;
            }
            return (position + 9);
        }
        /*{
            bool trouver = false;
            for (int i = 0; i < this.LesRv.Count; i++)
            {
                if (LesRv[i] == null)
                {
                    trouver = true;
                    for (int j = 0; j < r.Duree; j++)
                    {
                        if (LesRv[i + j] != null)
                        {
                            trouver = false;
                        }
                    }
                }
                if (trouver == true)
                {
                    for (int n = 0; n < r.Duree; n++)
                    {
                        LesRv[i + n] = r;
                    }

                    return i + 9;
                }
            }
            return 0;
        }*/

        public bool PlacerRendezVous(int heure, Rv r)
        {
            bool possible = true;
            int j = heure - Journee.Debut;
            if (heure < 9 || heure > 18)
            {
                possible = false;

            }
            while ((possible) && (j < r.Duree + (heure - Journee.Debut)))
            {
                if (LesRv[j] != null)
                {
                    possible = false;
                }
                j++;
            }
            if (possible)
            {
                // on place le RV
                for (int i = heure - Journee.Debut; i < heure - Journee.Debut + r.Duree; i++)
                {
                    LesRv[i] = r;
                }
            }

            return possible;
        }
        /*{
            if (heure > 8 && heure < 18)
            {
                if (this.LesRv[heure - 9] == null)
                {
                    bool trouver = true;
                    if (heure - 9 + r.Duree <= 9)
                    {
                        for (int i = 0; i < r.Duree; i++)
                        {
                            if (this.LesRv[heure - 9 + i] != null)
                            {
                                trouver = false;
                            }
                        }
                    }
                    if (trouver == true)
                    {
                        for (int j = 0; j < r.Duree; j++)
                        {
                            LesRv[heure - 9 + j] = r;
                        }
                    }
                    return trouver;
                }
            }
            return false;
        }*/

        public Rv DonnerRendezVous(int heure)
        {
            if (heure > 8 && heure < 18)
            {
                if (this.LesRv[heure - 9] != null)
                {
                    Rv r = new Rv();
                    r = this.LesRv[heure - 9];
                    return r;
                }
            }
            return null;
        }
    }
}
