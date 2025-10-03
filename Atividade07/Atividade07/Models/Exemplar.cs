using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade07.Models
{
    public class Exemplar
    {
        public int Tombo { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }

        public Exemplar() : this(0) { }
       
        public Exemplar(int tombo)
        {
            Tombo = tombo;
            Emprestimos = new List<Emprestimo>();
        }

        public bool Emprestar()
        {
            if (!Disponivel())
            {
                return false;
            }

            Emprestimos.Add(new Emprestimo());

            return true;
        }

        public bool Devolver()
        {
            var ultimoEmprestimo = Emprestimos.LastOrDefault();

            if (ultimoEmprestimo != null && ultimoEmprestimo.DtDevolucao >= DateTime.Now)
            {
                int indexUltimoEmprestimo = Emprestimos.IndexOf(ultimoEmprestimo);
                Emprestimos[indexUltimoEmprestimo].DtDevolucao = DateTime.Now;

                return true;
            }

            return false;
        }

        public bool Disponivel()
        {
            var ultimoEmprestimo = Emprestimos.LastOrDefault();

            if (ultimoEmprestimo == null) { return true; }

            if (ultimoEmprestimo.DtDevolucao < DateTime.Now) { return true;  }

            return false;
        }

        public int QtdeEmprestimos()
        {
            return Emprestimos.Count;
        }

        public override bool Equals(object obj)
        {
            return Tombo.Equals(((Exemplar)obj).Tombo);
        }
        public override string ToString()
        {
            string retornoExemplarFormatado = $"Tombo: {Tombo}\n\tEmprestimos:";

            foreach (var emprestimo in Emprestimos)
            {
                retornoExemplarFormatado += "\n\t\t" + emprestimo.ToString();
            }


            return retornoExemplarFormatado;
        }
    }
}
