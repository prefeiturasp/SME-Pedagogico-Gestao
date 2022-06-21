using SME.Pedagogico.Gestao.Infra;
using System.Data.Common;

namespace SME.Pedagogico.Gestao.Data
{
    public static class QueryInterceptors
    {
        private static IServicoTelemetria servicoTelemetria;

        public static void Init(IServicoTelemetria _servicoTelemetria)
            => servicoTelemetria = _servicoTelemetria; 

        public static DbDataReader ExecuteReader(this DbCommand commando, string queryName = "")
        {
            var restult = servicoTelemetria.RegistrarComRetorno<DbDataReader>(() => commando.ExecuteReader(), "query", $"Query {queryName}", commando.CommandText);
            return restult;
        }
    }
}
