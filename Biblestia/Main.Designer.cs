
using System.Drawing;

namespace Biblestia
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bibliotecaName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.fnome = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.fid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fnif = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fssn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.femail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fmorada = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ftelefone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(832, 182);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(167, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "Requisições";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(28, 78);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(293, 420);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bibliotecaName
            // 
            this.bibliotecaName.AutoSize = true;
            this.bibliotecaName.Location = new System.Drawing.Point(25, 24);
            this.bibliotecaName.Name = "bibliotecaName";
            this.bibliotecaName.Size = new System.Drawing.Size(113, 17);
            this.bibliotecaName.TabIndex = 5;
            this.bibliotecaName.Text = "Estás logado em";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(832, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 46);
            this.button1.TabIndex = 9;
            this.button1.Text = "Funcionários";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(832, 130);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(167, 46);
            this.button4.TabIndex = 10;
            this.button4.Text = "Leitores";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(832, 286);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(167, 46);
            this.button5.TabIndex = 11;
            this.button5.Text = "Materiais";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(832, 433);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(167, 65);
            this.button6.TabIndex = 12;
            this.button6.Text = "Sair";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(470, 505);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(230, 35);
            this.button7.TabIndex = 13;
            this.button7.Text = "Novo Funcionário";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(356, 505);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(108, 35);
            this.button8.TabIndex = 172;
            this.button8.Text = "Editar";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(706, 505);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(101, 35);
            this.button9.TabIndex = 173;
            this.button9.Text = "Remover";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox6.Location = new System.Drawing.Point(145, 19);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(315, 26);
            this.textBox6.TabIndex = 174;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(832, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 46);
            this.button2.TabIndex = 175;
            this.button2.Text = "Atividades";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label12.Location = new System.Drawing.Point(25, 505);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 20);
            this.label12.TabIndex = 182;
            this.label12.Text = "Total";
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox8.Location = new System.Drawing.Point(28, 530);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(92, 26);
            this.textBox8.TabIndex = 182;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox9.Location = new System.Drawing.Point(128, 530);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(92, 26);
            this.textBox9.TabIndex = 183;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label13.Location = new System.Drawing.Point(125, 505);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 20);
            this.label13.TabIndex = 184;
            this.label13.Text = "Atuais";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox10.Location = new System.Drawing.Point(229, 530);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(92, 26);
            this.textBox10.TabIndex = 185;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label14.Location = new System.Drawing.Point(229, 505);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 20);
            this.label14.TabIndex = 186;
            this.label14.Text = "Perc. (%)";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Label2.Location = new System.Drawing.Point(12, 84);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 1);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(96, 20);
            this.Label2.TabIndex = 143;
            this.Label2.Text = "Nome";
            // 
            // fnome
            // 
            this.fnome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fnome.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.fnome.Location = new System.Drawing.Point(11, 106);
            this.fnome.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.fnome.Name = "fnome";
            this.fnome.ReadOnly = true;
            this.fnome.Size = new System.Drawing.Size(423, 26);
            this.fnome.TabIndex = 144;
            // 
            // Label11
            // 
            this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Label11.Location = new System.Drawing.Point(12, 27);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(96, 20);
            this.Label11.TabIndex = 159;
            this.Label11.Text = "ID";
            // 
            // fid
            // 
            this.fid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fid.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.fid.Location = new System.Drawing.Point(11, 50);
            this.fid.Margin = new System.Windows.Forms.Padding(4);
            this.fid.Name = "fid";
            this.fid.ReadOnly = true;
            this.fid.Size = new System.Drawing.Size(92, 26);
            this.fid.TabIndex = 160;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label8.Location = new System.Drawing.Point(121, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 20);
            this.label8.TabIndex = 161;
            this.label8.Text = "NIF";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // fnif
            // 
            this.fnif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fnif.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.fnif.Location = new System.Drawing.Point(120, 50);
            this.fnif.Margin = new System.Windows.Forms.Padding(4);
            this.fnif.Name = "fnif";
            this.fnif.ReadOnly = true;
            this.fnif.Size = new System.Drawing.Size(149, 26);
            this.fnif.TabIndex = 162;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.Location = new System.Drawing.Point(286, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 163;
            this.label3.Text = "SSN";
            // 
            // fssn
            // 
            this.fssn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fssn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.fssn.Location = new System.Drawing.Point(285, 50);
            this.fssn.Margin = new System.Windows.Forms.Padding(4);
            this.fssn.Name = "fssn";
            this.fssn.ReadOnly = true;
            this.fssn.Size = new System.Drawing.Size(149, 26);
            this.fssn.TabIndex = 164;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 165;
            this.label4.Text = "Email";
            // 
            // femail
            // 
            this.femail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.femail.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.femail.Location = new System.Drawing.Point(11, 165);
            this.femail.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.femail.Name = "femail";
            this.femail.ReadOnly = true;
            this.femail.Size = new System.Drawing.Size(423, 26);
            this.femail.TabIndex = 166;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label5.Location = new System.Drawing.Point(12, 201);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 167;
            this.label5.Text = "Morada";
            // 
            // fmorada
            // 
            this.fmorada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fmorada.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.fmorada.Location = new System.Drawing.Point(11, 223);
            this.fmorada.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.fmorada.Name = "fmorada";
            this.fmorada.ReadOnly = true;
            this.fmorada.Size = new System.Drawing.Size(423, 26);
            this.fmorada.TabIndex = 168;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.Location = new System.Drawing.Point(12, 257);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 169;
            this.label6.Text = "Telefone";
            // 
            // ftelefone
            // 
            this.ftelefone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ftelefone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.ftelefone.Location = new System.Drawing.Point(11, 280);
            this.ftelefone.Margin = new System.Windows.Forms.Padding(4);
            this.ftelefone.Name = "ftelefone";
            this.ftelefone.ReadOnly = true;
            this.ftelefone.Size = new System.Drawing.Size(215, 26);
            this.ftelefone.TabIndex = 170;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label7.Location = new System.Drawing.Point(235, 257);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 20);
            this.label7.TabIndex = 171;
            this.label7.Text = "Data de Nascimento";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(238, 280);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(144, 22);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dateTimePicker3);
            this.groupBox2.Location = new System.Drawing.Point(6, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 109);
            this.groupBox2.TabIndex = 176;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cargo Atual";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox7.Location = new System.Drawing.Point(9, 20);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(204, 26);
            this.textBox7.TabIndex = 175;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label10.Location = new System.Drawing.Point(9, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 180;
            this.label10.Text = "Fim";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(67, 53);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(144, 22);
            this.dateTimePicker2.TabIndex = 176;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label9.Location = new System.Drawing.Point(9, 54);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 1, 4, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 179;
            this.label9.Text = "Início";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Enabled = false;
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(67, 83);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(144, 22);
            this.dateTimePicker3.TabIndex = 177;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ftelefone);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.fmorada);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.femail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.fssn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.fnif);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.fid);
            this.groupBox1.Controls.Add(this.Label11);
            this.groupBox1.Controls.Add(this.fnome);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Location = new System.Drawing.Point(356, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 428);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionários";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 569);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bibliotecaName);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biblestia";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label bibliotecaName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        internal System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox textBox8;
        internal System.Windows.Forms.TextBox textBox9;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox textBox10;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox fnome;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox fid;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox fnif;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox fssn;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox femail;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox fmorada;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox ftelefone;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox textBox7;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}