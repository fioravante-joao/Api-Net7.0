using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhasTarefas.Data;
using MinhasTarefas.Models;
using MinhasTarefas.Models.ResourceTarefa;
using MinhasTarefas.Services;
using MinhasTarefas.ViewModels;

namespace MinhasTarefas.Controllers
{
    [ApiController]
    [Route(template: "v1/users")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route(template: "login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromBody] UserLoginViewModel user,
            [FromServices] AppDbContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuario = await context.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);

            if (usuario == null)
                return NotFound(new {message = "Usuário ou senhas inválidos"});

            var usertoken = TokenService.GenerateToken(usuario);
            usuario.Password = "";
            return new
            {
                user = usuario.UserName,
                token = usertoken
            };
        }


        [HttpPost(template: "create")]
        [AllowAnonymous]
        public async Task<IActionResult> PostUserAsync(
            [FromServices] AppDbContext context,
            [FromBody] UserCreateViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var usuarioObj = new User
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Role = ""
                };
                await context.Users.AddAsync(usuarioObj);
                await context.SaveChangesAsync();

                return Created(uri: $"v1/users/create{usuarioObj.Id}", usuarioObj);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route(template: "list")]
        [AllowAnonymous]
        public async Task<ActionResult> GetUsersAsync(
            [FromServices] AppDbContext context)
        {
            try
            {
                var usuarios = await context
                    .Users //Dbset<Tarefa>
                    .AsNoTracking()
                    .ToListAsync();
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
