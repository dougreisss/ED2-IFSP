using Atividade11.Model;
using System;
using System.Linq;

namespace Atividade11
{
    class Program
    {
        static async Task Main()
        {
            // 1. Instancia o objeto de cadastro
            Cadastro cadastro = new Cadastro();
            HttpClient httpClient = new HttpClient();
            TTLockClient lockClient = new TTLockClient(httpClient, "05eb88a940484bd08e8f2f263e56eb2b", "8977e54ba82a23a016db74f4504f6b2d", "", "ifspcbtadsedd@gmail.com", "23e4b3eb0ac3ae12d4f9e13372b49cda");

            // 2. Fazer a carga dos dados ao executar a aplicação (download)
            cadastro.Download();

            int opc;

            do
            {
                Console.WriteLine("\n==== PROJETO ACESSO ====");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar ambiente");
                Console.WriteLine("2. Consultar ambiente");
                Console.WriteLine("3. Excluir ambiente");
                Console.WriteLine("4. Cadastrar usuario");
                Console.WriteLine("5. Consultar usuario");
                Console.WriteLine("6. Excluir usuario");
                Console.WriteLine("7. Conceder permissão de acesso");
                Console.WriteLine("8. Revogar permissão de acesso");
                Console.WriteLine("9. Registrar acesso");
                Console.WriteLine("10. Consultar logs de acesso");
                Console.WriteLine("11. Desbloquear trava");
                Console.Write("\nOpção: ");

                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                try
                {
                    switch (opc)
                    {
                        case 1: // Cadastrar ambiente
                            Console.Write("ID do Ambiente: ");
                            int idAmb = int.Parse(Console.ReadLine());
                            Console.Write("Nome do Ambiente: ");
                            string nomeAmb = Console.ReadLine();
                            cadastro.AdicionarAmbiente(new Ambiente(idAmb, nomeAmb));
                            Console.WriteLine("Ambiente cadastrado.");
                            break;

                        case 2: // Consultar ambiente
                            Console.Write("ID do Ambiente: ");
                            idAmb = int.Parse(Console.ReadLine());
                            Ambiente amb = cadastro.PesquisarAmbiente(new Ambiente { Id = idAmb });
                            if (amb != null) Console.WriteLine(amb);
                            else Console.WriteLine("Ambiente não encontrado.");
                            break;

                        case 3: // Excluir ambiente
                            Console.Write("ID do Ambiente a excluir: ");
                            idAmb = int.Parse(Console.ReadLine());
                            Ambiente ambExcluir = new Ambiente { Id = idAmb };
                            if (cadastro.RemoverAmbiente(ambExcluir))
                                Console.WriteLine("Ambiente excluído com sucesso.");
                            else
                                Console.WriteLine("ERRO: Ambiente não encontrado ou possui permissões ativas.");
                            break;

                        case 4: // Cadastrar usuario
                            Console.Write("ID do Usuário: ");
                            int idUser = int.Parse(Console.ReadLine());
                            Console.Write("Nome do Usuário: ");
                            string nomeUser = Console.ReadLine();
                            cadastro.AdicionarUsuario(new Usuario(idUser, nomeUser));
                            Console.WriteLine("Usuário cadastrado.");
                            break;

                        case 5: // Consultar usuario
                            Console.Write("ID do Usuário: ");
                            idUser = int.Parse(Console.ReadLine());
                            Usuario user = cadastro.PesquisarUsuario(new Usuario { Id = idUser });
                            if (user != null)
                            {
                                Console.WriteLine(user);
                                Console.WriteLine("Permissões:");
                                user.ListarPermissoes();
                            }
                            else Console.WriteLine("Usuário não encontrado.");
                            break;

                        case 6: // Excluir usuario
                            Console.Write("ID do Usuário a excluir: ");
                            idUser = int.Parse(Console.ReadLine());
                            Usuario userExcluir = new Usuario { Id = idUser };
                            if (cadastro.RemoverUsuario(userExcluir))
                                Console.WriteLine("Usuário excluído com sucesso.");
                            else
                                Console.WriteLine("ERRO: Usuário não encontrado ou ainda possui permissões.");
                            break;

                        case 7: // Conceder permissão de acesso
                            Console.Write("ID do Usuário: ");
                            idUser = int.Parse(Console.ReadLine());
                            Console.Write("ID do Ambiente: ");
                            idAmb = int.Parse(Console.ReadLine());

                            user = cadastro.PesquisarUsuario(new Usuario { Id = idUser });
                            amb = cadastro.PesquisarAmbiente(new Ambiente { Id = idAmb });

                            if (user == null || amb == null)
                            {
                                Console.WriteLine("ERRO: Usuário ou Ambiente não encontrado.");
                                break;
                            }

                            if (user.ConcederPermissao(amb))
                                Console.WriteLine($"Permissão concedida: Usuário {user.Nome} para Ambiente {amb.Nome}.");
                            else
                                Console.WriteLine("ERRO: Permissão já existe.");
                            break;

                        case 8: // Revogar permissão de acesso
                            Console.Write("ID do Usuário: ");
                            idUser = int.Parse(Console.ReadLine());
                            Console.Write("ID do Ambiente: ");
                            idAmb = int.Parse(Console.ReadLine());

                            user = cadastro.PesquisarUsuario(new Usuario { Id = idUser });
                            amb = cadastro.PesquisarAmbiente(new Ambiente { Id = idAmb });

                            if (user == null || amb == null)
                            {
                                Console.WriteLine("ERRO: Usuário ou Ambiente não encontrado.");
                                break;
                            }

                            if (user.RevogarPermissao(amb))
                                Console.WriteLine($"Permissão revogada: Usuário {user.Nome} para Ambiente {amb.Nome}.");
                            else
                                Console.WriteLine("ERRO: Permissão não existe.");
                            break;

                        case 9: // Registrar acesso
                            Console.Write("ID do Usuário: ");
                            idUser = int.Parse(Console.ReadLine());
                            Console.Write("ID do Ambiente: ");
                            idAmb = int.Parse(Console.ReadLine());

                            user = cadastro.PesquisarUsuario(new Usuario { Id = idUser });
                            amb = cadastro.PesquisarAmbiente(new Ambiente { Id = idAmb });

                            if (user == null || amb == null)
                            {
                                Console.WriteLine("ERRO: Usuário ou Ambiente não encontrado.");
                                break;
                            }

                            // Verifica se o usuário tem permissão
                            bool autorizado = user.TemPermissaoPara(amb);

                            // Cria e registra o log
                            Log novoLog = new Log(user, autorizado);
                            amb.RegistrarLog(novoLog);

                            if (autorizado)
                                Console.WriteLine($"ACESSO AUTORIZADO no ambiente {amb.Nome}. Log registrado.");
                            else
                                Console.WriteLine($"ACESSO NEGADO (sem permissão) no ambiente {amb.Nome}. Tentativa registrada em log.");
                            break;

                        case 10: // Consultar logs de acesso
                            Console.Write("ID do Ambiente para logs: ");
                            idAmb = int.Parse(Console.ReadLine());
                            amb = cadastro.PesquisarAmbiente(new Ambiente { Id = idAmb });

                            if (amb == null)
                            {
                                Console.WriteLine("ERRO: Ambiente não encontrado.");
                                break;
                            }

                            Console.WriteLine("Filtrar logs (0=Todos, 1=Autorizados, 2=Negados): ");
                            int filtro = int.Parse(Console.ReadLine());

                            var logsFiltrados = amb.ListarLogs(filtro);
                            Console.WriteLine($"\n--- Logs do Ambiente {amb.Nome} ({logsFiltrados.Count} registro(s)) ---");
                            foreach (var log in logsFiltrados.OrderBy(l => l.DtAcesso))
                                Console.WriteLine(log);

                            break;
                        case 11:
                            lockClient._accessToken = await lockClient.GerarAccessToken();
                            int lockId = 17097086;

                            bool isUnlocked = await lockClient.UnlockAsync(lockId);

                            if (isUnlocked)
                            {
                                Console.WriteLine("Trava desbloqueada com sucesso");
                            } else
                            {
                                Console.WriteLine("A trava não foi desbloqueada com sucesso");
                            }

                            break;
                        case 0: // Sair
                            // Realizar a persistência dos dados quando a aplicação for encerrada (upload)
                            cadastro.Upload();
                            Console.WriteLine("Aplicação encerrada.");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERRO: Entrada inválida. Esperado um número inteiro ou data.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
                }
            }
            while (opc != 0);
        }

    }
}