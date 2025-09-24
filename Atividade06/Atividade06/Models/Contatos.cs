using System.Collections.Generic;

namespace Atividade06.Models
{
    public class Contatos
    {
        public List<Contato> Agenda { get; private set; }

        public Contatos()
        {
            Agenda = new List<Contato>();
        }

        public bool Adicionar(Contato c)
        {
            if (Agenda.Contains(c)) return false;
            Agenda.Add(c);
            return true;
        }

        public Contato Pesquisar(string email)
        {
            return Agenda.Find(c => c.Email == email);
        }

        public bool Alterar(Contato c)
        {
            var existente = Pesquisar(c.Email);
            if (existente == null) return false;
            existente.Nome = c.Nome;
            existente.DtNasc = c.DtNasc;

            // Atualiza a lista de telefones do contato existente
            existente.Telefones.Clear();
            foreach (var telefone in c.Telefones)
            {
                existente.Telefones.Add(telefone);
            }
            return true;
        }

        public bool Remover(string email)
        {
            var c = Pesquisar(email);
            if (c == null) return false;
            Agenda.Remove(c);
            return true;
        }
    }
}
