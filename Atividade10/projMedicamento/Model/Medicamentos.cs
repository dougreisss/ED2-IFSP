using System;
using System.Collections.Generic;
using System.Linq;

namespace projMedicamento.Model
{
    public class Medicamentos
    {
        private List<Medicamento> listaMedicamentos = new List<Medicamento>();

        public void Adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            var m = Pesquisar(medicamento);
            if (m.QtdeDisponivel() == 0)
            {
                listaMedicamentos.Remove(m);
                return true;
            }
            return false;
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            return listaMedicamentos.FirstOrDefault(m => m.Id == medicamento.Id)
                   ?? new Medicamento();
        }

        public void ListarSintetico()
        {
            foreach (var m in listaMedicamentos)
                Console.WriteLine(m);
        }
    }
}
