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
    public partial class Etudiant : Form
    {

        public Etudiant()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogiinEtudiant L1 = new LogiinEtudiant();
            L1.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsulterDateVacanses C4 = new ConsulterDateVacanses();
            C4.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsulterDateEvaluations C3 = new ConsulterDateEvaluations();
            C3.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsulterEmploi C2 = new ConsulterEmploi();
            C2.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsulterNotes C1 = new ConsulterNotes();
            C1.Show();
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
