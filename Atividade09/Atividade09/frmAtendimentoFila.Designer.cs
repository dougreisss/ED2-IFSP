namespace Atividade09
{
    partial class frmAtendimentoFila
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
            btnGerarSenha = new Button();
            lstSenhas = new ListBox();
            btnListarSenha = new Button();
            btnAddGuiche = new Button();
            label1 = new Label();
            lblQtdGuiche = new Label();
            lstAtendimento = new ListBox();
            btnListarAtendimento = new Button();
            label3 = new Label();
            txtGuiche = new TextBox();
            btnChamarSenha = new Button();
            SuspendLayout();
            // 
            // btnGerarSenha
            // 
            btnGerarSenha.Location = new Point(12, 12);
            btnGerarSenha.Name = "btnGerarSenha";
            btnGerarSenha.Size = new Size(173, 23);
            btnGerarSenha.TabIndex = 0;
            btnGerarSenha.Text = "Gerar Senha";
            btnGerarSenha.UseVisualStyleBackColor = true;
            btnGerarSenha.Click += btnGerarSenha_Click;
            // 
            // lstSenhas
            // 
            lstSenhas.FormattingEnabled = true;
            lstSenhas.Location = new Point(12, 41);
            lstSenhas.Name = "lstSenhas";
            lstSenhas.Size = new Size(173, 139);
            lstSenhas.TabIndex = 1;
            // 
            // btnListarSenha
            // 
            btnListarSenha.Location = new Point(12, 186);
            btnListarSenha.Name = "btnListarSenha";
            btnListarSenha.Size = new Size(173, 23);
            btnListarSenha.TabIndex = 2;
            btnListarSenha.Text = "Listar Senha";
            btnListarSenha.UseVisualStyleBackColor = true;
            btnListarSenha.Click += btnListarSenha_Click;
            // 
            // btnAddGuiche
            // 
            btnAddGuiche.Location = new Point(191, 93);
            btnAddGuiche.Name = "btnAddGuiche";
            btnAddGuiche.Size = new Size(107, 23);
            btnAddGuiche.TabIndex = 3;
            btnAddGuiche.Text = "Adicionar Guichê";
            btnAddGuiche.UseVisualStyleBackColor = true;
            btnAddGuiche.Click += btnAddGuiche_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(191, 41);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 4;
            label1.Text = "Qtde Guichê(s)";
            // 
            // lblQtdGuiche
            // 
            lblQtdGuiche.AutoSize = true;
            lblQtdGuiche.Location = new Point(200, 66);
            lblQtdGuiche.Name = "lblQtdGuiche";
            lblQtdGuiche.Size = new Size(0, 15);
            lblQtdGuiche.TabIndex = 5;
            // 
            // lstAtendimento
            // 
            lstAtendimento.FormattingEnabled = true;
            lstAtendimento.Location = new Point(314, 41);
            lstAtendimento.Name = "lstAtendimento";
            lstAtendimento.Size = new Size(474, 139);
            lstAtendimento.TabIndex = 6;
            // 
            // btnListarAtendimento
            // 
            btnListarAtendimento.Location = new Point(314, 186);
            btnListarAtendimento.Name = "btnListarAtendimento";
            btnListarAtendimento.Size = new Size(474, 23);
            btnListarAtendimento.TabIndex = 7;
            btnListarAtendimento.Text = "Listar Atendimento";
            btnListarAtendimento.UseVisualStyleBackColor = true;
            btnListarAtendimento.Click += btnListarAtendimento_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(314, 16);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 8;
            label3.Text = "Guichê:";
            // 
            // txtGuiche
            // 
            txtGuiche.Location = new Point(367, 13);
            txtGuiche.Name = "txtGuiche";
            txtGuiche.Size = new Size(62, 23);
            txtGuiche.TabIndex = 9;
            // 
            // btnChamarSenha
            // 
            btnChamarSenha.Location = new Point(435, 13);
            btnChamarSenha.Name = "btnChamarSenha";
            btnChamarSenha.Size = new Size(98, 23);
            btnChamarSenha.TabIndex = 10;
            btnChamarSenha.Text = "Chamar Senha";
            btnChamarSenha.UseVisualStyleBackColor = true;
            btnChamarSenha.Click += btnChamarSenha_Click;
            // 
            // frmAtendimentoFila
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 219);
            Controls.Add(btnChamarSenha);
            Controls.Add(txtGuiche);
            Controls.Add(label3);
            Controls.Add(btnListarAtendimento);
            Controls.Add(lstAtendimento);
            Controls.Add(lblQtdGuiche);
            Controls.Add(label1);
            Controls.Add(btnAddGuiche);
            Controls.Add(btnListarSenha);
            Controls.Add(lstSenhas);
            Controls.Add(btnGerarSenha);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAtendimentoFila";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Atendimento de Filas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGerarSenha;
        private ListBox lstSenhas;
        private Button btnListarSenha;
        private Button btnAddGuiche;
        private Label label1;
        private Label lblQtdGuiche;
        private ListBox lstAtendimento;
        private Button btnListarAtendimento;
        private Label label3;
        private TextBox txtGuiche;
        private Button btnChamarSenha;
    }
}
