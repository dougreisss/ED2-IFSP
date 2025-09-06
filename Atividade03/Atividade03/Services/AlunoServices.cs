using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atividade03.Models;

namespace Atividade03.Services
{
    public class AlunoServices
    {
        public void PesquisarAluno(Escola escola)
        {
            Aluno aluno = new Aluno();
            const int MAX_DISCIPLINAS_POR_ALUNO = 6;
            int i = 0;
            Disciplina[] disciplinas = new Disciplina[MAX_DISCIPLINAS_POR_ALUNO];

            for (int j = 0; j < MAX_DISCIPLINAS_POR_ALUNO; j++)
            {
                disciplinas[j] = new Disciplina();
            }

            Console.Write("Digite o id do aluno: ");
            int idAluno = int.Parse(Console.ReadLine());

            foreach (var curso in escola.Cursos)
            {
                if (curso.Id != 0)
                {
                    foreach (var disciplina in curso.Disciplinas)
                    {
                        if (disciplina.Id != 0)
                        {
                            Aluno alunoTemp = disciplina.PesquisarAluno(new Aluno(idAluno));

                            if (alunoTemp.Id != 0)
                            {
                                disciplinas[i++] = disciplina;
                                aluno = alunoTemp;
                            }
                            ;
                        }
                    }
                }
            }

            if (aluno.Id != 0)
            {
                Console.WriteLine("\n" + aluno.ToString());
                Console.WriteLine("Disciplinas: ");
                foreach (var disciplina in disciplinas)
                {
                    if (disciplina.Id != 0)
                    {
                        Console.WriteLine("\t" + disciplina.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine("\nAluno não encontrado!");
            }
        }
    }
}
