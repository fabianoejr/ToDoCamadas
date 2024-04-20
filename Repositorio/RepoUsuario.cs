using Entidades;

namespace Repositorio
{
    public interface IRepoUsuario
    {
        void Inserir(Usuarios usuario);
        List<Usuarios> BuscarTodos();
        void Remover(Usuarios usuario);
    }
    public class RepoUsuario : IRepoUsuario
    {
        private DataContext _dataContext;

        public RepoUsuario(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }

        public void Inserir(Usuarios usuario)
        {
            _dataContext.Add(usuario);

            _dataContext.SaveChanges();
        }

        public List<Usuarios> BuscarTodos()
        {
            var usuarios = _dataContext.Usuario.ToList();

            return usuarios;
        }

        public void Remover(Usuarios usuario)
        {
            _dataContext.Remove(usuario);

            _dataContext.SaveChanges();
        }
    }
}
