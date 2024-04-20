using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServUsuario
    {
        void Inserir(InserirUsuarioDTO inserirUsuarioDto);
        List<Usuarios> BuscarTodos();
        void Remover(int id);
    }

    public class ServUsuario : IServUsuario
    {
        private IRepoUsuario _repoUsuario;

        public ServUsuario(IRepoUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public void Inserir(InserirUsuarioDTO inserirUsuarioDto)
        {
            var usuario = new Usuarios();

            usuario.Nome = inserirUsuarioDto.Nome;
            usuario.Email = inserirUsuarioDto.Email;

            ValidacoesAntesDeInserir(usuario);

            _repoUsuario.Inserir(usuario);
        }

        public void ValidacoesAntesDeInserir(Usuarios usuario)
        {
            if (usuario.Nome.Length < 3)
            {
                throw new Exception("Nome inválido. Deve possuir no mínimo 3 caracteres.");
            }

            if (usuario.Email.Length < 10)
            {
                throw new Exception("Email inválido. Deve possuir no mínimo 10 caracteres.");
            }
        }

        public List<Usuarios> BuscarTodos()
        {
            var usuarios = _repoUsuario.BuscarTodos();

            return usuarios;
        }

        public void Remover(int id)
        {
            var usuario = _repoUsuario.BuscarTodos().Where(p => p.Id == id).FirstOrDefault();

            _repoUsuario.Remover(usuario);
        }

    }
}