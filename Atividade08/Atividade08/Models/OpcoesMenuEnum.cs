using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade08.Models
{
    public enum OpcoesMenuEnum
    {
        Sair = 0,
        AdicionarProjeto = 1,
        PesquisarProjeto = 2,
        RemoverProjeto = 3,
        AdicionarTarefa = 4,
        ConcluirTarefa = 5,
        CancelarTarefa = 6,
        ReabrirTarefa = 7,
        ListarTarefasEmSomenteProjeto = 8,
        FiltrarTarefasEmSomenteProjeto = 9,
        FiltrarTarefasEmProjetos = 10,
        ResumoGeral = 11,
    }
}
