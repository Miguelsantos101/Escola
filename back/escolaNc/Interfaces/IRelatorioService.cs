using System.Collections.Generic;
using escolaNc.Modelos;

namespace escolaNc.Interfaces
{
    public interface IRelatorioService
    {
        public List<RelFaturamento> Faturamento();
        public string Inadimplentes(string cpf);
    }
}
