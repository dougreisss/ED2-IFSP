using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atividade03.Models;

namespace Atividade03.Services
{
    public class CursoServices
    {
        public void AdicionarCurso(Escola escola)
        {
            Curso curso = new Curso();

            Console.Write("Digite o id do curso: ");
            curso.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do curso: ");
            curso.Descricao = Console.ReadLine();

            bool cadastradoComSucesso = escola.AdicionarCurso(curso);

            if (cadastradoComSucesso)
            {
                Console.WriteLine("\nCadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nNão foi possivel cadastrar o curso!");
            }
        }

        public void PesquisarCurso(Escola escola)
        {
            Curso curso = new Curso();

            Console.Write("Digite o id do curso: ");
            curso.Id = int.Parse(Console.ReadLine());

            curso = escola.PesquisarCurso(curso);

            if (curso.Id == 0)
            {
                Console.WriteLine("\nCurso não encontrado!");
            }
            else
            {
                Console.WriteLine("\n" + curso.ToString());
                Console.WriteLine("Disciplinas: ");
                foreach (var disciplina in curso.Disciplinas)
                {
                    if (disciplina.Id != 0)
                    {
                        Console.WriteLine("\t" + disciplina.ToString());
                    }
                }
            }
        }

        public void RemoverCurso(Escola escola)
        {
            Curso curso = new Curso();

            Console.Write("Digite o id do curso: ");
            curso.Id = int.Parse(Console.ReadLine());

            bool cursoRemovido = escola.RemoverCurso(curso);

            if (cursoRemovido)
            {
                Console.WriteLine("\nCurso removido com sucesso!");
            }
        }
    }
}
