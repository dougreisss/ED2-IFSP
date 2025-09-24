using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Atividade06.Models;

namespace Atividade06
{
    public partial class Form1 : Form
    {
        private Contatos contatos = new Contatos();
        private List<Telefone> tempTelefones = new List<Telefone>();

        public Form1()
        {
            InitializeComponent();
            InicializarGridSeNecessario();
            gridContatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridContatos.MultiSelect = false;
            gridContatos.AllowUserToAddRows = false;
            gridContatos.RowHeadersVisible = false;
        }

        private void InicializarGridSeNecessario()
        {
            if (gridContatos.Columns.Count == 0)
            {
                gridContatos.Columns.Add("colNome", "Nome");
                gridContatos.Columns.Add("colEmail", "Email");
                gridContatos.Columns.Add("colDataNasc", "Nascimento");
                gridContatos.Columns.Add("colTelefone", "Telefone Principal");
            }
        }

        private void btnAddTelefone_Click(object sender, EventArgs e)
        {
            var tipo = txtTipoTelefone.Text?.Trim();
            var numero = txtTelefone.Text?.Trim();
            var principal = chkPrincipalTelefone.Checked;

            if (string.IsNullOrEmpty(numero))
            {
                MessageBox.Show("Digite o número do telefone.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (principal)
            {
                foreach (var t in tempTelefones) t.Principal = false;
            }

            var tel = new Telefone { Tipo = string.IsNullOrEmpty(tipo) ? "Outro" : tipo, Numero = numero, Principal = principal };
            tempTelefones.Add(tel);
            AtualizarListaTelefonesTemp();

            txtTipoTelefone.Clear();
            txtTelefone.Clear();
            chkPrincipalTelefone.Checked = false;
        }

        private void AtualizarListaTelefonesTemp()
        {
            lstTelefones.Items.Clear();
            foreach (var t in tempTelefones)
                lstTelefones.Items.Add(t.ToString());
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text?.Trim();
            var nome = txtNome.Text?.Trim();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Nome e Email são obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var contato = new Contato
            {
                Email = email,
                Nome = nome,
                DtNasc = new Data(dtpNascimento.Value.Day, dtpNascimento.Value.Month, dtpNascimento.Value.Year)
            };

            foreach (var t in tempTelefones)
                contato.AdicionarTelefone(new Telefone { Tipo = t.Tipo, Numero = t.Numero, Principal = t.Principal });

            if (contatos.Adicionar(contato))
            {
                MessageBox.Show("Contato adicionado.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                AtualizarGrid();
            }
            else
            {
                MessageBox.Show("Já existe contato com esse e-mail.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text?.Trim();
            if (string.IsNullOrEmpty(email) && gridContatos.SelectedRows.Count > 0)
                email = gridContatos.SelectedRows[0].Cells["colEmail"].Value?.ToString();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Digite o email ou selecione uma linha para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var c = contatos.Pesquisar(email);
            if (c == null)
            {
                MessageBox.Show("Contato não encontrado.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PreencherInputsComContato(c);
            SelecionarLinhaPorEmail(email);
        }

        private void PreencherInputsComContato(Contato c)
        {
            txtNome.Text = c.Nome;
            txtEmail.Text = c.Email;
            dtpNascimento.Value = new DateTime(c.DtNasc.Ano, c.DtNasc.Mes, c.DtNasc.Dia);

            tempTelefones = c.Telefones.Select(t => new Telefone { Tipo = t.Tipo, Numero = t.Numero, Principal = t.Principal }).ToList();
            AtualizarListaTelefonesTemp();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text?.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Digite o email do contato que deseja alterar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var contatoExistente = contatos.Pesquisar(email);
            if (contatoExistente == null)
            {
                MessageBox.Show("Contato não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            contatoExistente.Nome = txtNome.Text?.Trim();
            contatoExistente.DtNasc = new Data(dtpNascimento.Value.Day, dtpNascimento.Value.Month, dtpNascimento.Value.Year);
            contatoExistente.Telefones.Clear();
            foreach (var t in tempTelefones)
                contatoExistente.AdicionarTelefone(new Telefone { Tipo = t.Tipo, Numero = t.Numero, Principal = t.Principal });

            MessageBox.Show("Contato alterado.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AtualizarGrid();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text?.Trim();
            if (string.IsNullOrEmpty(email) && gridContatos.SelectedRows.Count > 0)
                email = gridContatos.SelectedRows[0].Cells["colEmail"].Value?.ToString();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Digite o email ou selecione uma linha para remover.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contatos.Remover(email))
            {
                MessageBox.Show("Contato removido.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                AtualizarGrid();
            }
            else
            {
                MessageBox.Show("Contato não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AtualizarGrid()
        {
            gridContatos.Rows.Clear();
            foreach (var c in contatos.Agenda)
            {
                gridContatos.Rows.Add(c.Nome, c.Email, c.DtNasc.ToString(), c.GetTelefonePrincipal());
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            dtpNascimento.Value = DateTime.Today;
            tempTelefones.Clear();
            AtualizarListaTelefonesTemp();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void gridContatos_SelectionChanged(object sender, EventArgs e)
        {
            if (gridContatos.SelectedRows.Count == 0) return;
            var email = gridContatos.SelectedRows[0].Cells["colEmail"].Value?.ToString();
            if (!string.IsNullOrEmpty(email))
            {
                txtEmail.Text = email;
                var c = contatos.Pesquisar(email);
                if (c != null) PreencherInputsComContato(c);
            }
        }

        private void SelecionarLinhaPorEmail(string email)
        {
            foreach (DataGridViewRow row in gridContatos.Rows)
            {
                if ((row.Cells["colEmail"].Value?.ToString() ?? "") == email)
                {
                    row.Selected = true;
                    gridContatos.CurrentCell = row.Cells[0];
                    return;
                }
            }
        }
    }
}
