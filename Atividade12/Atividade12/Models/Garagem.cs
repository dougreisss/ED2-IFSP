using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Atividade12.Models
{
    public class Garagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public Queue<Veiculo> Veiculos { get; set; }

        public Garagem()
        {
            Veiculos = new Queue<Veiculo>();
        }
        public Garagem(int id)
        {
            Id = id;
            Veiculos = new Queue<Veiculo>();
        }

        public Garagem(int id, string nome, string localizacao, Queue<Veiculo> veiculos)
        {
            Id = id;
            Nome = nome;
            Localizacao = localizacao;
            Veiculos = veiculos;
        }

        public override string ToString()
        {
            string veiculosFormatado = "";

            foreach (var veiculo in Veiculos)
            {
                veiculosFormatado += $"{veiculo.ToString()}, "; 
            }

            return $"{Id} - {Nome} - {Localizacao} - Veiculos: {veiculosFormatado}";
        }

        public override bool Equals(object obj)
        {
            return Id.Equals(((Garagem)obj).Id);
        }
    }
}
