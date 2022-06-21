using System;
using System.Collections;
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
        private int listBox2currentIndex;
        private String currentAction = "null";
        private Requisicao currentRequisicao;

        public Main()
        {
            InitializeComponent();
        }
        public Main(String BibliotecaName)
        {
            if (!verifySGBDConnection())
            {
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
            InitializeComponent();
            textBox6.Text = biblioteca.ToString();
            updateListFuncionarios();
        }
        private void groupsVisibleFalse()
        {
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
        }

        private void panelsVisibleFalse()
        {
            panel2.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
        }
        private void updateListFuncionarios()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            groupsVisibleFalse();
            panelsVisibleFalse();
            panel2.Visible = true;
            groupBox1.Visible = true;
            listBox1.Visible = true;
            listBox1.Enabled = true;
            listBox1.Items.Clear();
            button8.Visible = true;
            button7.Visible = true;
            button9.Visible = true;
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
            reader.Close();
            cn.Close();
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd2 = new SqlCommand("select * from Biblestia.obterFuncionariosAtuais('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            reader2.Read();
            String nFuncionariosAtuais = reader2["FuncionariosAtuais"].ToString();
            double percentagemAtuais = int.Parse(nFuncionariosAtuais);
            double total = listBox1.Items.Count;
            double output = percentagemAtuais / total * 100;
            textBox8.Text = listBox1.Items.Count.ToString();
            textBox9.Text = nFuncionariosAtuais;
            textBox10.Text = String.Format("{0:0.##}", output);
            reader2.Close();
            cn.Close();
        }

        private void updateListLeitores()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            groupsVisibleFalse();
            groupBox4.Visible = true;
            panelsVisibleFalse();
            panel4.Visible = true;
            listBox1.Visible = true;
            listBox1.Enabled = true;
            button20.Visible = true;
            button23.Visible = true;
            button19.Visible = true;

            listType = "Leitor";
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterLeitores('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                Leitor leitor = new Leitor();
                leitor.Nif = reader["nif"].ToString();
                leitor.NomeCompleto = reader["nomeCompleto"].ToString();
                leitor.IdLeitor = reader["idLeitor"].ToString();
                leitor.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                leitor.Email = reader["email"].ToString();
                leitor.Morada = reader["morada"].ToString();
                leitor.Telefone = reader["telefone"].ToString();
                leitor.DataNascimento = reader["dataNascimento"].ToString();
                listBox1.Items.Add(leitor);
            }
            reader.Close();
            cn.Close();
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
            if (!verifySGBDConnection())
            {
                return;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }
        private SqlConnection getSGBDConnection()
        {
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
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            panel2.Enabled = false;
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

            currentAction = "updatingFuncionario";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                switch (listType)
                {
                    case "Funcionario":
                        currentListIndex = listBox1.SelectedIndex;
                        showFuncionario();
                        getCargosDoFuncionario();
                        break;
                    case "Leitor":
                        currentListIndex = listBox1.SelectedIndex;
                        showLeitor();
                        break;
                    default:
                        break;
                }
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
            cn.Close();
        }
       public void showLeitor()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;
            Leitor leitor = new Leitor();
            leitor = (Leitor)listBox1.Items[currentListIndex];
            textBox13.Text = leitor.IdLeitor;
            textBox12.Text = leitor.Nif;
            textBox14.Text = leitor.NomeCompleto;
            textBox7.Text = leitor.Email;
            textBox5.Text = leitor.Morada;
            textBox4.Text = leitor.Telefone;
            dateTimePicker6.Text = leitor.DataNascimento;
            if (leitor.DataNascimento == "")
            {
                dateTimePicker6.Format = DateTimePickerFormat.Custom;
                dateTimePicker6.CustomFormat = " ";
            }
            else
            {
                dateTimePicker6.Format = DateTimePickerFormat.Short;
                dateTimePicker6.Text = leitor.DataNascimento;
            }
            cn.Close();
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
            cargoBox.SelectedIndex = cargoBox.Items.Count -1;
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
            if (cargoBox.Items.Count > 0 && cargoBox.SelectedIndex > -1)
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

        private void lid_TextChanged(object sender, EventArgs e)
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
            if (currentAction == "updatingFuncionario")
            {
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
            } else if (currentAction == "addingFuncionario")
            {
                SqlCommand cmd = new SqlCommand("Biblestia.adicionarFuncionario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nif", funcionario.Nif));
                cmd.Parameters.Add(new SqlParameter("@nomeCompleto", funcionario.NomeCompleto));
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
            }
            cn.Close();
            listBox1.SelectedItem = funcionario;
            saidaEdicao();
        }
        private void saidaEdicao()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            panel2.Enabled = true;
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
            if (currentAction == "updatingFuncionario")
            {
                listBox1.SelectedIndex = saveIndex;

            }
            else if (currentAction == "addingFuncionario")
            {
                listBox1.SelectedIndex = 0;
            }
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
            if (listBox2.Items.Count > 0)
            {
                listBox2.SelectedIndex = listBox2.Items.Count - 1;
            }
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
            
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            listBox2currentIndex = listBox2.SelectedIndex;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button13.Enabled = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = true;
            button18.Visible = true;
            listBox2.Enabled = false;
            label15.Enabled = true;
            dateTimePicker4.Enabled = true;
            dateTimePicker5.Format = DateTimePickerFormat.Short;
            dateTimePicker5.Enabled = true;
            checkBox2.Visible = true;
            currentAction = "UpdatingCargo";
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0 && listBox2.SelectedIndex > -1)
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
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            Cargo cargo = new Cargo();
            cargo.NomeBiblioteca = biblioteca.Nome;
            cargo.IdFuncionario = textBox2.Text;
            cargo.NomeCargo = textBox3.Text;
            cargo.DataInicio = dateTimePicker4.Text;
            cargo.DataFim = dateTimePicker5.Text;
            if (checkBox2.Checked)
            {
                cargo.DataFim = "";
            }
            if (currentAction == "UpdatingCargo")
            {
                SqlCommand cmd = new SqlCommand("Biblestia.editarCargo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", cargo.NomeBiblioteca));
                cmd.Parameters.Add(new SqlParameter("@idFuncionario", cargo.IdFuncionario));
                cmd.Parameters.Add(new SqlParameter("@nomeCargo", cargo.NomeCargo));
                cmd.Parameters.Add(new SqlParameter("@dataInicio", cargo.DataInicio));
                if (!checkBox2.Checked)
                {
                    cmd.Parameters.Add(new SqlParameter("@dataFim", dateTimePicker5.Value.ToString("yyyy-MM-dd")));
                }
                cmd.ExecuteNonQuery();
                cn.Close();
                listBox2.SelectedItem = cargo;
            } else if (currentAction == "AddingCargo")
            {
                SqlCommand cmd = new SqlCommand("Biblestia.adicionarCargo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", cargo.NomeBiblioteca));
                cmd.Parameters.Add(new SqlParameter("@idFuncionario", cargo.IdFuncionario));
                cmd.Parameters.Add(new SqlParameter("@nomeCargo", cargo.NomeCargo));
                cmd.Parameters.Add(new SqlParameter("@dataInicio", cargo.DataInicio));
                if (!checkBox2.Checked)
                {
                    cmd.Parameters.Add(new SqlParameter("@dataFim", dateTimePicker5.Value.ToString("yyyy-MM-dd")));
                }
                cmd.ExecuteNonQuery();
                cn.Close();
                listBox2.Items.Add(cargo);
            }

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button13.Enabled = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
            button17.Visible = false;
            button18.Visible = false;
            listBox2.Enabled = true;
            label15.Enabled = false;
            dateTimePicker4.Enabled = false;
            dateTimePicker5.Enabled = false;
            textBox3.ReadOnly = true;
            checkBox2.Visible = false;
            updateCargoList();

            if (currentAction == "UpdatingCargo")
            {
                listBox2.SelectedIndex = listBox2currentIndex;
            }
            else if (currentAction == "AddingCargo")
            {
                listBox2.SelectedIndex = listBox2.Items.Count - 1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button13.Enabled = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
            button17.Visible = false;
            button18.Visible = false;
            listBox2.Enabled = true;
            label15.Enabled = false;
            dateTimePicker4.Enabled = false;
            dateTimePicker5.Enabled = false;
            textBox3.ReadOnly = true;
            checkBox2.Visible = false;
            updateCargoList();
            listBox2.SelectedIndex = listBox2currentIndex;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox2currentIndex = listBox2.SelectedIndex;
            listBox2.ClearSelected();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button13.Enabled = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = true;
            button18.Visible = true;
            listBox2.Enabled = false;
            label15.Enabled = true;
            dateTimePicker4.Enabled = true;
            dateTimePicker5.Format = DateTimePickerFormat.Short;
            dateTimePicker5.Enabled = true;
            dateTimePicker4.ResetText();
            dateTimePicker5.ResetText();
            textBox3.Clear();
            textBox3.ReadOnly = false;
            checkBox2.Visible = true;

            currentAction = "AddingCargo";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string message = "De certeza que pretende remover esse cargo?\n";
            string title = "Check Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    Cargo cargo = (Cargo)listBox2.SelectedItem;

                    SqlCommand cmd = new SqlCommand("Biblestia.removerCargo", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", cargo.NomeBiblioteca));
                    cmd.Parameters.Add(new SqlParameter("@idFuncionario", cargo.IdFuncionario));
                    cmd.Parameters.Add(new SqlParameter("@nomeCargo", cargo.NomeCargo));
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    listBox2.Items.Remove(listBox2.SelectedItem);
                    updateCargoList();
                    listBox2.SelectedIndex = listBox2.Items.Count - 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fid.Clear();
            fnif.Clear();
            fssn.Clear();
            fnome.Clear();
            femail.Clear();
            fmorada.Clear();
            ftelefone.Clear();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            panel2.Enabled = false;
            listBox1.ClearSelected();
            fid.Text = "-------------";
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

            currentAction = "addingFuncionario";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            groupBox1.Visible = true;
            button8.Visible = true;
            button7.Visible = true;
            button9.Visible = true;
            listBox1.Enabled = true;
            showFuncionario();
            getCargosDoFuncionario();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateListLeitores();
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string message = "De certeza que pretende remover esse leitor?\n";
            string title = "Check Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    Leitor leitor = (Leitor)listBox1.SelectedItem;

                    SqlCommand cmd = new SqlCommand("Biblestia.removerLeitor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", leitor.NomeBiblioteca));
                    cmd.Parameters.Add(new SqlParameter("@idLeitor", leitor.IdLeitor));
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    listBox1.Items.Remove(listBox1.SelectedItem);
                    listBox1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string message = "De certeza que pretende remover esse funcionário?\n";
            string title = "Check Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    Funcionario funcionario = (Funcionario)listBox1.SelectedItem;

                    SqlCommand cmd = new SqlCommand("Biblestia.removerFuncionario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", funcionario.NomeBiblioteca));
                    cmd.Parameters.Add(new SqlParameter("@idFuncionario", funcionario.IdFuncionario));
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    listBox1.Items.Remove(listBox1.SelectedItem);
                    updateCargoList();
                    listBox1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateAllRequisicoes();
        }

        private void updateAllRequisicoes()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            groupsVisibleFalse();
            panelsVisibleFalse();
            groupBox5.Visible = true;
            panel5.Visible = true;
            listBox1.Visible = false;
            panel3.Visible = true;
            string previews = "";
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterRequisicoes('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            Requisicao requisicao = new Requisicao();
            while (reader.Read())
            {
                if (reader["id"].ToString() != previews)
                {
                    requisicao = new Requisicao();
                    requisicao.Id = reader["id"].ToString();
                    requisicao.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                    requisicao.IdLeitor = reader["idLeitor"].ToString();
                    requisicao.NomeCompletoLeitor = reader["nomeCompletoLeitor"].ToString();
                    requisicao.IdFuncResponsavel = reader["idFuncResponsavel"].ToString();
                    requisicao.NomeCompletoFuncResponsavel = reader["nomeCompletoFuncResponsavel"].ToString();
                    requisicao.DataInicio = reader["dataInicio"].ToString();
                    requisicao.DataLimite = reader["dataLimite"].ToString();
                    requisicao.DataEntrega = reader["dataEntrega"].ToString();
                    requisicao.addMaterial(reader["idMaterial"].ToString());
                    if (requisicao.DataEntrega == "")
                    {
                        listBox3.Items.Add(requisicao);
                    }
                    listBox4.Items.Add(requisicao);
                    previews = reader["id"].ToString();
                } else
                {
                    requisicao.addMaterial(reader["idMaterial"].ToString());
                }
            }
            reader.Close();
            cn.Close();
            if (listBox4.Items.Count > 0)
            {
                listBox4.SelectedIndex = 0;
            } else if (listBox3.Items.Count > 0)
            {
                listBox3.SelectedIndex = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button20.Enabled = false;
            button19.Enabled = false;
            button23.Enabled = false;
            textBox12.ReadOnly = false;
            textBox14.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox4.ReadOnly = false;
            dateTimePicker6.Enabled = true;
            dateTimePicker6.Format = DateTimePickerFormat.Short;
            panel4.Enabled = false;
            panel10.Visible = true;
            listBox1.Enabled = false;

            currentAction = "updatingLeitor";

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex > -1)
            {
                listBox3.ClearSelected();
                label35.Visible = false;
                textBox15.Visible = false;
                currentRequisicao = (Requisicao)listBox4.SelectedItem;
                Requisicao requisicao = (Requisicao)listBox4.SelectedItem;
                textBox17.Text = requisicao.Id;
                textBox19.Text = requisicao.NomeCompletoFuncResponsavel;
                textBox16.Text = requisicao.NomeCompletoLeitor;
                textBox20.Text = requisicao.Materials.Count.ToString();
                dateTimePicker8.Format = DateTimePickerFormat.Custom;
                dateTimePicker8.CustomFormat = "yyyy-MM-dd";
                dateTimePicker8.Text = requisicao.DataInicio;
                dateTimePicker7.Format = DateTimePickerFormat.Custom;
                dateTimePicker7.CustomFormat = "yyyy-MM-dd";
                dateTimePicker7.Text = requisicao.DataLimite;
                dateTimePicker9.Format = DateTimePickerFormat.Custom;
                dateTimePicker9.CustomFormat = "yyyy-MM-dd";
                dateTimePicker9.Text = requisicao.DataEntrega;
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex > -1)
            {
                listBox4.ClearSelected();
                currentRequisicao = (Requisicao)listBox3.SelectedItem;
                Requisicao requisicao = (Requisicao)listBox3.SelectedItem;
                textBox17.Text = requisicao.Id;
                textBox19.Text = requisicao.NomeCompletoFuncResponsavel;
                textBox16.Text = requisicao.NomeCompletoLeitor;
                textBox20.Text = requisicao.Materials.Count.ToString();
                dateTimePicker8.Format = DateTimePickerFormat.Custom;
                dateTimePicker8.CustomFormat = "yyyy-MM-dd";
                dateTimePicker8.Text = requisicao.DataInicio;
                dateTimePicker7.Format = DateTimePickerFormat.Custom;
                dateTimePicker7.CustomFormat = "yyyy-MM-dd";
                dateTimePicker7.Text = requisicao.DataLimite;
                dateTimePicker9.Format = DateTimePickerFormat.Custom;
                dateTimePicker9.CustomFormat = " ";
                label35.Visible = true;
                textBox15.Visible = true;
                TimeSpan atraso = DateTime.UtcNow - dateTimePicker7.Value;
                textBox15.Text = atraso.Days.ToString();
            }
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            groupBox6.Visible = true;
            panel3.Enabled = false;
            panel5.Enabled = false;
            listBox5.Items.Clear();
            for (int i = 0; i < currentRequisicao.Materials.Count; i++)
            {
                //Debug.Print((string)currentRequisicao.Materials[i]);
                string idMaterial = (string)currentRequisicao.Materials[i];
                if (!verifySGBDConnection())
                {
                    return;
                }
                SqlCommand cmd = new SqlCommand("select * from Biblestia.obterRequisicoesMaterial(" + idMaterial + ",'" + biblioteca.Nome + "') order by dataInicio", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["id"].ToString() != currentRequisicao.Id && reader["nomeBiblioteca"].ToString() == currentRequisicao.NomeBiblioteca)
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao.Id = reader["id"].ToString();
                        requisicao.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                        requisicao.IdLeitor = reader["idLeitor"].ToString();
                        requisicao.NomeCompletoLeitor = reader["nomeCompletoLeitor"].ToString();
                        requisicao.IdFuncResponsavel = reader["idFuncResponsavel"].ToString();
                        requisicao.NomeCompletoFuncResponsavel = reader["nomeCompletoFuncResponsavel"].ToString();
                        requisicao.DataInicio = reader["dataInicio"].ToString();
                        requisicao.DataLimite = reader["dataLimite"].ToString();
                        requisicao.DataEntrega = reader["dataEntrega"].ToString();
                        requisicao.addMaterial(reader["idMaterial"].ToString());
                        String a = idMaterial + "\t        " + DateTime.Parse(requisicao.DataInicio).ToString("yyyy-MM-dd") + "\t" + requisicao.NomeCompletoLeitor;
                        listBox5.Items.Add(a);
                    }
                }
                reader.Close();
                cn.Close();
            }
            //chart1.Titles.Add("Gráfico dos Tipos de Material Nesta Requisição");
            obterDadosMateriasRequisicao(currentRequisicao);
        }
        private void obterDadosMateriasRequisicao(Requisicao requisicao)
        {
            chart1.Series["s1"].Points.Clear();
            chart1.Series["s1"].IsValueShownAsLabel = true;
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterLivrosRequisicao(" + requisicao.Id + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader["cont"].ToString() != "0")
            {
                chart1.Series["s1"].Points.AddXY("Livros", int.Parse(reader["cont"].ToString()));
            }
            reader.Close();
            cn.Close();
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd2 = new SqlCommand("select * from Biblestia.obterJornaisRequisicao(" + requisicao.Id + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            reader2.Read();
            if (reader2["cont"].ToString() != "0")
            {
                chart1.Series["s1"].Points.AddXY("Jornais", int.Parse(reader2["cont"].ToString()));
            }
            reader2.Close();
            cn.Close();
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd3 = new SqlCommand("select * from Biblestia.obterRevistasRequisicao(" + requisicao.Id + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            reader3.Read();
            if (reader3["cont"].ToString() != "0")
            {
                chart1.Series["s1"].Points.AddXY("Revistas", int.Parse(reader3["cont"].ToString()));
            }
            reader3.Close();
            cn.Close();
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd4 = new SqlCommand("select * from Biblestia.obterJogosRequisicao(" + requisicao.Id + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            reader4.Read();
            if (reader4["cont"].ToString() != "0")
            {
                chart1.Series["s1"].Points.AddXY("Jogos", int.Parse(reader4["cont"].ToString()));
            }
            reader4.Close();
            cn.Close();
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd5 = new SqlCommand("select * from Biblestia.obterCDsRequisicao(" + requisicao.Id + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader5 = cmd5.ExecuteReader();
            reader5.Read();
            if (reader5["cont"].ToString() != "0")
            {
                chart1.Series["s1"].Points.AddXY("CDs", int.Parse(reader5["cont"].ToString()));
            }
            reader5.Close();
            cn.Close();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            groupBox5.Visible = true;
            panel3.Enabled = true;
            panel5.Enabled = true;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            
            Requisicao requisicao = currentRequisicao;
            groupsVisibleFalse();
            groupBox7.Visible = true;
            foreach(string materialId in requisicao.Materials) {
                if (!verifySGBDConnection())
                {
                    return;
                }
                SqlCommand cmd = new SqlCommand("select * from Biblestia.obterDadosMaterial(" + materialId + ",'" + biblioteca.Nome + "')", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Material material = new Material();
                    material.Id = reader["id"].ToString();
                    material.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                    material.SeccaoExposicao = reader["seccaoExposicao"].ToString();
                    material.Estado = reader["estado"].ToString();
                    listBox6.Items.Add(material);
                }
                reader.Close();
                cn.Close();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {

        }

        private void fssn_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox13.Clear();
            textBox12.Clear();
            textBox14.Clear();
            textBox7.Clear();
            textBox5.Clear();
            textBox4.Clear();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button20.Enabled = false;
            button23.Enabled = false;
            button19.Enabled = false;
            listBox1.ClearSelected();
            textBox13.Text = "--------------------";
            textBox12.ReadOnly = false;
            textBox14.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox4.ReadOnly = false;
            dateTimePicker6.Enabled = true;
            dateTimePicker6.Format = DateTimePickerFormat.Short;
            panel4.Enabled = false;
            panel10.Visible = true;
            listBox1.Enabled = false;

            currentAction = "addingLeitor";

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                dateTimePicker6.Enabled = false;
            }
            else
            {
                dateTimePicker6.Enabled = true;
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            Leitor leitor = new Leitor();
            leitor.Nif = textBox12.Text;
            leitor.NomeCompleto = textBox14.Text;
            leitor.IdLeitor = textBox13.Text;
            leitor.NomeBiblioteca = biblioteca.Nome;
            leitor.Email = textBox7.Text;
            leitor.Morada = textBox5.Text;
            leitor.Telefone = textBox4.Text;
            leitor.DataNascimento = dateTimePicker6.Text;
            if (checkBox7.Checked)
            {
                leitor.DataNascimento = "";
            }
            if (currentAction == "updatingLeitor")
            {
                SqlCommand cmd = new SqlCommand("Biblestia.editarLeitor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nif", leitor.Nif));
                cmd.Parameters.Add(new SqlParameter("@nomeCompleto", leitor.NomeCompleto));
                cmd.Parameters.Add(new SqlParameter("@idLeitor", leitor.IdLeitor));
                cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", biblioteca.Nome));
                cmd.Parameters.Add(new SqlParameter("@email", leitor.Email));
                cmd.Parameters.Add(new SqlParameter("@morada", leitor.Morada));
                cmd.Parameters.Add(new SqlParameter("@telefone", leitor.Telefone));
                if (!checkBox7.Checked)
                {
                    cmd.Parameters.Add(new SqlParameter("@dataNascimento", dateTimePicker6.Value.ToString("yyyy-MM-dd")));
                }
                cmd.ExecuteNonQuery();
            }
            else if (currentAction == "addingLeitor")
            {
                SqlCommand cmd = new SqlCommand("Biblestia.adicionarLeitor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nif", leitor.Nif));
                cmd.Parameters.Add(new SqlParameter("@nomeCompleto", leitor.NomeCompleto));
                cmd.Parameters.Add(new SqlParameter("@idLeitor", leitor.IdLeitor));
                cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", biblioteca.Nome));
                cmd.Parameters.Add(new SqlParameter("@email", leitor.Email));
                cmd.Parameters.Add(new SqlParameter("@morada", leitor.Morada));
                cmd.Parameters.Add(new SqlParameter("@telefone", leitor.Telefone));
                if (!checkBox7.Checked)
                {
                    cmd.Parameters.Add(new SqlParameter("@dataNascimento", dateTimePicker6.Value.ToString("yyyy-MM-dd")));
                }
                cmd.ExecuteNonQuery();
            }
            cn.Close();
            listBox1.SelectedItem = leitor;
            saidaEdicaoLeitor();
        }

        private void saidaEdicaoLeitor()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button20.Enabled = true;
            button19.Enabled = true;
            button23.Enabled = true;
            textBox12.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox4.ReadOnly = true;
            dateTimePicker6.Enabled = false;
            panel10.Visible = false;
            panel4.Enabled = true;
            listBox1.Enabled = true;
            int saveIndex = currentListIndex;
            updateListLeitores();
            if (currentAction == "updatingLeitor")
            {
                listBox1.SelectedIndex = saveIndex;

            }
            else if (currentAction == "addingLeitor")
            {
                listBox1.SelectedIndex = 0;
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            saidaEdicaoLeitor();
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox6.Items.Count > 0 && listBox6.SelectedIndex > -1)
            {

                if (!verifySGBDConnection())
                {
                    return;
                }
                Material material = (Material)listBox6.SelectedItem;
                SqlCommand cmd = new SqlCommand("Biblestia.saberTipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMaterial", material.Id);
                cmd.Parameters.AddWithValue("@nomeBiblioteca", biblioteca.Nome);
                cmd.Parameters.Add("@return", SqlDbType.VarChar, 60);
                cmd.Parameters["@return"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string o = Convert.ToString(cmd.Parameters["@return"].Value);
                cn.Close();

                Debug.Print(o);
                   // ja é identificavel o tipo de material agora falta fazer a parte de switch para alternar entre
                   // os panels e depois fazer as chamadas para cada material e atribuiçao de valores
            }
        }
    }
}
