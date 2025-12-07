using Atividade12.Models;

Queue<Jornada> JornadasRealizadas = new Queue<Jornada>();

Jornada jornadaAtual = new Jornada();
jornadaAtual.Finalizada = true;
Queue<Veiculo> veiculosAtuais = new Queue<Veiculo>();
Queue<Garagem> garagemsAtuais = new Queue<Garagem>();

int opcaoMenu = -1;

while (opcaoMenu != 0)
{
    ExibirMenu();

    Console.WriteLine("Digite a opção desejada:");
    int opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 0:
            Sair();
            opcaoMenu = 0;
            break;
        case 1:
            CadastrarVeiculo();
            break;
        case 2:
            CadastrarGaragem();
            break;
        case 3:
            IniciarJornada();
            break;
        case 4:
            EncerrarJornada();
            break;
        case 5:
            LiberarViagem();
            break;
        case 6:
            ListarVeiculos();
            break;
        case 7:
            QtdViagem();
            break;
        case 8:
            ListarViagens();
            break;
        case 9:
            InformarPassageirosViagem();
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void ExibirMenu()
{
    Console.WriteLine("Menu:");
    Console.WriteLine("0. Sair");
    Console.WriteLine("1. Cadastrar Veiculo");
    Console.WriteLine("2. Cadastrar Garagem");
    Console.WriteLine("3. Iniciar Jornada");
    Console.WriteLine("4. Encerrar Jornada");
    Console.WriteLine("5. Liberar viagem de uma determinada origem para um determinado destino");
    Console.WriteLine("6. Listar veículos em determinada garagem (informando a quantidade de veículos e seu potencial de transporte)");
    Console.WriteLine("7. Informar quantidade de viagens efetuadas de uma determinada origem para um determinado destino");
    Console.WriteLine("8. Listar viagens efetuadas de uma determinada origem para um determinado destino");
    Console.WriteLine("9. Informar quantidade de passageiros transportados de uma determinada origem para um determinado destino");
}

void Sair() {
    Console.WriteLine("Saindo do programa...");
}

void CadastrarVeiculo()
{
    Veiculo veiculo = new Veiculo();

    if (!jornadaAtual.Finalizada)
    {
        Console.WriteLine("Não é possível cadastrar um veículo durante uma jornada ativa.");
        return;
    }

    Console.WriteLine("Digite a placa do veiculo: ");  
    veiculo.Placa = Console.ReadLine();

    Console.WriteLine("Digite o modelo do veiculo: ");
    veiculo.Modelo = Console.ReadLine();

    Console.WriteLine("Digite o nome do motorista: ");
    veiculo.NomeMotorista = Console.ReadLine();

    Console.WriteLine("Digite a lotação máxima do veiculo: ");
    veiculo.QtdLotacaoMax = int.Parse(Console.ReadLine());

    veiculosAtuais.Enqueue(veiculo);     
}

void CadastrarGaragem()
{
    Garagem garagem = new Garagem();

    if (!jornadaAtual.Finalizada)
    {
        Console.WriteLine("Não é possível cadastrar uma garagem durante uma jornada ativa.");
        return;
    }

    Console.WriteLine("Digite o id da garagem: ");
    garagem.Id = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o nome da garagem: ");
    garagem.Nome = Console.ReadLine();

    Console.WriteLine("Digite a localização da garagem: ");
    garagem.Localizacao = Console.ReadLine();

    string opcaoVeiculo = "";

    while (opcaoVeiculo != "n")
    {
        Console.WriteLine("Deseja adicionar um novo veículo a esta garagem? (s/n)");
        opcaoVeiculo = Console.ReadLine().ToLower();

        switch (opcaoVeiculo)
        {
            case "s":
                Console.WriteLine("Digite a placa do veiculo: ");
                string placa = Console.ReadLine();

                Veiculo veiculo = new Veiculo(placa);

                foreach (var vei in veiculosAtuais)
                {
                    if (vei.Equals(veiculo))
                    {
                        garagem.Veiculos.Enqueue(vei);
                        Console.WriteLine("Veículo adicionado à garagem.");
                    }
                }

                break;
            case "n":
                Console.WriteLine("Saindo do cadastro de veiculos na garagem...");
                break;
            default:
                Console.WriteLine("Opção invalida");
                break;
        }
    } 

    garagemsAtuais.Enqueue(garagem);
}

void IniciarJornada()
{

    if (!jornadaAtual.Finalizada)
    {
        Console.WriteLine("Jornada atual ainda não foi finalizada");
        return;
    }

    Jornada jornada = new Jornada();
    jornada.Diaria = DateTime.Now;
    jornada.Finalizada = false;

    Console.WriteLine("Digite o id da jornada: ");
    jornada.Id = int.Parse(Console.ReadLine());

    string opcaoViagem = "";

    while (opcaoViagem != "n")
    {
        Console.WriteLine("Deseja adicionar uma nova viagem a esta jornada? (s/n)");
        opcaoViagem = Console.ReadLine().ToLower();

        switch (opcaoViagem)
        {
            case "s":
                Viagem viagem = new Viagem();
                viagem.DataViagem = DateTime.Now;
                viagem.Liberada = false;

                Console.WriteLine("Digite o id da viagem: ");
                viagem.Id = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a origem da viagem: ");
                viagem.Origem = Console.ReadLine();

                Console.WriteLine("Digite o destino da viagem: ");
                viagem.Destino = Console.ReadLine();

                Console.WriteLine("Digite a placa do veiculo: ");
                string placaVeiculo = Console.ReadLine();

                Veiculo veiculoViagem = new Veiculo(placaVeiculo);

                foreach (var vei in veiculosAtuais)
                {
                    if (vei.Equals(veiculoViagem))
                    {
                        viagem.Veiculos = vei;
                        Console.WriteLine("Veículo associado à viagem.");
                    } else
                    {
                        Console.WriteLine("Veiculo em uso ou veiculo não cadastrado");
                    }
                }

                Console.WriteLine("Digite a quantidade de passageiros da viagem: ");
                int qtdPassageiros = int.Parse(Console.ReadLine());

                if (qtdPassageiros > viagem.Veiculos.QtdLotacaoMax)
                {
                    Console.WriteLine("Quantidade de passageiros atingiu o limite maximo");
                }

                viagem.QtdPassageiros = qtdPassageiros;
                jornada.Viagems.Enqueue(viagem);

                break;
            case "n":
                Console.WriteLine("Saindo do cadastro de veiculos na garagem...");
                break;
            default:
                Console.WriteLine("Opção invalida");
                break;
        }
    }

    jornadaAtual = jornada;
}

void EncerrarJornada()
{
    jornadaAtual.Finalizada = true;
    JornadasRealizadas.Enqueue(jornadaAtual);
}

void LiberarViagem()
{
    Viagem viagemBusca = new Viagem();

    Console.WriteLine("Digite o id da viagem: ");
    viagemBusca.Id = int.Parse(Console.ReadLine());

    foreach (var viagem in jornadaAtual.Viagems)
    {
        if (viagem.Equals(viagemBusca))
        {
            viagem.Liberada = true;
            viagem.DataLiberacao = DateTime.Now;
            Console.WriteLine("Viagem liberada com sucesso.");
            return;
        }
    }

    Console.WriteLine("Viagem não encontrada.");
}

void ListarVeiculos()
{
    Console.WriteLine("Digite o id da garagem: ");

    int idGaragem = int.Parse(Console.ReadLine());

    Garagem garagemBusca = new Garagem(idGaragem);

    foreach (var garagem in garagemsAtuais)
    {
        if (garagem.Equals(garagemBusca))
        {
            Console.WriteLine(garagem.ToString());
        }
    }
}

void QtdViagem()
{
    int qtdViagens = 0;
    Console.WriteLine("Digite a origem: ");
    string origem = Console.ReadLine();

    Console.WriteLine("Digite o destino: ");
    string destino = Console.ReadLine();

    foreach (var jornada in JornadasRealizadas)
    {
        foreach (var viagem in jornada.Viagems)
        {
            if (viagem.Destino == destino && viagem.Origem == origem)
            {
                qtdViagens++;
            }
        }
    }

    Console.WriteLine($"Quantidades de viagens: {qtdViagens}");
}

void ListarViagens()
{
    int qtdViagens = 0;
    Console.WriteLine("Digite a origem: ");
    string origem = Console.ReadLine();

    Console.WriteLine("Digite o destino: ");
    string destino = Console.ReadLine();

    foreach (var jornada in JornadasRealizadas)
    {
        foreach (var viagem in jornada.Viagems)
        {
            if (viagem.Destino == destino && viagem.Origem == origem)
            {
                Console.WriteLine(viagem.ToString());
            }
        }
    }

}

void InformarPassageirosViagem()
{
    int qtdViagens = 0;
    Console.WriteLine("Digite a origem: ");
    string origem = Console.ReadLine();

    Console.WriteLine("Digite o destino: ");
    string destino = Console.ReadLine();

    foreach (var jornada in JornadasRealizadas)
    {
        foreach (var viagem in jornada.Viagems)
        {
            if (viagem.Destino == destino && viagem.Origem == origem)
            {
                Console.WriteLine($"A quantidade de passageiros de viagem {viagem.Id} é: {viagem.QtdPassageiros}");  
            }
        }
    }
}