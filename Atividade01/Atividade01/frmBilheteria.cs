namespace Atividade01
{
    public partial class frmBilheteria : Form
    {
        private const int FILEIRAS = 15;
        private const int POLTRONAS = 40;

        private Label lblMapaOcupacao;
        private Label lblFaturamento;
        private Label lblMapaFileira;
        private Label lblMapaPoltronas;

        private CheckBox[,] cbxOcupacao;

        private Button btnFaturamento;
       
        public frmBilheteria()
        {
            InitializeComponent();
            InitializeBilheteriaComponent();
        }

        public void InitializeBilheteriaComponent()
        {
            CreateLblOcupacao();
            CreateCbxOcupacao();
            CreateBtnFaturamento();
        }

        private void CreateLblOcupacao()
        {
            lblMapaOcupacao = new Label();
            lblMapaOcupacao.Text = "Mapa de ocupação:";
            lblMapaOcupacao.Name = "lblMapaOcupacao";
            lblMapaOcupacao.Top = 5;
            lblMapaOcupacao.Left = 5;
            lblMapaOcupacao.Width = 120;
            lblMapaOcupacao.Parent = this;
        }

        private void CreateCbxOcupacao()
        {
            cbxOcupacao = new CheckBox[FILEIRAS, POLTRONAS];

            for (int i = 0; i < FILEIRAS; i++)
            {
                CreateLblFileira(i);

                for (int j = 0; j < POLTRONAS; j++)
                {
                    cbxOcupacao[i, j] = new CheckBox();
                    cbxOcupacao[i, j].Top = (i * 20) + 40;
                    cbxOcupacao[i, j].Left = (j * 30) + 25;
                    cbxOcupacao[i, j].Width = 15;
                    cbxOcupacao[i, j].Tag = $"{i};{j}";
                    cbxOcupacao[i, j].Name = $"cbxOcupacao{i}_{j}";
                    cbxOcupacao[i, j].Parent = this;

                    if (i == 0)
                    {
                        CreateLblPoltrona(j);
                    }
                }
            }
        }

        private void CreateLblPoltrona(int indexPoltrona)
        {
            lblMapaPoltronas = new Label();
            lblMapaPoltronas.Top = 25;
            lblMapaPoltronas.Left = (indexPoltrona * 30) + 25;
            lblMapaPoltronas.Width = 20;
            lblMapaPoltronas.Name = "lblMapaPoltronas";
            lblMapaPoltronas.Text = (indexPoltrona + 1).ToString();
            lblMapaPoltronas.Parent = this;
        }

        private void CreateLblFileira(int indexFileira)
        {
            lblMapaFileira = new Label();
            lblMapaFileira.Text = (indexFileira + 1).ToString();
            lblMapaFileira.Name = "lblMapaFileira";
            lblMapaFileira.Top = (indexFileira * 20) + 45;
            lblMapaFileira.Left = 5;
            lblMapaFileira.Width = 20;
            lblMapaFileira.Parent = this;
        }
        private void CreateBtnFaturamento()
        {
            btnFaturamento = new Button();
            btnFaturamento.Text = "Verificar faturamento";
            btnFaturamento.Name = "btnFaturamento";
            btnFaturamento.Top = 350;
            btnFaturamento.Left = 5;
            btnFaturamento.Width = 180;
            btnFaturamento.Click += new EventHandler(BtnFaturamentoClick);
            btnFaturamento.Parent = this;
        }
        private void BtnFaturamentoClick(object sender, EventArgs e)
        {
            decimal valorFaturamento = 0;
            int qtdLugaresOcupados = 0;

            for (int i = 0; i < FILEIRAS; i++)
            {
                for (int j = 0; j < POLTRONAS; j++)
                {
                    if (cbxOcupacao[i, j].Checked)
                    {
                        qtdLugaresOcupados++;

                        if (i >= 0 && i < 5)
                        {
                            valorFaturamento += 50;
                        } else if (i >= 5 && i < 10) {
                            valorFaturamento += 30;
                        }
                        else
                        {
                            valorFaturamento += 15;
                        }
                    }
                }
            }

            CreateLblFaturamento(valorFaturamento, qtdLugaresOcupados);

        }

        private void CreateLblFaturamento(decimal valorFaturamento, int qtdLugaresOcupados)
        {
            if (lblFaturamento == null)
            {
                lblFaturamento = new Label();
                lblFaturamento.TextAlign = ContentAlignment.MiddleLeft;
                lblFaturamento.Top = 350;
                lblFaturamento.Left = 190;
                lblFaturamento.Width = 600;
                lblFaturamento.Parent = this;
            }

            lblFaturamento.Text = $"Qtde de lugares ocupados: {qtdLugaresOcupados} - Valor da bilheteria: {valorFaturamento.ToString("c2")}";
        }
    }
}
