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
    public partial class AjouterEtudiant : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);
        public SqlDataReader sdr;
        public DataTable dt = new DataTable();

        public AjouterEtudiant()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sexe;
                cone.Open();
                if (guna2RadioButton1.Checked)
                {
                    sexe = guna2RadioButton1.Text;
                }
                else if (guna2RadioButton2.Checked)
                {
                    sexe = guna2RadioButton2.Text;
                }
                else
                {
                    sexe = "";
                }
                string cmd = "insert into Etudiant values (" + guna2TextBox1.Text + ",'" + guna2TextBox2.Text + "','" + guna2TextBox3.Text + "','" + sexe + "','" + guna2TextBox4.Text + "','" + guna2DateTimePicker1.Value + "'," + guna2TextBox5.Text + ",'" + guna2TextBox6.Text + "')";
                SqlCommand comm = new SqlCommand(cmd, cone);
                comm.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Ajoute bien fait");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                cone.Open();
                string cmd = "delete from Etudiant where id_Etudiant=" + guna2TextBox1.Text + "";
                SqlCommand comm = new SqlCommand(cmd, cone);
                comm.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Supprition bien fait");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sexe;
                cone.Open();
                
                if (guna2RadioButton1.Checked)
                {
                    sexe = guna2RadioButton1.Text;
                }
                else if (guna2RadioButton2.Checked)
                {
                    sexe = guna2RadioButton2.Text;
                }
                else
                {
                    sexe = "";
                }
                cone.Open();
                string cmd = "update Etudiant set Nom_Etudiant='" + guna2TextBox2.Text + "',Prenom_Etudiant='" + guna2TextBox3.Text + "',sexe='" + sexe + "',CIN='" + guna2TextBox4.Text + "',Date_Naissance_Etudiant='" + guna2DateTimePicker1.Value + "',Numero_Telephone=" + guna2TextBox5.Text + ",Adresse_Etudiant='" + guna2TextBox6.Text + "' where id_Etudiant= " + guna2TextBox1.Text + "";
                SqlCommand comm = new SqlCommand(cmd, cone);
                comm.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Modifiction bien fait");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                cone.Open();
                dt.Clear();
                string cmd = "select*from Etudiant";
                SqlCommand comm = new SqlCommand(cmd, cone);
                sdr = comm.ExecuteReader();
                dt.Load(sdr);
                guna2DataGridView1.DataSource = dt;
                sdr.Close();
                cone.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            SurveillantGeneral A = new SurveillantGeneral();
            A.Show();
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
