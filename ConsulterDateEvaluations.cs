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
    public partial class ConsulterDateEvaluations : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);
        public SqlDataReader sdr;
        public DataTable dt = new DataTable();

        public ConsulterDateEvaluations()
        {
            InitializeComponent();
        }

        private void ConsulterDateEvaluations2_Load(object sender, EventArgs e)
        {
            try
            {
                cone.Open();
                dt.Clear();
                string cmd = "select M.Nom_Module,E.date_Evaluation from Evaluation E,Module M where E.id_Module=M.id_Module group by M.Nom_Module ,E.date_Evaluation";
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Etudiant ET = new Etudiant();
            ET.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
