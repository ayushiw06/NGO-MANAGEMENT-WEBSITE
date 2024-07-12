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
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
// Establish connection


namespace dbs
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string server = "localhost";
            string uid = "root";
            string password = "";
            string database = "ngo_manager";
            string constring = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
            MySqlConnection con = new MySqlConnection(constring);
            
            con.Open();


            string query = "SELECT * FROM NGO where lower(ngo_name) = lower(@val1) ORDER BY Sector;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@val1", textBox1.Text);

            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close(); // Close the reader after loading data

            // Assuming only one row is returned
            if (dt.Rows.Count > 0)
            {
                label7.Text = textBox1.Text;

                textBox2.Text = dt.Rows[0]["id"].ToString();
                textBox6.Text = dt.Rows[0]["type"].ToString();
                textBox3.Text = dt.Rows[0]["state"].ToString();
                textBox4.Text = dt.Rows[0]["sector"].ToString();
                textBox5.Text = dt.Rows[0]["address"].ToString();
            }

            // Now, let's fetch the heads
            string query6 = "SELECT heads.head_name, position.position_name FROM heads JOIN position ON position.position_id = heads.position_id JOIN NGO ON ngo.id = heads.ngo_id WHERE ngo.ngo_name = @val1 ;";
            MySqlCommand cmd6 = new MySqlCommand(query6, con);
            cmd6.Parameters.AddWithValue("@val1", textBox1.Text);

            reader = cmd6.ExecuteReader();
            DataTable dt6 = new DataTable();
            dt6.Load(reader);
            

            dataGridView1.DataSource = dt6;
            reader.Close(); // Close the reader after loading data





        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }

       


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

