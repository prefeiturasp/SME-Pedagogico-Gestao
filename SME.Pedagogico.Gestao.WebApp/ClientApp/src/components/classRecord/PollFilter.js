import React, { Component } from "react";
import { withRouter } from "react-router";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { actionCreators as actionCreatorsPoll } from "../../store/Filters";
import { actionCreators as actionCreatorsPoll2 } from "../../store/Poll";

import SelectChangeColor from "../inputs/SelectChangeColor";
import CircleButton from "../inputs/CircleButton";
import MensagemConfirmacaoAutoral from "./SondagemPortuguesAutoral/mensagemConfirmacaoAutoral";

import { actionCreators as actionCreatorsPollRouter } from "../../store/PollRouter";

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
    const anoLetivo = new Date();
    const anoAtual = anoLetivo.getFullYear();
    this.setState({
      schoolYear: anoAtual,
    });

    this.props.filterMethods.getPeriod(anoAtual);
    this.props.filterMethods.setSchoolYear(anoAtual);

    this.applyRole(anoAtual);
  }

  componentDidUpdate() {
    const { user, history, filters } = this.props;
    const {
      selectedDre,
      selectedSchool,
      classroom,
      selectedClassRoom,
    } = this.state;
    if (!user.perfil.perfilSelecionado.nomePerfil) {
      history.push("/Usuario/TrocarPerfil");
    }

    if (
      (!selectedDre ||
        selectedDre.indexOf(filters.listDres[0].codigoDRE) < 0) &&
      filters.listDres.length === 1
    ) {
      this.SelectedDre(0);
    }
    if (!selectedSchool && filters.scholls.length === 1) {
      this.SelectedSchool(0);
    }
    if (!selectedSchool && filters.scholls.length === 1) {
      this.SelectedSchool(0);
    }
    if (
      !classroom &&
      filters.listClassRoom &&
      filters.listClassRoom.length === 1
    ) {
      this.getClassroom(0);
    }
    if (
      !selectedClassRoom &&
      filters.listClassRoom &&
      filters.listClassRoom.length === 1
    ) {
      this.SelectedClassRoom(0);
    }

    console.log("state ------------>", this.state);
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
    const { filters, filterMethods } = this.props;
    const index = event && event.nativeEvent.target.selectedIndex;
    const label = event
      ? event.nativeEvent.target[index].value
      : filters.listDres[0].codigoDRE;

    const schoolCode = {
      dreCodeEol: label,
      schoolYear: filters.setSchoolYear,
    };

    filterMethods.getSchool(schoolCode);
    this.setState({
      selectedDre: label,
      selectedClassRoom: "",
      yearClassroom: null,
      classroom: "",
    });

    if (label === "todas") {
      filterMethods.activeClassroom("");
      filterMethods.getClassroom({
        schoolCodeEol: "",
        schoolYear: this.props.filters.setSchoolYear,
      });
    }
  }

  SelectedYear(event) {
    this.props.filterMethods.getYear();
  }

  SelectedSchool(event) {
    const { filters, filterMethods } = this.props;
    const index = event && event.nativeEvent.target.selectedIndex;
    const label = event
      ? event.nativeEvent.target[index].value
      : filters.scholls[0].codigoEscola;

    const schoolAll = label === "todas";

    if (schoolAll) {
      filterMethods.listClassRoom();
    } else {
      filterMethods.getClassroom({
        schoolCodeEol: label,
        schoolYear: filters.setSchoolYear,
      });
    }

    this.setState({
      selectedSchool: label,
      selectedClassRoom: "",
      yearClassroom: null,
      classroom: "",
      schoolAll,
    });
  }

  subString = (value) => {
    return value.substring(0, 1);
  };

  SelectedClassRoom(event) {
    const { filters, filterMethods } = this.props;
    const index = event && event.nativeEvent.target.selectedIndex;
    const label = event
      ? event.nativeEvent.target[index].value
      : filters.listClassRoom[0].codigoTurma;

    filterMethods.getDisciplinesByClassroom({ codigoTurmaEol: label });
    filterMethods.activeClassroom(label);

    const valueString = event
      ? event.target[index].innerText
      : filters.listClassRoom[0].nomeTurma;
    this.setState({
      classroom: this.subString(valueString),
      selectedClassRoom: label,
    });
  }

  getClassroom(event) {
    const { filters, filterMethods } = this.props;
    const label = event
      ? event.target.value
      : this.subString(filters.listClassRoom[0].nomeTurma);

    filterMethods.activeClassroom("");
    this.setState({
      classroom: label,
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
    const {
      selectedDre,
      selectedClassRoom,
      schoolAll,
      selectedSchool,
      schoolYear,
      classroom,
      showMessageBox,
    } = this.state;
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
      selectDre = (
        <SelectChangeColor
          className="col-4"
          defaultText="Selecione a DRE"
          value={selectedDre}
          options={listDresOptions}
          onChange={this.SelectedDre}
          activeColor={selectedDre}
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
            value={selectedSchool}
            defaultText="Escola"
            options={listSchoolOptions}
            onChange={this.SelectedSchool}
            activeColor={selectedSchool}
            resetColor={!selectedSchool}
          />
        );
      }

      if (
        selectedDre !== "todas" &&
        (filters.listClassRoom || filters.scholls.length || user.ehProfessor)
      ) {
        if (!filters.listClassRoom) {
          hiddenDisabled = true;
        }
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
            activeColor={selectedClassRoom}
            resetColor={!selectedClassRoom}
          />
        );

        if (filters.listClassRoom) {
          const temp = filters.listClassRoom;
          const uniques = [];

          for (let i = 0; i < temp.length; i++) {
            const room = temp[i].nomeTurma.substring(0, 1);

            if (uniques.indexOf(room) === -1) {
              yearClassrooms.push({ label: room, value: room });
              uniques.push(room);
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
          value={schoolYear}
          options={listYearsOptions}
          onChange={this.selectedSchoolYear}
          activeColor={schoolYear}
        />
        <div className="px-2"></div>
        {selectDre}
        <div className="px-2"></div>
        {selectSchool}
        <div className="px-2"></div>
        <SelectChangeColor
          className="col"
          value={classroom}
          defaultText="Ano"
          options={yearClassrooms}
          onChange={this.getClassroom}
          activeColor={classroom}
          resetColor={!classroom}
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
          exibir={showMessageBox}
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
