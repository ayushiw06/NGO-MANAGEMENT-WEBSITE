using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dbs
{
    public partial class Form1 : Form
    {
        public Form1()
        {   
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = "localhost";
            string uid = "root";
            string password = "";
            string database = "ngo_manager";
            string constring = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
            MySqlConnection con = new MySqlConnection(constring);
            MySqlDataReader reader;
            con.Open();
            string query = "INSERT INTO donor (NAME,user_id, ngo_id,amount)  VALUES (@val1,@val2, @val3, @val4);";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@val1", textBox1.Text);
            cmd.Parameters.AddWithValue("@val2", textBox2.Text);
            cmd.Parameters.AddWithValue("@val3", textBox3.Text);
            cmd.Parameters.AddWithValue("@val4", textBox4.Text);
            reader = cmd.ExecuteReader();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string server = "localhost";
            string uid = "root";
            string password = "";
            string database = "ngo_manager";
            string constring = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
            MySqlConnection con = new MySqlConnection(constring);
            MySqlDataReader reader;
            con.Open();
            string query = "Select donor.name,ngo.ngo_name, donor.amount from donor, ngo where donor.ngo_id = ngo.id;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }
    }
}
