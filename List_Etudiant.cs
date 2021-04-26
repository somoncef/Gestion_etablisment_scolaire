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
    public partial class List_Etudiant : Form
    {
        public List_Etudiant()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                CrystalReport1 C1 = new CrystalReport1();
                C1.SetParameterValue("Nom_Groupe", guna2TextBox1.Text.ToString());
                crystalReportViewer1.ReportSource = C1;
                crystalReportViewer1.Refresh();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SurveillantGeneral S1 = new SurveillantGeneral();
            S1.Show();
        }
    }
}
