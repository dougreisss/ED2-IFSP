// Dupla: Douglas Reis - CB3022722 e Gabriel Chaves - CB302024X

using Atividade03.Models;
using Atividade03.Services;

Escola escola = new Escola();
CursoServices cursoServices = new CursoServices();
DisciplinaServices disciplinaServices = new DisciplinaServices();
AlunoServices alunoServices = new AlunoServices();
int opcao = 1;

IniciarDados();

while (opcao != 0)
{
    Console.WriteLine("0. Sair" +
        "\n1. Adicionar curso" +
        "\n2. Pesquisar curso (mostrar inclusive as disciplinas associadas)" +
        "\n3. Remover curso (não pode ter nenhuma disciplina associada)" +
        "\n4. Adicionar disciplina no curso" +
        "\n5. Pesquisar disciplina (mostrar inclusive os alunos matriculados)" +
        "\n6. Remover disciplina do curso (não pode ter nenhum aluno matriculado)" +
        "\n7. Matricular aluno na disciplina" +
        "\n8. Remover aluno da disciplina" +
        "\n9. Pesquisar aluno (informar seu nome e em quais disciplinas ele está matriculado) ");

    Console.Write("\nDigite a opção: ");

    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case (int)OpcaoEnum.Sair:
            Sair();
            break;
        case (int)OpcaoEnum.AdicionarCurso:
            cursoServices.AdicionarCurso(escola);
            break;
        case (int)OpcaoEnum.PesquisarCurso:
            cursoServices.PesquisarCurso(escola);
            break;
        case (int)OpcaoEnum.RemoverCurso:
            cursoServices.RemoverCurso(escola);
            break;
        case (int)OpcaoEnum.AdicionarDisciplinaCurso:
            disciplinaServices.AdicionarDisciplinaCurso(escola);
            break;
        case (int)OpcaoEnum.PesquisarDisciplina:
            disciplinaServices.PesquisarDisciplina(escola);
            break;
        case (int)OpcaoEnum.RemoverDisciplinaCurso:
            disciplinaServices.RemoverDisciplinaCurso(escola);
            break;
        case (int)OpcaoEnum.MatricularAlunoDisciplina:
            disciplinaServices.MatricularAlunoDisciplina(escola);
            break;
        case (int)OpcaoEnum.RemoverAlunoDisciplina:
            disciplinaServices.RemoverAlunoDisciplina(escola);
            break;
        case (int)OpcaoEnum.PesquisarAluno:
            alunoServices.PesquisarAluno(escola);
            break;
        default:
            Console.WriteLine("\n\nOpção invalida\n\n");
            break;
    }
}

void Sair()
{
    Console.WriteLine("Saindo...");
    Console.ReadKey();
}

void IniciarDados()
{
    Aluno aluno = new Aluno(1, "Douglas");
    Curso curso = new Curso(1, "ADS");

    Disciplina disciplina1 = new Disciplina(1, "LPL1");
    Disciplina disciplina2 = new Disciplina(2, "ED2");
    Disciplina disciplina3 = new Disciplina(3, "DWE1");

    curso.AdicionarDisciplina(disciplina1);
    curso.AdicionarDisciplina(disciplina2);
    curso.AdicionarDisciplina(disciplina3);

    disciplina1.MatricularAluno(aluno);
    disciplina2.MatricularAluno(aluno);
    disciplina3.MatricularAluno(aluno);

    escola.AdicionarCurso(curso);
}




