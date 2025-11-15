using System;
using System.Collections.Generic;
using System.Linq;

namespace Atividade11.Model
{
    public class Ambiente
    {
        // - id: int
        public int Id { get; set; }
        // - nome: string
        public string Nome { get; set; }
        // - logs: Queue<Log>
        private Queue<Log> logs = new Queue<Log>();

        // Propriedade para Serialização (necessário para persistência)
        public List<Log> LogsList
        {
            get => logs.ToList();
            set => logs = new Queue<Log>(value);
        }

        public Ambiente() { }

        public Ambiente(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        // + registrarLog(Log log): void
        // Cada ambiente registrará, no máximo, 100 logs (descartando os mais antigos)
        public void RegistrarLog(Log log)
        {
            logs.Enqueue(log);
            if (logs.Count > 100)
            {
                logs.Dequeue(); // Remove o log mais antigo (FIFO)
            }
        }

        public List<Log> ListarLogs(int filtro) // 0=Todos, 1=Autorizado, 2=Negado
        {
            if (filtro == 1) // Autorizado
                return logs.Where(l => l.TipoAcesso).ToList();
            if (filtro == 2) // Negado
                return logs.Where(l => !l.TipoAcesso).ToList();

            return logs.ToList(); // Todos (incluindo 0 ou qualquer outro valor)
        }

        public override string ToString()
        {
            return $"ID: {Id} | Nome: {Nome} | Logs Registrados: {logs.Count}";
        }
    }
}