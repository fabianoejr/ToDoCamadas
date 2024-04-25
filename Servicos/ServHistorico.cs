using Entidades;
using Repositorio;
using System.Security.Cryptography;
using System.Text;

namespace Servicos
{
    public interface IServHistorico
    {
        List<Historico> BuscarHistorico();
        void Inserir(Tarefas inserirTarefaDto);
    }

    public class ServHistorico : IServHistorico
    {
        private IRepoHistorico _repoHistorico;

        public ServHistorico(IRepoHistorico repoHistorico)
        {
            _repoHistorico = repoHistorico;
        }

        public void Inserir(Tarefas inserirTarefaDto)
        {
            var historico = new Historico();

            historico.IdUsuario = inserirTarefaDto.IdUsuario;
            historico.IdTarefa = inserirTarefaDto.Id;
            historico.Operacao = (Historico.OperacaoEnum)inserirTarefaDto.Status;

            _repoHistorico.Inserir(historico);
        }

        public List<Historico> BuscarHistorico()
        {
            var historico = _repoHistorico.BuscarHistorico();

            return historico;
        }
    }
}