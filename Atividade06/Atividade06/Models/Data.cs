namespace Atividade06.Models
{
    public class Data
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public Data() { }

        public Data(int dia, int mes, int ano)
        {
            Dia = dia;
            Mes = mes;
            Ano = ano;
        }

        public override string ToString()
        {
            return $"{Dia:D2}/{Mes:D2}/{Ano}";
        }
    }
}
