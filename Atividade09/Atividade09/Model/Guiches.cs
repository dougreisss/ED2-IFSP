using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade09.Model
{
    public class Guiches
    {
        public List<Guiche> listaGuiches { get; set; }

        public Guiches()
        {
            listaGuiches = new List<Guiche>();  
        }

        public void Adicionar(Guiche guiche)
        {
            listaGuiches.Add(guiche);   
        }
    }
}
