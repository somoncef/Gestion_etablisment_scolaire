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
    public partial class ConsulterNotes : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);
        public SqlDataReader sdr;

        public ConsulterNotes()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string logiin = LogiinEtudiant.login;
                cone.Open();
                string cmd = "select M.Nom_Module,N.Note_1,N.Note_2,N.Note_3,N.Note_4,Coefficient from Evaluation EV, Module M,Note N where M.id_Module = EV.id_Module and N.id_Evaluation=EV.id_Evaluation and EV.id_Etudiant =(select id_Etudiant from Etudiant_user where logiin='" + logiin + "') group by M.Nom_Module,N.Note_1,N.Note_2,N.Note_3,N.Note_4,Coefficient";
                SqlCommand comm = new SqlCommand(cmd, cone);
                sdr = comm.ExecuteReader();
                guna2DataGridView1.Columns.Add("Nom Module", "Nom Module");
                guna2DataGridView1.Columns.Add("Note_1", "Note_1");
                guna2DataGridView1.Columns.Add("Note_2", "Note_2");
                guna2DataGridView1.Columns.Add("Note_3", "Note_3");
                guna2DataGridView1.Columns.Add("Note_4", "Note_4");
                guna2DataGridView1.Columns.Add("Coefficient", "Coefficient");
                guna2DataGridView1.Columns.Add("Moyenne Module", "Moyenne Module");
                guna2DataGridView1.Columns.Add("Note*Coefficient", "Note*Coefficient");
                while (sdr.Read())
                {
                    guna2DataGridView1.Rows.Add(sdr[0], sdr[1], sdr[2], sdr[3], sdr[4], sdr[5]);
                }
                for (int i = 0; i < guna2DataGridView1.Rows.Count - 1; i++)
                {
                    if (guna2DataGridView1.Rows[i].Cells[1].ToString() != ""
                        && guna2DataGridView1.Rows[i].Cells[2].ToString() != ""
                        && guna2DataGridView1.Rows[i].Cells[3].ToString() != ""
                        && guna2DataGridView1.Rows[i].Cells[4].ToString() != "")
                    {
                        guna2DataGridView1.Rows[i].Cells[6].Value = ((float.Parse(guna2DataGridView1.Rows[i].Cells[1].Value.ToString()) + float.Parse(guna2DataGridView1.Rows[i].Cells[2].Value.ToString()) + float.Parse(guna2DataGridView1.Rows[i].Cells[3].Value.ToString()) + float.Parse(guna2DataGridView1.Rows[i].Cells[4].Value.ToString())) / 4);

                        guna2DataGridView1.Rows[i].Cells[7].Value = (float.Parse(guna2DataGridView1.Rows[i].Cells[5].Value.ToString()) * float.Parse(guna2DataGridView1.Rows[i].Cells[6].Value.ToString()));
                    }
                    else if (guna2DataGridView1.Rows[i].Cells[1].ToString() != ""
                        && guna2DataGridView1.Rows[i].Cells[2].ToString() != ""
                        && guna2DataGridView1.Rows[i].Cells[3].ToString() != ""
                        && guna2DataGridView1.Rows[i].Cells[4].ToString() == "")
                    {
                        guna2DataGridView1.Rows[i].Cells[6].Value = (float.Parse(guna2DataGridView1.Rows[i].Cells[1].Value.ToString()) + float.Parse(guna2DataGridView1.Rows[i].Cells[2].Value.ToString()) + float.Parse(guna2DataGridView1.Rows[i].Cells[3].Value.ToString())) / 3;
                        guna2DataGridView1.Rows[i].Cells[7].Value = (float.Parse(guna2DataGridView1.Rows[i].Cells[5].Value.ToString()) * int.Parse(guna2DataGridView1.Rows[i].Cells[6].Value.ToString()));
                    }
                    else if (guna2DataGridView1.Rows[i].Cells[1].ToString() != ""
                        && guna2DataGridView1.Rows[i].Cells[2].ToString() != ""
                        && guna2DataGridView1.Rows[i].Cells[3].ToString() == ""
                        && guna2DataGridView1.Rows[i].Cells[4].ToString() == "")
                    {
                        guna2DataGridView1.Rows[i].Cells[6].Value = (float.Parse(guna2DataGridView1.Rows[i].Cells[1].Value.ToString()) + float.Parse(guna2DataGridView1.Rows[i].Cells[2].Value.ToString())) / 2;
                        guna2DataGridView1.Rows[i].Cells[7].Value = (float.Parse(guna2DataGridView1.Rows[i].Cells[5].Value.ToString()) * int.Parse(guna2DataGridView1.Rows[i].Cells[6].Value.ToString()));
                    }
                    else if (guna2DataGridView1.Rows[i].Cells[1].ToString() != ""
                        && guna2DataGridView1.Rows[i].Cells[2].ToString() == ""
                        && guna2DataGridView1.Rows[i].Cells[3].ToString() == ""
                        && guna2DataGridView1.Rows[i].Cells[4].ToString() == "")
                    {
                        guna2DataGridView1.Rows[i].Cells[6].Value = (float.Parse(guna2DataGridView1.Rows[i].Cells[1].Value.ToString()));
                        guna2DataGridView1.Rows[i].Cells[7].Value = (float.Parse(guna2DataGridView1.Rows[i].Cells[5].Value.ToString()) * int.Parse(guna2DataGridView1.Rows[i].Cells[6].Value.ToString()));
                    }
                    else
                    {
                        guna2DataGridView1.Rows[i].Cells[6].Value = 0;
                        guna2DataGridView1.Rows[i].Cells[7].Value = 0;

                    }
                }
                cone.Close();
                MessageBox.Show("bien fait");
                int Q = 0;
                float moy = 0;
                for (int i = 0; i < guna2DataGridView1.Rows.Count - 1; i++)
                {
                    moy += float.Parse(guna2DataGridView1.Rows[i].Cells[7].Value.ToString());
                    Q += int.Parse(guna2DataGridView1.Rows[i].Cells[5].Value.ToString());
                }
                guna2TextBox1.Text = "" + (moy / Q);
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
