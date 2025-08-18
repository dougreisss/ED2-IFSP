namespace Atividade01
{
    public partial class frmBilheteria : Form
    {
        private const int FILEIRAS = 15;
        private const int POLTRONAS = 40;

        private Label lblMapaOcupacao;
        private Label lblFaturamento;
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
            lblMapaOcupacao.Top = 10;
            lblMapaOcupacao.Left = 5;
            lblMapaOcupacao.Width = 120;
            lblMapaOcupacao.Parent = this;
        }

        private void CreateCbxOcupacao()
        {
            cbxOcupacao = new CheckBox[FILEIRAS, POLTRONAS];

            for (int i = 0; i < FILEIRAS; i++)
            {
                for (int j = 0; j < POLTRONAS; j++)
                {
                    cbxOcupacao[i, j] = new CheckBox();
                    cbxOcupacao[i, j].Top = (i * 20) + 40;
                    cbxOcupacao[i, j].Left = (j * 30) + 10;
                    cbxOcupacao[i, j].Width = 20;
                    cbxOcupacao[i, j].Tag = $"{i};{j}";
                    cbxOcupacao[i, j].Name = $"cbxOcupacao{i}_{j}";

                    //if (j == 0)
                    //{
                    //    cbxOcupacao[i, j].RightToLeft = RightToLeft.Yes;
                    //    cbxOcupacao[i, j].Text = (i + 1).ToString();
                    //}

                    cbxOcupacao[i, j].Parent = this;

                }
            }
        }

        private void CbxOcupacaoClick(object sender, EventArgs e)
        {
            // todo
        }

        private void CreateBtnFaturamento()
        {
            btnFaturamento = new Button();
            btnFaturamento.Text = "Verificar faturamento";
            btnFaturamento.Name = "BtnFaturamento";
            btnFaturamento.Top = 345;
            btnFaturamento.Left = 5;
            btnFaturamento.Width = 180;
            btnFaturamento.Click += new EventHandler(BtnFaturamentoClick);
            btnFaturamento.Parent = this;
        }
        private void BtnFaturamentoClick(object sender, EventArgs e)
        {
            decimal valorFaturamento = 0;
            CreateLblFaturamento(valorFaturamento);
        }

        private void CreateLblFaturamento(decimal valorFaturamento)
        {
            lblFaturamento = new Label();
            lblFaturamento.Text = $"Valor total do faturamento: {valorFaturamento.ToString("c2")}";
            lblFaturamento.TextAlign = ContentAlignment.BottomCenter;
            lblFaturamento.Top = 340;
            lblFaturamento.Left = 190;
            lblFaturamento.Width = 200;
            lblFaturamento.Parent = this;
        }
    }
}
