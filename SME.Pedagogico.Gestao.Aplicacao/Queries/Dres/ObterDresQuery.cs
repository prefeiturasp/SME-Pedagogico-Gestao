using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterDresQuery : IRequest<List<DREsDTO>>
    {
        public ObterDresQuery(long anoLetivo)
        {
            AnoLetivo = anoLetivo;
        }

        public long AnoLetivo { get; set; }
    }
}
