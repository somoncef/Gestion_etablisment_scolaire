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
using System.IO;
using System.Diagnostics;

namespace Gestion_etablisment_scolaire
{
    public partial class ConsulterEmploi : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);

        public ConsulterEmploi()
        {
            InitializeComponent();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            int pos = name.IndexOf("\\");
            if (pos >= 0)
            {
                string UserName = name.Remove(0, pos + 1);
                try
                {
                    cone.Open();
                    List<int> lst = new List<int>();
                    string cmdd = "select id_Groupe from Groupe where Nom_Groupe='" + guna2TextBox1.Text + "'";
                    SqlCommand command1 = new SqlCommand(cmdd, cone);
                    SqlDataReader SDR = command1.ExecuteReader();
                    while (SDR.Read())
                    {
                        lst.Add(Convert.ToInt32(SDR[0].ToString()));
                    }
                    SDR.Close();
                    if (lst[0].ToString() != "")
                    {
                        string cmd = "select filee from Emploi where id_Groupe=" + lst[0].ToString() + "";
                        SqlCommand command = new SqlCommand(cmd, cone);
                        SqlDataReader SDR1 = command.ExecuteReader();
                        if (SDR1.Read())
                        {
                            byte[] fileData = (byte[])SDR1[0];
                            File.WriteAllBytes(@"C:\Users\" + UserName + "\\Desktop\\Emploi.pdf", fileData);
                        }
                    }
                    cone.Close();
                    MessageBox.Show("bien Fait!!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
            string name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            int pos = name.IndexOf("\\");
            if (pos >= 0)
            {
                string UserName = name.Remove(0, pos + 1);
                string file = @"C:\Users\" + UserName + "\\Desktop\\Emploi.pdf";
                Process.Start(file);
            }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Etudiant ET = new Etudiant();
            ET.Show();
        }
    }
}
