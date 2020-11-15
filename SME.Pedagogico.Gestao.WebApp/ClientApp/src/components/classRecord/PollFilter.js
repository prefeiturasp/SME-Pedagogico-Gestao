import React, { Component } from "react";
import SelectChangeColor from "../inputs/SelectChangeColor";
import CircleButton from "../inputs/CircleButton";
import { connect } from "react-redux";
import { withRouter } from "react-router";
import { actionCreators as actionCreatorsPoll } from "../../store/Filters";
import { actionCreators as actionCreatorsPoll2 } from "../../store/Poll";
import { actionCreators as actionCreatorsPollRouter } from "../../store/PollRouter";
import { bindActionCreators } from "redux";
import MensagemConfirmacaoAutoral from "./SondagemPortuguesAutoral/mensagemConfirmacaoAutoral";
import permissoes from "../../utils/permissoes";
import { ROUTES_ENUM } from "../../Enums";

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
      schoolAll: false,
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
  }

  componentDidMount() {
    this.props.filterMethods.resetFilters();
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
  }

  componentDidUpdate() {
    const { user, history } = this.props;
    if (!user.perfil.perfilSelecionado.nomePerfil) {
      history.push("/Usuario/TrocarPerfil");
    }
  }

  applyRole(ano) {
    this.props.filterMethods.getListDres();
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

    this.applyRole(label);
  }

  selectedDreTeacher(event) {
    var index = event.nativeEvent.target.selectedIndex;
    var label = event.nativeEvent.target[index].value;
    var schoolCode = {
      dreCodeEol: label,
    };

    this.props.filterMethods.activeDreCode(schoolCode);

    if (
      this.props.filters &&
      this.props.filters.filterTeachers &&
      this.props.filters.filterTeachers.escolas &&
      this.props.filters.filterTeachers.escolas.length
    ) {
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
  }
  selectedSchoolTeacher(event) {
    var listClassRoomTeacher = [];

    var index = event.nativeEvent.target.selectedIndex;
    var label = event.nativeEvent.target[index].value;
    var classRoomFilter = {
      schoolCodeEol: label,
    };

    this.props.filterMethods.activeSchoolCode(classRoomFilter);

    if (this.props.user.ehProfessor) {
      listClassRoomTeacher = this.props.filters.filterTeachers.turmas.filter(
        (x) => x.codigoEscola === label
      );
    } else if (
      permissoes.IsUE(this.props.user) ||
      permissoes.IsDRE(this.props.user)
    ) {
      var classRoomFilterYear = {
        schoolCodeEol: label,
        schoolYear: this.props.filters.setSchoolYear,
      };
      this.props.filterMethods.getClassroom(classRoomFilterYear);
      listClassRoomTeacher = this.props.filters.listClassRoom;
    }

    this.setState({
      listClassRoomTeacher: listClassRoomTeacher,
      yearClassroom: null,
      classroom: "",
    });
  }

  SelectedDre(event) {
    var index = event.nativeEvent.target.selectedIndex;
    var label = event.nativeEvent.target[index].value;

    var schoolCode = {
      dreCodeEol: label,
      schoolYear: this.props.filters.setSchoolYear,
    };

    this.props.filterMethods.getSchool(schoolCode);
    this.setState({
      selectedDre: label,
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
    var index = event.nativeEvent.target.selectedIndex;
    var label = event.nativeEvent.target[index].value;

    if (label === "todas") {
      this.setState({
        schoolAll: true,
      });
      return;
    }

    var classRoomFilter = {
      schoolCodeEol: label,
      schoolYear: this.props.filters.setSchoolYear,
    };

    this.props.filterMethods.getClassroom(classRoomFilter);
    this.setState({
      selectedSchool: label,
      selectedClassRoom: "",
      yearClassroom: null,
      classroom: "",
      schoolAll: false,
    });
  }

  SelectedClassRoom(event) {
    var index = event.nativeEvent.target.selectedIndex;
    var label = event.nativeEvent.target[index].value;

    var codeClassRoom = label;

    var disciplinesFilter = {
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
    const {
      pollRouter: { activeRoute },
      user: { ehProfessor },
    } = this.props;
    const { classroom, selectedClassRoom } = this.state;

    if (activeRoute === ROUTES_ENUM.RELATORIOS) {
      return ehProfessor ? selectedClassRoom : classroom;
    }
    return selectedClassRoom;
  }

  render() {
    const { selectedDre, selectedClassRoom, schoolAll } = this.state;
    let selectDre = null;
    let selectSchool = null;
    let selectClassRoom = null;
    const yearClassrooms = [];
    const listDresOptions = [];
    const listSchoolOptions = [];
    const listClassRoomOptions = [];
    const listYearsOptions = [];
    let hiddenDisabled = false;

    const dataAtual = new Date();
    const anoAtual = dataAtual.getFullYear();
    let aux = anoAtual;
    listYearsOptions.push({
      value: anoAtual,
      label: anoAtual,
    });

    for (let i = 2019; i < anoAtual; i++) {
      aux = aux - 1;
      listYearsOptions.push({
        value: aux,
        label: aux,
      });
    }

    listYearsOptions.reverse();

    const { filters, user } = this.props;

    if (filters.listDres) {
      let SchoolSelected;

      selectDre = (
        <SelectChangeColor
          className="col-4"
          defaultText="Selecione a DRE"
          value={selectedDre}
          options={listDresOptions}
          onChange={this.SelectedDre}
        />
      );

      for (let item in filters.listDres) {
        listDresOptions.push({
          value: filters.listDres[item].codigoDRE,
          label: filters.listDres[item].nomeDRE.replace(
            "DIRETORIA REGIONAL DE EDUCACAO",
            "DRE -"
          ),
        });
      }

      if (
        selectedDre !== "todas" &&
        (filters.scholls.length || user.ehProfessor)
      ) {
        for (let item in filters.scholls) {
          listSchoolOptions.push({
            value: filters.scholls[item].codigoEscola,
            label: filters.scholls[item].nomeEscola,
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
      }

      if (
        selectedDre !== "todas" &&
        (filters.listClassRoom || filters.scholls.length || user.ehProfessor)
      ) {
        if (this.state.classroom)
          for (let item in filters.listClassRoom) {
            if (
              filters.listClassRoom[item].nomeTurma.startsWith(
                this.state.classroom
              )
            )
              listClassRoomOptions.push({
                value: filters.listClassRoom[item].codigoTurma,
                label: filters.listClassRoom[item].nomeTurma,
              });
          }
        else
          for (let item in filters.listClassRoom) {
            listClassRoomOptions.push({
              value: filters.listClassRoom[item].codigoTurma,
              label: filters.listClassRoom[item].nomeTurma,
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

        if (filters.listClassRoom) {
          const temp = filters.listClassRoom;
          const uniques = [];

          for (let i = 0; i < temp.length; i++) {
            const classroom = temp[i].nomeTurma.substring(0, 1);

            if (uniques.indexOf(classroom) === -1) {
              yearClassrooms.push({ label: classroom, value: classroom });
              uniques.push(classroom);
            }
          }
        }
      }

      if (selectedDre === "todas" || (schoolAll && !yearClassrooms.length)) {
        const listYearClassrooms = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        for (let item in listYearClassrooms) {
          yearClassrooms.push({
            value: listYearClassrooms[item],
            label: listYearClassrooms[item],
          });
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
)(withRouter(PollFilter));
