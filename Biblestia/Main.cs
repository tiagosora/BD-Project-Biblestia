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
        private Biblioteca biblioteca;
        private String listType;
        private int currentListIndex;

        public Main()
        {
            InitializeComponent();
        }
        public Main(String BibliotecaName)
        {
            if (!verifySGBDConnection())
            {
                // Debug.Print("Connection not stablished!");
                return;
            }
            SqlCommand cmd = new SqlCommand("select * from Biblestia.Biblioteca", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            biblioteca = new Biblioteca();
            while (reader.Read())
            {
                if (reader["nome"].ToString().Equals(BibliotecaName))
                biblioteca.Nome = BibliotecaName;
                biblioteca.Morada = reader["morada"].ToString();
                biblioteca.Email = reader["email"].ToString();
                biblioteca.Telefone = reader["telefone"].ToString();
            }
            cn.Close();
            Debug.Print(biblioteca.ToString());
            InitializeComponent();
            textBox6.Text = biblioteca.ToString();
            updateListFuncionarios();
        }

        private void updateListFuncionarios()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            groupBox1.Visible = true;
            listType = "Funcionario";
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterFuncionários('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Nif = reader["nif"].ToString();
                funcionario.NomeCompleto = reader["nomeCompleto"].ToString();
                funcionario.IdFuncionario = reader["idFuncionario"].ToString();
                funcionario.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                funcionario.Ssn = reader["ssn"].ToString();
                funcionario.Email = reader["email"].ToString();
                funcionario.Morada = reader["morada"].ToString();
                funcionario.Telefone = reader["telefone"].ToString();
                funcionario.DataNascimento = reader["dataNascimento"].ToString();
                listBox1.Items.Add(funcionario);
            }
            listBox1.SelectedIndex = 0;
            cn.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listType)
            {
                case "Funcionario":
                    currentListIndex = listBox1.SelectedIndex;
                    showFuncionario();
                    break;
                default:
                    break;
            }
        }

        public void showFuncionario()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;
            Funcionario funcionario = new Funcionario();
            funcionario = (Funcionario)listBox1.Items[currentListIndex];
            fid.Text = funcionario.IdFuncionario;
            fnif.Text = funcionario.Nif;
            fssn.Text = funcionario.Ssn;
            fnome.Text = funcionario.NomeCompleto;
            femail.Text = funcionario.Email;
            fmorada.Text = funcionario.Morada;
            ftelefone.Text = funcionario.Telefone;
            if (funcionario.DataNascimento == "") {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = " ";
            } else
            {
                dateTimePicker1.Format = DateTimePickerFormat.Short;
                dateTimePicker1.Text = funcionario.DataNascimento;
            }
            
            Debug.Print(funcionario.DataNascimento);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
