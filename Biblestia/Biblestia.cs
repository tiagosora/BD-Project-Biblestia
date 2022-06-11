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
                Biblioteca B = new Biblioteca();
                B.Nome = reader["nome"].ToString();
                B.Morada = reader["morada"].ToString();
                B.Email = reader["email"].ToString();
                B.Telefone = reader["telefone"].ToString();
                selecao.Items.Add(B);
            }
            cn.Close();
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
            // Por agr fica so com esta biblioteca se tiversmo tempo fazemos para adicionar
            if (password.Equals("123"))
            {
                Debug.Print("Entrei");
                this.Visible = false;
                Biblioteca b = (Biblioteca)selecao.SelectedItem;
                // Main mainWindow = new Main(b.Nome);
                // Por agora
                Main mainWindow = new Main("Biblioteca Universitária de Aveiro");
                mainWindow.Show();
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
