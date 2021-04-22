using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Gestion_etablisment_scolaire
{
    public partial class AjouterDateVacanses : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);
        public SqlDataReader SDR;
        public DataTable dt = new DataTable();
        public string file_namee;
        public string filee;
        public OpenFileDialog OpenFile = new OpenFileDialog();
        public AjouterDateVacanses()
        {
            InitializeComponent();
        }
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                file_namee = guna2TextBox1.Text = OpenFile.FileName;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                cone.Open();
                string cmd = "insert into Vacanses(file_namee,filee) values(@file_namee,@filee)";
                SqlCommand command = new SqlCommand(cmd, cone);
                command.Parameters.AddWithValue("file_namee", file_namee);
                command.Parameters.AddWithValue("filee", SqlDbType.VarBinary).Value = File.ReadAllBytes(guna2TextBox1.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Ajout bien fait");
                cone.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SurveillantGeneral su = new SurveillantGeneral();
            su.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
