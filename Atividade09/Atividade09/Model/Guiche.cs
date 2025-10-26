using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade09.Model
{
    public class Guiche
    {
        public int Id { get; set; }
        public Queue<Senha> Atendimentos { get; }

        public Guiche(int id)
        {
            this.Id = id;
            this.Atendimentos = new Queue<Senha>();
        }

        public bool Chamar(Queue<Senha> filaSenhas)
        {
            if (filaSenhas.Count == 0)
            {
                return false;
            }

            Senha? senha = filaSenhas.Dequeue();

            senha.Atender();

            Atendimentos.Enqueue(senha);

            return true;
        }
    }
}
