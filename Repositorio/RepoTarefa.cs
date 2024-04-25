using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public interface IRepoTarefa
    {
        Tarefas Inserir(Tarefas tarefa);
        List<Tarefas> BuscarTodasTarefas();
        Tarefas BuscarTarefa(int id);
        void Atualizar(Tarefas tarefa);
        void Remover(int id);
    }
    public class RepoTarefa : IRepoTarefa
    {
        private DataContext _dataContext;

        public RepoTarefa(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Tarefas Inserir(Tarefas tarefa)
        {
            _dataContext.Add(tarefa);
            _dataContext.SaveChanges();

            return tarefa;
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

        public void Remover(int id)
        {
            var tarefa = _dataContext.Tarefa.FirstOrDefault(t => t.Id == id);

            if (tarefa != null)
            {
                tarefa.Status = Tarefas.StatusEnum.Deletada; // Atualiza o status para Deletada
                _dataContext.SaveChanges();
            }
        }

        public void Atualizar(Tarefas tarefa)
        {
            // Primeiro, anexe a entidade ao contexto se ainda não estiver
            _dataContext.Tarefa.Attach(tarefa);

            // Marque as propriedades que foram modificadas como "modificadas"
            _dataContext.Entry(tarefa).State = EntityState.Modified;

            // Agora salve as alterações
            _dataContext.SaveChanges();
        }
    }
}
