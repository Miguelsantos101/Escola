using System;
using escolaNc.Data;
using escolaNc.Interfaces;
using escolaNc.Modelos;
using System.Collections.Generic;
using System.Linq;
using escolaNc.Excecao;

namespace escolaNc.Servicos
{
    public class ServicoService : IServicoService
    {
        private EscolaContext _context;
        public ServicoService(EscolaContext context)
        {
            _context = context;
        }

        public List<Servico> RetornaServicos()
        {
            try
            {
                return _context.SERVICOS.ToList();
            }
            catch (Exception)
            {
                throw new Excecoes("Não foi possível acessar a base de dados");
            }
        }

        public Servico InsereServico(Servico servico)
        {
            try
            {
                _context.SERVICOS.Add(servico);
                _context.SaveChanges();
                return servico;
            }
            catch (Exception)
            {
                throw new Excecoes($"O serviço já existe na base de dados");
            }
        }
    }
}
