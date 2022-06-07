using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblestia
{
    public partial class Biblestia : Form
    {
        private SqlConnection cn;
        private String password = "";
        public Biblestia()
        {
            InitializeComponent();
            updateList();
        }

        private void updateList()
        {
            if (!verifySGBDConnection())
            {
                // Debug.WriteLine("Connection not stablished!");
                return;
            }
            SqlCommand cmd = new SqlCommand("select * from Biblestia.Biblioteca", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            selecao.Items.Clear();

            while (reader.Read())
            {
                selecao.Items.Add(reader["nome"].ToString());
            }
            cn.Close();
        }

        private SqlConnection getSGBDConnection()
        {
            // Debug.WriteLine("Tentar conectar");
            return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p6g7; uid = p6g7; password = Albertos3csu4l;");

        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void Biblestia_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            password = pass.Text.ToString();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (password.Equals("123"))
            {
                Debug.Print("Entrei");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void addbiblioteca_Click(object sender, EventArgs e)
        {

        }
    }
}
