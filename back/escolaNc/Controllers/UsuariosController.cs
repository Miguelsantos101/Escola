using escolaNc.Interfaces;
using escolaNc.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace escolaNc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;
        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuariosService.RetornaUsuarios());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("Inserir")]
        public IActionResult InserirUsuario ([FromBody] Usuario usuario)
        {
            try
            {
                return Ok(_usuariosService.InsereUsuario(usuario));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("Atualizar")]
        public IActionResult AtualizaUsuario ([FromBody] Usuario usuario)
        {
            try
            {
                return Ok(_usuariosService.AtualizaUsuario(usuario));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{cpf}")]
        public IActionResult RemoveUsuario (string cpf)
        {
            try
            {
                return Ok(_usuariosService.RemoveUsuario(cpf));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
