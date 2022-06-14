using escolaNc.Modelos;
using System.Collections.Generic;

namespace escolaNc.Interfaces
{
    public interface IServicoService
    {
        public List<Servico> RetornaServicos();
        public Servico InsereServico(Servico servico);
    }
}
