using Atividade07.Models;

int Opcao = 1;
Livros Livros = new Livros();


while (Opcao != 0)
{
    Console.WriteLine("0. Sair");
    Console.WriteLine("1. Adicionar livro");
    Console.WriteLine("2. Pesquisar livro (sintético)");
    Console.WriteLine("3. Pesquisar livro (analítico)");
    Console.WriteLine("4. Adicionar exemplar");
    Console.WriteLine("5. Registrar empréstimo");
    Console.WriteLine("6. Registrar devolução");

    Console.Write("\nDigite a opção: ");
    Opcao = int.Parse(Console.ReadLine());
    
    switch (Opcao)
    {
        case (int)OpcoesMenuEnum.Sair:
            Sair();
            break;
        case (int)OpcoesMenuEnum.AdicionarLivro:
            AdicionarLivro(Livros);
            break;
        case (int)OpcoesMenuEnum.PesquisarSintetico:
            PesquisarSintetico(Livros);
            break;
        case (int)OpcoesMenuEnum.PesquisarAnalitico:
            PesquisarAnalitico(Livros);
            break;
        case (int)OpcoesMenuEnum.AdicionarExemplar:
            AdicionarExemplar(Livros);
            break;
        case (int)OpcoesMenuEnum.RegistrarEmprestimo:
            RegistrarEmprestimo(Livros);
            break;
        case (int)OpcoesMenuEnum.RegistrarDevolucao:
            RegistrarDevolucao(Livros);
            break;
        default:
            Console.WriteLine("\nOpção invalida, por favor selecione um valor entre 0 e 6\n");
            break;
    }
}

void AdicionarExemplar(Livros livros)
{
    Livro livro = new Livro();
    Exemplar exemplar = new Exemplar();

    Console.Write("Digite isbn do livro: ");
    livro.Isbn = int.Parse(Console.ReadLine());

    livro = livros.Pesquisar(livro);

    if (livro == null)
    {
        Console.WriteLine("Livro não encontrado.");
        return;
    }

    Console.Write("Digite tombo do exemplar desse livro: ");
    exemplar.Tombo = int.Parse(Console.ReadLine());

    livro.AdicionarExemplar(exemplar);

    Console.WriteLine("Exemplar adicionada com sucesso!");
}

void PesquisarAnalitico(Livros livros)
{
    Livro livro = new Livro();

    Console.Write("Digite isbn do livro: ");
    livro.Isbn = int.Parse(Console.ReadLine());

    livro = livros.Pesquisar(livro);

    if (livro != null)
    {
        Console.WriteLine(livro.ToString());
        Console.WriteLine("Exemplares:");

        foreach (var exemplar in livro.Exemplares)
        {
            Console.WriteLine("\t" + exemplar.ToString());
        }
    }
    else
    {
        Console.WriteLine("Livro não encontrado.");
    }
}

void PesquisarSintetico(Livros livros)
{
    Livro livro = new Livro();

    Console.Write("Digite isbn do livro: ");
    livro.Isbn = int.Parse(Console.ReadLine());

    livro = livros.Pesquisar(livro);

    if (livro != null)
    {
        Console.WriteLine("\n" + livro.ToString());
    }
    else
    {
        Console.WriteLine("Livro não encontrado.");
    }
}

void AdicionarLivro(Livros livros)
{
    Livro livro = new Livro();
    Exemplar exemplar = new Exemplar();

    Console.Write("Digite isbn do livro: ");
    livro.Isbn = int.Parse(Console.ReadLine());

    Console.Write("Digite titulo do livro: ");
    livro.Titulo = Console.ReadLine();

    Console.Write("Digite autor do livro: ");
    livro.Autor = Console.ReadLine();

    Console.Write("Digite editora do livro: ");
    livro.Editora = Console.ReadLine();

    Console.Write("Digite tombo do exemplar desse livro: ");
    exemplar.Tombo = int.Parse(Console.ReadLine());

    livro.AdicionarExemplar(exemplar);
    livros.Adicionar(livro);

    Console.WriteLine("Livro adicionada com sucesso!");
}

void RegistrarDevolucao(Livros livros)
{
    Livro livro = new Livro();
    Exemplar exemplar = new Exemplar();

    Console.Write("Digite isbn do livro: ");
    livro.Isbn = int.Parse(Console.ReadLine());

    livro = livros.Pesquisar(livro);

    if (livro == null)
    {
        Console.WriteLine("Livro não encontrado.");
        return;
    }

    Console.Write("Digite tombo do exemplar desse livro: ");
    exemplar.Tombo = int.Parse(Console.ReadLine());

    exemplar = livro.Exemplares.FirstOrDefault(ex => ex.Equals(exemplar));

    if (exemplar == null)
    {
        Console.WriteLine("Exemplar não encontrado.");
        return;
    }

    if (exemplar.Devolver())
    {
        Console.WriteLine("Exemplar devolvido com sucesso.");
    }
    else
    {
        Console.WriteLine("Não foi possivel devolver o exemplar.");
    }
}

void RegistrarEmprestimo(Livros livros)
{
    Livro livro = new Livro();
    Exemplar exemplar = new Exemplar();

    Console.Write("Digite isbn do livro: ");
    livro.Isbn = int.Parse(Console.ReadLine());

    livro = livros.Pesquisar(livro);

    if (livro == null)
    {
        Console.WriteLine("Livro não encontrado.");
        return;
    }

    Console.Write("Digite tombo do exemplar desse livro: ");
    exemplar.Tombo = int.Parse(Console.ReadLine());

    exemplar = livro.Exemplares.FirstOrDefault(ex => ex.Equals(exemplar));

    if (exemplar == null)
    {
        Console.WriteLine("Exemplar não encontrado.");
        return;
    }

    if (exemplar.Emprestar())
    {
        Console.WriteLine("Exemplar emprestado com sucesso.");
    }
    else
    {
        Console.WriteLine("Não foi possivel emprestar o exemplar.");
    }
}

void Sair()
{
    Console.WriteLine("Saindo...");
    Console.ReadKey();
}