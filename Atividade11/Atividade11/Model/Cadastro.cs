using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Atividade11.Model
{
    public class Cadastro
    {   

        private const string CONNECTION_STRING = "Server=DESKTOP-VQ6H075;Database=TPLOG;Trusted_Connection=True;";

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
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                // Exemplo para usuários
                foreach (var usuario in Usuarios)
                {
                    var cmd = new SqlCommand("INSERT INTO Usuarios (Id, Nome) VALUES (@Id, @Nome)", conn);
                    cmd.Parameters.AddWithValue("@Id", usuario.Id);
                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.ExecuteNonQuery();
                }

                // Exemplo para ambientes
                foreach (var ambiente in Ambientes)
                {
                    var cmd = new SqlCommand("INSERT INTO Ambientes (Id, Nome) VALUES (@Id, @Nome)", conn);
                    cmd.Parameters.AddWithValue("@Id", ambiente.Id);
                    cmd.Parameters.AddWithValue("@Nome", ambiente.Nome);
                    cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Dados salvos com sucesso (Upload).");
        }

        // + download(): void - Fazer a carga dos dados ao executar a aplicação
        public void Download()
        {  
            Usuarios.Clear();
            Ambientes.Clear();

            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                // Carrega usuários
                var cmdUsuarios = new SqlCommand("SELECT Id, Nome FROM Usuarios", conn);
                using (var reader = cmdUsuarios.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuarios.Add(new Usuario(reader.GetInt32(0), reader.GetString(1)));
                    }
                }

                // Carrega ambientes
                var cmdAmbientes = new SqlCommand("SELECT Id, Nome FROM Ambientes", conn);
                using (var reader = cmdAmbientes.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ambientes.Add(new Ambiente(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }
        }
    }
}