using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Business
{
  public class Profile
    {
        private string _token;
        public Profile(IConfiguration config)
        {
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
        }


        public FuncionarioDTO GetOccupationsRF(string rf)
        {
            
            // ir na API pegar a parada 
            if (rf == "7944560")
            {
                var employeeDto = new FuncionarioDTO();
                // Chamar A Api de cargos por RF aqui 
                // Exemplo de objeto Retornado
                //{
                //    "nomeServidor": "HELOISA MARIA DE MORAIS GIANNICHI",
                //    "codigoServidor": "7944560",
                //    "cargos": [
                //                 {
                //                     "codigoCargo": "3360",
                //                     "nomeCargo": "DIRETOR DE ESCOLA",
                //                     "nomeCargoSobreposto": "ASSISTENTE TECNICO DE EDUCACAO I",
                //                     "codigoCargoSobreposto": "2640"
                //                 }
                //               ]
                // }


                var listOccupationsEmployeeDTO = new List<CargoDTO>();
                employeeDto.nomeServidor = "HELOISA MARIA DE MORAIS GIANNICHI";
                employeeDto.codigoServidor = "7944560";

                var occupationsDTO = new CargoDTO()
                {
                    codigoCargo = "3360",
                    nomeCargo = "DIRETOR DE ESCOLA",
                    nomeCargoSobreposto = "ASSISTENTE TECNICO DE EDUCACAO I",
                    codigoCargoSobreposto = "2640"
                };

                listOccupationsEmployeeDTO.Add(occupationsDTO);
                employeeDto.ListOccupations = listOccupationsEmployeeDTO;
                return employeeDto;
            }

            else
            {
                return null;
            }
        
        }

        public PerfisServidoresDTO GetProfileEmployeeInformation(string codeRF, string codeOccupations, string schoolYear)
        {  
            
            //ChamarAPI api/perfis/servidores
            var teacher = new PerfisServidoresDTO();

          
                var listaDre = new List<DreDTO>();
                var listSchool = new List<EscolaDTO>();
                var listClassRoom = new List<TurmaDTO>();
              
          
                teacher.codigoServidor = "6950167";
                teacher.nomeServidor = "ANGELA LUCIA BARBOSA PEREIRA";

                var dre = new DreDTO();
                dre.codigo = "108800";
                dre.nome = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE";
                dre.sigla = "DRE - JT";
                listaDre.Add(dre);
                teacher.drEs = listaDre;

                var school = new EscolaDTO();
                school.codigo = "094765";
                school.codigoDRE = "108800";
                school.nome = "MAXIMO DE MOURA SANTOS, PROF.";
                school.sigla = "PROF. MAXIMO DE MOURA SANTOS";

                listSchool.Add(school);
                teacher.escolas = listSchool;

                var turma1A = new TurmaDTO();
                turma1A.codigo = "1992661";
                turma1A.codigoEscola = "094765";
                turma1A.nome = "1A";

                var turma1B = new TurmaDTO();
                turma1A.codigo = "1992674";
                turma1A.codigoEscola = "1B";
                turma1A.nome = "094765";

                listClassRoom.Add(turma1A);
                listClassRoom.Add(turma1B);

                teacher.turmas = listClassRoom;

            return teacher;
        }
    }
}
