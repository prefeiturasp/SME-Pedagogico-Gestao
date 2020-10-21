﻿import React, { Component } from "react";
import SelectChangeColor from "../inputs/SelectChangeColor";
import CircleButton from "../inputs/CircleButton";
import { connect } from "react-redux";
import { actionCreators as actionCreatorsPoll } from "../../store/Filters";
import { actionCreators as actionCreatorsPoll2 } from "../../store/Poll";
import { actionCreators as actionCreatorsPollRouter } from "../../store/PollRouter";
import { bindActionCreators } from "redux";
import { ROLES_ENUM } from "../../Enums";
import { DISCIPLINES_ENUM } from "../../Enums";
import TwoSteps from "../messaging/TwoSteps";
import MensagemConfirmacaoAutoral from "./SondagemPortuguesAutoral/mensagemConfirmacaoAutoral";

class PollFilter extends Component {
  constructor(props) {
    super(props);
    this.state = {
      selectedDre: "",
      selectedSchool: "",
      showMessageBox: false,
      selectedClassRoom: "",
      yearClassroom: null,
      classroom: "",
      listSchools: [],
      listClassRoomTeacher: [],
      schoolYear: "",
    };

    this.SelectedDre = this.SelectedDre.bind(this);
    this.SelectedSchool = this.SelectedSchool.bind(this);
    this.SelectedClassRoom = this.SelectedClassRoom.bind(this);
    this.setSelectedFilter = this.setSelectedFilter.bind(this);
    this.getClassroom = this.getClassroom.bind(this);
    this.checkDisabledButton = this.checkDisabledButton.bind(this);
    this.selectedDreTeacher = this.selectedDreTeacher.bind(this);
    this.toggleMessageBox = this.toggleMessageBox.bind(this);
    this.selectedSchoolTeacher = this.selectedSchoolTeacher.bind(this);
    this.selectedSchoolYear = this.selectedSchoolYear.bind(this);
    this.getProfileInformationProf = this.getProfileInformationProf.bind(this);
    // this.getPeriod = this.getPeriod.bind(this);
  }

  componentWillMount() {
    var anoLetivo = new Date();
    var anoAtual = anoLetivo.getFullYear();
    this.setState({
      schoolYear: anoAtual,
    });

    this.props.filterMethods.getPeriod(anoAtual);
    this.props.filterMethods.setSchoolYear(anoAtual);

    this.applyRole(anoAtual);

    if (ROLES_ENUM.ApenasRelatorios(this.props.user.activeRole.roleName)) {
      this.props.pollRouterMethods.setActiveRoute("Relatórios");
    }
  }

  applyRole(ano) {
    if (ROLES_ENUM.IsDRE(this.props.user.activeRole.roleName))
      this.props.filterMethods.getDreAdm(this.props.user.username);
    else if (ROLES_ENUM.IsSME(this.props.user.activeRole.roleName))
      this.props.filterMethods.getListDres();
    else if (ROLES_ENUM.IsUE(this.props.user.activeRole.roleName))
      this.getProfileInformationProf(ano);
  }

  getProfileInformationProf(anoAtual) {
    var role = this.props.user;

    if (role.activeRole.roleName === ROLES_ENUM.PROFESSOR) {
      var codeOccupations = this.props.user.listOccupations.Professor;
    } else if (role.activeRole.roleName === ROLES_ENUM.COORDENADOR_PEDAGOGICO) {
      var codeOccupations = this.props.user.listOccupations.CP;
    } else if (role.activeRole.roleName === ROLES_ENUM.DIRETOR) {
      var codeOccupations = this.props.user.listOccupations.Diretor;
    } else if (role.activeRole.roleName === ROLES_ENUM.AD) {
      var codeOccupations = this.props.user.listOccupations.AD;
    }

    var profileOccupatios = {
      codigoRF: this.props.user.username,
      codigoCargo: codeOccupations,
      anoLetivo: anoAtual,
      activeRole: this.props.user.activeRole,
    };

    this.props.filterMethods.getFilters_teacher(profileOccupatios);
  }

  selectedSchoolYear(event) {
    this.props.filterMethods.resetPollFilters();

    var index = event.nativeEvent.target.selectedIndex;
    var label = event.nativeEvent.target[index].value;

    this.props.filterMethods.setSchoolYear(label);

    this.props.filterMethods.getPeriod(label);
    this.setState({
      selectedDre: "",
      selectedClassRoom: "",
      schoolYear: label,
      listSchools: null,
      yearClassroom: null,
      classroom: "",
    });

    // this.setState({
    //     selectedDre: "",
    //     selectedClassRoom: "",
    //     yearClassroom: null,
    //     classroom: "",
    // });

    this.applyRole(label);
  }

