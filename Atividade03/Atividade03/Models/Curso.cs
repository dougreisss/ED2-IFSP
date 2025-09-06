// Dupla: Douglas Reis - CB3022722 e Gabriel Chaves - CB302024X

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade03.Models
{
    public class Curso
    {
        private int id;
        private string descricao;
        private Disciplina[] disciplinas;
        private int qtd;
        private const int QTD_DISCIPLINAS = 12;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public Disciplina[] Disciplinas { get => disciplinas; set => disciplinas = value; }
        public int QtdDisciplina { get => qtd; }

        public Curso(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            this.qtd = 0;
            InicializarDisciplinas();
        }

        public Curso(int id) : this (id, "")
        {
            
        }

        public Curso() : this (0, "")
        {
            
        }

        public bool AdicionarDisciplina(Disciplina disciplina)
        {
            if (this.qtd == QTD_DISCIPLINAS)
                return false;

            this.disciplinas[this.qtd++] = disciplina;

            return true;
        }

        public Disciplina PesquisarDisciplina(Disciplina disciplina)
        {
            int i = 0;

            Disciplina disciplinaEncontrada = new Disciplina();

            while (i < QTD_DISCIPLINAS && !disciplinas[i].Equals(disciplina))
            {
                i++;
            }

            if (i < QTD_DISCIPLINAS)
                disciplinaEncontrada = this.disciplinas[i];

            return disciplinaEncontrada;
        }

        public bool RemoverDisciplina(Disciplina disciplina)
        {
            int i = 0;

            while (i < QTD_DISCIPLINAS && !disciplinas[i].Equals(disciplina)) 
            {
                i++;
            }

            bool podeRemoverDisciplina = (i != QTD_DISCIPLINAS && disciplinas[i].QtdAlunos == 0);

            if (i == QTD_DISCIPLINAS) 
            {
                Console.WriteLine("Disciplina não encontrada");
            } else if (disciplinas[i].QtdAlunos > 0)
            {
                Console.WriteLine("Disciplina não pode ser removido por haver alunos cadastrados");
            }

            if (podeRemoverDisciplina) 
            {
                while (i < QTD_DISCIPLINAS - 1)
                {
                    disciplinas[i] = disciplinas[i + 1];
                    i++;
                }

                disciplinas[i] = new Disciplina();
                this.qtd--;
            }

            return podeRemoverDisciplina;
        }

        public override bool Equals(object obj) => id.Equals(((Curso)obj).Id);
        public override string ToString() => $"Id: {this.Id}\nDescrição: {this.Descricao}";

        private void InicializarDisciplinas()
        {
            disciplinas = new Disciplina[QTD_DISCIPLINAS];

            for (int i = 0; i < QTD_DISCIPLINAS; i++)
            {
                disciplinas[i] = new Disciplina();
            }
        }
    }
}
