using escolaNc.Data;
using escolaNc.Excecao;
using escolaNc.Interfaces;
using escolaNc.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace escolaNc.Servicos
{
    public class ContratacaoService : IContratacaoService
    {
        private readonly EscolaContext _context;

        public ContratacaoService(EscolaContext context)
        {
            _context = context;
        }
        public List<Detalhes> ContratadosCpf(string cpf)
        {
            if (!_context.USUARIOS.Any(u => u.cpf == cpf))
                throw new Excecoes($"CPF {cpf} não encontrado");

            List<Detalhes> detalhes = new List<Detalhes>();

            var consulta = from c in _context.SERVICOS_CONTRATADOS
                           join u in _context.USUARIOS
                           on c.cpf_usuario equals u.cpf
                           join s in _context.SERVICOS
                           on c.id_servico equals s.id
                           where c.cpf_usuario == cpf
                           select new
                           {
                               u.nome,
                               u.cpf,
                               s.descricao,
                               s.preco,
                               c.dt_contratacao,
                               c.id_servicos_contratados
                           };
            foreach (var c in consulta)
            {
                detalhes.Add(new Detalhes
                {
                    nome = c.nome,
                    cpf_usuario = c.cpf,
                    descricao = c.descricao,
                    preco = c.preco,
                    dt_contratacao = c.dt_contratacao,
                    id_servicos_contratados = c.id_servicos_contratados
                });
            }

            if (detalhes.Count == 0)
            {
                var cliente = _context.USUARIOS.FirstOrDefault(u => u.cpf == cpf);
                detalhes.Add(new Detalhes 
                { 
                    nome = cliente.nome, 
                    cpf_usuario = cliente.cpf,
                    descricao = "VAZIO"
                });
            }

            return detalhes;
        }

        public bool ContrataServicos(List<Contratados> lista)
        {
            try
            {
                foreach(var contratado in lista)
                {
                    _context.SERVICOS_CONTRATADOS.Add(contratado);
                }
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                throw new Excecoes("Não foi possível contratar um serviço");
            }
        }


        public bool RemoveServicos(int id_servicos_contratados)
        {
            if (!_context.SERVICOS_CONTRATADOS.Any(u => u.id_servicos_contratados == id_servicos_contratados))
                throw new Excecoes("Contrato não encontrado no banco de dados");

            try
            {
                var contrato = _context.SERVICOS_CONTRATADOS.Find(id_servicos_contratados);

                _context.SERVICOS_CONTRATADOS.Remove(contrato);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                throw new Excecoes("Não foi possivel remover o contrato");
            }
        }

        public List<Detalhes> RetornaContratados()
        {
            List<Detalhes> detalhes = new List<Detalhes>();

            var consulta = from c in _context.SERVICOS_CONTRATADOS
                           join u in _context.USUARIOS
                           on c.cpf_usuario equals u.cpf
                           join s in _context.SERVICOS
                           on c.id_servico equals s.id
                           select new
                           {
                               u.nome,
                               u.cpf,
                               s.descricao,
                               s.preco,
                               c.dt_contratacao,
                               c.id_servicos_contratados
                           };
            foreach(var c in consulta)
            {
                detalhes.Add(new Detalhes
                {
                    nome = c.nome,
                    cpf_usuario = c.cpf,
                    descricao = c.descricao,
                    preco = c.preco,
                    dt_contratacao = c.dt_contratacao,
                    id_servicos_contratados = c.id_servicos_contratados
                });
            }
            return detalhes;
        }

        public List<Servico> RetornaServicos()
        {
            return _context.SERVICOS.ToList();
        }
    }
}
