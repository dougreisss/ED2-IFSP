using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade07.Models
{
    public class Livro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public List<Exemplar> Exemplares { get; set; }

        public Livro() : this(0, "", "", "")
        {
        }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Exemplares = new List<Exemplar>();
        }

        public void AdicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }

        public int QtdExemplares() => Exemplares.Count;
        
        public int QtdDisponiveis() => Exemplares.Count(exemplar => exemplar.Disponivel());

        public int QtdEmprestimos() => Exemplares.Sum(exemplar => exemplar.Emprestimos.Count); 
        
        public double PercDisponibilidade()
        {
            return (QtdDisponiveis() / QtdExemplares());
        }

        public override bool Equals(object obj)
        {
            return Isbn.Equals(((Livro)obj).Isbn);
        }
        public override string ToString()
        {
            return $"ISBN: {Isbn}\nTitulo: {Titulo}\nAutor: {Autor}\nEditora: {Editora}\nTotal de exemplares: {QtdExemplares()}\nTotal de exemplares disponíveis: {QtdDisponiveis()}\nTotal de empréstimos: {QtdEmprestimos()}\nPercentual de disponibilidade: {PercDisponibilidade() * 100}%";
        }
    }
}
