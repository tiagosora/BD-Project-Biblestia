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
            reader.Close();
            cn.Close();
            Debug.Print(biblioteca.ToString());
            InitializeComponent();
            textBox6.Text = biblioteca.ToString();
            updateListFuncionarios();
        }
        private void groupsVisibleFalse()
        {
            groupBox1.Visible = false;
            groupBox3.Visible = false;
        }
        private void updateListFuncionarios()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            groupBox1.Visible = true;
            listBox1.Enabled = true;
            button8.Visible = true;
            button7.Visible = true;
            button9.Visible = true;
            listType = "Funcionario";
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterFuncionários('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();
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
            reader.Close();
            cn.Close();
            listBox1.SelectedIndex = 0;
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
            button8.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            fnif.ReadOnly = false;
            fssn.ReadOnly = false;
            fnome.ReadOnly = false;
            femail.ReadOnly = false;
            fmorada.ReadOnly = false;
            ftelefone.ReadOnly = false;
            dateTimePicker1.Enabled = true;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            groupBox2.Visible = false;
            panel1.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            listBox1.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            switch (listType)
            {
                case "Funcionario":
                    currentListIndex = listBox1.SelectedIndex;
                    showFuncionario();
                    getCargosDoFuncionario();
                    break;
                default:
                    break;
            }
        }

        public void showFuncionario()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
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
        }

        private void getCargosDoFuncionario()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            Funcionario funcionario = (Funcionario)listBox1.Items[currentListIndex];
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterCargosFuncionario(" + funcionario.IdFuncionario + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            cargoBox.Items.Clear();
            while (reader.Read())
            {
                Cargo cargo = new Cargo();
                cargo.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                cargo.IdFuncionario = reader["idFuncionario"].ToString();
                cargo.NomeCargo = reader["nomeCargo"].ToString();
                cargo.DataInicio = reader["dataInicio"].ToString();
                cargo.DataFim = reader["dataFim"].ToString();
                cargoBox.Items.Add(cargo);
                
            }
            cargoBox.SelectedIndex = 0;
            for (int i = 0; i < cargoBox.Items.Count; i++)
            {
                Cargo c = (Cargo)cargoBox.Items[i];
                if (c.DataFim == "")
                {
                    cargoBox.SelectedIndex = i;
                }
            }
            reader.Close();
            cn.Close();
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

        private void cargoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargo cargo = (Cargo)cargoBox.Items[cargoBox.SelectedIndex];
            dateTimePicker2.Text = cargo.DataInicio;
            if (cargo.DataFim == "")
            {
                label10.Enabled = false;
                dateTimePicker3.Format = DateTimePickerFormat.Custom;
                dateTimePicker3.CustomFormat = " ";
            }
            else
            {
                label10.Enabled = true;
                dateTimePicker3.Format = DateTimePickerFormat.Short;
                dateTimePicker3.Text = cargo.DataFim;
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void fid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            Funcionario funcionario = new Funcionario();
            funcionario.Nif = fnif.Text;
            funcionario.NomeCompleto = fnome.Text;
            funcionario.IdFuncionario = fid.Text;
            funcionario.NomeBiblioteca = biblioteca.Nome;
            funcionario.Ssn = fssn.Text;
            funcionario.Email = femail.Text;
            funcionario.Morada = fmorada.Text;
            funcionario.Telefone = ftelefone.Text;
            funcionario.DataNascimento = dateTimePicker1.Text;
            if (checkBox1.Checked)
            {
                funcionario.DataNascimento = "";
            }
            SqlCommand cmd = new SqlCommand("Biblestia.editarFuncionario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nif", funcionario.Nif));
            cmd.Parameters.Add(new SqlParameter("@nomeCompleto", funcionario.NomeCompleto));
            cmd.Parameters.Add(new SqlParameter("@idFuncionario", funcionario.IdFuncionario));
            cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", biblioteca.Nome));
            cmd.Parameters.Add(new SqlParameter("@ssn", funcionario.Ssn));
            cmd.Parameters.Add(new SqlParameter("@email", funcionario.Email));
            cmd.Parameters.Add(new SqlParameter("@morada", funcionario.Morada));
            cmd.Parameters.Add(new SqlParameter("@telefone", funcionario.Telefone));
            if (!checkBox1.Checked)
            {
                cmd.Parameters.Add(new SqlParameter("@dataNascimento", dateTimePicker1.Value.ToString("yyyy-MM-dd")));
            }
            cmd.ExecuteNonQuery();
            listBox1.SelectedItem = funcionario;
            saidaEdicao();
        }
        private void saidaEdicao()
        {
            button8.Enabled = true;
            button7.Enabled = true;
            button9.Enabled = true;
            fnif.ReadOnly = true;
            fssn.ReadOnly = true;
            fnome.ReadOnly = true;
            femail.ReadOnly = true;
            fmorada.ReadOnly = true;
            ftelefone.ReadOnly = true;
            dateTimePicker1.Enabled = false;
            groupBox2.Visible = true;
            panel1.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            listBox1.Enabled = true;
            int saveIndex = currentListIndex;
            updateListFuncionarios();
            listBox1.SelectedIndex = saveIndex;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            saidaEdicao();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Enabled = false;
            } else
            {
                dateTimePicker1.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            updateListFuncionarios();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            groupBox3.Visible = true;
            button8.Visible = false;
            button7.Visible = false;
            button9.Visible = false;
            listBox1.Enabled = false;
            Funcionario funcionario = (Funcionario)listBox1.SelectedItem;
            textBox2.Text = funcionario.IdFuncionario;
            textBox1.Text = funcionario.NomeCompleto;
            updateCargoList();
        }
        private void updateCargoList()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            Funcionario funcionario = (Funcionario)listBox1.Items[currentListIndex];
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterCargosFuncionario(" + funcionario.IdFuncionario + ",'" + biblioteca.Nome + "') order by dataInicio", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox2.Items.Clear();
            while (reader.Read())
            {
                Cargo cargo = new Cargo();
                cargo.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                cargo.IdFuncionario = reader["idFuncionario"].ToString();
                cargo.NomeCargo = reader["nomeCargo"].ToString();
                cargo.DataInicio = reader["dataInicio"].ToString();
                cargo.DataFim = reader["dataFim"].ToString();
                listBox2.Items.Add(cargo);
            }
            reader.Close();
            cn.Close();
            if (listBox2.Items.Count > 0) {
                listBox2.SelectedIndex = listBox2.Items.Count - 1;
            }
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            listBox2.Enabled = false;
            label15.Enabled = true;
            button13.Enabled = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = true;
            button18.Visible = true;
            dateTimePicker4.Enabled = true;
            dateTimePicker5.Format = DateTimePickerFormat.Short;
            dateTimePicker5.Enabled = true;
            textBox3.ReadOnly = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargo cargo = (Cargo)listBox2.SelectedItem;
            textBox3.Text = cargo.NomeCargo;
            dateTimePicker4.Text = cargo.DataInicio;
            if (cargo.DataFim == "")
            {
                label15.Enabled = false;
                dateTimePicker5.Format = DateTimePickerFormat.Custom;
                dateTimePicker5.CustomFormat = " ";
            }
            else
            {
                label15.Enabled = true;
                dateTimePicker5.Format = DateTimePickerFormat.Short;
                dateTimePicker5.Text = cargo.DataFim;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Cargo cargo = new Cargo();
            cargo.NomeBiblioteca = biblioteca.Nome;
            cargo.IdFuncionario = textBox2.Text;
            cargo.NomeCargo = textBox3.Text;
            cargo.DataInicio = dateTimePicker4.Text;
            cargo.DataFim = dateTimePicker5.Text;

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                // ESTOU A FAZER AQUI
            }
        }
    }
}
