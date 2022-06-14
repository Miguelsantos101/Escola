using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escolaNc.Modelos
{
    public class RelFaturamento
    {
        public int ID_SERVICO { get; set; }
        public string DESCRICAO { get; set; }
        public int ASSINANTES { get; set; }
        public decimal VALOR { get; set; }
        public decimal FATURAMENTO { get; set; }
    }
}
