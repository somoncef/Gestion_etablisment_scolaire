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
    public partial class AjouterGroups : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);
        public SqlDataReader sdr1;
        public SqlDataReader sdr2;
        public SqlDataReader sdr3;
        public DataTable dt = new DataTable();

        public AjouterGroups()
        {
            InitializeComponent();
        }

        public void fill_combobox_Filier()
        {
            try
            {
                cone.Open();
                string cmd = "select id_Filiere from Filiere";
                SqlCommand comm = new SqlCommand(cmd, cone);
                sdr1 = comm.ExecuteReader();
                while (sdr1.Read())
                {
                    guna2ComboBox1.Items.Add(sdr1[0]);
                }
                sdr1.Close();
                cone.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void fill_combobox_Etudiant()
        {
            try
            {
                cone.Open();
                string cmd = "select id_Etudiant from Etudiant";
                SqlCommand comm = new SqlCommand(cmd, cone);
                sdr2 = comm.ExecuteReader();
                while (sdr2.Read())
                {
                    guna2ComboBox2.Items.Add(sdr2[0]);
                }
                sdr2.Close();
                cone.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                cone.Open();
                string cmd = "insert into Groupe values (" + guna2TextBox1.Text + ",'" + guna2TextBox2.Text + "'," + guna2ComboBox2.SelectedItem + "," + guna2ComboBox1.SelectedItem + ")";
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
                string cmd = "delete from Groupe where id_Groupe=" + guna2TextBox1.Text + "";
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
                string cmd = "update Groupe set Nom_Groupe='" + guna2TextBox2.Text + "',id_Etudiant=" + guna2ComboBox1.Text + ",id_Filiere=" + guna2ComboBox2.Text + " where id_Groupe = " + guna2TextBox1.Text + "";
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
                string cmd = "select*from Groupe";
                SqlCommand comm = new SqlCommand(cmd, cone);
                sdr3 = comm.ExecuteReader();
                dt.Load(sdr3);
                guna2DataGridView1.DataSource = dt;
                sdr3.Close();
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

        private void AjouterGroups2_Load(object sender, EventArgs e)
        {
            fill_combobox_Etudiant();
            fill_combobox_Filier();
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
