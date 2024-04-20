using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IServUsuario _servUsuario;

        public UsuarioController(IServUsuario servUsuario)
        {
            _servUsuario = servUsuario;
        }

        [HttpPost]
        public ActionResult Inserir(InserirUsuarioDTO inserirDto)
        {
            try
            {
                _servUsuario.Inserir(inserirDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var usuarios = _servUsuario.BuscarTodos();

                var usuariosEnxuta = usuarios.Select(p =>
                    new
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Email = p.Email
                    }).ToList();

                return Ok(usuariosEnxuta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpDelete]
        public IActionResult Remover(int id)
        {
            try
            {
                _servUsuario.Remover(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}