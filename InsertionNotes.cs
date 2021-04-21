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
    public partial class InsertionNotes : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);
        public SqlDataReader sdr1;
        public SqlDataReader sdr2;
        public SqlDataAdapter SDA;
        public DataTable dt = new DataTable();
        public DataSet DS = new DataSet();

        public InsertionNotes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void fill_dgv()
        {
            try
            {
                //test1

                //cone.Open();
                //dt.Clear();
                //string cmd1 = "select Nom_Etudiant,Prenom_Etudiant from Etudiant";
                //string cmd2 = "select Note_1,Note_2,Note_3,Note_4 from Note";
                //SqlCommand comm1 = new SqlCommand(cmd1, cone);
                //SqlCommand comm2 = new SqlCommand(cmd2, cone);
                //sdr1 = comm1.ExecuteReader();
                //sdr2 = comm2.ExecuteReader();
                //dt.Load(sdr1);
                //dt.Load(sdr2);
                //dataGridView1.DataSource = dt;
                //sdr1.Close();
                //sdr2.Close();
                //cone.Close();


                //test2

                //cone.Open();
                //string cmd1 = "select E.Nom_Etudiant,E.Prenom_Etudiant,N.Note_1,N.Note_2,N.Note_3,N.Note_4 from Etudiant E,Note N ,Evaluation Ev where N.id_note=Ev.id_note and Ev.id_Etudiant=E.id_Etudiant";
                //SqlCommand comm1 = new SqlCommand(cmd1, cone);
                //sdr1 = comm1.ExecuteReader();

                //dataGridView1.Columns.Add("Nom_Etudiant", "Nom_Etudiant");
                //dataGridView1.Columns.Add("Prenom_Etudiant", "Prenom_Etudiant");
                //dataGridView1.Columns.Add("Note_1", "Note_1");
                //dataGridView1.Columns.Add("Note_2", "Note_2");
                //dataGridView1.Columns.Add("Note_3", "Note_3");
                //dataGridView1.Columns.Add("Note_4", "Note_4");

                //while (sdr1.Read())
                //{
                //    dataGridView1.Rows.Add(sdr1[0], sdr1[1], sdr1[2], sdr1[3], sdr1[4], sdr1[5]);
                //}
                //sdr1.Close();
                //sdr2 = comm1.ExecuteReader();
                //for(int i =0;i<dataGridView1.Rows.Count-1;i++)
                //{
                //    while(sdr2.Read())
                //    { 
                //    dataGridView1.Rows[i].Cells[2].Value=sdr2[0];
                //    dataGridView1.Rows[1].Cells[3].Value=sdr2[1];
                //    dataGridView1.Rows[1].Cells[4].Value=sdr2[2];
                //    dataGridView1.Rows[1].Cells[5].Value=sdr2[3];
                //    }
                //}
                //sdr2.Close();
                cone.Open();
                string cmd1 = "select id_Etudiant,Nom_Etudiant,Prenom_Etudiant from Etudiant";
                string cmd2 = "select Note_1,Note_2,Note_3,Note_4 from Note";
                SDA = new SqlDataAdapter(cmd1,cone);
                SDA.Fill(DS,"T1");
                SDA = new SqlDataAdapter(cmd2, cone);
                SDA.Fill(DS, "T2");
                dataGridView2.DataSource = DS.Tables["T1"];
                dataGridView1.DataSource = DS.Tables["T2"];
                //dataGridView1.DataSource = DS.Tables["T1"]+DS.Tables["T2"];
                cone.Close();
                MessageBox.Show("bien fait");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formateur F1 = new Formateur();
            F1.Show();
        }

        private void InsertionNotes_Load(object sender, EventArgs e)
        {
            fill_dgv();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void rechercher_Click(object sender, EventArgs e)
        {

        }
    }
}
