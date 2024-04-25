using Apresentacao.Migrations;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private IServTarefa _servTarefa;
        private IServHistorico _servHistorico;

        public TarefaController(IServTarefa servTarefa, IServHistorico servHistorico)
        {
            _servTarefa = servTarefa;
            _servHistorico = servHistorico;
        }

        [HttpPost]
        public ActionResult Inserir(InserirTarefaDTO inserirTarefaDto)
        {
            try
            {
                Tarefas tarefa = _servTarefa.Inserir(inserirTarefaDto);
                _servHistorico.Inserir(tarefa);

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

        [Route("/api/[controller]")]
        [HttpPut]
        public IActionResult Atualizar(Tarefas tarefa)
        {
            try
            {
                _servTarefa.Atualizar(tarefa);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}