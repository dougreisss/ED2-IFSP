using System.Windows.Forms;
using Atividade09.Model;

namespace Atividade09
{
    public partial class frmAtendimentoFila : Form
    {
        private Senhas senhas;
        private Guiches guiches;
        private int qtdGuiche;

        public frmAtendimentoFila()
        {
            InitializeComponent();

            senhas = new Senhas();
            guiches = new Guiches();
            qtdGuiche = 0;
            CarregarQtdeGuiches();
            lstAtendimento.Items.Clear();
            lstSenhas.Items.Clear();
        }

        private void btnGerarSenha_Click(object sender, EventArgs e)
        {
            senhas.Gerar();
            CarregarListSenhas();
        }

        private void btnAddGuiche_Click(object sender, EventArgs e)
        {
            Guiche guiche = new Guiche(++qtdGuiche);
            guiches.Adicionar(guiche);

            CarregarQtdeGuiches();
        }

        private void CarregarQtdeGuiches()
        {
            lblQtdGuiche.Text = qtdGuiche.ToString();
        }

        private void btnListarSenha_Click(object sender, EventArgs e)
        {
            CarregarListSenhas();
        }

        private void btnChamarSenha_Click(object sender, EventArgs e)
        {
            try
            {
                int idGuiche = GetGuicheDigitado();
                var guiche = guiches.listaGuiches.FirstOrDefault(g => g.Id == idGuiche);

                if (guiche == null)
                    throw new Exception("Guichê não encontrado");

                bool sucessoChamarSenha = guiche.Chamar(senhas.filaSenhas);

                if (!sucessoChamarSenha)
                    throw new Exception("Não há senhas a serem atendidas.");

                CarregarListSenhas();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnListarAtendimento_Click(object sender, EventArgs e)
        {
            try
            {
                int idGuiche = GetGuicheDigitado();
                var guiche = guiches.listaGuiches.FirstOrDefault(g => g.Id == idGuiche);

                if (guiche == null)
                    throw new Exception("Guichê não encontrado");


                CarregarListAtendimentos(guiche.Atendimentos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetGuicheDigitado()
        {
            int idGuiche = 0;

            if (string.IsNullOrEmpty(txtGuiche.Text))
                throw new Exception("Para chamar um atendimento é preciso preencher o campo guichê");

            if (!int.TryParse(txtGuiche.Text, out idGuiche))
                throw new Exception("O identificador do guichê deve ser um numero");

            return idGuiche;
        }

        private void CarregarListSenhas()
        {
            lstSenhas.Items.Clear();

            foreach (var senha in senhas.filaSenhas)
            {
                lstSenhas.Items.Add(senha.DadosParciais());
            }
        }

        private void CarregarListAtendimentos(Queue<Senha> senhasAtendidas)
        {
            lstAtendimento.Items.Clear();

            foreach (var senha in senhasAtendidas)
            {
                lstAtendimento.Items.Add(senha.DadosCompletos());
            }
        }
    }
}
