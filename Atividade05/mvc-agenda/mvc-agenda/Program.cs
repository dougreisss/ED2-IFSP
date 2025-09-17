using mvc_agenda.Models;
using System;

namespace Agenda
{
    class Program
    {
        static void Main(string[] args)
        {
            var contatos = new Contatos();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar contato");
                Console.WriteLine("2. Pesquisar contato");
                Console.WriteLine("3. Alterar contato");
                Console.WriteLine("4. Remover contato");
                Console.WriteLine("5. Listar contatos");
                Console.Write("Opção: ");
                var op = Console.ReadLine();

                switch (op)
                {
                    case "0": return;
                    case "1": Adicionar(contatos); break;
                    case "2": Pesquisar(contatos); break;
                    case "3": Alterar(contatos); break;
                    case "4": Remover(contatos); break;
                    case "5": Listar(contatos); break;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        static void Adicionar(Contatos contatos)
        {
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.Write("Dia nasc: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Mês nasc: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Ano nasc: ");
            int ano = int.Parse(Console.ReadLine());

            var dt = new Data(dia, mes, ano);
            var contato = new Contato(email, nome, dt);

            Console.Write("Telefone principal (s/n)? ");
            var principal = Console.ReadLine().Trim().ToLower() == "s";
            Console.Write("Tipo: ");
            var tipo = Console.ReadLine();
            Console.Write("Número: ");
            var numero = Console.ReadLine();
            contato.AdicionarTelefone(new Telefone(tipo, numero, principal));

            if (contatos.Adicionar(contato))
                Console.WriteLine("Contato adicionado.");
            else
                Console.WriteLine("Contato já existe.");
        }

        static void Pesquisar(Contatos contatos)
        {
            Console.Write("Email do contato: ");
            var email = Console.ReadLine();
            var c = contatos.Pesquisar(new Contato { Email = email });
            Console.WriteLine(c != null ? c.ToString() : "Não encontrado.");
        }

        static void Alterar(Contatos contatos)
        {
            Console.Write("Email do contato a alterar: ");
            var email = Console.ReadLine();
            var c = contatos.Pesquisar(new Contato { Email = email });
            if (c == null) { Console.WriteLine("Não encontrado."); return; }

            Console.Write("Novo nome: ");
            c.Nome = Console.ReadLine();
            Console.Write("Novo dia nasc: ");
            c.DtNasc.Dia = int.Parse(Console.ReadLine());
            Console.Write("Novo mês nasc: ");
            c.DtNasc.Mes = int.Parse(Console.ReadLine());
            Console.Write("Novo ano nasc: ");
            c.DtNasc.Ano = int.Parse(Console.ReadLine());
            Console.WriteLine("Contato alterado.");
        }

        static void Remover(Contatos contatos)
        {
            Console.Write("Email do contato a remover: ");
            var email = Console.ReadLine();
            if (contatos.Remover(new Contato { Email = email }))
                Console.WriteLine("Removido.");
            else
                Console.WriteLine("Não encontrado.");
        }

        static void Listar(Contatos contatos)
        {
            foreach (var c in contatos.Agenda)
                Console.WriteLine(c);
        }
    }
}
