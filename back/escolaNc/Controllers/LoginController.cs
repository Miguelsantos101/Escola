using escolaNc.Interfaces;
using escolaNc.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace escolaNc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost, Route("registrar")]
        public IActionResult Registrar([FromBody] Registro registro)
        {
            try
            {
                return Ok(_loginService.Registrar(registro));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("logar")]
        public IActionResult Logar([FromBody] Login dados)
        {
            try
            {
                return Ok(_loginService.Logar(dados));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
