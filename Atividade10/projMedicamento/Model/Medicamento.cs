using System;
using System.Collections.Generic;
using System.Linq;

namespace projMedicamento.Model
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Laboratorio { get; set; }
        private Queue<Lote> lotes = new Queue<Lote>();

        public Medicamento() { }

        public Medicamento(int id, string nome, string laboratorio)
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
        }

        public int QtdeDisponivel()
        {
            return lotes.Sum(l => l.Qtde);
        }

        public void Comprar(Lote lote)
        {
            lotes.Enqueue(lote);
        }

        public bool Vender(int qtde)
        {
            int disponivel = QtdeDisponivel();
            if (qtde > disponivel) return false;

            while (qtde > 0 && lotes.Count > 0)
            {
                var lote = lotes.Peek();
                if (lote.Qtde > qtde)
                {
                    lote.Qtde -= qtde;
                    qtde = 0;
                }
                else
                {
                    qtde -= lote.Qtde;
                    lotes.Dequeue();
                }
            }
            return true;
        }

        public override string ToString()
        {
            return $"{Id}-{Nome}-{Laboratorio}-{QtdeDisponivel()}";
        }

        public override bool Equals(object obj)
        {
            return obj is Medicamento m && m.Id == Id;
        }

        public void ListarLotes()
        {
            foreach (var lote in lotes)
                Console.WriteLine("   " + lote);
        }
    }
}
