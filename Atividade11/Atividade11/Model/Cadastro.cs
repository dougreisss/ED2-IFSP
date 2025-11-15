using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Atividade11.Model
{
    public class Cadastro
    {
        // - usuarios: List<Usuario>
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        // - ambientes: List<Ambiente>
        public List<Ambiente> Ambientes { get; set; } = new List<Ambiente>();

        // Constantes para persistência
        private const string USUARIOS_FILE = "usuarios.json";
        private const string AMBIENTES_FILE = "ambientes.json";

        // Métodos de Usuário

        // + adicionarUsuario(Usuario usuario): void
        public void AdicionarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        // + removerUsuario(Usuario usuario): bool
        // Usuários só poderão ser removidos se estiverem sem nenhum tipo de permissão de acesso
        public bool RemoverUsuario(Usuario usuario)
        {
            var u = PesquisarUsuario(usuario);
            if (u != null && !u.PossuiPermissoes())
            {
                Usuarios.Remove(u);
                return true;
            }
            return false;
        }

        // + pesquisarUsuario(Usuario usuario): Usuario
        public Usuario PesquisarUsuario(Usuario usuario)
        {
            // Retorna o objeto completo ou null se não encontrar
            return Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
        }

        // Métodos de Ambiente

        // + adicionarAmbiente(Ambiente ambiente): void
        public void AdicionarAmbiente(Ambiente ambiente)
        {
            Ambientes.Add(ambiente);
        }

        // + removerAmbiente(Ambiente ambiente): bool
        // Ambiente pode ser removido? (Vamos assumir que sim, se não estiver associado a nenhuma permissão)
        public bool RemoverAmbiente(Ambiente ambiente)
        {
            var a = PesquisarAmbiente(ambiente);
            if (a == null) return false;

            // Verifica se o ambiente está vinculado a alguma permissão de usuário
            bool vinculado = Usuarios.Any(u => u.Ambientes.Any(amb => amb.Id == a.Id));

            if (!vinculado)
            {
                Ambientes.Remove(a);
                return true;
            }
            return false;
        }

        // + pesquisarAmbiente(Ambiente ambiente): Ambiente
        public Ambiente PesquisarAmbiente(Ambiente ambiente)
        {
            // Retorna o objeto completo ou null se não encontrar
            return Ambientes.FirstOrDefault(a => a.Id == ambiente.Id);
        }

        // Métodos de Persistência

        // + upload(): void - Realizar a persistência dos dados quando a aplicação for encerrada
        public void Upload()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            // Salva Usuários
            string jsonUsuarios = JsonSerializer.Serialize(Usuarios, options);
            File.WriteAllText(USUARIOS_FILE, jsonUsuarios);

            // Salva Ambientes
            string jsonAmbientes = JsonSerializer.Serialize(Ambientes, options);
            File.WriteAllText(AMBIENTES_FILE, jsonAmbientes);

            Console.WriteLine("Dados salvos com sucesso (Upload).");
        }

        // + download(): void - Fazer a carga dos dados ao executar a aplicação
        public void Download()
        {
            // Carrega Usuários
            if (File.Exists(USUARIOS_FILE))
            {
                string jsonUsuarios = File.ReadAllText(USUARIOS_FILE);
                Usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonUsuarios);
                Console.WriteLine($"Carga de {Usuarios.Count} usuários realizada.");
            }

            // Carrega Ambientes
            if (File.Exists(AMBIENTES_FILE))
            {
                string jsonAmbientes = File.ReadAllText(AMBIENTES_FILE);
                Ambientes = JsonSerializer.Deserialize<List<Ambiente>>(jsonAmbientes);
                Console.WriteLine($"Carga de {Ambientes.Count} ambientes realizada.");
            }
        }
    }
}