  selectedDreTeacher(event) {
    var index = event.nativeEvent.target.selectedIndex;
    var label = event.nativeEvent.target[index].value;
    var schoolCode = {
      dreCodeEol: label,
    };

    this.props.filterMethods.activeDreCode(schoolCode);

    var listSchools = this.props.filters.filterTeachers.escolas.filter(
      (x) => x.codigoDRE === label
    );

    if (listSchools.length === 1) {
      var filterSchool = {
        schoolCodeEol: listSchools[0].codigo,
      };

      this.props.filterMethods.activeSchoolCode(filterSchool);
    }

    this.setState({
      listSchools: listSchools,
      yearClassroom: null,
      classroom: "",
    });
  }
  selectedSchoolTeacher(event) {
    var listClassRoomTeacher = [];

    var index = event.nativeEvent.target.selectedIndex;
    var label = event.nativeEvent.target[index].value;
    var classRoomFilter = {
      schoolCodeEol: label,
    };

    this.props.filterMethods.activeSchoolCode(classRoomFilter);

    if (this.props.user.activeRole.roleName === ROLES_ENUM.PROFESSOR) {
      listClassRoomTeacher = this.props.filters.filterTeachers.turmas.filter(
        (x) => x.codigoEscola === label
      );
    } else if (
      ROLES_ENUM.IsUE(this.props.user.activeRole.roleName) ||
      ROLES_ENUM.IsDRE(this.props.user.activeRole.roleName)
    ) {
      var classRoomFilter = {
        schoolCodeEol: label,
        schoolYear: this.props.filters.setSchoolYear,
      };
      this.props.filterMethods.getClassroom(classRoomFilter);
      listClassRoomTeacher = this.props.filters.listClassRoom;
    }

    this.setState({
      listClassRoomTeacher: listClassRoomTeacher,
      yearClassroom: null,
      classroom: "",
    });
  }

  SelectedDre(event) {
    //  this.props.filterMethods.resetPollFilters();
    //  this.props.filterMethods.getDre();
    var index = event.nativeEvent.target.selectedIndex;
    var label = event.nativeEvent.target[index].value;

    var schoolCode = {
      dreCodeEol: label,
      schoolYear: this.props.filters.setSchoolYear,
    };

    this.props.filterMethods.getSchool(schoolCode);
    this.setState({
      selectedDre: label,
      // selectedSchool: "",
      selectedClassRoom: "",
      yearClassroom: null,
      classroom: "",
    });

    if (label === "todas") {
      this.props.filterMethods.activeClassroom("");
      this.props.filterMethods.getClassroom({
        schoolCodeEol: "",
        schoolYear: this.props.filters.setSchoolYear,
      });
    }
  }

  SelectedYear(event) {
    this.props.filterMethods.getYear();
  }

  SelectedSchool(event) {
    this.props.filterMethods.getSchool({
      dreCodeEol: this.state.selectedDre,
      schoolYear: this.props.filters.setSchoolYear,
    });

    var index = event.nativeEvent.target.selectedIndex;
    var label = event.nativeEvent.target[index].value;

    var classRoomFilter = {
      schoolCodeEol: label,
      schoolYear: this.props.filters.setSchoolYear,
    };
    if (label !== "todas")
      this.props.filterMethods.getClassroom(classRoomFilter);
    this.setState({
      selectedSchool: label,
      selectedClassRoom: "",
      yearClassroom: null,
      classroom: "",
    });
  }

  SelectedClassRoom(event) {
    var index = event.nativeEvent.target.selectedIndex;
    var label = event.nativeEvent.target[index].value;

    var codeClassRoom = label;

    var disciplinesFilter = {
      codigoRf: this.props.user.username,
      codigoTurmaEol: codeClassRoom,
    };

    this.props.filterMethods.getDisciplinesByClassroom(disciplinesFilter);
    this.props.filterMethods.activeClassroom(codeClassRoom);

    this.setState({
      classroom: event.target[index].innerText.substring(0, 1),
      selectedClassRoom: codeClassRoom,
    });
  }

  getClassroom(event) {
    this.props.filterMethods.activeClassroom("");
    this.setState({
      classroom: event.target.value,
      selectedClassRoom: "",
    });
  }

