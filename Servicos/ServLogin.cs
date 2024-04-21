using Entidades;
using Repositorio;
using System.Security.Cryptography;
using System.Text;

namespace Servicos
{
    public interface IServLogin
    {
        List<Usuarios> BuscarTodos();
        string GerarHashMD5(string email, string senha);
        string Autenticar(LoginDTO loginDTO);
    }

    public class ServLogin : IServLogin
    {
        private IRepoUsuario _repoUsuario;

        public ServLogin(IRepoUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public string Autenticar(LoginDTO loginDTO)
        {
            {
                var usuario = _repoUsuario.BuscarUsuario(loginDTO.Email);
                var hash = GerarHashMD5(loginDTO.Email, loginDTO.Senha);

                if (usuario != null && usuario.Hash == hash)
                {
                    return hash;
                }
                else
                {
                    return null;
                }
            }
        }

        public string GerarHashMD5(string email, string senha)
        {
            string input = email + senha; // Concatena o email e senha
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Converte os bytes para uma string hexadecimal
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
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
    }
}