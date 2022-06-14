using escolaNc.Interfaces;
using escolaNc.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace escolaNc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicosController : ControllerBase
    {
        private readonly IServicoService _servicoService;

        public ServicosController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_servicoService.RetornaServicos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("Inserir")]
        public IActionResult InserirServico([FromBody] Servico servico)
        {
            try
            {
                return Ok(_servicoService.InsereServico(servico));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
