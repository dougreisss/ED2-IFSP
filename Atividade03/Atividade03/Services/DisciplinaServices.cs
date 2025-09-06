using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atividade03.Models;

namespace Atividade03.Services
{
    public class DisciplinaServices
    {
        public void AdicionarDisciplinaCurso(Escola escola)
        {
            Curso curso = new Curso();
            Disciplina disciplina = new Disciplina();

            Console.Write("Digite o id do curso: ");
            curso.Id = int.Parse(Console.ReadLine());

            curso = escola.PesquisarCurso(curso);

            if (curso.Id == 0)
            {
                Console.WriteLine("\nCurso não encontrado!");
                return;
            }

            Console.Write("Digite o id da disciplina: ");
            disciplina.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da disciplina: ");
            disciplina.Descricao = Console.ReadLine();

            bool cadastradoComSucesso = curso.AdicionarDisciplina(disciplina);

            if (cadastradoComSucesso)
            {
                Console.WriteLine("\nDisciplina adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nNão foi possivel adicionar a disciplina!");
            }

        }


        public void PesquisarDisciplina(Escola escola)
        {
            Console.Write("Digite o id da disciplina: ");
            int idDisciplina = int.Parse(Console.ReadLine());

            Disciplina disciplina = PesquisarDisciplinaCurso(escola, idDisciplina);

            if (disciplina.Id == 0)
            {
                Console.WriteLine("\nDisciplina não encontrada!");
                return;
            }

            Console.WriteLine("\n" + disciplina.ToString());
            Console.WriteLine("Alunos: ");
            foreach (var aluno in disciplina.Alunos)
            {
                if (aluno.Id != 0)
                {
                    Console.WriteLine(" " + aluno.ToString());
                }
            }
        }

        public Disciplina PesquisarDisciplinaCurso(Escola escola, int idDisciplina)
        {
            Disciplina disciplina = new Disciplina();

            foreach (var curso in escola.Cursos)
            {
                if (curso.Id != 0)
                {
                    disciplina = curso.PesquisarDisciplina(new Disciplina(idDisciplina));

                    if (disciplina.Id != 0)
                    {
                        break;
                    }
                }
            }

            return disciplina;
        }

        public void RemoverDisciplinaCurso(Escola escola)
        {
            Curso curso = new Curso();
            Disciplina disciplina = new Disciplina();

            Console.Write("Digite o id do curso: ");
            curso.Id = int.Parse(Console.ReadLine());

            curso = escola.PesquisarCurso(curso);

            if (curso.Id == 0)
            {
                Console.WriteLine("\nCurso não encontrado!");
                return;
            }

            Console.Write("Digite o id da disciplina: ");
            disciplina.Id = int.Parse(Console.ReadLine());

            bool disciplinaRemovida = curso.RemoverDisciplina(disciplina);

            if (disciplinaRemovida)
            {
                Console.WriteLine("\nDisciplina removida com sucesso!");
            }
        }

        public void MatricularAlunoDisciplina(Escola escola)
        {
            int idDisciplina;
            Aluno aluno = new Aluno();

            Console.Write("Digite o id da disciplina: ");
            idDisciplina = int.Parse(Console.ReadLine());

            Disciplina disciplina = PesquisarDisciplinaCurso(escola, idDisciplina);

            if (disciplina.Id == 0)
            {
                Console.WriteLine("\nDisciplina não encontrada!");
                return;
            }

            Console.Write("Digite o id do aluno: ");
            aluno.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do aluno: ");
            aluno.Nome = Console.ReadLine();

            bool podeMatricular = aluno.podeMatricular(escola.Cursos);
            if (!podeMatricular)
            {
                Console.WriteLine("\nAluno já atingiu o maximo de disciplinas!");
                return;
            }

            bool matriculadoComSucesso = disciplina.MatricularAluno(aluno);
            if (matriculadoComSucesso)
            {
                Console.WriteLine("\nAluno matriculado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nNão foi possivel matricular o aluno no curso!");
            }
        }

        public void RemoverAlunoDisciplina(Escola escola)
        {
            int idDisciplina;
            Aluno aluno = new Aluno();

            Console.Write("Digite o id da disciplina: ");
            idDisciplina = int.Parse(Console.ReadLine());

            Disciplina disciplina = PesquisarDisciplinaCurso(escola, idDisciplina);

            if (disciplina.Id == 0)
            {
                Console.WriteLine("\nDisciplina não encontrado!");
                return;
            }

            Console.Write("Digite o id do aluno: ");
            aluno.Id = int.Parse(Console.ReadLine());

            bool desmatriculadoComSucesso = disciplina.DesmatricularAluno(aluno);

            if (desmatriculadoComSucesso)
            {
                Console.WriteLine("\nAluno desmatriculado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nAluno não encontrado!");
            }
        }
    }
}
