using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IServLogin _servLogin;

        public LoginController(IServLogin servLogin)
        {
            _servLogin = servLogin;
        }

        [HttpPost]
        public ActionResult Autenticar(LoginDTO loginDto)
        {
            try
            {
                var login = _servLogin.Autenticar(loginDto);

                if (login == null)
                {
                    return BadRequest("Usuário ou senha ínválido.");
                }

                return Ok(login);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
