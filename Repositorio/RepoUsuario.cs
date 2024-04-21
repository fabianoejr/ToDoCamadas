using Entidades;

namespace Repositorio
{
    public interface IRepoUsuario
    {
        void Inserir(Usuarios usuario);
        List<Usuarios> BuscarTodos();
        Usuarios BuscarUsuario(string email);
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

        public Usuarios BuscarUsuario(string email)
        {
            var usuario = _dataContext.Usuario.FirstOrDefault(u => u.Email == email);

            return usuario;
        }

        public void Remover(Usuarios usuario)
        {
            _dataContext.Remove(usuario);

            _dataContext.SaveChanges();
        }
    }
}
