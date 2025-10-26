using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade09.Model
{
    public class Senhas
    {
        public int proxAtendimento { get; set; }
        public Queue<Senha> filaSenhas { get; set; }

        public Senhas()
        {
            filaSenhas = new Queue<Senha>();
            proxAtendimento = 0;
        }

        public void Gerar()
        {
            proxAtendimento++;
            filaSenhas.Enqueue(new Senha(proxAtendimento));
        }
    }
}
