﻿using MySql.Data.MySqlClient;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            MySqlConnection conn;
            string myConnectionString = "server=172.17.0.6;uid=anthony;pwd=btssio;database=ppe3;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
            String requete = "SELECT * FROM membre WHERE Nom='" + textBox1.Text + "' AND Mdp='" + textBox2.Text + "';";
            MySqlCommand command = new MySqlCommand(requete, conn);
            int result = Convert.ToInt16(command.ExecuteScalar());
            
            if (result > 0)
            {
                new Form1().Show();
            }
            else
            {
                MessageBox.Show("Connexion refusée ! Nom de compte ou mot de passe incorrect.");
            }
            conn.Close();
        }
    }
}
