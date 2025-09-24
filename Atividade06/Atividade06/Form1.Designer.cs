namespace Atividade06
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            dtpNascimento = new DateTimePicker();
            gridContatos = new DataGridView();
            colNome = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDataNasc = new DataGridViewTextBoxColumn();
            colTelefone = new DataGridViewTextBoxColumn();
            btnAdicionar = new Button();
            btnPesquisar = new Button();
            btnAlterar = new Button();
            btnRemover = new Button();
            btnListar = new Button();
            btnSair = new Button();
            label4 = new Label();
            txtTipoTelefone = new TextBox();
            txtTelefone = new TextBox();
            label5 = new Label();
            chkPrincipalTelefone = new CheckBox();
            btnAddTelefone = new Button();
            btnLimpar = new Button();
            lstTelefones = new ListBox();
            ((System.ComponentModel.ISupportInitialize)gridContatos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 24);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(181, 53);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(181, 86);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "Data Nasc:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(226, 21);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(226, 50);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 4;
            // 
            // dtpNascimento
            // 
            dtpNascimento.Format = DateTimePickerFormat.Short;
            dtpNascimento.Location = new Point(250, 82);
            dtpNascimento.Name = "dtpNascimento";
            dtpNascimento.Size = new Size(200, 23);
            dtpNascimento.TabIndex = 5;
            // 
            // gridContatos
            // 
            gridContatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridContatos.Columns.AddRange(new DataGridViewColumn[] { colNome, colEmail, colDataNasc, colTelefone });
            gridContatos.Dock = DockStyle.Bottom;
            gridContatos.Location = new Point(0, 300);
            gridContatos.Name = "gridContatos";
            gridContatos.Size = new Size(800, 150);
            gridContatos.TabIndex = 6;
            gridContatos.SelectionChanged += gridContatos_SelectionChanged;
            // 
            // colNome
            // 
            colNome.HeaderText = "Nome";
            colNome.Name = "colNome";
            colNome.Width = 150;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.Width = 200;
            // 
            // colDataNasc
            // 
            colDataNasc.HeaderText = "Nascimento";
            colDataNasc.Name = "colDataNasc";
            // 
            // colTelefone
            // 
            colTelefone.HeaderText = "Telefone Principal";
            colTelefone.Name = "colTelefone";
            colTelefone.Width = 150;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(53, 271);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(75, 23);
            btnAdicionar.TabIndex = 7;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(169, 271);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 8;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.Location = new Point(280, 271);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(75, 23);
            btnAlterar.TabIndex = 9;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(385, 271);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(75, 23);
            btnRemover.TabIndex = 10;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(571, 271);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(75, 23);
            btnListar.TabIndex = 11;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(665, 271);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(75, 23);
            btnSair.TabIndex = 12;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(181, 115);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 13;
            label4.Text = "Tipo:";
            // 
            // txtTipoTelefone
            // 
            txtTipoTelefone.Location = new Point(221, 112);
            txtTipoTelefone.Name = "txtTipoTelefone";
            txtTipoTelefone.Size = new Size(100, 23);
            txtTipoTelefone.TabIndex = 14;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(241, 141);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(100, 23);
            txtTelefone.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(181, 144);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 15;
            label5.Text = "Número:";
            // 
            // chkPrincipalTelefone
            // 
            chkPrincipalTelefone.AutoSize = true;
            chkPrincipalTelefone.Location = new Point(347, 144);
            chkPrincipalTelefone.Name = "chkPrincipalTelefone";
            chkPrincipalTelefone.Size = new Size(72, 19);
            chkPrincipalTelefone.TabIndex = 17;
            chkPrincipalTelefone.Text = "Principal";
            chkPrincipalTelefone.UseVisualStyleBackColor = true;
            // 
            // btnAddTelefone
            // 
            btnAddTelefone.Location = new Point(181, 170);
            btnAddTelefone.Name = "btnAddTelefone";
            btnAddTelefone.Size = new Size(124, 23);
            btnAddTelefone.TabIndex = 18;
            btnAddTelefone.Text = "Adicionar Telefone";
            btnAddTelefone.UseVisualStyleBackColor = true;
            btnAddTelefone.Click += btnAddTelefone_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(481, 271);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(75, 23);
            btnLimpar.TabIndex = 0;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // lstTelefones
            // 
            lstTelefones.FormattingEnabled = true;
            lstTelefones.ItemHeight = 15;
            lstTelefones.Location = new Point(425, 115);
            lstTelefones.Name = "lstTelefones";
            lstTelefones.Size = new Size(120, 94);
            lstTelefones.TabIndex = 19;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLimpar);
            Controls.Add(lstTelefones);
            Controls.Add(btnAddTelefone);
            Controls.Add(chkPrincipalTelefone);
            Controls.Add(txtTelefone);
            Controls.Add(label5);
            Controls.Add(txtTipoTelefone);
            Controls.Add(label4);
            Controls.Add(btnSair);
            Controls.Add(btnListar);
            Controls.Add(btnRemover);
            Controls.Add(btnAlterar);
            Controls.Add(btnPesquisar);
            Controls.Add(btnAdicionar);
            Controls.Add(gridContatos);
            Controls.Add(dtpNascimento);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)gridContatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNome;
        private TextBox txtEmail;
        private DateTimePicker dtpNascimento;
        private DataGridView gridContatos;
        private DataGridViewTextBoxColumn colNome;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDataNasc;
        private DataGridViewTextBoxColumn colTelefone;
        private Button btnAdicionar;
        private Button btnPesquisar;
        private Button btnAlterar;
        private Button btnRemover;
        private Button btnListar;
        private Button btnSair;
        private Label label4;
        private TextBox txtTipoTelefone;
        private TextBox txtTelefone;
        private Label label5;
        private CheckBox chkPrincipalTelefone;
        private Button btnAddTelefone;
        private Button btnLimpar;
        private ListBox lstTelefones;
    }
}
