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
    public partial class InsertionAbscence : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);
        public SqlDataReader sdr;
        public SqlDataReader sdr1;
        public DataTable dt = new DataTable();

        public InsertionAbscence()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> lst = new List<int>();
                cone.Open();
                string logiin = LogiinFormateur.username;
                string idmod = " select M.id_Module from Module M,Formateur_user FU where M.id_Formateur=FU.id_Formateur and logiin='" + logiin + "'";
                SqlCommand comma = new SqlCommand(idmod, cone);
                sdr1 = comma.ExecuteReader();
                while (sdr1.Read())
                {
                    lst.Add(Convert.ToInt32(sdr1[0].ToString()));
                }
                if (lst[0].ToString() != "")
                {
                    string cmd = "insert into Abscence values (" + guna2TextBox1.Text + "," + guna2TextBox2.Text + "," + lst[0] + ",'" + guna2DateTimePicker1.Value + "')";
                    SqlCommand comm = new SqlCommand(cmd, cone);
                    comm.ExecuteNonQuery();
                }
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
                string cmd = "delete from Abscence where id_Abscence= " + guna2TextBox1.Text + "";
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
                string cmd = "update  Abscence set id_Etudiant= " + guna2TextBox2.Text + ", Date_Abscence='" + guna2DateTimePicker1.Value + "' where id_Abscence= " + guna2TextBox1.Text + "";
                SqlCommand comm = new SqlCommand(cmd, cone);
                comm.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Modification bien fait");
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
                string cmd = "select id_Abscence ,id_Etudiant ,Date_Abscence from Abscence";
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
            Formateur F1 = new Formateur();
            F1.Show();
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
