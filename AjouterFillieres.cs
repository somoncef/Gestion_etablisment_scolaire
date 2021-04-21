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
    public partial class AjouterFillieres : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);
        public SqlDataReader sdr;
        public DataTable dt = new DataTable();

        public AjouterFillieres()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                cone.Open();
                string cmd = "insert into Filiere values (" + guna2TextBox1.Text + ",'" + guna2TextBox2.Text + "')";
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
                string cmd = "delete from Filiere where id_Filiere=" + guna2TextBox1.Text + "";
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
                string cmd = "update Filiere set Nom_Filiere='" + guna2TextBox2.Text + "' where id_Filiere= " + guna2TextBox1.Text + "";
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
                string cmd = "select*from Filiere";
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
            SurveillantGeneral su = new SurveillantGeneral();
            su.Show();
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
