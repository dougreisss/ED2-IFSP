using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade07.Models
{
    public class Livros
    {
        public List<Livro> Acervo { get; set; }

        public Livros()
        {
            Acervo = new List<Livro>();
        }

        public void Adicionar(Livro livro)
        {
            Acervo.Add(livro);
        }

        public Livro Pesquisar(Livro livro)
        {
            return Acervo.FirstOrDefault(l => l.Equals(livro));
        }
    }
}
