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
        Tarefas Inserir(InserirTarefaDTO inserirTarefaDto);
        void Atualizar(Tarefas tarefa);
        void Remover(int id);
    }

    public class ServTarefa : IServTarefa
    {
        private IRepoTarefa _repoTarefa;
        private IServHistorico _servHistorico;

        public ServTarefa(IRepoTarefa repoTarefa, IServHistorico servHistorico)
        {
            _repoTarefa = repoTarefa;
            _servHistorico = servHistorico;
        }

        public Tarefas Inserir(InserirTarefaDTO inserirTarefaDto)
        {
            var tarefa = new Tarefas();

            tarefa.Titulo = inserirTarefaDto.Titulo;
            tarefa.Descricao = inserirTarefaDto.Descricao;
            tarefa.IdCategoria = inserirTarefaDto.IdCategoria;
            tarefa.IdUsuario = inserirTarefaDto.IdUsuario;
            tarefa.DtValidade = inserirTarefaDto.DtValidade;

            Tarefas entityTarefa = _repoTarefa.Inserir(tarefa);

            return entityTarefa;
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
            Tarefas tarefa = _repoTarefa.BuscarTodasTarefas().Where(p => p.Id == id).FirstOrDefault();

            try
            {
                _repoTarefa.Remover(tarefa.Id);
                _servHistorico.Inserir(tarefa);
            } catch (Exception e)
            {
                throw;
            }
        }

        public void Atualizar(Tarefas tarefa)
        {
            try
            {
                _repoTarefa.Atualizar(tarefa);
                _servHistorico.Inserir(tarefa);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}