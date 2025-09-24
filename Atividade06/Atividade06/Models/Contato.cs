using System;
using System.Collections.Generic;

namespace Atividade06.Models
{
    public class Contato
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public Data DtNasc { get; set; }
        public List<Telefone> Telefones { get; private set; }

        public Contato()
        {
            Telefones = new List<Telefone>();
        }

        public int GetIdade()
        {
            var hoje = DateTime.Today;
            var nascimento = new DateTime(DtNasc.Ano, DtNasc.Mes, DtNasc.Dia);
            int idade = hoje.Year - nascimento.Year;
            if (nascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }

        public void AdicionarTelefone(Telefone t)
        {
            Telefones.Add(t);
        }

        public string GetTelefonePrincipal()
        {
            var tel = Telefones.Find(t => t.Principal);
            return tel != null ? tel.Numero : "Nenhum principal definido";
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Email: {Email}, Nascimento: {DtNasc}, Idade: {GetIdade()}, Telefone Principal: {GetTelefonePrincipal()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Contato c)
                return c.Email == this.Email;
            return false;
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode();
        }
    }
}
