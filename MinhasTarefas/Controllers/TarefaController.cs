using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasTarefas.Data;
using MinhasTarefas.Models.ResourceTarefa;
using MinhasTarefas.ViewModels;
using System.Security.Claims;

namespace MinhasTarefas.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        [Route(template: "tarefas")]
        [Authorize]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context,
            [FromServices] TarefaResources tarefaResources)
        {
            var tarefas = await tarefaResources.ListTodasTarefasAsync();
            return tarefas == null
                ? StatusCode(204)
                : Ok(tarefas);
        }

        [HttpGet]
        [Route(template: "tarefas/{id}")]
        [Authorize]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromServices] TarefaResources tarefaResources,
            [FromRoute] int id)
        {
            var tarefa = await tarefaResources.ListTarefaIdAsync(id);

            return tarefa == null
                ? NotFound()
                : Ok(tarefa);
        }

        [HttpPost(template: "tarefas")]
        [Authorize]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromServices] TarefaResources tarefaResources,
            [FromBody] CreateTarefaViewModel tarefa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                // Acessa o ID do usuário do contexto de solicitação HTTP
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var tarefaObj = await tarefaResources.AdicionarTarefaAsync(tarefa, userId);
                return Created(uri: $"v1/tarefas/{tarefaObj.Id}", tarefaObj);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut(template: "tarefas/{id}")]
        [Authorize]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromServices] TarefaResources tarefaResources,
            [FromBody] UpdateTarefaViewModel tarefa,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
                        
            try
            {
                // Acessa o ID do usuário do contexto de solicitação HTTP
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var tarefaObj = await tarefaResources.AtualizarTarefaAsync(id, tarefa, userId);
                if (tarefaObj == null)
                {
                    return NotFound();
                }
                return Ok(tarefaObj);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete(template: "tarefas/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromServices] TarefaResources tarefaResources,
            [FromRoute] int id)
        {
            try
            {
                // Acessa o ID do usuário do contexto de solicitação HTTP
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var BoolOperacaoDelete = await tarefaResources.DeleteTarefaAsync(id, userId);
                if (!BoolOperacaoDelete) return StatusCode(404);

                return Ok("Tarefa Deletada com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