  toggleMessageBox() {
    if (!this.props.data.newDataToSave) this.setSelectedFilter();

    this.setState({
      showMessageBox:
        this.props.data.newDataToSave && !this.state.showMessageBox,
    });
  }

  setSelectedFilter() {
    var selectedFilter = {
      dreCodeEol: this.props.filters.activeDreCode,
      schoolCodeEol: this.props.filters.activeSchollsCode,
      classroomCodeEol: this.props.filters.activeClassRoomCode,
      schoolYear: this.props.filters.setSchoolYear,
      yearClassroom: this.state.classroom,
      rfCode: this.props.user.username,
    };

    this.props.poll2.setSelectedFilter(selectedFilter);

    if (this.props.resultClick !== undefined) this.props.resultClick(true);
  }

  checkDisabledButton() {
    if (this.props.reports) {
      //Independente do perfil o relatorio so pode ser tirado por Ano
      if (this.state.classroom !== null && this.state.classroom !== "" && this.props.user.activeRole.roleName !== ROLES_ENUM.PROFESSOR)
        return true;
      //Para professor é necessário selecionar a turma
      else if (this.props.user.activeRole.roleName === ROLES_ENUM.PROFESSOR && this.props.filters.listDisciplines.length > 0)
        return true;
      else
        return false;


      //if (this.props.filters.activeDreCode !== null &&
      //    this.props.filters.activeSchollsCode !== null || this.props.filters.activeClassRoomCode !== null)
      //    return (true);
      //else
      //    return (false);
    } else {
      if (this.props.user.activeRole.roleName !== ROLES_ENUM.PROFESSOR) {
        if (
          this.props.filters.activeDreCode !== null &&
          this.props.filters.activeSchollsCode !== null &&
          this.props.filters.activeClassRoomCode !== null
        )
          return true;
        else return false;
      } else if (this.props.filters.activeClassRoomCode !== null) return true;
      else return false;
    }
  }

