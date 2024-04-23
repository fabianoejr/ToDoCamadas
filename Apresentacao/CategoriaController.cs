using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private IServCategoria _servCategoria;

        public CategoriaController(IServCategoria servCategoria)
        {
            _servCategoria = servCategoria;
        }

        [HttpPost]
        public ActionResult Inserir(InserirCategoriaDTO inserirCategoriaDto)
        {
            try
            {
                _servCategoria.Inserir(inserirCategoriaDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult BuscarTodasCategorias()
        {
            try
            {
                var categorias = _servCategoria.BuscarTodasCategorias();

                return Ok(categorias);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpGet]
        public IActionResult BuscarCategoria(int id)
        {
            try
            {
                var categoria = _servCategoria.BuscarCategoria(id);

                return Ok(categoria);
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
                _servCategoria.Remover(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}