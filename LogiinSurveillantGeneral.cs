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
    public partial class LogiinSurveillantGeneral : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);
        public SqlDataReader sdr;

        public LogiinSurveillantGeneral()
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

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                cone.Open();
                string cmd = "select logiin,mot_passe from SurveillantGeneral_user";
                SqlCommand comm = new SqlCommand(cmd, cone);
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    if (guna2TextBox1.Text == sdr[0].ToString() && guna2TextBox2.Text == sdr[1].ToString())
                    {
                        SurveillantGeneral S = new SurveillantGeneral();
                        S.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("mot passe ou login  incorrect");
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

        private void LogiinSurveillantGeneral_Load(object sender, EventArgs e)
        {
            guna2TextBox2.PasswordChar = '*';
        }
    }
}
