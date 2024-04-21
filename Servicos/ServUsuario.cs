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
        private IServLogin _servLogin;

        public ServUsuario(IRepoUsuario repoUsuario, IServLogin servLogin)
        {
            _repoUsuario = repoUsuario;
            _servLogin = servLogin;
        }

        public void Inserir(InserirUsuarioDTO inserirUsuarioDto)
        {
            var usuario = new Usuarios();

            usuario.Nome = inserirUsuarioDto.Nome;
            usuario.Email = inserirUsuarioDto.Email;
            
            ValidacoesAntesDeInserir(inserirUsuarioDto);

            usuario.Hash = _servLogin.GerarHashMD5(inserirUsuarioDto.Email, inserirUsuarioDto.Senha);


            _repoUsuario.Inserir(usuario);
        }

        public void ValidacoesAntesDeInserir(InserirUsuarioDTO usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nome) || usuario.Nome.Length < 3)
            {
                throw new Exception("Nome inválido. Deve possuir no mínimo 3 caracteres.");
            }

            if (string.IsNullOrEmpty(usuario.Email) || !IsValidEmail(usuario.Email))
            {
                throw new Exception("Email inválido.");
            }

            if (string.IsNullOrEmpty(usuario.Senha) || usuario.Senha.Length < 3 || !IsStrongPassword(usuario.Senha))
            {
                throw new Exception("Senha inválida. Deve possuir no mínimo 10 caracteres e conter no mínimo uma letra maiúscula e um número");
            }

            // Outras validações, como idade mínima, existência de e-mail único, etc.
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsStrongPassword(string senha)
        {
            // Implemente sua lógica de validação de senha forte aqui.
            // Exemplo simples: pelo menos 1 letra maiúscula e 1 número.
            return senha.Any(char.IsUpper) && senha.Any(char.IsDigit);
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