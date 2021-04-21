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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogiinFormateur LF = new LogiinFormateur();
            LF.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogiinSurveillantGeneral LS = new LogiinSurveillantGeneral();
            LS.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogiinEtudiant LE = new LogiinEtudiant();
            LE.Show();
        }
    }
}
