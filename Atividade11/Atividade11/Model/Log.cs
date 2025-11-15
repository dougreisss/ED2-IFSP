using Atividade11.Model;
using System;

namespace Atividade11.Model
{
    public class Log
    {
        // - dtAcesso: DateTime
        public DateTime DtAcesso { get; set; }
        // - usuario: Usuario
        public Usuario Usuario { get; set; }
        // - tipoAcesso: bool (true=Autorizado, false=Negado)
        public bool TipoAcesso { get; set; }

        public Log() { }

        public Log(Usuario usuario, bool tipoAcesso)
        {
            DtAcesso = DateTime.Now;
            Usuario = usuario;
            TipoAcesso = tipoAcesso;
        }

        public override string ToString()
        {
            string status = TipoAcesso ? "AUTORIZADO" : "NEGADO";
            // Exibir dados sintéticos do usuário
            return $"{DtAcesso:dd/MM/yyyy HH:mm:ss} | Usuário: {Usuario.Id}-{Usuario.Nome} | Status: {status}";
        }
    }
}