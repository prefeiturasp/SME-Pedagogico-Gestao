using Dapper;
using SME.Pedagogico.Gestao.Infra;
using System.Data.Common;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data
{
    public static class QueryInterceptors
    {
        private static IServicoTelemetria servicoTelemetria;

        public static void Init(IServicoTelemetria _servicoTelemetria)
            => servicoTelemetria = _servicoTelemetria; 

        public static DbDataReader ExecuteReader(this DbCommand commando, string queryName = "")
        {
            var restult = servicoTelemetria.RegistrarComRetorno<DbDataReader>(() => SqlMapper.ExecuteReader(commando.Connection,
                commando.CommandText), "query", $"Query {queryName}", commando.CommandText);

            return restult;
        }

        public static async Task<DbDataReader> ExecuteReaderAsync(this DbCommand commando, string queryName = "")
            => await servicoTelemetria.RegistrarComRetornoAsync<DbDataReader>(async () => await SqlMapper.ExecuteReaderAsync(commando.Connection,
                commando.CommandText), "query", $"Query {queryName}", commando.CommandText);
    }
}
