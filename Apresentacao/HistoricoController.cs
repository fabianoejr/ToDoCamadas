using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        private IServHistorico _servHistorico;

        public HistoricoController(IServHistorico servHistorico)
        {
            _servHistorico = servHistorico;
        }

        [HttpGet]
        public IActionResult BuscarHistorico()
        {
            try
            {
                var historico = _servHistorico.BuscarHistorico();

                return Ok(historico);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}