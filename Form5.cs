using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbs
{
    public partial class Form5 : Form
    {
        public Form5()
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
            MySqlDataReader reader;
            con.Open();
            string query = "select * from ngo where state = @val1 and sector = @val2 and type = @val3 order by id;";
            
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@val1", comboBox1.Text);
            cmd.Parameters.AddWithValue("@val2", comboBox2.Text);
            cmd.Parameters.AddWithValue("@val3", comboBox3.Text);

            /*if (comboBox1.Text == "<EMPTY>")
            {
                query = "select * from ngo where sector = @val2 order by id;";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@val2", comboBox2.Text);
            }
            else if (comboBox2.Text == "<EMPTY>")
            {
                query = "select * from ngo where state = @val1 order by id;";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@val1", comboBox1.Text);
            }*/

            if (comboBox3.Text == "<EMPTY>" && comboBox1.Text != "<EMPTY>" && comboBox2.Text != "<EMPTY>")
            {
                query = "select * from ngo where state = @val1 and sector = @val2 order by id;";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@val1", comboBox1.Text);
                cmd.Parameters.AddWithValue("@val2", comboBox2.Text);
            }
            else if (comboBox3.Text == "<EMPTY>" && comboBox1.Text == "<EMPTY>" && comboBox2.Text != "<EMPTY>")
            {
                query = "select * from ngo where sector = @val2 order by id;";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.Clear();
     
                cmd.Parameters.AddWithValue("@val2", comboBox2.Text);
            }
            else if (comboBox3.Text == "<EMPTY>" && comboBox1.Text != "<EMPTY>" && comboBox2.Text == "<EMPTY>")
            {
                query = "select * from ngo where state = @val1 order by id;";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@val1", comboBox1.Text);
            }
            else if (comboBox3.Text != "<EMPTY>" && comboBox1.Text != "<EMPTY>" && comboBox2.Text == "<EMPTY>")
            {
                query = "select * from ngo where type = @val3 and state = @val1 order by id;";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.Clear();
               
                cmd.Parameters.AddWithValue("@val1", comboBox1.Text);
                cmd.Parameters.AddWithValue("@val3", comboBox3.Text);
            }
            else if (comboBox3.Text != "<EMPTY>" && comboBox1.Text == "<EMPTY>" && comboBox2.Text == "<EMPTY>")
            {
                query = "select * from ngo where type = @val3 order by id;";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@val3", comboBox3.Text);
               
            }

            else if (comboBox3.Text != "<EMPTY>" && comboBox1.Text == "<EMPTY>" && comboBox2.Text != "<EMPTY>")
            {
                query = "select * from ngo where sector = @val2 and type = @val3 order by id;";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@val2", comboBox2.Text);
                cmd.Parameters.AddWithValue("@val3", comboBox3.Text);
            }




            reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();   
            form.ShowDialog();
          
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           Login frm = new Login();
            frm.Show();       
        }
    }
}
