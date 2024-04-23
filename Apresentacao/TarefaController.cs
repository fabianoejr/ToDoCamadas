using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private IServTarefa _servTarefa;

        public TarefaController(IServTarefa servTarefa)
        {
            _servTarefa = servTarefa;
        }

        [HttpPost]
        public ActionResult Inserir(InserirTarefaDTO inserirTarefaDto)
        {
            try
            {
                Console.WriteLine(inserirTarefaDto);
                _servTarefa.Inserir(inserirTarefaDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult BuscarTodasTarefas()
        {
            try
            {
                var tarefas = _servTarefa.BuscarTodasTarefas();

                return Ok(tarefas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpGet]
        public IActionResult BuscarTarefa(int id)
        {
            try
            {
                var tarefa = _servTarefa.BuscarTarefa(id);

                return Ok(tarefa);
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
                _servTarefa.Remover(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}