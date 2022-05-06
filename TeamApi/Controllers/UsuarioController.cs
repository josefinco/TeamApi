using Microsoft.AspNetCore.Mvc;
using TeamApi.Services;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace TeamApi.Controllers
{
    [Controller]

    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {

        private readonly UsuarioService _usuarioService;


        public UsuarioController(UsuarioService mongoDBService)
        {
            _usuarioService = mongoDBService;
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario model)
        {
            // Recupera o usuário
            var user = UsuarioRepository.Get(model.Username, model.Password);

            // Verifica se o usuário existe            
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("getusuario")]
        [AllowAnonymous]
        public async Task<Usuario> Get(string usuario)
        {
            if (string.IsNullOrEmpty(usuario)) return null;
            return await _usuarioService.GetAsync(usuario);
        }


        [HttpPost]
        [Route("createUsuario")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            await _usuarioService.CreateAsync(usuario);

            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }
    }
}
