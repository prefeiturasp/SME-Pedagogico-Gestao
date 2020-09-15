using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Models.Organization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
  
    public class PeriodoAbertura
    {
        private string _token;
        public PeriodoAbertura(IConfiguration config)
        {
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
        }

        public async Task<List<PeriodoDeAbertura>> GetPeriodoDeAberturas(string  schoolYear)
        {
            try
            {
                using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
                {
                    var teste = db.AccessLevels;
                    var listaPeriodoAbertura = db.PeriodoDeAberturas.Where(x => x.Ano == schoolYear).ToList();
                    return listaPeriodoAbertura;
                }
            }
            catch (System.Exception ex) 
            {

                throw ex;
            }
        }
    }
}
