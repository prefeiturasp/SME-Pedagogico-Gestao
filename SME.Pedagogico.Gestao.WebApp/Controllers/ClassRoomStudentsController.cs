using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.WebApp.Contexts;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassRoomStudentsController : ControllerBase
    {
        #region ==================== ATTRIBUTES ====================
        private IConfiguration _config; // Objeto para recuperar informações de configuração do arquivo appsettings.json
        private readonly SMEManagementContext _db; // Objeto context referente ao banco smeCoreDB
        #endregion ==================== ATTRIBUTES ====================


        #region ==================== CONSTRUCTORS ====================
        /// <summary>
        /// Construtor padrão para o ClassRoomStudents, faz injeção de dependências de IConfiguration e SMEManagementContext.
        /// </summary>
        /// <param name="config">Depêndencia de configurações</param>
        /// <param name="db">Depêndencia de dataContext (SMEManagementContext)</param>
        public ClassRoomStudentsController(IConfiguration config, SMEManagementContext db)
        {
            _config = config;
            _db = db;
        }
        #endregion ==================== CONSTRUCTORS ====================

        //[HttpPost]
        //public async Task<ActionResult<string>> ListaAlunosDaTurma([FromBody]ClassRoom classRoom)
        //{
        //    // Fazer chamada para o metodo da 
        //    //api que passando o classRoom e pegando o retorno que é a lista de alunos.

        //    var BusinessClassRomm = new Data.Business.ClassRoom();

        //    using (SMEManagementContext db = new SMEManagementContext())
        //    {
        //        List<PortuguesePoll> portuguese = await db.PortuguesePolls.Where(x =>
        //       x.schoolCodeEol
        //    }

          
        //    // Pegar Alunos da turma 

        //    var listStudentsClassRoom = BusinessClassRomm.MockListaChamada();

        //    return (Ok(listStudentsClassRoom));
        //    //APLICAR REGRAS QUE ENVOLVEM A LISTA DE CHAMADA

        //    //// Remover alunos que sairam antes do inicio do periodo letivo
        //    //var schoolYear = GetSchoolYearCalendar("Ensino Regular", 2019);
        //    //string name = "Ensino Regular";

        //    //SchoolTerm schoolTerm = await
        //    //    (from current in _db.SchoolTerms
        //    //     where current.SchoolYear.Year == 2019
        //    //     select current).FirstOrDefaultAsync();


        //    //// Remover alunos que sairam antes do inicio do periodo letivo
        //    //var ListAlunosAtivos = List.FindAll(x => x.DataDaSituacao >= schoolTerm.ValidityStart);

        //    ////Se o aluno for maior de 18 anos aparecer nome social, se houver na lista de frequência. Nas demais listas nome oficial com social entre parênteses

        //    //foreach (var student in ListAlunosAtivos)
        //    //{
        //    //    var idade = CalculaIdade(student.DataNascimento);

        //    //    if (idade >= 18)
        //    //    {
        //    //        student.NomeFrequencia = student.NomeSocial;
        //    //        student.NomeAluno = student.NomeAluno + " (" + student.NomeSocial + ")";
        //    //    }

        //    //    else
        //    //    {
        //    //        student.NomeFrequencia = student.NomeAluno;
        //    //        student.NomeAluno = student.NomeAluno + " (" + student.NomeSocial + ")";

        //    //    }

        //    //}

        //    //// Marcador visual alunos recem matriculados.

        //    //SchoolTerm schoolTermAtual = AchaBimetreAtual();

        //    //foreach (var student in ListAlunosAtivos)
        //    //{
        //    //    //Verifica se foi matriculado nesse bimestre
        //    //    if (student.DataDaSituacao > schoolTermAtual.ValidityStart && student.DataDaSituacao < schoolTermAtual.ValidityEnd)
        //    //    {
        //    //        int diasMatriculado = DateTime.Now.DayOfYear - student.DataDaSituacao.DayOfYear;

        //    //        if (diasMatriculado < 30) //Incluir parametro do banco
        //    //        {
        //    //            student.AlunoRecemMatriculado = true;
        //    //        }

        //    //    }

        //    //}
        //}
    } 
}
