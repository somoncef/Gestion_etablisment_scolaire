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
    public partial class ConsulterDateVacanses : Form
    {
        public static string str = ServerName.conn;
        public SqlConnection cone = new SqlConnection(str);

        public ConsulterDateVacanses()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            int pos = name.IndexOf("\\");
            if (pos >= 0)
            {
                string UserName = name.Remove(0, pos + 1);
                try
                {
                    cone.Open();
                    string cmd = "select filee from Vacanses";
                    SqlCommand command = new SqlCommand(cmd, cone);
                    SqlDataReader SDR1 = command.ExecuteReader();
                    if (SDR1.Read())
                    {
                        byte[] fileData = (byte[])SDR1[0];
                        File.WriteAllBytes(@"C:\Users\" + UserName + "\\Desktop\\DateVacances.pdf", fileData);
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            int pos = name.IndexOf("\\");
            if (pos >= 0)
            {
                string UserName = name.Remove(0, pos + 1);
                string file = @"C:\Users\" + UserName + "\\Desktop\\DateVacances.pdf";
                Process.Start(file);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
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
