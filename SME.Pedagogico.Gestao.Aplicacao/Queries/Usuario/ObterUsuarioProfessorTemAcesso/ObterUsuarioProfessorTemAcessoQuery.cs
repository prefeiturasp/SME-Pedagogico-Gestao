using MediatR;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterUsuarioProfessorTemAcessoQuery : IRequest<bool>
    {
        public ObterUsuarioProfessorTemAcessoQuery(string professorRF)
        {
            ProfessorRF = professorRF;
        }

        public string ProfessorRF { get; set; }
    }
}
