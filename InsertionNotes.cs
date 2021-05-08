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
        public SqlConnection connection = new SqlConnection(str);
        public SqlDataReader SDR;
        public SqlDataReader SDR1;
        public DataTable DT = new DataTable();

        public InsertionNotes()
        {
            InitializeComponent();
        }

        private void InsertionNotes_Load(object sender, EventArgs e)
        {
            fill_dgv();
            fill_combobox();
        }

        public void fill_combobox()
        {
            try
            {
                connection.Open();
                string cmd = "select id_Etudiant from Etudiant";
                SqlCommand command = new SqlCommand(cmd,connection);
                SDR1 = command.ExecuteReader();
                while(SDR1.Read())
                {
                    comboBox1.Items.Add(SDR1[0]);
                }
                connection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void fill_dgv()
        {
            try
            {
                DT.Clear();
                connection.Open();
                string cmd = "select E.id_Etudiant,E.Nom_Etudiant,E.Prenom_Etudiant,N.Note_1,N.Note_2,N.Note_3,N.Note_4 from Etudiant E,Evaluation Ev,Note N where E.id_Etudiant=Ev.id_Etudiant and Ev.id_Evaluation=N.id_Evaluation";
                SqlCommand command = new SqlCommand(cmd, connection);
                SDR = command.ExecuteReader();
                DT.Load(SDR);
                dataGridView1.DataSource = DT;
                connection.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                if (textBox2.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    string cmd = "insert into Note(Note_1,Note_2,Note_3,Note_4,id_Evaluation,id_Etudiant) values(" + textBox2.Text+ "," + textBox3.Text + "," + textBox4.Text + "," + textBox5.Text + "," + textBox1.Text + "," + comboBox1.SelectedItem + ")";
                    SqlCommand command = new SqlCommand(cmd, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Ajout bien fait");
                }
                else if (textBox2.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text == "")
                {
                    string cmd = "insert into Note(Note_1,Note_2,Note_3,id_Evaluation,id_Etudiant) values(" + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + "," + textBox1.Text + "," + comboBox1.SelectedItem + ")";
                    SqlCommand command = new SqlCommand(cmd, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Ajout bien fait");
                }
                else if (textBox2.Text != "" && textBox2.Text != "" && textBox4.Text == "" && textBox5.Text == "")
                {
                    string cmd = "insert into Note(Note_1,Note_2,id_Evaluation,id_Etudiant) values(" + textBox2.Text + "," + textBox3.Text + "," + textBox1.Text + "," + comboBox1.SelectedItem + ")";
                    SqlCommand command = new SqlCommand(cmd, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Ajout bien fait");
                }
                else if (textBox2.Text != "" && textBox2.Text == "" && textBox4.Text == "" && textBox5.Text == "")
                {
                    string cmd = "insert into Note(Note_1,id_Evaluation,id_Etudiant) values(" + textBox2.Text + "," + textBox1.Text + "," + comboBox1.SelectedItem + ")";
                    SqlCommand command = new SqlCommand(cmd, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Ajout bien fait");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rechercher_Click(object sender, EventArgs e)
        {
            fill_dgv();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string cmd = "delete from Note where ";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ajout bien fait");
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
            connection.Open();
                string cmd = "update Note set Note_1=" + textBox2.Text + ",Note_2=" +textBox3.Text + ",Note_3=" + textBox4.Text + ",Note_4=" +textBox5.Text + " where id_Evaluation=(select id_Evaluation from Evaluation where id_Etudiant=" + textBox1.Text + ")";
                SqlCommand command = new SqlCommand(cmd, connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Ajout bien fait");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
