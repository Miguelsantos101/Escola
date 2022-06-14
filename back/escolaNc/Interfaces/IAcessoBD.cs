using Microsoft.Data.SqlClient;
using System.Data;

namespace escolaNc.Interfaces
{
    public interface IAcessoBD
    {
        public DataTable ExecutaProc(string Procedure);
        public DataTable ExecutaProc(string Procedure, SqlParameter parametros);
    }
}
