using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dbs
{
    public partial class Login : Form
    {
       public Login instance;
       public System.Windows.Forms.TextBox tb4;
        public Login()
        {
           
            InitializeComponent();
            instance = this;
            tb4 = textBox4;
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
            string query = "INSERT INTO Volunteer (NAME, age, user_id, ngo_id)  VALUES (@val1,@val2, @val3, @val4);";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@val1", textBox4.Text);
            cmd.Parameters.AddWithValue("@val2", textBox5.Text);
            cmd.Parameters.AddWithValue("@val3", textBox2.Text);
            cmd.Parameters.AddWithValue("@val4", textBox1.Text);
            reader = cmd.ExecuteReader();
            
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            string query = "Select * from Volunteer;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Form1 form = new Form1();
            form.Show();
        }
    }
}
