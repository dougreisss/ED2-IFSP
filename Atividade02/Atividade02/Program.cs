// Dupla: Douglas Reis - CB3022722 e Gabriel Chaves - CB302024X

using Atividade02.Models;

const int SAIR = 0;
const int CADASTRAR_VENDEDOR = 1;
const int CONSULTAR_VENDEDOR = 2;
const int EXCLUIR_VENDEDOR = 3;
const int REGISTRAR_VENDA = 4;
const int LISTAR_VENDEDORES = 5;

int opcao = 1;
Vendedores vendedores = new Vendedores(10);

while (opcao != 0)
{
    Console.WriteLine("0. Sair" +
        "\n1. Cadastrar vendedor" +
        "\n2. Consultar vendedor" +
        "\n3. Excluir vendedor" +
        "\n4. Registrar venda" +
        "\n5. Listar vendedores");

    Console.WriteLine("Digite a opção: ");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case SAIR:
            sair();
            break;
        case CADASTRAR_VENDEDOR:
            cadastrarVendedor(vendedores);
            break;
        case CONSULTAR_VENDEDOR:
            consultarVendedor(vendedores);
            break;
        case EXCLUIR_VENDEDOR:
            excluirVendedor(vendedores);
            break;
        case REGISTRAR_VENDA:
            registrarVenda(vendedores);
            break;
        case LISTAR_VENDEDORES:
            listarVendedores(vendedores);
            break;
        default:
            Console.WriteLine("\n\nOpção invalida, por favor selecione uma opção entre 0 e 5\n\n");
            break;
    }

}

void sair()
{
    Console.WriteLine("Saindo...");
    Console.ReadKey();
}

void cadastrarVendedor(Vendedores vendedores)
{
    Vendedor vendedor = new Vendedor();

    Console.Write("Digite o id do vendedor: ");
    vendedor.Id = int.Parse(Console.ReadLine());

    Console.Write("Digite o nome do vendedor: ");
    vendedor.Nome = Console.ReadLine();

    Console.Write("Digite o percentual de comissão do vendedor: ");
    vendedor.PercComissao = double.Parse(Console.ReadLine());

    bool cadastradoComSucesso = vendedores.addVendedor(vendedor);

    if (cadastradoComSucesso)
    {
        Console.WriteLine("\nCadastrado com sucesso!");
        Console.WriteLine("");
    }
    else
    {
        Console.WriteLine("\nNão foi possivel cadastrar");
    }
}

void consultarVendedor(Vendedores vendedores)
{
    Vendedor vendedor = new Vendedor();

    Console.Write("Digite o id do vendedor: ");
    vendedor.Id = int.Parse(Console.ReadLine());

    vendedor = vendedores.searchVendedor(vendedor);

    if (vendedor.Id == 0)
    {
        Console.WriteLine("\nNão foi possivel encontrar o vendedor");
        return;
    }

    Console.WriteLine($"\n{vendedor.ToString()}");

    if (vendedor.valorVendas() > 0)
    {
        Console.WriteLine("Vendas: \n");
        for (int i = 0; i < vendedor.AsVendas.Length; i++)
        {
            Venda venda = vendedor.AsVendas[i];
            if (venda.Qtde > 0)
            {
                Console.WriteLine($"Dia: {i + 1} - {venda.ToString()}");
            }
        }
    }
}

void excluirVendedor(Vendedores vendedores)
{
    Vendedor vendedor = new Vendedor();

    Console.Write("Digite o id do vendedor: ");
    vendedor.Id = int.Parse(Console.ReadLine());

    vendedor = vendedores.searchVendedor(vendedor);

    if (vendedor.Id == 0)
    {
        Console.WriteLine("\nNão foi possivel encontrar o vendedor");
        return;
    }

    if (vendedor.valorVendas() > 0)
    {
        Console.WriteLine("\nVendedor não pode ser excluido pois tem vendas associadas");
        return;
    }

    bool excluidoComSucesso = vendedores.delVendedor(vendedor);

    if (excluidoComSucesso)
    {
        Console.WriteLine("\nExcluido com sucesso!");
    }
    else
    {
        Console.WriteLine("\nNão foi possivel excluir o vendedor");
    }
}
void registrarVenda(Vendedores vendedores)
{
    int dia;
    Venda venda = new Venda();
    Vendedor vendedor = new Vendedor();

    Console.Write("Digite o id do vendedor: ");
    vendedor.Id = int.Parse(Console.ReadLine());

    vendedor = vendedores.searchVendedor(vendedor);

    if (vendedor.Id == 0)
    {
        Console.WriteLine("\nNão foi possivel encontrar o vendedor");
        return;
    }

    Console.Write("Digite o dia da venda: ");
    dia = int.Parse(Console.ReadLine());

    Console.Write("Digite a quantidade de vendas do dia: ");
    venda.Qtde = int.Parse(Console.ReadLine());

    Console.Write("Digite a o valor total da venda de vendas: ");
    venda.Valor = double.Parse(Console.ReadLine());

    vendedor.registrarVenda(dia, venda);

    Console.WriteLine("\nVenda registrada");
}
void listarVendedores(Vendedores vendedores)
{
    Console.WriteLine("Listagem dos vendedores: \n\n");
    foreach (var vendedor in vendedores.OsVendedores)
    {
        if (vendedor.Id != 0)
        {
            Console.WriteLine(vendedor.ToString());
            Console.WriteLine("");
        }
    }
}





