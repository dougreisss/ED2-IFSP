using mvc_agenda.Models;
using System.Collections.Generic;

namespace mvc_agenda.Models
{
    public class Contatos
    {
        private List<Contato> agenda = new List<Contato>();

        public IReadOnlyList<Contato> Agenda => agenda.AsReadOnly();

        public bool Adicionar(Contato c)
        {
            if (agenda.Contains(c)) return false;
            agenda.Add(c);
            return true;
        }

        public Contato Pesquisar(Contato c)
        {
            return agenda.Find(x => x.Equals(c));
        }

        public bool Alterar(Contato c)
        {
            var existente = Pesquisar(c);
            if (existente == null) return false;
            existente.Nome = c.Nome;
            existente.DtNasc = c.DtNasc;
            existente.Telefones = c.Telefones;
            return true;
        }

        public bool Remover(Contato c)
        {
            return agenda.Remove(c);
        }
    }
}
