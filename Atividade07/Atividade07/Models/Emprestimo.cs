using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade07.Models
{
    public class Emprestimo
    {
        public DateTime DtEmprestimo { get; set; }
        public DateTime DtDevolucao { get; set; }

        public Emprestimo() : this(DateTime.Now, DateTime.Now.AddDays(7))
        {

        }

        public Emprestimo(DateTime dtEmprestimo, DateTime dtDevolucao)
        {
            DtEmprestimo = dtEmprestimo;
            DtDevolucao = dtDevolucao;
        }

        public override string ToString()
        {
            return $"{DtEmprestimo.ToString("G")} - {DtDevolucao.ToString("G")}";
        }
    }
}
