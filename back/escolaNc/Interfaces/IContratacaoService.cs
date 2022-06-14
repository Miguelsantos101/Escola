using escolaNc.Modelos;
using System.Collections.Generic;

namespace escolaNc.Interfaces
{
    public interface IContratacaoService
    {
        public List<Detalhes> RetornaContratados();
        public List<Detalhes> ContratadosCpf(string cpf);
        public List<Servico> RetornaServicos();
        public bool ContrataServicos(List<Contratados> lista);
        public bool RemoveServicos(int id_servicos_contratados);
    }
}
