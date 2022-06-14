using escolaNc.Interfaces;
using escolaNc.Modelos;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace escolaNc.Servicos
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IAcessoBD _acessoBD;
        public RelatorioService(IAcessoBD acesso)
        {
            _acessoBD = acesso;
        }
        public List<RelFaturamento> Faturamento()
        {
            var retorno = new List<RelFaturamento>();

            DataTable dt = _acessoBD.ExecutaProc("dbo.REL_SERVICOS_CONTRATADOS");

            foreach (DataRow r in dt.Rows)
            {
                retorno.Add(new RelFaturamento
                {
                    ID_SERVICO = int.Parse(r.ItemArray[0].ToString()),
                    DESCRICAO = r.ItemArray[1].ToString(),
                    ASSINANTES = int.Parse(r.ItemArray[2].ToString()),
                    VALOR = decimal.Parse(r.ItemArray[3].ToString()),
                    FATURAMENTO = decimal.Parse(r.ItemArray[4].ToString()),
                });
            }

            return retorno;
        }

        public string Inadimplentes(string cpf)
        {
            SqlParameter Parametros = new SqlParameter();
            Parametros.ParameterName = "@CPF";
            Parametros.Value = cpf;
            Parametros.SqlDbType = SqlDbType.NVarChar;

            DataTable dt = new DataTable();

            dt = _acessoBD.ExecutaProc("dbo.RETORNA_INADIMPLENTES", Parametros);


            string JSONString = string.Empty;

            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;
        }
        
    }
}
