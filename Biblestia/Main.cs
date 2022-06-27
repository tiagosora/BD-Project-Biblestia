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
        private string listType;
        private string voltar;
        private int currentListIndex;
        private int listBox2currentIndex;
        private String currentAction = "null";
        private Requisicao currentRequisicao;
        public string tipoMaterial;

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
            groupBox8.Visible = false;
            groupBox9.Visible = false;
            groupBox10.Visible = false;
            groupBox11.Visible = false;
            groupBox12.Visible = false;
            groupBox13.Visible = false;
            groupBox14.Visible = false;
            groupBox15.Visible = false;
        }

        private void panelsVisibleFalse()
        {
            panel2.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel12.Visible = false;
            panel18.Visible = false;
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
                    case "Material":
                        currentListIndex = listBox1.SelectedIndex;
                        showMaterial();
                        break;
                    case "Atividade":
                        currentListIndex = listBox1.SelectedIndex;
                        showAtividade();
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

        public void showAtividade()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;
            Atividade atividade = new Atividade();
            atividade = (Atividade)listBox1.Items[currentListIndex];
            textBox81.Text = atividade.NomeAtividade;
            textBox80.Text = atividade.Tematica;
            textBox82.Text = atividade.IdFuncResponsavel;
            textBox83.Text = atividade.DuracaoMin;
            dateTimePicker20.Text = atividade.DataAtividade;
            if (atividade.DataAtividade == "")
            {
                dateTimePicker20.Format = DateTimePickerFormat.Custom;
                dateTimePicker20.CustomFormat = " ";
            }
            else
            {
                dateTimePicker20.Format = DateTimePickerFormat.Short;
                dateTimePicker20.Text = atividade.DataAtividade;
            }
            SqlCommand cmd = new SqlCommand("select * from Biblestia.nLeitoresAtividade('" + atividade.NomeAtividade + "','" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox84.Text = reader["cont"].ToString();
            reader.Close();
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
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
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
            if (currentAction == "UpdatingCargo")
            {
                listBox2.SelectedIndex = listBox2currentIndex;
            }
            else if (currentAction == "AddingCargo")
            {
                listBox2.SelectedIndex = listBox2.Items.Count - 1;
            }
            try
            {
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
                }
                else if (currentAction == "AddingCargo")
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
                    listBox2.Items.Add(cargo);
                    cn.Close();
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
            }
            catch
            {
                cn.Close();
                string message = "As datas inseridas não fazem sentido!\n";
                string title = "Alert Window";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
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
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
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

        
        private void panel4_Paint(object sender, PaintEventArgs e)
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


        private void button28_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
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
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            
            Requisicao requisicao = currentRequisicao;
            groupsVisibleFalse();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            groupBox7.Visible = true;
            panel3.Enabled = false;
            panel5.Enabled = false;
            listBox6.Items.Clear();
            foreach(string materialId in requisicao.Materials) {
                if (!verifySGBDConnection())
                {
                    return;
                }
                Material material = new Material();
                SqlCommand cmd = new SqlCommand("select * from Biblestia.obterDadosMaterial(" + materialId + ",'" + biblioteca.Nome + "')", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                material.Id = reader["id"].ToString();
                material.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                material.SeccaoExposicao = reader["seccaoExposicao"].ToString();
                material.Estado = reader["estado"].ToString();
                listBox6.Items.Add(material);
                reader.Close();
                cn.Close();
            }
            if (listBox6.Items.Count > 0)
            {
                listBox6.SelectedIndex = 0;
            }
        }

        private void fssn_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
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
                string returnValue = Convert.ToString(cmd.Parameters["@return"].Value);
                cn.Close();

                switch (returnValue)
                {
                    case "Livro":
                        apresentarLivro(material.Id);
                        break;
                    case "Jornal":
                        apresentarJornal(material.Id);
                        break;
                    case "Revista":
                        apresentarRevista(material.Id);
                        break;
                    case "Jogo":
                        apresentarJogo(material.Id);
                        break;
                    case "CD":
                        apresentarCD(material.Id);
                        break;
                    default:
                        break;
                }
                   // ja é identificavel o tipo de material agora falta fazer a parte de switch para alternar entre
                   // os panels e depois fazer as chamadas para cada material e atribuiçao de valores
            }
        }

        private void apresentarLivro(string materialId)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            panel11.Visible = false;
            panel9.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterDadosLivro(" + materialId + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox23.Text = reader["titulo"].ToString();
            textBox25.Text = reader["autor"].ToString();
            textBox24.Text = reader["genero"].ToString();
            textBox30.Text = reader["ano"].ToString();
            textBox18.Text = reader["nomeEditora"].ToString();
            reader.Close();
            cn.Close();
        }
        private void apresentarJornal(string materialId)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            panel11.Visible = false;
            panel9.Visible = false;
            panel6.Visible = false;
            panel7.Visible = true;
            panel8.Visible = false;
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterDadosJornal(" + materialId + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox28.Text = reader["nome"].ToString();
            textBox21.Text = reader["nomeEditora"].ToString();
            dateTimePicker11.Format = DateTimePickerFormat.Custom;
            dateTimePicker11.CustomFormat = "yyyy-MM-dd";
            dateTimePicker11.Text = reader["dataPublicacao"].ToString();
            reader.Close();
            cn.Close();
        }
        private void apresentarRevista(string materialId)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            panel11.Visible = false;
            panel9.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = true;
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterDadosRevista(" + materialId + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox33.Text = reader["nome"].ToString();
            textBox32.Text = reader["categoria"].ToString();
            textBox27.Text = reader["nomeEditora"].ToString();
            dateTimePicker10.Format = DateTimePickerFormat.Custom;
            dateTimePicker10.CustomFormat = "yyyy-MM-dd";
            dateTimePicker10.Text = reader["dataPublicacao"].ToString();
            reader.Close();
            cn.Close();
        }
        private void apresentarJogo(string materialId)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            panel11.Visible = false;
            panel9.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterDadosJogo(" + materialId + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox37.Text = reader["nome"].ToString();
            textBox26.Text = reader["ano"].ToString();
            textBox36.Text = reader["categoria"].ToString();
            textBox31.Text = reader["marcaProdutora"].ToString();
            reader.Close();
            cn.Close();
        }
        private void apresentarCD(string materialId)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            panel11.Visible = true;
            panel9.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterDadosCD(" + materialId + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox40.Text = reader["nome"].ToString();
            textBox11.Text = reader["ano"].ToString();
            textBox39.Text = reader["categoria"].ToString();
            textBox35.Text = reader["marcaProdutora"].ToString();
            reader.Close();
            cn.Close();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            groupBox5.Visible = true;
            panel3.Enabled = true;
            panel5.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Requisicao requisicao = currentRequisicao;
            requisicoesLeitor(requisicao.IdLeitor, "requisicao");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Leitor leitor = (Leitor)listBox1.SelectedItem;
            requisicoesLeitor(leitor.IdLeitor, "leitor");
        }
        private void requisicoesLeitor(string LeitorId, string voltarA)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            voltar = voltarA;
            groupsVisibleFalse();
            groupBox8.Visible = true;
            listBox1.Enabled = false;
            panel3.Enabled = false;
            panel4.Enabled = false;
            panel5.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterDadosLeitor(" + LeitorId + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox42.Text = LeitorId;
            textBox43.Text = reader["nomeCompleto"].ToString();
            reader.Close();
            cn.Close();
            if (!verifySGBDConnection())
            {
                return;
            }
            listBox7.Items.Clear();
            SqlCommand cmd2 = new SqlCommand("select * from Biblestia.obterRequisicoesLeitor(" + LeitorId + ",'" + biblioteca.Nome + "') order by dataInicio", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                Requisicao requisicao = new Requisicao();
                requisicao.Id = reader2["id"].ToString();
                requisicao.NomeCompletoLeitor = reader2["nomeCompletoLeitor"].ToString();
                requisicao.DataInicio = reader2["dataInicio"].ToString();
                requisicao.DataLimite = reader2["dataLimite"].ToString();
                requisicao.DataEntrega = reader2["dataEntrega"].ToString();
                listBox7.Items.Add(requisicao);
            }
            reader.Close();
            cn.Close();
            if (listBox7.Items.Count > 0)
            {
                listBox7.SelectedIndex = 0;
            }
        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Requisicao requisicao = (Requisicao)listBox7.SelectedItem;
            dateTimePicker13.Format = DateTimePickerFormat.Custom;
            dateTimePicker13.CustomFormat = "yyyy-MM-dd";
            dateTimePicker13.Text = requisicao.DataInicio.ToString();
            dateTimePicker14.Format = DateTimePickerFormat.Custom;
            dateTimePicker14.CustomFormat = "yyyy-MM-dd";
            dateTimePicker14.Text = requisicao.DataLimite.ToString();

            if (requisicao.DataEntrega == "")
            {
                
                dateTimePicker12.Format = DateTimePickerFormat.Custom;
                dateTimePicker12.CustomFormat = " ";
                label66.Visible = true;
                textBox45.Visible = true;
                TimeSpan atraso = DateTime.UtcNow - dateTimePicker14.Value;
                textBox45.Text = atraso.Days.ToString();
            } else
            {
                label66.Visible = false;
                textBox45.Visible = false;
                dateTimePicker12.Format = DateTimePickerFormat.Custom;
                dateTimePicker12.CustomFormat = "yyyy-MM-dd";
                dateTimePicker12.Text = requisicao.DataEntrega.ToString();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            listBox1.Enabled = true;
            panel3.Enabled = true;
            panel4.Enabled = true;
            panel5.Enabled = true;
            switch (voltar)
            {
                case "requisicao":
                    groupBox5.Visible = true;
                    break;
                case "leitor":
                    groupBox4.Visible = true;
                    break;
                default:
                    break;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            groupsVisibleFalse();
            groupBox9.Visible = true;
            panelsVisibleFalse();
            panel12.Visible = true;
            listBox1.Visible = true;
            listBox1.Enabled = true;
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterMateriais('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listType = "Material";
            listBox1.Items.Clear();
            while (reader.Read())
            {
                Material material = new Material();
                material.Id = reader["id"].ToString();
                material.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                material.SeccaoExposicao = reader["seccaoExposicao"].ToString();
                material.Estado = reader["estado"].ToString();
                listBox1.Items.Add(material);
            }
            reader.Close();
            cn.Close();
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }

        }

        private void showMaterial()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            Material material = (Material)listBox1.SelectedItem;
            textBox68.Text = material.Id;
            textBox69.Text = material.Estado;
            textBox70.Text = material.SeccaoExposicao;
            if (material.Estado == "Requisitado")
            {
                label98.Visible = true;
                textBox71.Visible = true;
                SqlCommand cmd2 = new SqlCommand("select * from Biblestia.obterRequisitor(" + material.Id + ",'" + biblioteca.Nome + "')", cn);
                SqlDataReader reader = cmd2.ExecuteReader();
                reader.Read();
                textBox71.Text = reader["nomeCompleto"].ToString();
                reader.Close();
                cn.Close();
            } else
            {
                label98.Visible = false;
                textBox71.Visible = false;
            }


            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd = new SqlCommand("Biblestia.saberTipo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idMaterial", material.Id);
            cmd.Parameters.AddWithValue("@nomeBiblioteca", biblioteca.Nome);
            cmd.Parameters.Add("@return", SqlDbType.VarChar, 60);
            cmd.Parameters["@return"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string returnValue = Convert.ToString(cmd.Parameters["@return"].Value);
            cn.Close();
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel16.Visible = false;
            panel17.Visible = false;
            tipoMaterial = returnValue;
            switch (returnValue)
            {
                case "Livro":
                    panel15.Visible = true;
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd3 = new SqlCommand("select * from Biblestia.obterDadosLivro(" + material.Id + ",'" + biblioteca.Nome + "')", cn);
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    reader3.Read();
                    textBox59.Text = reader3["titulo"].ToString();
                    textBox57.Text = reader3["autor"].ToString();
                    textBox58.Text = reader3["genero"].ToString();
                    textBox55.Text = reader3["ano"].ToString();
                    textBox56.Text = reader3["nomeEditora"].ToString();
                    reader3.Close();
                    cn.Close();
                    break;
                case "Jornal":
                    panel16.Visible = true;
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd4 = new SqlCommand("select * from Biblestia.obterDadosJornal(" + material.Id + ",'" + biblioteca.Nome + "')", cn);
                    SqlDataReader reader4 = cmd4.ExecuteReader();
                    reader4.Read();
                    textBox62.Text = reader4["nome"].ToString();
                    textBox61.Text = reader4["nomeEditora"].ToString();
                    dateTimePicker15.Format = DateTimePickerFormat.Custom;
                    dateTimePicker15.CustomFormat = "yyyy-MM-dd";
                    dateTimePicker15.Text = reader4["dataPublicacao"].ToString();
                    reader4.Close();
                    cn.Close();
                    break;
                case "Revista":
                    panel17.Visible = true;
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd5 = new SqlCommand("select * from Biblestia.obterDadosRevista(" + material.Id + ",'" + biblioteca.Nome + "')", cn);
                    SqlDataReader reader5 = cmd5.ExecuteReader();
                    reader5.Read();
                    textBox66.Text = reader5["nome"].ToString();
                    textBox65.Text = reader5["categoria"].ToString();
                    textBox64.Text = reader5["nomeEditora"].ToString();
                    dateTimePicker16.Format = DateTimePickerFormat.Custom;
                    dateTimePicker16.CustomFormat = "yyyy-MM-dd";
                    dateTimePicker16.Text = reader5["dataPublicacao"].ToString();
                    reader5.Close();
                    cn.Close();
                    break;
                case "Jogo":
                    panel14.Visible = true;
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd6 = new SqlCommand("select * from Biblestia.obterDadosJogo(" + material.Id + ",'" + biblioteca.Nome + "')", cn);
                    SqlDataReader reader6 = cmd6.ExecuteReader();
                    reader6.Read();
                    textBox53.Text = reader6["nome"].ToString();
                    textBox50.Text = reader6["ano"].ToString();
                    textBox52.Text = reader6["categoria"].ToString();
                    textBox51.Text = reader6["marcaProdutora"].ToString();
                    reader6.Close();
                    cn.Close();
                    break;
                case "CD":
                    panel13.Visible = true;
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd7 = new SqlCommand("select * from Biblestia.obterDadosCD(" + material.Id + ",'" + biblioteca.Nome + "')", cn);
                    SqlDataReader reader7 = cmd7.ExecuteReader();
                    reader7.Read();
                    textBox48.Text = reader7["nome"].ToString();
                    textBox44.Text = reader7["ano"].ToString();
                    textBox47.Text = reader7["categoria"].ToString();
                    textBox46.Text = reader7["marcaProdutora"].ToString();
                    reader7.Close();
                    cn.Close();
                    break;
                default:
                    break;
            }
        }

        
        private void button39_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            groupsVisibleFalse();
            groupBox10.Visible = true;
            listBox1.Enabled = false;
            panel5.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            Material material = (Material)listBox1.SelectedItem;
            textBox73.Text = material.Id;
            textBox74.Text = material.Estado;
            textBox75.Text = tipoMaterial;
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterRequisicoesMaterial(" + material.Id + ",'" + biblioteca.Nome + "') order by dataInicio", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox8.Items.Clear();
            while (reader.Read())
            {
                Requisicao requisicao = new Requisicao();
                requisicao.Id = reader["id"].ToString();
                requisicao.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                requisicao.DataInicio = reader["dataInicio"].ToString();
                requisicao.DataLimite = reader["dataLimite"].ToString();
                requisicao.DataEntrega = reader["dataEntrega"].ToString();
                listBox8.Items.Add(requisicao);
            }
            reader.Close();
            cn.Close();
            if (listBox8.Items.Count > 0)
            {
                listBox8.SelectedIndex = 0;
            }
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Requisicao requisicao = (Requisicao)listBox8.SelectedItem;
            dateTimePicker18.Format = DateTimePickerFormat.Custom;
            dateTimePicker18.CustomFormat = "yyyy-MM-dd";
            dateTimePicker18.Text = requisicao.DataInicio.ToString();
            dateTimePicker19.Format = DateTimePickerFormat.Custom;
            dateTimePicker19.CustomFormat = "yyyy-MM-dd";
            dateTimePicker19.Text = requisicao.DataLimite.ToString();

            if (requisicao.DataEntrega == "")
            {
                dateTimePicker17.Format = DateTimePickerFormat.Custom;
                dateTimePicker17.CustomFormat = " ";
                label99.Visible = true;
                textBox72.Visible = true;
                TimeSpan atraso = DateTime.UtcNow - dateTimePicker19.Value;
                textBox72.Text = atraso.Days.ToString();
            }
            else
            {
                label99.Visible = false;
                textBox72.Visible = false;
                dateTimePicker17.Format = DateTimePickerFormat.Custom;
                dateTimePicker17.CustomFormat = "yyyy-MM-dd";
                dateTimePicker17.Text = requisicao.DataEntrega.ToString();
            }
        }

        

        private void button40_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            groupBox9.Visible = true;
            listBox1.Enabled = true;
            panel5.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }
        private void button38_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            groupsVisibleFalse();
            groupBox11.Visible = true;
            panel12.Enabled = false;
            listBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            Material material = (Material)listBox1.SelectedItem;
            textBox79.Text = tipoMaterial;
            string nLivros;
            string nJornais;
            string nRevistas;
            string nJogos;
            string nCDs;
            string nRequisiçoes;

            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterNumeroTotalLivros('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            nLivros = reader["cont"].ToString();
            reader.Close();
            cn.Close();
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd2 = new SqlCommand("select * from Biblestia.obterNumeroTotalJornais('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            reader2.Read();
            nJornais = reader2["cont"].ToString();
            reader2.Close();
            cn.Close();
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd3 = new SqlCommand("select * from Biblestia.obterNumeroTotalLivros('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            reader3.Read();
            nRevistas = reader3["cont"].ToString();
            reader3.Close();
            cn.Close();
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd4 = new SqlCommand("select * from Biblestia.obterNumeroTotalLivros('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            reader4.Read();
            nJogos = reader4["cont"].ToString();
            reader4.Close();
            cn.Close();
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd5 = new SqlCommand("select * from Biblestia.obterNumeroTotalCDs('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader5 = cmd5.ExecuteReader();
            reader5.Read();
            nCDs = reader5["cont"].ToString();
            reader5.Close();
            cn.Close();

            chart2.Series["s2"].Points.Clear();
            chart2.Series["s2"].IsValueShownAsLabel = true;
            chart2.Series["s2"].Points.AddXY("Livros", int.Parse(nLivros));
            chart2.Series["s2"].Points.AddXY("Jornais", int.Parse(nJornais));
            chart2.Series["s2"].Points.AddXY("Revistas", int.Parse(nRevistas));
            chart2.Series["s2"].Points.AddXY("Jogos", int.Parse(nJogos));
            chart2.Series["s2"].Points.AddXY("CDs", int.Parse(nCDs));

            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd6 = new SqlCommand("select * from Biblestia.nReq('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader6 = cmd6.ExecuteReader();
            reader6.Read();
            nRequisiçoes = reader6["cont"].ToString();
            reader6.Close();
            cn.Close();

            switch (tipoMaterial)
            {
                case "Livro":
                    label103.Text = "Número de Livros";
                    textBox76.Text = nLivros;
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd7 = new SqlCommand("select * from Biblestia.nLivrosReq('" + biblioteca.Nome + "')", cn);
                    SqlDataReader reader7 = cmd7.ExecuteReader();
                    reader7.Read();
                    string nLivrosReq = reader7["cont"].ToString();
                    reader7.Close();
                    cn.Close();
                    label105.Text = "Perc. de Livros em Requisições";
                    double count = ((double.Parse(nLivrosReq) / double.Parse(nRequisiçoes)) *100);
                    textBox77.Text = String.Format("{0:0.##} %", count);
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd8 = new SqlCommand("select * from Biblestia.obterContGeneros('" + biblioteca.Nome + "') order by cont desc", cn);
                    SqlDataReader reader8 = cmd8.ExecuteReader();
                    reader8.Read();
                    label104.Text = "Género Mais Lido";
                    textBox78.Text = reader8["genero"].ToString();
                    reader8.Close();
                    cn.Close();
                    break;
                case "Jornal":
                    // editora com mais titulos
                    label103.Text = "Número de Jornais";
                    textBox76.Text = nJornais;
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd9 = new SqlCommand("select * from Biblestia.nJornalReq('" + biblioteca.Nome + "')", cn);
                    SqlDataReader reader9 = cmd9.ExecuteReader();
                    reader9.Read();
                    string nJornaisReq = reader9["cont"].ToString();
                    reader9.Close();
                    cn.Close();
                    label105.Text = "Perc. de Jornais em Requisições";
                    double count2 = ((double.Parse(nJornaisReq) / double.Parse(nRequisiçoes)) * 100);
                    textBox77.Text = String.Format("{0:0.##} %", count2);
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd10 = new SqlCommand("select * from Biblestia.obterContEditora('" + biblioteca.Nome + "') order by cont desc", cn);
                    SqlDataReader reader10 = cmd10.ExecuteReader();
                    reader10.Read();
                    label104.Text = "Editor com Mais Títulos";
                    textBox78.Text = reader10["nomeEditora"].ToString();
                    reader10.Close();
                    cn.Close();
                    break;
                case "Revista":
                    // categoria mais lida
                    label103.Text = "Número de Revistas";
                    textBox76.Text = nRevistas;
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd11 = new SqlCommand("select * from Biblestia.nRevistaReq('" + biblioteca.Nome + "')", cn);
                    SqlDataReader reader11 = cmd11.ExecuteReader();
                    reader11.Read();
                    string nRevistaReq = reader11["cont"].ToString();
                    reader11.Close();
                    cn.Close();
                    label105.Text = "Perc. de Revistas em Requisições";
                    double count3 = ((double.Parse(nRevistaReq) / double.Parse(nRequisiçoes)) * 100);
                    textBox77.Text = String.Format("{0:0.##} %", count3);
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd12 = new SqlCommand("select * from Biblestia.obterContCategoria('" + biblioteca.Nome + "') order by cont desc", cn);
                    SqlDataReader reader12 = cmd12.ExecuteReader();
                    reader12.Read();
                    label104.Text = "Categoria Mais Lido";
                    textBox78.Text = reader12["categoria"].ToString();
                    reader12.Close();
                    cn.Close();
                    break;
                case "Jogo":
                    // categoria com mais jogos
                    label103.Text = "Número de Jogos";
                    textBox76.Text = nJogos;
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd13 = new SqlCommand("select * from Biblestia.nJogoReq('" + biblioteca.Nome + "')", cn);
                    SqlDataReader reader13 = cmd13.ExecuteReader();
                    reader13.Read();
                    string nJogosReq = reader13["cont"].ToString();
                    reader13.Close();
                    cn.Close();
                    label105.Text = "Perc. de Jogos em Requisições";
                    double count4 = ((double.Parse(nJogosReq) / double.Parse(nRequisiçoes)) * 100);
                    textBox77.Text = String.Format("{0:0.##} %", count4);
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd14 = new SqlCommand("select * from Biblestia.obterContCategoriaJogos('" + biblioteca.Nome + "') order by cont desc", cn);
                    SqlDataReader reader14 = cmd14.ExecuteReader();
                    reader14.Read();
                    label104.Text = "Categoria Com Mais Jogos";
                    textBox78.Text = reader14["categoria"].ToString();
                    reader14.Close();
                    cn.Close();
                    break;
                case "CD":
                    // tipo com mais CDs
                    label103.Text = "Número de CDs";
                    textBox76.Text = nCDs;
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd15 = new SqlCommand("select * from Biblestia.nCDsReq('" + biblioteca.Nome + "')", cn);
                    SqlDataReader reader15 = cmd15.ExecuteReader();
                    reader15.Read();
                    string nCDsReq = reader15["cont"].ToString();
                    reader15.Close();
                    cn.Close();
                    label105.Text = "Perc. de CDs em Requisições";
                    double count5 = ((double.Parse(nCDsReq) / double.Parse(nRequisiçoes)) * 100);
                    textBox77.Text = String.Format("{0:0.##} %", count5);
                    if (!verifySGBDConnection())
                    {
                        return;
                    }
                    SqlCommand cmd16 = new SqlCommand("select * from Biblestia.obterContTipoCds('" + biblioteca.Nome + "') order by cont desc", cn);
                    SqlDataReader reader16 = cmd16.ExecuteReader();
                    reader16.Read();
                    label104.Text = "Tipo Com Mais CDs";
                    textBox78.Text = reader16["categoria"].ToString();
                    reader16.Close();
                    cn.Close();
                    break;
                default:
                    break;
            }
        }

        private void updateAllAtividades()
        {
            if (!verifySGBDConnection())
            {
                return;
            }

            groupsVisibleFalse();
            panelsVisibleFalse();
            groupBox12.Visible = true;
            listBox1.Visible = true;
            listBox1.Enabled = true;
            panel18.Visible = true;
            panel18.Enabled = true;
            listType = "Atividade";

            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterAtividades('" + biblioteca.Nome + "') order by dataAtividade", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                Atividade atividade = new Atividade();
                atividade.NomeAtividade = reader["nomeAtividade"].ToString();
                atividade.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                atividade.DataAtividade = reader["dataAtividade"].ToString();
                atividade.Tematica = reader["tematica"].ToString();
                atividade.DuracaoMin = reader["duracaoMin"].ToString();
                atividade.IdFuncResponsavel = reader["idFuncResponsavel"].ToString();
                listBox1.Items.Add(atividade);
            }
            reader.Close();
            cn.Close();
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }


        }
        private void button41_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            groupBox9.Visible = true;
            panel12.Enabled = true;
            listBox1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }


        private void button43_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            panel18.Enabled = false;
            textBox81.ReadOnly = false;
            textBox80.ReadOnly = false;
            textBox82.ReadOnly = false;
            textBox83.ReadOnly = false;
            textBox84.ReadOnly = false;
            dateTimePicker20.Enabled = true;
            dateTimePicker20.Format = DateTimePickerFormat.Short;
            panel19.Visible = true;
            listBox1.Enabled = false;
            currentAction = "updatingAtividade";
        }
        private void button44_Click(object sender, EventArgs e)
        {
            textBox81.Clear();
            textBox80.Clear();
            textBox82.Clear();
            textBox83.Clear();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            panel18.Enabled = false;
            listBox1.ClearSelected();
            textBox81.ReadOnly = false;
            textBox80.ReadOnly = false;
            textBox82.ReadOnly = false;
            textBox83.ReadOnly = false;
            textBox84.ReadOnly = false;
            dateTimePicker20.Enabled = true;
            dateTimePicker20.Format = DateTimePickerFormat.Short;
            panel19.Visible = true;
            listBox1.Enabled = false;
            currentAction = "addingAtividade";
        }

        private void button42_Click(object sender, EventArgs e)
        {
            string message = "De certeza que pretende remover esta atividade?\n";
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
                    Atividade atividade = (Atividade)listBox1.SelectedItem;

                    SqlCommand cmd = new SqlCommand("Biblestia.removerAtividade", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", atividade.NomeBiblioteca));
                    cmd.Parameters.Add(new SqlParameter("@nomeAtividade", atividade.NomeAtividade));
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            updateAllAtividades();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            Atividade atividade = new Atividade();
            atividade.NomeAtividade = textBox81.Text;
            atividade.NomeBiblioteca = biblioteca.Nome;
            atividade.Tematica = textBox80.Text;
            atividade.DuracaoMin = textBox83.Text;
            atividade.DataAtividade = dateTimePicker20.Text;
            atividade.IdFuncResponsavel = textBox82.Text;
            try
            {
                if (checkBox3.Checked)
                {
                    atividade.DataAtividade = "";
                }
                if (currentAction == "updatingAtividade")
                {
                    Debug.Print("Entrei aqui");
                    SqlCommand cmd = new SqlCommand("Biblestia.editarAtividade", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", atividade.NomeBiblioteca));
                    cmd.Parameters.Add(new SqlParameter("@nomeAtividade", atividade.NomeAtividade));
                    cmd.Parameters.Add(new SqlParameter("@tematica", atividade.Tematica));
                    cmd.Parameters.Add(new SqlParameter("@duracaoMin", atividade.DuracaoMin));
                    cmd.Parameters.Add(new SqlParameter("@idFuncResponsavel", atividade.IdFuncResponsavel));
                    if (!checkBox3.Checked)
                    {
                        cmd.Parameters.Add(new SqlParameter("@dataAtividade", dateTimePicker20.Value.ToString("yyyy-MM-dd")));
                    }
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    listBox1.SelectedItem = atividade;
                }
                else if (currentAction == "addingAtividade")
                {
                    SqlCommand cmd = new SqlCommand("Biblestia.adicionarAtividade", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", atividade.NomeBiblioteca));
                    cmd.Parameters.Add(new SqlParameter("@nomeAtividade", atividade.NomeAtividade));
                    cmd.Parameters.Add(new SqlParameter("@tematica", atividade.Tematica));
                    cmd.Parameters.Add(new SqlParameter("@duracaoMin", atividade.DuracaoMin));
                    cmd.Parameters.Add(new SqlParameter("@idFuncResponsavel", atividade.IdFuncResponsavel));
                    if (!checkBox3.Checked)
                    {
                        cmd.Parameters.Add(new SqlParameter("@dataAtividade", dateTimePicker20.Value.ToString("yyyy-MM-dd")));
                    }
                    cmd.ExecuteNonQuery();
                    listBox1.Items.Add(atividade);
                    cn.Close();
                }

                if (currentAction == "addingAtividade")
                {
                    listBox1.SelectedIndex = currentListIndex;
                }
                else if (currentAction == "addingAtividade")
                {
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                panel18.Enabled = true;
                textBox81.ReadOnly = true;
                textBox80.ReadOnly = true;
                textBox82.ReadOnly = true;
                textBox83.ReadOnly = true;
                textBox84.ReadOnly = true;
                dateTimePicker20.Enabled = false;
                dateTimePicker20.Format = DateTimePickerFormat.Short;
                panel19.Visible = false;
                listBox1.Enabled = true;

            }
            catch
            {
                cn.Close();
                string message = "As datas inseridas não fazem sentido!\n";
                string title = "Alert Window";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            updateLeitoresAtividade();
        }

        private void updateLeitoresAtividade()
        {
            groupsVisibleFalse();
            groupBox13.Visible = true;
            listBox1.Enabled = false;
            panel18.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            Atividade atividade = (Atividade)listBox1.SelectedItem;
            textBox87.Text = atividade.NomeAtividade;

            if (!verifySGBDConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("select * from Biblestia.leitoresAtividades('" + atividade.NomeAtividade + "','" + biblioteca.Nome + "')", cn);

            SqlDataReader reader = cmd.ExecuteReader();

            listBox9.Items.Clear();
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
                listBox9.Items.Add(leitor);
            }
            reader.Close();
            cn.Close();
            if (listBox9.Items.Count > 0)
            {
                listBox9.SelectedIndex = 0;
            }
        }

        private void listBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox9.Items.Count > 0 && listBox9.SelectedIndex > -1)
            {
                Leitor leitor = (Leitor)listBox9.SelectedItem;

                textBox85.Text = leitor.IdLeitor;
                textBox86.Text = leitor.NomeCompleto;
            }
        }
        private void button51_Click(object sender, EventArgs e)
        {
            if (listBox9.Items.Count > 0 && listBox9.SelectedIndex > -1)
            {

                label114.Enabled = false;
                textBox85.Clear();
                textBox85.ReadOnly = false;
                listBox9.ClearSelected();
                button52.Visible = true;
                button53.Visible = true;
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            try
            {
                Atividade atividade = (Atividade)listBox1.SelectedItem;
                SqlCommand cmd = new SqlCommand("Biblestia.adicionarParticipacao", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", atividade.NomeBiblioteca));
                cmd.Parameters.Add(new SqlParameter("@nomeAtividade", atividade.NomeAtividade));
                cmd.Parameters.Add(new SqlParameter("@idLeitor", textBox85.Text));
                cmd.ExecuteNonQuery();
                cn.Close();

                label114.Enabled = true;
                textBox85.ReadOnly = true;
                button52.Visible = false;
                button53.Visible = false;

                updateLeitoresAtividade();
            }
            catch
            {
                cn.Close();
                string message = "O ID inserido não é válido!\n";
                string title = "Alert Window";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            label114.Enabled = true;
            textBox85.ReadOnly = true;
            button52.Visible = false;
            button53.Visible = false;

            updateLeitoresAtividade();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (listBox9.Items.Count > 0 && listBox9.SelectedIndex > -1)
            {

                if (!verifySGBDConnection())
                {
                    return;
                }
                Leitor leitor = (Leitor)listBox9.SelectedItem;
                Atividade atividade = (Atividade)listBox1.SelectedItem;

                SqlCommand cmd = new SqlCommand("Biblestia.removerParticipacao", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nomeBiblioteca", atividade.NomeBiblioteca));
                cmd.Parameters.Add(new SqlParameter("@nomeAtividade", atividade.NomeAtividade));
                cmd.Parameters.Add(new SqlParameter("@idLeitor", leitor.IdLeitor));
                cmd.ExecuteNonQuery();
                cn.Close();

                listBox9.Items.Remove(listBox9.SelectedItem);
                listBox9.SelectedIndex = 0;
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            groupBox12.Visible = true;
            listBox1.Enabled = true;
            panel18.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }
        private void button46_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }

            groupsVisibleFalse();
            groupBox14.Visible = true;
            panel18.Enabled = false;
            listBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterScoreLeitor('" + biblioteca.Nome + "') order by score desc", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Leitor leitor = new Leitor();
            textBox90.Text = reader["nomeBiblioteca"].ToString();
            textBox92.Text = reader["nif"].ToString();
            textBox89.Text = reader["nomeCompleto"].ToString();
            textBox93.Text = reader["email"].ToString();
            string nAtividadesLeitor = reader["contAti"].ToString();
            textBox88.Text = nAtividadesLeitor;
            string nRequisicoesLeitor = reader["contReq"].ToString();
            textBox95.Text = nRequisicoesLeitor;
            reader.Close();
            cn.Close();

            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd2 = new SqlCommand("select * from Biblestia.nAtividades('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            reader2.Read();
            string nAtividades = reader2["cont"].ToString();
            reader2.Close();
            cn.Close();

            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd3 = new SqlCommand("select * from Biblestia.nRequisicoes('" + biblioteca.Nome + "')", cn);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            reader3.Read();
            string nRequisicoes = reader3["cont"].ToString();
            reader3.Close();
            cn.Close();

            double taxaParticipacao = ((double.Parse(nAtividadesLeitor) / double.Parse(nAtividades)) * 100);
            double taxaRequisicao = ((double.Parse(nRequisicoesLeitor) / double.Parse(nRequisicoes)) * 100);

            textBox91.Text = String.Format("{0:0.##} %", taxaParticipacao);
            textBox94.Text = String.Format("{0:0.##} %", taxaRequisicao);

        }

        private void button54_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            groupBox12.Visible = true;
            panel18.Enabled = true;
            listBox1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }
        private void button21_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            groupBox15.Visible = true;
            panel4.Enabled = false;
            listBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            Leitor leitor = (Leitor)listBox1.SelectedItem;
            textBox97.Text = leitor.IdLeitor;
            textBox98.Text = leitor.NomeCompleto;
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd = new SqlCommand("select * from Biblestia.obterAtividadesLeitor(" + leitor.IdLeitor + ",'" + biblioteca.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox10.Items.Clear();
            while (reader.Read())
            {
                Atividade atividade = new Atividade();
                atividade.NomeAtividade = reader["nomeAtividade"].ToString();
                atividade.NomeBiblioteca = reader["nomeBiblioteca"].ToString();
                atividade.DataAtividade = reader["dataAtividade"].ToString();
                atividade.Tematica = reader["tematica"].ToString();
                atividade.DuracaoMin = reader["duracaoMin"].ToString();
                atividade.IdFuncResponsavel = reader["idFuncResponsavel"].ToString();
                listBox10.Items.Add(atividade);
            }
            reader.Close();
            cn.Close();

            if (listBox10.Items.Count > 0)
            {
                listBox10.SelectedIndex = 0;
            }
        }

        private void listBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox10.Items.Count > 0 && listBox10.SelectedIndex > -1)
            {
                Atividade atividade = (Atividade)listBox10.SelectedItem;

                textBox101.Text = atividade.NomeAtividade;
                textBox100.Text = atividade.Tematica;
                if (atividade.DataAtividade == "")
                {
                    dateTimePicker21.Format = DateTimePickerFormat.Custom;
                    dateTimePicker21.CustomFormat = " ";
                }
                else
                {
                    dateTimePicker21.Format = DateTimePickerFormat.Custom;
                    dateTimePicker21.CustomFormat = "yyyy-MM-dd";
                    dateTimePicker21.Text = atividade.DataAtividade;
                }
            }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            groupsVisibleFalse();
            groupBox4.Visible = true;
            panel4.Enabled = true;
            listBox1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }
    }
}