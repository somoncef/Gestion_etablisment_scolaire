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
    public partial class InsertionDateExame : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);
        public SqlDataReader sdr1;
        public SqlDataReader sdr2;
        public SqlDataReader sdr3;
        public DataTable dt = new DataTable();

        public InsertionDateExame()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                cone.Open();
                string cmd = "insert into Evaluation values (" + guna2TextBox1.Text + "," + guna2ComboBox1.SelectedItem + "," + guna2ComboBox2.SelectedItem + ",'" + guna2DateTimePicker1.Value + "')";
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
                string cmd = "delete from Evaluation where id_Evaluation=" + guna2TextBox1.Text + "";
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
                string cmd = "update Evaluation set id_Etudiant=" + guna2ComboBox1.Text + ",id_Module=" + guna2ComboBox2.Text + ",date_Evaluation='" + guna2DateTimePicker1.Value + "' where id_Evaluation = " + guna2TextBox1.Text + "";
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
                string cmd = "select*from Evaluation";
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
            Formateur F1 = new Formateur();
            F1.Show();
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
