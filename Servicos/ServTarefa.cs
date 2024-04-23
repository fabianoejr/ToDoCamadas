using Entidades;
using Repositorio;
using System.Security.Cryptography;
using System.Text;

namespace Servicos
{
    public interface IServTarefa
    {
        List<Tarefas> BuscarTodasTarefas();
        Tarefas BuscarTarefa(int id);
        void Inserir(InserirTarefaDTO inserirTarefaDto);
        void Remover(int id);
    }

    public class ServTarefa : IServTarefa
    {
        private IRepoTarefa _repoTarefa;

        public ServTarefa(IRepoTarefa repoTarefa)
        {
            _repoTarefa = repoTarefa;
        }

        public void Inserir(InserirTarefaDTO inserirTarefaDto)
        {
            var tarefa = new Tarefas();

            tarefa.Titulo = inserirTarefaDto.Titulo;
            tarefa.Descricao = inserirTarefaDto.Descricao;
            tarefa.IdCategoria = inserirTarefaDto.IdCategoria;
            tarefa.IdUsuario = inserirTarefaDto.IdUsuario;
            tarefa.DtValidade = inserirTarefaDto.DtValidade;

            _repoTarefa.Inserir(tarefa);
        }

        public List<Tarefas> BuscarTodasTarefas()
        {
            var tarefas = _repoTarefa.BuscarTodasTarefas();

            return tarefas;
        }

        public Tarefas BuscarTarefa(int id)
        {
            return _repoTarefa.BuscarTodasTarefas().Where(p => p.Id == id).FirstOrDefault();
        }

        public void Remover(int id)
        {
            var tarefa = _repoTarefa.BuscarTodasTarefas().Where(p => p.Id == id).FirstOrDefault();

            _repoTarefa.Remover(tarefa);
        }
    }
}