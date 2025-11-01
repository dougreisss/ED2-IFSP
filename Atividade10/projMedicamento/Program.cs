using System;
using projMedicamento.Model;

namespace projMedicamento
{
    class Program
    {
        static void Main()
        {
            Medicamentos medicamentos = new Medicamentos();
            int opc;

            do
            {
                Console.WriteLine("\nMENU PRINCIPAL");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos");
                Console.WriteLine("7. Deletar medicamento"); // NOVA OPÇÃO
                Console.Write("\nOpção: ");

                // Trata a conversão de forma segura
                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                switch (opc)
                {
                    case 1:
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Laboratório: ");
                        string lab = Console.ReadLine();
                        // Adicionar o medicamento na lista de medicamentos
                        medicamentos.Adicionar(new Medicamento(id, nome, lab));
                        Console.WriteLine("Medicamento cadastrado.");
                        break;

                    case 2:
                    case 3:
                        Console.Write("ID do medicamento: ");
                        id = int.Parse(Console.ReadLine());
                        // Procurar o medicamento indicado na lista de Medicamentos utilizando o id
                        var med = medicamentos.Pesquisar(new Medicamento { Id = id });
                        // Caso não encontrado, retornar um objeto vazio
                        if (med.Id == 0)
                            Console.WriteLine("Não encontrado.");
                        else
                        {
                            // Sintético: informar dados (ID NOME + LABORATÓRIO + QTDE DISPONÍVEL)
                            Console.WriteLine("\nDados do Medicamento:");
                            Console.WriteLine(med);
                            if (opc == 3) // Analítico: informar dados + lotes
                            {
                                Console.WriteLine("\nLotes:");
                                med.ListarLotes();
                            }
                        }
                        break;

                    case 4:
                        Console.Write("ID do medicamento: ");
                        id = int.Parse(Console.ReadLine());
                        med = medicamentos.Pesquisar(new Medicamento { Id = id });
                        if (med.Id == 0)
                        {
                            Console.WriteLine("Medicamento não encontrado.");
                            break;
                        }
                        Console.Write("ID Lote: ");
                        int idLote = int.Parse(Console.ReadLine());
                        Console.Write("Qtde: ");
                        int qtde = int.Parse(Console.ReadLine());
                        Console.Write("Vencimento (dd/mm/yyyy): ");
                        DateTime venc = DateTime.Parse(Console.ReadLine());
                        // Colocar o lote comprado na fila de lotes
                        med.Comprar(new Lote(idLote, qtde, venc));
                        Console.WriteLine("Lote cadastrado (compra registrada).");
                        break;

                    case 5:
                        Console.Write("ID do medicamento: ");
                        id = int.Parse(Console.ReadLine());
                        med = medicamentos.Pesquisar(new Medicamento { Id = id });
                        if (med.Id == 0)
                        {
                            Console.WriteLine("Medicamento não encontrado.");
                            break;
                        }
                        Console.Write("Quantidade a vender: ");
                        int qtv = int.Parse(Console.ReadLine());

                        // Se houver saldo possivel para ser vendido, realizar a venda
                        if (med.Vender(qtv))
                            Console.WriteLine("Venda realizada com sucesso.");
                        // Não havendo quantidade disponível para venda, retornar o fato
                        else
                            Console.WriteLine($"ERRO: Quantidade insuficiente. Disponível: {med.QtdeDisponivel()}");
                        break;

                    case 6:
                        // Listar medicamentos (informando dados sintéticos)
                        Console.WriteLine("\nLista de Medicamentos (ID-NOME-LAB-QTDE):");
                        medicamentos.ListarSintetico();
                        break;

                    case 7: // NOVO CASE PARA DELETAR
                        Console.Write("ID do medicamento a ser deletado: ");
                        id = int.Parse(Console.ReadLine());
                        Medicamento medParaDeletar = new Medicamento { Id = id };

                        // Deletar medicamento. Remover somente se a quantidade disponível for 0 (zero)
                        if (medicamentos.Deletar(medParaDeletar))
                        {
                            Console.WriteLine("Medicamento deletado com sucesso.");
                        }
                        else
                        {
                            var m = medicamentos.Pesquisar(medParaDeletar);
                            if (m.Id == 0)
                                Console.WriteLine("ERRO: Medicamento não encontrado.");
                            else
                                Console.WriteLine($"ERRO: Não é possível deletar. Quantidade disponível: {m.QtdeDisponivel()}.");
                        }
                        break;

                }
            }
            // 0. Finalizar processo
            while (opc != 0);
        }
    }
}