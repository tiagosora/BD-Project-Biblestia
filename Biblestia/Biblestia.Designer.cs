
namespace Biblestia
{
    partial class Biblestia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Biblestia));
            this.selecao = new System.Windows.Forms.ComboBox();
            this.pass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.entrar = new System.Windows.Forms.Button();
            this.addbiblioteca = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selecao
            // 
            this.selecao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selecao.FormattingEnabled = true;
            this.selecao.ItemHeight = 16;
            this.selecao.Location = new System.Drawing.Point(359, 190);
            this.selecao.Name = "selecao";
            this.selecao.Size = new System.Drawing.Size(299, 24);
            this.selecao.TabIndex = 0;
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(359, 270);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(299, 22);
            this.pass.TabIndex = 1;
            this.pass.UseSystemPasswordChar = true;
            this.pass.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleciona uma biblioteca";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Palavra-passe";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password Biblioteca Universitária de Aveiro: 123";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // entrar
            // 
            this.entrar.Location = new System.Drawing.Point(359, 327);
            this.entrar.Name = "entrar";
            this.entrar.Size = new System.Drawing.Size(142, 48);
            this.entrar.TabIndex = 5;
            this.entrar.Text = "Entrar";
            this.entrar.UseVisualStyleBackColor = true;
            this.entrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // addbiblioteca
            // 
            this.addbiblioteca.Location = new System.Drawing.Point(516, 327);
            this.addbiblioteca.Name = "addbiblioteca";
            this.addbiblioteca.Size = new System.Drawing.Size(142, 48);
            this.addbiblioteca.TabIndex = 7;
            this.addbiblioteca.Text = "Adicionar\r\nBiblioteca";
            this.addbiblioteca.UseVisualStyleBackColor = true;
            this.addbiblioteca.Click += new System.EventHandler(this.addbiblioteca_Click);
            // 
            // Biblestia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Biblestia.Properties.Resources.plural_mundo_de_livros;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1033, 569);
            this.Controls.Add(this.addbiblioteca);
            this.Controls.Add(this.entrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.selecao);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Biblestia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to Biblestia";
            this.Load += new System.EventHandler(this.Biblestia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selecao;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button entrar;
        private System.Windows.Forms.Button addbiblioteca;
    }
}