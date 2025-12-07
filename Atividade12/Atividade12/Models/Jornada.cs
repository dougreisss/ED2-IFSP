using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Atividade12.Models
{
    public class Jornada
    {
        public int Id { get; set; }
        public DateTime Diaria { get; set; }
        public Queue<Viagem> Viagems { get; set; }
        public bool Finalizada { get; set; }

        public Jornada()
        {
            Viagems = new Queue<Viagem>();
        }
        public Jornada(int id, DateTime diaria, Queue<Viagem> viagems, bool finalizada)
        {
            Id = id;
            Diaria = diaria;
            Viagems = viagems;
            Finalizada = finalizada;
        }

        public override bool Equals(object obj)
        {
            return Id.Equals(((Jornada)obj).Id);
        }
    }
}
