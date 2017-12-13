using System;
using System.Collections;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            var monthCalendar = sender as MonthCalendar;
            var dateEtHeure = monthCalendar.SelectionStart.ToString();
            var date = dateEtHeure.Substring(0,10);
            var jour = dateEtHeure.Substring(0, 2);
            var mois = dateEtHeure.Substring(3, 2);
            var annee = dateEtHeure.Substring(6, 4);
            var dateFormat = annee + "-" + mois + "-" + jour;
            DAOEvt evt = new DAOEvt();
            string result = evt.EvenementJournee(dateFormat);
            textBox1.Text = "Evenement pour le : " + dateFormat ;
            textBox2.Text = result;
        }
    }
}
