using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade08.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public int Prioridade { get; set; }
        public string? Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }


        public Tarefa() : this(0, "", 0, "", DateTime.Now, null)
        {

        }

        public Tarefa(int id) : this (id, "", 0, "", DateTime.Now, null)
        {
            
        }

        public Tarefa(int id, string descricao, int prioridade, string status, DateTime dataCriacao, DateTime? dataConclusao)
        {
            Id = id;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = status;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
        }

        public void Concluir()
        {
            Status = "Fechada";
            DataConclusao = DateTime.Now;
        }

        public void Cancelar()
        {
            Status = "Cancelada";
            DataConclusao = DateTime.Now;
        }

        public void Reabir()
        {
            Status = "Aberta";
        }

        public override string ToString()
        {
            string resultadoFormatado = $"Id: {Id} " +
                                        $"- Descrição: {Descricao} " +
                                        $"- Prioridade: {Prioridade} " +
                                        $"- Status: {Status}" +
                                        $"\nData de criação: {DataCriacao.ToString("G")} " +
                                        $"- Data de conclusão: {DataConclusao?.ToString("G") ?? "-"}";

            return resultadoFormatado;
        }

        public override bool Equals(object obj)
        {
            return Id.Equals(((Tarefa)obj).Id);
        }
    }
}
