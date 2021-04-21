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
    public partial class Formateur : Form
    {
        public Formateur()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogiinFormateur L2 = new LogiinFormateur();
            L2.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertionDateExame I3 = new InsertionDateExame();
            I3.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertionAbscence I2 = new InsertionAbscence();
            I2.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertionNotes I1 = new InsertionNotes();
            I1.Show();
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
