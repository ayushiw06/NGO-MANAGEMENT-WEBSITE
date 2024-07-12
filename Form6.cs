using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace dbs
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
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
            string query = "select password, username, user_id from user_ngo where username = @val1 and password = @val2 ;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@val1", textBox1.Text);
            cmd.Parameters.AddWithValue("@val2", textBox2.Text);
            cmd.Prepare();
            reader = cmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                count += 1;
            }
            if (count == 1)
            {
                Form3 form = new Form3();
                form.Show();
                con.Close();
            }
        }
    }
}