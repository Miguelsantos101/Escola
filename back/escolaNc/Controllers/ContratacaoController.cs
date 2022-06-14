using escolaNc.Interfaces;
using escolaNc.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace escolaNc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContratacaoController : ControllerBase
    {
        private readonly IContratacaoService _contratacaoService;

        public ContratacaoController(IContratacaoService contratacaoService)
        {
            _contratacaoService = contratacaoService;
        }
        [HttpGet, Route("contratados")]
        public IActionResult RetornaContratados()
        {
            return Ok(_contratacaoService.RetornaContratados());
        }

        [HttpGet("{cpf}")]
        public IActionResult ContratadosCpf(string cpf)
        {
            try
            {
                return Ok(_contratacaoService.ContratadosCpf(cpf));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet, Route("servicos")]
        public IActionResult RetornaServicos()
        {
            try
            {
                return Ok(_contratacaoService.RetornaServicos());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult ContrataServicos([FromBody] List<Contratados> lista)
        {
            try
            {
                return Ok(_contratacaoService.ContrataServicos(lista));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id_servicos_contratados}")]
        public IActionResult RemoveServicos(int id_servicos_contratados)
        {
            try
            {
                return Ok(_contratacaoService.RemoveServicos(id_servicos_contratados));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
