using System;
using System.Runtime.InteropServices.Marshalling;
using Atividade08.Models;

int opcaoMenu = 1;

Projetos projetos = new Projetos();

while (opcaoMenu != 0)
{
	Console.WriteLine("0. Sair");
	Console.WriteLine("1. Adicionar projeto");
	Console.WriteLine("2. Pesquisar projeto");
	Console.WriteLine("3. Remover projeto");
	Console.WriteLine("4. Adicionar tarefa em projeto");
	Console.WriteLine("5. Concluir tarefa");
	Console.WriteLine("6. Cancelar tarefa");
	Console.WriteLine("7. Reabrir tarefa");
	Console.WriteLine("8. Listar tarefas de um projeto");
	Console.WriteLine("9. Filtrar tarefas por status ou prioridade em um projeto");
	Console.WriteLine("10. Filtrar tarefas por status ou prioridade em todos os projetos");
	Console.WriteLine("11. Resumo geral");

	Console.WriteLine("\nDigite uma opção: ");
	opcaoMenu = int.Parse(Console.ReadLine());

	switch (opcaoMenu)
	{
		case (int)OpcoesMenuEnum.Sair:
			Sair();
			break;
		case (int)OpcoesMenuEnum.AdicionarProjeto:
			AdicionarProjeto();
            break;
		case (int)OpcoesMenuEnum.PesquisarProjeto:
			PesquisarProjeto();
            break;
		case (int)OpcoesMenuEnum.RemoverProjeto:
			RemoverProjeto();
            break;
		case (int)OpcoesMenuEnum.AdicionarTarefa:
			AdicionarTarefa();
            break;
		case (int)OpcoesMenuEnum.ConcluirTarefa:
			ConcluirTarefa();
            break;
		case (int)OpcoesMenuEnum.CancelarTarefa:
			CancelarTarefa();
            break;
		case (int)OpcoesMenuEnum.ReabrirTarefa:
			ReabrirTarefa();
            break;
		case (int)OpcoesMenuEnum.ListarTarefasEmSomenteProjeto:
			ListarTarefasEmProjeto();
			break;
		case (int)OpcoesMenuEnum.FiltrarTarefasEmSomenteProjeto:
			FiltrarTarefasEmProjeto();
            break;
		case (int)OpcoesMenuEnum.FiltrarTarefasEmProjetos:
			FiltrarTarefasEmProjetos();
            break;                      
		case (int)OpcoesMenuEnum.ResumoGeral:
			ResumoGeral();
            break;
		default:
			Console.WriteLine("Opção invalida, tente outra opção entre 0 até 11.");
			break;
	}
}

void Sair()
{
	Console.WriteLine("Saindo...");
}

void AdicionarProjeto()
{
	int idProjeto = 0;

	string nomeProjeto = "";

	Console.WriteLine("Digite o id do projeto: ");
	idProjeto = int.Parse(Console.ReadLine());

	Console.WriteLine("Digite o nome do projeto: ");
	nomeProjeto = Console.ReadLine();

    Projeto projeto = new Projeto(idProjeto, nomeProjeto);

    projetos.Adicionar(projeto);
}

Projeto BuscarProjeto()
{
    int idProjeto = 0;

    Console.WriteLine("Digite o id do projeto: ");
    idProjeto = int.Parse(Console.ReadLine());

    Projeto projetoEncontrado = projetos.Buscar(new Projeto(idProjeto));

	return projetoEncontrado;
}

Tarefa BuscarTarefa()
{
    int idTarefa = 0;

    Projeto projetoEncontrado = BuscarProjeto();

    Console.WriteLine("Digite o id da tarefa: ");
    idTarefa = int.Parse(Console.ReadLine());

    Tarefa tarefaEncontrada = projetoEncontrado.BuscarTarefa(new Tarefa(idTarefa));

	return tarefaEncontrada;
}

void PesquisarProjeto()
{
	Projeto projetoEncontrado = BuscarProjeto();

    Console.WriteLine(projetoEncontrado.ToString());
}

void RemoverProjeto()
{
	Projeto projetoEncontrado = BuscarProjeto();

	if (!projetos.Remover(projetoEncontrado))
	{
		Console.WriteLine("Não foi possível remover o projeto. Verifique se não há tarefas pendentes!");
		return;
	}

	Console.WriteLine("Projeto removido com sucesso!");
}

void AdicionarTarefa()
{
	int idTarefa = 0;
	string descricaoTarefa = "";
    int prioridadeTarefa = 0;
	string statusTarefa = "Aberta";

    Projeto projetoEncontrado = BuscarProjeto();

	Console.WriteLine("Digite o id da tarefa: ");
    idTarefa = int.Parse(Console.ReadLine());

	Console.WriteLine("Digite a descrição da tarefa: ");
	descricaoTarefa = Console.ReadLine();

    Console.WriteLine("Digite a prioridade da tarefa: ");
    prioridadeTarefa = int.Parse(Console.ReadLine());

    projetoEncontrado.AdicionarTarefa(new Tarefa(idTarefa, descricaoTarefa, prioridadeTarefa, statusTarefa, DateTime.Now, null));
}

