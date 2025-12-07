using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade12.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string NomeMotorista { get; set; }
        public int QtdLotacaoMax { get; set; }

        public Veiculo()
        {
            
        }

        public Veiculo(string placa)
        {
            Placa = placa;
        }

        public Veiculo(string placa, string modelo, string nomeMotorista, int qtdLotacaoMax)
        {
            Placa = placa;
            Modelo = modelo;
            NomeMotorista = nomeMotorista;
            QtdLotacaoMax = qtdLotacaoMax;
        }

        public override string ToString()
        {
            return $"{Placa} - {Modelo} - {NomeMotorista:20} - {QtdLotacaoMax}";
        }

        public override bool Equals(object obj)
        {
            return Placa.Equals(((Veiculo)obj).Placa);
        }
    }
}
