namespace Atividade06.Models
{
    public class Telefone
    {
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public bool Principal { get; set; }

        public override string ToString()
        {
            return $"{Tipo}: {Numero}" + (Principal ? " (Principal)" : "");
        }
    }
}
