using MediatR;
using SME.Pedagogico.Gestao.Infra;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class AtualizarPerfilCommand : IRequest<ModificarPerfilRetornoSGPDto>
    {
        public AtualizarPerfilCommand(string perfil)
        {

            Perfil = perfil;
        }


        public string Perfil { get; set; }
    }
}

