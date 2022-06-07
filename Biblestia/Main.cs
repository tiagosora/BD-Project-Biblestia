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
    public partial class Main : Form
    {
        private SqlConnection cn;
        private Biblioteca Biblioteca;
        public Main(String BibliotecaName)
        {
            if (!verifySGBDConnection())
            {
                // Debug.Print("Connection not stablished!");
                return;
            }
            SqlCommand cmd = new SqlCommand("select * from Biblestia.Biblioteca", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            Biblioteca = new Biblioteca();
            while (reader.Read())
            {
                if (reader["nome"].ToString().Equals(BibliotecaName))
                Biblioteca.Nome = BibliotecaName;
                Biblioteca.Morada = reader["morada"].ToString();
                Biblioteca.Email = reader["email"].ToString();
                Biblioteca.Telefone = (int)reader["telefone"];
            }
            cn.Close();
            Debug.Print(Biblioteca.ToString());
            InitializeComponent();
        }
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

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
    }
}