  render() {
    const { selectedDre } = this.state;
    const { selectedSchool } = this.state;
    const { selectedClassRoom } = this.state;
    var selectDre = null;
    var selectSchool = null;
    var selectClassRoom = null;
    var yearClassrooms = [];
    var hiddenDisabled = false;
    const listDresOptions = [];
    const listSchoolOptions = [];
    const listClassRoomOptions = [];
    const listYearsOptions = [];

    var dataAtual = new Date();
    var anoAtual = dataAtual.getFullYear();
    var aux = anoAtual;
    listYearsOptions.push({
      value: anoAtual,
      label: anoAtual,
    });

    for (var i = 2019; i < anoAtual; i++) {
      aux = aux - 1;
      listYearsOptions.push({
        value: aux,
        label: aux,
      });
    }

    listYearsOptions.reverse();

    if (this.props.pollRouter.activeRoute !== "Sondagem") {
      if (ROLES_ENUM.IsSME(this.props.user.activeRole.roleName)) {
        listDresOptions.push({ label: "Todas", value: "todas" });
      }
    }

    if (
      this.props.filters.filterTeachers !== null &&
      this.props.filters.filterTeachers.drEs !== undefined
    ) {
      var DreSelected;
      var SchoolSelected;
      var enabledDre = false;
      var disabledSchool = false;
      // DRES de professor
      for (var item in this.props.filters.filterTeachers.drEs) {
        listDresOptions.push({
          value: this.props.filters.filterTeachers.drEs[item].codigo,
          label: this.props.filters.filterTeachers.drEs[item].nome.replace(
            "DIRETORIA REGIONAL DE EDUCACAO",
            "DRE -"
          ),
        });
      }

      selectDre = (
        <SelectChangeColor
          className="col-4"
          defaultText="Selecione a DRE"
          value={DreSelected}
          options={listDresOptions}
          disabled={enabledDre}
          onChange={this.selectedDreTeacher}
        />
      );
      // escolas de professor
      for (var item in this.state.listSchools) {
        listSchoolOptions.push({
          value: this.state.listSchools[item].codigo,
          label: this.state.listSchools[item].nome,
        });
      }

      selectSchool = (
        <SelectChangeColor
          className="col-4"
          value={SchoolSelected}
          defaultText="Escola"
          options={listSchoolOptions}
          disabled={disabledSchool}
          onChange={this.selectedSchoolTeacher}
          resetColor={SchoolSelected === "" ? true : false}
        />
      );

      if (this.props.user.activeRole.roleName === ROLES_ENUM.PROFESSOR) {
        if (this.state.classroom !== null)
          for (var item in this.state.listClassRoomTeacher) {
            if (
              this.state.listClassRoomTeacher[item].nome.startsWith(
                this.state.classroom
              )
            )
              listClassRoomOptions.push({
                value: this.state.listClassRoomTeacher[item].codigo,
                label: this.state.listClassRoomTeacher[item].nome,
              });
          }
        else
          for (var item in this.state.listClassRoomTeacher) {
            listClassRoomOptions.push({
              value: this.state.listClassRoomTeacher[item].codigo,
              label: this.state.listClassRoomTeacher[item].nome,
            });
          }

        selectClassRoom = (
          <SelectChangeColor
            className="col"
            value={selectedClassRoom}
            defaultText="Turma"
            options={listClassRoomOptions}
            disabled={hiddenDisabled}
            onChange={this.SelectedClassRoom}
            resetColor={selectedClassRoom === "" ? true : false}
          />
        );

        // var yearClassrooms = [];

        if (this.state.listClassRoomTeacher !== null) {
          var temp = this.state.listClassRoomTeacher;
          var uniques = [];

          for (var i = 0; i < temp.length; i++) {
            var classroom = temp[i].nome.substring(0, 1);

            if (uniques.indexOf(classroom) === -1) {
              yearClassrooms.push({ label: classroom, value: classroom });
              uniques.push(classroom);
            }
          }
        }
      } else if (ROLES_ENUM.IsUE(this.props.user.activeRole.roleName)) {
        if (
          selectedSchool !== "todas" &&
          this.props.filters.listClassRoom !== undefined
        ) {
          if (
            this.props.filters.listClassRoom !== [] &&
            this.props.filters.listClassRoom !== null &&
            this.props.filters.listClassRoom.length > 1
          ) {
            if (this.state.classroom !== null)
              for (var item in this.props.filters.listClassRoom) {
                if (
                  this.props.filters.listClassRoom[item].nomeTurma.startsWith(
                    this.state.classroom
                  )
                )
                  listClassRoomOptions.push({
                    value: this.props.filters.listClassRoom[item].codigoTurma,
                    label: this.props.filters.listClassRoom[item].nomeTurma,
                  });
              }
            else
              for (var item in this.props.filters.listClassRoom) {
                listClassRoomOptions.push({
                  value: this.props.filters.listClassRoom[item].codigoTurma,
                  label: this.props.filters.listClassRoom[item].nomeTurma,
                });
              }
          }
        }

        selectClassRoom = (
          <SelectChangeColor
            className="col"
            value={selectedClassRoom}
            defaultText="Turma"
            options={listClassRoomOptions}
            disabled={hiddenDisabled}
            onChange={this.SelectedClassRoom}
            resetColor={selectedClassRoom === "" ? true : false}
          />
        );

        if (
          this.props.filters.listClassRoom !== null &&
          this.props.filters.listClassRoom !== undefined
        ) {
          var temp = this.props.filters.listClassRoom;
          var uniques = [];

          for (var i = 0; i < temp.length; i++) {
            var classroom = temp[i].nomeTurma.substring(0, 1);

            if (uniques.indexOf(classroom) === -1) {
              yearClassrooms.push({ label: classroom, value: classroom });
              uniques.push(classroom);
            }
          }
        }
      }

      if (selectedSchool === "todas" || selectedDre === "todas") {
        hiddenDisabled = true;

        var listyearClassrooms = [1, 2, 3, 4, 5, 6];
        for (var item in listyearClassrooms) {
          yearClassrooms.push({
            value: listyearClassrooms[item],
            label: listyearClassrooms[item],
          });
        }
      }
    } else {
      if (this.props.filters.listDres !== null) {
        selectDre = (
          <SelectChangeColor
            className="col-4"
            defaultText="Selecione a DRE"
            value={selectedDre}
            options={listDresOptions}
            onChange={this.SelectedDre}
          />
        );

        if (this.props.filters.activeDreCode !== null) {
          if (this.props.pollRouter.activeRoute !== "Sondagem") {
            listSchoolOptions.push({ label: "Todas", value: "todas" });
          }
        }
        for (var item in this.props.filters.listDres) {
          listDresOptions.push({
            value: this.props.filters.listDres[item].codigoDRE,
            label: this.props.filters.listDres[item].nomeDRE.replace(
              "DIRETORIA REGIONAL DE EDUCACAO",
              "DRE -"
            ),
          });
        }

        if (selectedDre !== "todas" && this.props.filters.scholls !== undefined)
          if (this.props.filters.scholls[0] !== undefined) {
            for (var item in this.props.filters.scholls) {
              listSchoolOptions.push({
                value: this.props.filters.scholls[item].codigoEscola,
                label: this.props.filters.scholls[item].nomeEscola,
              });
            }

            selectSchool = (
              <SelectChangeColor
                className="col-4"
                value={SchoolSelected}
                defaultText="Escola"
                options={listSchoolOptions}
                onChange={this.SelectedSchool}
                resetColor={SchoolSelected === "" ? true : false}
              />
            );

            if (
              selectedSchool !== "todas" &&
              this.props.filters.listClassRoom !== undefined
            ) {
              if (
                this.props.filters.listClassRoom !== [] &&
                this.props.filters.listClassRoom !== null &&
                this.props.filters.listClassRoom.length > 1
              ) {
                if (this.state.classroom !== null)
                  for (var item in this.props.filters.listClassRoom) {
                    if (
                      this.props.filters.listClassRoom[
                        item
                      ].nomeTurma.startsWith(this.state.classroom)
                    )
                      listClassRoomOptions.push({
                        value: this.props.filters.listClassRoom[item]
                          .codigoTurma,
                        label: this.props.filters.listClassRoom[item].nomeTurma,
                      });
                  }
                else
                  for (var item in this.props.filters.listClassRoom) {
                    listClassRoomOptions.push({
                      value: this.props.filters.listClassRoom[item].codigoTurma,
                      label: this.props.filters.listClassRoom[item].nomeTurma,
                    });
                  }
              }
            }

            selectClassRoom = (
              <SelectChangeColor
                className="col"
                value={selectedClassRoom}
                defaultText="Turma"
                options={listClassRoomOptions}
                disabled={hiddenDisabled}
                onChange={this.SelectedClassRoom}
                resetColor={selectedClassRoom === "" ? true : false}
              />
            );

            if (
              this.props.filters.listClassRoom !== null &&
              this.props.filters.listClassRoom !== undefined
            ) {
              var temp = this.props.filters.listClassRoom;
              var uniques = [];

              for (var i = 0; i < temp.length; i++) {
                var classroom = temp[i].nomeTurma.substring(0, 1);

                if (uniques.indexOf(classroom) === -1) {
                  yearClassrooms.push({ label: classroom, value: classroom });
                  uniques.push(classroom);
                }
              }
            }
          }

        if (selectedSchool === "todas" || selectedDre === "todas") {
          hiddenDisabled = true;

          var listyearClassrooms = [1, 2, 3, 4, 5, 6, 7, 8, 9];
          for (var item in listyearClassrooms) {
            yearClassrooms.push({
              value: listyearClassrooms[item],
              label: listyearClassrooms[item],
            });
          }
        }
      }
    }
    return (
      <div className="py-2 px-3 d-flex align-items-center">
        <SelectChangeColor
          className="col-1"
          value={this.state.schoolYear}
          options={listYearsOptions}
          onChange={this.selectedSchoolYear}
        />
        <div className="px-2"></div>
        {selectDre}
        <div className="px-2"></div>
        {selectSchool}
        <div className="px-2"></div>
        <SelectChangeColor
          className="col"
          value={this.state.classroom}
          defaultText="Ano"
          options={yearClassrooms}
          onChange={this.getClassroom}
          activeColor={this.state.classroom === "" ? false : true}
          resetColor={this.state.classroom === "" ? true : false}
        />
        <div className="px-2"></div>
        {selectClassRoom}
        <div className="px-2"></div>
        <CircleButton
          iconClass="fas fa-search"
          onClick={this.toggleMessageBox}
          disabled={!this.checkDisabledButton()}
        />
        <MensagemConfirmacaoAutoral
          controleExibicao={this.toggleMessageBox}
          acaoPrincipal={async () => {
            this.props
              .savePollStudent()
              .then(() => setTimeout(() => this.setSelectedFilter(), 1000));
          }}
          acaoSecundaria={async () => {
            this.setSelectedFilter();
          }}
          exibir={this.state.showMessageBox}
        />
      </div>
    );
  }
}
export default connect(
  (state) => ({
    filters: state.filters,
    poll: state.poll,
    data: state.data,
    user: state.user,
    pollRouter: state.pollRouter,
  }),
  (dispatch) => ({
    filterMethods: bindActionCreators(actionCreatorsPoll, dispatch),
    poll2: bindActionCreators(actionCreatorsPoll2, dispatch),
    pollRouterMethods: bindActionCreators(actionCreatorsPollRouter, dispatch),
  })
)(PollFilter);
