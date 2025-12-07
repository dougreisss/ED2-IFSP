using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Atividade12.Models
{
    public class Viagem
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime DataViagem { get; set; }
        public bool Liberada { get; set; }
        public DateTime DataLiberacao { get; set; }
        public int QtdPassageiros { get; set; }
        public Veiculo Veiculos { get; set; }

        public Viagem()
        {
            Veiculos = new Veiculo();
        }

        public Viagem(int id, string origem, string destino, DateTime dataViagem, int qtdPassageiros, Veiculo veiculo)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            QtdPassageiros = qtdPassageiros;
            Veiculos = veiculo;
        }
        public override string ToString()
        {
            return $"{Id} - {Origem} - {Destino} - {DataViagem} - {QtdPassageiros} - {Veiculos.ToString()}";
        }

        public override bool Equals(object obj)
        {
            return Id.Equals(((Viagem)obj).Id);
        }
    }
}
