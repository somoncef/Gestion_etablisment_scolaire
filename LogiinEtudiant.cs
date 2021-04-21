using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestion_etablisment_scolaire
{
    public partial class LogiinEtudiant : Form
    {
        public static string conn = @"Data Source=DESKTOP-SQH9NT6\SQLEXPRESS;Initial Catalog=Gestion_etablisment_scolaire;Integrated Security=True";
        public SqlConnection cone = new SqlConnection(conn);
        public SqlDataReader sdr;
        public static string login;

        public LogiinEtudiant()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu M1 = new Menu();
            M1.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                cone.Open();
                string cmd = "select logiin,mot_passe from Etudiant_user";
                SqlCommand comm = new SqlCommand(cmd, cone);
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    if (guna2TextBox1.Text == sdr[0].ToString() && guna2TextBox2.Text == sdr[1].ToString())
                    {
                        LogiinEtudiant.login = guna2TextBox1.Text;
                        Etudiant E = new Etudiant();
                        E.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("mote ou login pass incorrect");
                    }
                }
                cone.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked == true)
            {
                guna2TextBox2.PasswordChar = '\0';
            }
            else
            {
                guna2TextBox2.PasswordChar = '*';
            }
        }

        private void LogiinEtudiant_Load(object sender, EventArgs e)
        {
            guna2TextBox2.PasswordChar = '*';
        }
    }
}
