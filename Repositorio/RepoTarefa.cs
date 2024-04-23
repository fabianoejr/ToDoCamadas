using Entidades;

namespace Repositorio
{
    public interface IRepoTarefa
    {
        void Inserir(Tarefas tarefa);
        List<Tarefas> BuscarTodasTarefas();
        Tarefas BuscarTarefa(int id);
        void Remover(Tarefas tarefa);
    }
    public class RepoTarefa : IRepoTarefa
    {
        private DataContext _dataContext;

        public RepoTarefa(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Tarefas tarefa)
        {
            _dataContext.Add(tarefa);

            _dataContext.SaveChanges();
        }

        public List<Tarefas> BuscarTodasTarefas()
        {
            var tarefas = _dataContext.Tarefa.ToList();

            return tarefas;
        }

        public Tarefas BuscarTarefa(int id)
        {
            var tarefa = _dataContext.Tarefa.FirstOrDefault(u => u.Id == id);

            return tarefa;
        }

        public void Remover(Tarefas tarefa)
        {
            _dataContext.Remove(tarefa);

            _dataContext.SaveChanges();
        }
    }
}
