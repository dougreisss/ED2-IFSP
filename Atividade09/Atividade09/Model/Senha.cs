using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade09.Model
{
    public class Senha
    {
        public int Id { get; set; }
        public DateOnly DataGeracao { get; set; }
        public TimeOnly HoraGeracao { get; set; }
        public DateOnly DataAtendimento { get; set; }
        public TimeOnly HoraAtendimento { get; set; }

        public Senha(int id)
        {
            this.Id = id;
            this.DataGeracao = DateOnly.FromDateTime(DateTime.Now);
            this.HoraGeracao = TimeOnly.FromDateTime(DateTime.Now);
        }

        public string DadosParciais()
        {
            return $"{this.Id} - {this.DataGeracao} - {this.HoraGeracao}";
        }

        public string DadosCompletos()
        {
            return $"{DadosParciais()} - {this.DataAtendimento} - {this.HoraAtendimento}";
        }

        public void Atender()
        {
            this.DataAtendimento = DateOnly.FromDateTime(DateTime.Now);
            this.HoraAtendimento = TimeOnly.FromDateTime(DateTime.Now);
        }
    }
}
