using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade08.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public List<Tarefa> Tarefas { get; set; }

        public Projeto() : this(0, "")
        {
            
        }

        public Projeto(int id) : this(id, "")
        {
            
        }

        public Projeto(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Tarefas = new List<Tarefa>();
        }

        public void AdicionarTarefa(Tarefa t)
        {
            Tarefas.Add(t);                     
        }

        public bool RemoverTarefa(Tarefa t)
        {
            Tarefa tarefaEncontrada = new Tarefa();

            tarefaEncontrada = BuscarTarefa(tarefaEncontrada);

            if (tarefaEncontrada.Id != 0 && tarefaEncontrada.Status == "Cancelada")
            {
                Tarefas.Remove(t);
                return true;
            }

            return false;
        }

        public Tarefa? BuscarTarefa(Tarefa t)
        {
            Tarefa? tarefaEncontrada = null;

            foreach (var tarefa in Tarefas)
            {
                if (tarefa.Equals(t))
                {
                    tarefaEncontrada = tarefa;
                    break;
                }
            }

            return tarefaEncontrada;
        }

        public List<Tarefa> TarefasPorStatus(string s)
        {
            List<Tarefa> tarefasEncontradas = new List<Tarefa>();

            tarefasEncontradas = Tarefas.Where(t => t.Status == s).ToList();

            return tarefasEncontradas;
        }

        public List<Tarefa> TarefasPorPrioridade(int p)
        {
            List<Tarefa> tarefasEncontradas = new List<Tarefa>();

            tarefasEncontradas = Tarefas.Where(t => t.Prioridade == p).ToList();

            return tarefasEncontradas;
        }
        public int TotalAbertas() => Tarefas.Where(t => t.Status == "Aberta").Count();
        public int TotalFechadas() => Tarefas.Where(t => t.Status == "Fechada").Count();
        public int TotalCanceladas() => Tarefas.Where(t => t.Status == "Cancelada").Count();

        public override bool Equals(object obj)
        {
            return Id.Equals(((Projeto)obj).Id);
        }

        public override string ToString()
        {
            string tarefasFormatadas = string.Join("\n", Tarefas.Select(t => t.ToString()));

            string resultadoFormatado = $"Projeto:\n Id: {Id} " +
                                        $"- Nome: {Nome}" +
                                        $"\nTarefas:\n {tarefasFormatadas ?? "-"}" +
                                        $"\nTotais de tarefas abertas: {TotalAbertas()}" +
                                        $"\nTotais de tarefas fechadas: {TotalFechadas()}" +
                                        $"\nTotais de tarefas canceladas: {TotalCanceladas()}";

            return resultadoFormatado;
        }
    }
}
