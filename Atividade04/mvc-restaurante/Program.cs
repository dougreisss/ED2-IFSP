using System;
using System.Globalization;
using mvc_restaurante.Models;

namespace mvc_restaurante
{
    class Program
    {
        static void Main(string[] args)
        {
            var restaurante = new Restaurante();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Criar novo pedido");
                Console.WriteLine("2. Adicionar item ao pedido");
                Console.WriteLine("3. Remover item do pedido");
                Console.WriteLine("4. Consultar pedido");
                Console.WriteLine("5. Cancelar pedido");
                Console.WriteLine("6. Listar todos os pedidos");
                Console.Write("Opção: ");
                var op = Console.ReadLine();

                switch (op)
                {
                    case "0": return;
                    case "1": CriarNovoPedido(restaurante); break;
                    case "2": AdicionarItem(restaurante); break;
                    case "3": RemoverItem(restaurante); break;
                    case "4": ConsultarPedido(restaurante); break;
                    case "5": CancelarPedido(restaurante); break;
                    case "6": ListarTodos(restaurante); break;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        static void CriarNovoPedido(Restaurante r)
        {
            Console.Write("Nome do cliente: ");
            var nome = Console.ReadLine();
            var p = new Pedido(nome);
            if (r.NovoPedido(p)) Console.WriteLine($"Pedido criado com id {p.Id}");
            else Console.WriteLine("Não foi possível criar: capacidade de pedidos (50) atingida.");
        }

        static void AdicionarItem(Restaurante r)
        {
            Console.Write("Id do pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int pid)) { Console.WriteLine("Id inválido."); return; }
            var p = r.BuscarPedido(pid);
            if (p == null) { Console.WriteLine("Pedido não encontrado."); return; }

            Console.Write("Descrição do item: ");
            var desc = Console.ReadLine();
            Console.Write("Preço (use '.' para decimais): ");
            var precoStr = Console.ReadLine();
            if (!double.TryParse(precoStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double preco))
            {
                Console.WriteLine("Preço inválido.");
                return;
            }

            var item = new Item(0, desc, preco);
            if (p.AdicionarItem(item)) Console.WriteLine("Item adicionado.");
            else Console.WriteLine("Não foi possível adicionar: máximo de 10 itens por pedido.");
        }

        static void RemoverItem(Restaurante r)
        {
            Console.Write("Id do pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int pid)) { Console.WriteLine("Id inválido."); return; }
            var p = r.BuscarPedido(pid);
            if (p == null) { Console.WriteLine("Pedido não encontrado."); return; }

            Console.Write("Id do item a remover: ");
            if (!int.TryParse(Console.ReadLine(), out int iid)) { Console.WriteLine("Id inválido."); return; }

            if (p.RemoverItem(iid)) Console.WriteLine("Item removido.");
            else Console.WriteLine("Item não encontrado no pedido.");
        }

        static void ConsultarPedido(Restaurante r)
        {
            Console.Write("Id do pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int pid)) { Console.WriteLine("Id inválido."); return; }
            var p = r.BuscarPedido(pid);
            if (p == null) { Console.WriteLine("Pedido não encontrado."); return; }
            Console.WriteLine();
            Console.WriteLine(p.DadosDoPedido());
        }

        static void CancelarPedido(Restaurante r)
        {
            Console.Write("Id do pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int pid)) { Console.WriteLine("Id inválido."); return; }
            if (r.CancelarPedido(pid)) Console.WriteLine("Pedido cancelado.");
            else Console.WriteLine("Pedido não encontrado.");
        }

        static void ListarTodos(Restaurante r)
        {
            var pedidos = r.ListarPedidos();
            Console.WriteLine();
            Console.WriteLine("Pedidos ativos:");
            foreach (var p in pedidos)
            {
                if (p != null)
                {
                    Console.WriteLine($"  Id: {p.Id} - Cliente: {p.Cliente} - Total: R$ {p.CalcularTotal():F2}");
                }
            }
            Console.WriteLine($"Soma geral do dia: R$ {r.SomaGeral():F2}");
        }
    }
}
