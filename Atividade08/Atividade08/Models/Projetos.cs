using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade08.Models
{
    public class Projetos
    {
        public List<Projeto> Itens { get; set; }

        public Projetos()
        {
            Itens = new List<Projeto>();
        }

        public bool Adicionar(Projeto p)
        {
            if (!Itens.Contains(p))
            {
                Itens.Add(p);
                return true;
            }

            return false;
        }

        public bool Remover(Projeto p)
        {
            bool podeRemover = Itens.Any(x => x.Tarefas.Any(t => t.Status == "Aberta"));

            if (!podeRemover) 
            {
                Itens.Remove(p); 
                return true; 
            }

            return false;
        }

        public Projeto Buscar(Projeto p)
        {
            Projeto projetoEncontrado = new Projeto();

            foreach (var item in Itens)
            {
                if (item.Equals(p))
                {
                    projetoEncontrado = item;
                    break;
                }
            }

            return projetoEncontrado;
        }

        public List<Projeto> Listar()
        {
            return Itens;
        }
    }
}
