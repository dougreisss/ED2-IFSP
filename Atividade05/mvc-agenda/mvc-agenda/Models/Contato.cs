using mvc_agenda.Models;
using System.Collections.Generic;
using System.Text;

namespace mvc_agenda.Models
{
    public class Contato
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public Data DtNasc { get; set; }
        public List<Telefone> Telefones { get; set; } = new List<Telefone>();

        public Contato() { }

        public Contato(string email, string nome, Data dtNasc)
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
        }

        public int GetIdade()
        {
            var hoje = DateTime.Now;
            int idade = hoje.Year - DtNasc.Ano;
            if (hoje.Month < DtNasc.Mes || (hoje.Month == DtNasc.Mes && hoje.Day < DtNasc.Dia))
                idade--;
            return idade;
        }

        public void AdicionarTelefone(Telefone t) => Telefones.Add(t);

        public string GetTelefonePrincipal()
        {
            var tel = Telefones.Find(t => t.Principal);
            return tel != null ? tel.Numero : "(sem principal)";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Nome: {Nome}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Nascimento: {DtNasc} ({GetIdade()} anos)");
            sb.AppendLine($"Telefone principal: {GetTelefonePrincipal()}");
            sb.AppendLine("Todos os telefones:");
            foreach (var t in Telefones)
                sb.AppendLine("  " + t);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Contato c)
                return Email.Equals(c.Email, StringComparison.OrdinalIgnoreCase);
            return false;
        }

        public override int GetHashCode() => Email.ToLower().GetHashCode();
    }
}
