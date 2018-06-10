using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE3PlanningForms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //Appel des terrain dispo pour le creaneux
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            float heure_debut = Convert.ToInt16(numericUpDown1.Value);
            float heure_fin = Convert.ToInt16(numericUpDown2.Value);
            var monthCalendar = sender as MonthCalendar;
            var dateEtHeure = monthCalendar1.SelectionStart.ToString();
            string date = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
            DAOEvt evt = new DAOEvt();
            List<Terrain> lesTerrains = evt.TerrainDispo(heure_debut, heure_fin, date);
            List<Membre> lesAnimateurs = evt.AnimateurDispo(heure_debut, heure_fin, date);
            foreach (Terrain t in lesTerrains)
            {
                listBox2.Items.Add(t.Nom);
            }
            foreach (Membre m in lesAnimateurs)
            {
                listBox3.Items.Add(m.Nom);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var monthCalendar = sender as MonthCalendar;
            var dateEtHeure = monthCalendar1.SelectionStart.ToString();
            string date = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
            string description = textBox1.Text;
            float heure_debut = Convert.ToInt16(numericUpDown1.Value);
            float heure_fin = Convert.ToInt16(numericUpDown2.Value);

            int x = listBox2.SelectedIndex;
            string terrain = Convert.ToString(listBox2.Items[x]);
            int y = listBox3.SelectedIndex;
            string animateur = Convert.ToString(listBox3.Items[y]);
            DAOEvt evt = new DAOEvt();
            int idTerrain = evt.RecupIdTerrain(terrain);
            int idAnimateur = evt.RecupIdAnimateur(animateur);
            evt.CreerEvt(idTerrain, idAnimateur, heure_debut, heure_fin, description, date);


            //listBox1.Items.Add(date);
            //listBox1.Items.Add(description);
            //listBox1.Items.Add(heure_debut);
            //listBox1.Items.Add(heure_fin);
            //listBox1.Items.Add(terrain);
            //listBox1.Items.Add(animateur);
        }
    }
}
