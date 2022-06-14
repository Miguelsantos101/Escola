using escolaNc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace escolaNc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _relService;
        public RelatoriosController(IRelatorioService relService)
        {
            _relService = relService;
        }
        
        [HttpGet, Route("faturamento")]
        public IActionResult Faturamento()
        {
            return Ok(_relService.Faturamento());
        }

        [HttpGet, Route("inadimplentes/{cpf=}")]
        public IActionResult Inadimplentes(string cpf)
        {
            return Ok(_relService.Inadimplentes(cpf));
        }

    }
}
