using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_etablisment_scolaire
{
    public partial class SurveillantGeneral : Form
    {
        public SurveillantGeneral()
        {
            InitializeComponent();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterEtudiant A1 = new AjouterEtudiant();
            A1.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterFillieres A2 = new AjouterFillieres();
            A2.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterGroups A3 = new AjouterGroups();
            A3.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterDateVacanses A4 = new AjouterDateVacanses();
            A4.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterModules A5 = new AjouterModules();
            A5.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ajouter_Emploi A6 = new Ajouter_Emploi();
            A6.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            List_Etudiant L = new List_Etudiant();
            L.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogiinSurveillantGeneral L1 = new LogiinSurveillantGeneral();
            L1.Show();
        }
    }
}
