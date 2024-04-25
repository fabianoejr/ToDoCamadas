using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public interface IRepoHistorico
    {
        void Inserir(Historico historico);
        List<Historico> BuscarHistorico();
    }
    public class RepoHistorico : IRepoHistorico
    {
        private DataContext _dataContext;

        public RepoHistorico(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Historico historico)
        {
            _dataContext.Add(historico);

            _dataContext.SaveChanges();
        }

        public List<Historico> BuscarHistorico()
        {
            var historico = _dataContext.Historico
                .FromSqlRaw("select Historico.* " +
                            "from Historico " +
                            "join Usuario on Historico.IdUsuario = Usuario.Id " +
                            "join Tarefa on Historico.IdTarefa = Tarefa.Id")
                .ToList();

            return historico;
        }
    }
}
