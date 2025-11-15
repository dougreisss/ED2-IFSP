using System.Collections.Generic;
using System.Linq;

namespace Atividade11.Model
{
    public class Usuario
    {
        // - id: int
        public int Id { get; set; }
        // - nome: string
        public string Nome { get; set; }
        // - ambientes: List<Ambiente>
        public List<Ambiente> Ambientes { get; set; } = new List<Ambiente>();

        public Usuario() { }

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        // + concederPermissao(Ambiente ambiente): bool
        // Cada usuário só pode ter uma permissão para cada ambiente
        public bool ConcederPermissao(Ambiente ambiente)
        {
            if (Ambientes.Any(a => a.Id == ambiente.Id))
                return false; // Permissão já existe

            Ambientes.Add(ambiente);
            return true;
        }

        // + revogarPermissao(Ambiente ambiente): bool
        public bool RevogarPermissao(Ambiente ambiente)
        {
            var ambienteParaRemover = Ambientes.FirstOrDefault(a => a.Id == ambiente.Id);
            if (ambienteParaRemover != null)
            {
                Ambientes.Remove(ambienteParaRemover);
                return true;
            }
            return false; // Permissão não encontrada
        }

        public bool PossuiPermissoes()
        {
            return Ambientes.Count > 0;
        }

        public bool TemPermissaoPara(Ambiente ambiente)
        {
            return Ambientes.Any(a => a.Id == ambiente.Id);
        }

        public override string ToString()
        {
            return $"ID: {Id} | Nome: {Nome} | Permissões: {Ambientes.Count}";
        }

        public void ListarPermissoes()
        {
            if (Ambientes.Count == 0)
            {
                Console.WriteLine("    Nenhuma permissão concedida.");
                return;
            }
            foreach (var ambiente in Ambientes)
                Console.WriteLine($"    {ambiente.Id} - {ambiente.Nome}");
        }
    }
}