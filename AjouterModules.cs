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
    public partial class AjouterModules : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);
        public SqlDataReader sdr;
        public DataTable dt = new DataTable();

        public AjouterModules()
        {
            InitializeComponent();
        }

        private void AjouterModules2_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                cone.Open();
                string cmd = "insert into Etudiant values (" + guna2TextBox1.Text + ",'" + guna2TextBox2.Text + "'," + guna2TextBox3.Text + "," + guna2TextBox4.Text + "," + guna2TextBox5.Text + ")";
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
                string cmd = "delete from Module where id_Module=" + guna2TextBox1.Text + "";
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
                cone.Open();
                string cmd = "update Etudiant set Nom_Module=" + guna2TextBox2.Text + ",Masse_Horaire=" + guna2TextBox3.Text + ",Coefficient=" + guna2TextBox4.Text + ",id_Formateur=" + guna2TextBox5.Text + " where id_Module= " + guna2TextBox1.Text + "";
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                cone.Open();
                dt.Clear();
                string cmd = "select*from Module";
                SqlCommand comm = new SqlCommand(cmd, cone);
                sdr = comm.ExecuteReader();
                dt.Load(sdr);
                guna2DataGridView1.DataSource = dt;
                sdr.Close();
                cone.Close();

                MessageBox.Show("bien fait");
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

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