void ConcluirTarefa()
{
	Tarefa tarefaEncontrada = BuscarTarefa();

    if (tarefaEncontrada == null)
	{
		Console.WriteLine("Tarefa não encontrada!");
		return;
	}

	tarefaEncontrada.Concluir();

	Console.WriteLine($"Tarefa do id {tarefaEncontrada.Id} concluida com sucesso!");
}

void CancelarTarefa()
{
    Tarefa tarefaEncontrada = BuscarTarefa();

    if (tarefaEncontrada == null)
    {
        Console.WriteLine("Tarefa não encontrada!");
        return;
    }

    tarefaEncontrada.Cancelar();

    Console.WriteLine($"Tarefa do id {tarefaEncontrada.Id} cancelada com sucesso!");
}

void ReabrirTarefa()
{
    Tarefa tarefaEncontrada = BuscarTarefa();

    if (tarefaEncontrada == null)
    {
        Console.WriteLine("Tarefa não encontrada!");
        return;
    }

    tarefaEncontrada.Reabir();

    Console.WriteLine($"Tarefa do id {tarefaEncontrada.Id} cancelada com sucesso!");
}

void ListarTarefasEmProjeto()
{
    Projeto projetoEncontrado = BuscarProjeto();

	ListarTarefas(projetoEncontrado.Tarefas);
}

void FiltrarTarefasEmProjeto()
{
	int opcaoFiltro = 0;

    Projeto projetoEncontrado = BuscarProjeto();

    Console.WriteLine("Digite 1 para filtrar tarefas por status");
	Console.WriteLine("Digite 2 para filtrar tarefas por prioridade");
	opcaoFiltro = int.Parse(Console.ReadLine());

	switch (opcaoFiltro)
	{
		case 1:
			ListarTarefasPorStatus(projetoEncontrado);
            break;
		case 2:
			ListarTarefasPorPrioridade(projetoEncontrado);
			break;
		default:
			Console.WriteLine("Opção invalida");
			break;
	}
}

void ListarTarefasPorStatus(Projeto projeto)
{
	string status = "";

	Console.WriteLine("Digite o status: ");
	status = Console.ReadLine();

	List<Tarefa> tarefasPorStatus = projeto.TarefasPorStatus(status);

	ListarTarefas(tarefasPorStatus);
}

void ListarTarefasPorPrioridade(Projeto projeto)
{
	int prioridade = 0;

	Console.WriteLine("Digite a prioridade: ");
	prioridade = int.Parse(Console.ReadLine());

	List<Tarefa> tarefasPorPrioridade = projeto.TarefasPorPrioridade(prioridade);

    ListarTarefas(tarefasPorPrioridade);
}

void ListarTarefas(List<Tarefa> tarefas)
{
    foreach (var tarefa in tarefas)
    {
        Console.WriteLine(tarefa.ToString());
    }
}

void ListarProjetosTarefasPorStatus()
{
    string status = "";

    Console.WriteLine("Digite o status: ");
    status = Console.ReadLine();

    foreach (var projeto in projetos.Itens)
	{
		Console.WriteLine($"Projeto {projeto.Id}");
		List<Tarefa> tarefasPorStatus = new List<Tarefa>();

        tarefasPorStatus = projeto.TarefasPorStatus(status);

        ListarTarefas(tarefasPorStatus);
    }
}

void ListarProjetosTarefasPorPrioridade()
{
  
    int prioridade = 0;

    Console.WriteLine("Digite a prioridade: ");
    prioridade = int.Parse(Console.ReadLine());

    foreach (var projeto in projetos.Itens)
    {
        Console.WriteLine($"Projeto {projeto.Id}");
        List<Tarefa> tarefasPorPrioridade = new List<Tarefa>();

        tarefasPorPrioridade = projeto.TarefasPorPrioridade(prioridade);

		ListarTarefas(tarefasPorPrioridade);
    }
}

void FiltrarTarefasEmProjetos()
{
    int opcaoFiltro = 0;

    Console.WriteLine("Digite 1 para filtrar tarefas por status");
    Console.WriteLine("Digite 2 para filtrar tarefas por prioridade");

    opcaoFiltro = int.Parse(Console.ReadLine());

    switch (opcaoFiltro)
    {
        case 1:
            ListarProjetosTarefasPorStatus();
            break;
        case 2:
            ListarProjetosTarefasPorPrioridade();
            break;
        default:
            Console.WriteLine("Opção invalida");
            break;
    }
}

void ResumoGeral()
{

    int totalAbertas = projetos.Itens.Sum(x => x.TotalAbertas());
    int totalFechadas = projetos.Itens.Sum(x => x.TotalFechadas());
    int totalCanceladas = projetos.Itens.Sum(x => x.TotalCanceladas());

    double percentualConcluidas = totalAbertas == 0
        ? 0
        : (double)totalFechadas / totalAbertas * 100;

    Console.WriteLine($"Quantidade total de tarefas em aberto: {totalAbertas}");
    Console.WriteLine($"Quantidade total de tarefas fechadas: {totalFechadas}");
    Console.WriteLine($"Quantidade total de tarefas canceladas: {totalCanceladas}");
    Console.WriteLine($"Percentual de tarefas concluídas em relação às abertas: {percentualConcluidas:F2}%");
}