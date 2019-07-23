import React, { Component } from 'react';
import SelectChangeColor from '../inputs/SelectChangeColor';
import CircleButton from '../inputs/CircleButton';
import { connect } from 'react-redux';
import { actionCreators as actionCreatorsPoll } from '../../store/Filters';
import { actionCreators as actionCreatorsPoll2 } from '../../store/Poll';
import { actionCreators as actionCreatorsPollRouter } from '../../store/PollRouter';
import { bindActionCreators } from 'redux';
import { ROLES_ENUM } from '../../Enums';
import { debounce } from 'redux-saga/effects';

class PollFilter extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selectedDre: "",
            selectedSchool: "",
            selectedClassRoom: "",
            yearClassroom: null,
            classroom: "",
            listSchools: [],
            listClassRoomTeacher: [],
        }

        this.SelectedDre = this.SelectedDre.bind(this);
        this.SelectedSchool = this.SelectedSchool.bind(this);
        this.SelectedClassRoom = this.SelectedClassRoom.bind(this);
        this.setSelectedFilter = this.setSelectedFilter.bind(this);
        this.getClassroom = this.getClassroom.bind(this);
        this.checkDisabledButton = this.checkDisabledButton.bind(this);
        this.selectedDreTeacher = this.selectedDreTeacher.bind(this);
        this.selectedSchoolTeacher = this.selectedSchoolTeacher.bind(this);

    }

    componentWillMount() {
        
       // this.props.filterMethods.resetPollFilters();
        var role = this.props.user;
        if (role.activeRole.roleName === ROLES_ENUM.PROFESSOR ||
            role.activeRole.roleName === ROLES_ENUM.COORDENADOR_PEDAGOGICO ||
            role.activeRole.roleName === ROLES_ENUM.DIRETOR) {

            var codeOccupations = this.props.user.listOccupations[0];

            var profileOccupatios = {
                codigoRF: this.props.user.username,
                codigoCargo: codeOccupations,
                anoLetivo: '2019',
            }

            this.props.filterMethods.getFilters_teacher(profileOccupatios);
            //if (this.props.filters.filterTeachers !== null) {
            //    if (this.props.filters.filterTeachers.drEs.length == 1) {
            //        var schoolCode = {
            //            dreCodeEol: this.props.filters.filterTeachers.drEs[0].codigo
            //        }

            //        this.props.filterMethods.activeDreCode(schoolCode);
            //        var listSchools = this.props.filters.filterTeachers.escolas.filter(x => x.codigoDRE === this.props.filters.filterTeachers.drEs[0].codigo)
            //    }
            //    if (this.props.filters.filterTeachers.escolas.length == 1) {
            //        var classRoomFilter = {
            //            schoolCodeEol: this.props.filters.filterTeachers.escolas[0].codigo
            //        }

            //        this.props.filterMethods.activeSchoolCode(classRoomFilter);
            //    }
            //}


            //          
            //this.setState({
            //    listSchools: listSchools
            //});
        }
        if (role.activeRole.roleName === ROLES_ENUM.DIRETOR ||
            role.activeRole.roleName === ROLES_ENUM.ADM_DRE) {
            this.props.pollRouterMethods.setActiveRoute("Relatórios");
        }
        //else {
        //    this.props.pollRouterMethods.setActiveRoute("Sondagem");
        //}
      
    }

    componentDidMount() {
        if(this.props.user.activeRole.roleName === ROLES_ENUM.ADM_DRE) 
        {
            var userName = this.props.user.username;
            this.props.filterMethods.getDreAdm(userName)
        }

        else {
            this.props.filterMethods.getListDres();
        }
    }

    selectedDreTeacher(event) {
        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].value;
        var schoolCode = {
            dreCodeEol: label
        }

        this.props.filterMethods.activeDreCode(schoolCode);

        
        var listSchools = this.props.filters.filterTeachers.escolas.filter(x => x.codigoDRE === label)

        if (listSchools.length === 1) {
            var filterSchool = {
                schoolCodeEol: listSchools[0].codigo
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
            schoolCodeEol: label
        }

        this.props.filterMethods.activeSchoolCode(classRoomFilter);

        if (this.props.user.activeRole.roleName === ROLES_ENUM.PROFESSOR) {

            listClassRoomTeacher = this.props.filters.filterTeachers.turmas.filter(x => x.codigoEscola === label)
        }

        else if (this.props.user.activeRole.roleName === ROLES_ENUM.COORDENADOR_PEDAGOGICO ||
            this.props.user.activeRole.roleName === ROLES_ENUM.DIRETOR ||
            this.props.user.activeRole.roleName === ROLES_ENUM.ADM_DRE) {
            var classRoomFilter = {
                schoolCodeEol: label,
                schoolYear: "2019",
            }

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
debugger
      //  this.props.filterMethods.resetPollFilters();
     //  this.props.filterMethods.getDre();
        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].value;

        var schoolCode = {
            dreCodeEol: label,
            schoolYear: "2019",
        }

        this.props.filterMethods.getSchool(schoolCode);
        this.setState({
            selectedDre: label,
            selectedSchool: "",
            selectedClassRoom: "",
            yearClassroom: null,
            classroom: "",
        });

        if (label === "todas") {
            this.props.filterMethods.activeClassroom("");
            this.props.filterMethods.getClassroom({
                schoolCodeEol: "",
                schoolYear: "2019",
            });
        }
    }

    SelectedClassRoom(event) {

        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].value;

        var codeClassRoom = label;

        this.props.filterMethods.activeClassroom(codeClassRoom);

        this.setState({
            classroom: event.target[index].innerText.substring(0, 1),
            selectedClassRoom: codeClassRoom,
        });
    }

    SelectedSchool(event) {
        this.props.filterMethods.getSchool({
            dreCodeEol: this.state.selectedDre,
            schoolYear: "2019",
        });

        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].value;

        var classRoomFilter = {
            schoolCodeEol: label,
            schoolYear: "2019",
        }

        this.props.filterMethods.getClassroom(classRoomFilter);
        this.setState({
            selectedSchool: label,
            selectedClassRoom: "",
            yearClassroom: null,
            classroom: "",
        });
    }

    getClassroom(event) {
        this.props.filterMethods.activeClassroom("");
        this.setState({
            classroom: event.target.value,
            selectedClassRoom: "",
        });
    }

    setSelectedFilter() {
        var selectedFilter = {
            dreCodeEol: this.props.filters.activeDreCode,
            schoolCodeEol: this.props.filters.activeSchollsCode,
            classroomCodeEol: this.props.filters.activeClassRoomCode,
            schoolYear: "2019",
            yearClassroom: this.state.classroom,
        }

        this.props.poll2.setSelectedFilter(selectedFilter);

        if (this.props.resultClick !== undefined)
            this.props.resultClick(true);
    }

    checkDisabledButton() {
        if (this.props.reports) {

            //Independente do perfil o relatorio so pode ser tirado por Ano
            if (this.state.classroom !== null && this.state.classroom !== "") {
                return (true);
            }

            else {
                return (false);
            }


            //if (this.props.filters.activeDreCode !== null &&
            //    this.props.filters.activeSchollsCode !== null || this.props.filters.activeClassRoomCode !== null)
            //    return (true);
            //else
            //    return (false);
        }
        else {
            if (this.props.user.activeRole.roleName !== ROLES_ENUM.PROFESSOR) {
                if (this.props.filters.activeDreCode !== null && this.props.filters.activeSchollsCode !== null && this.props.filters.activeClassRoomCode !== null)
                    return (true);
                else
                    return (false);
            } else if (this.props.filters.activeClassRoomCode !== null)
                return (true);
            else
                return (false);
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

        const ano = "2019";

        if (this.props.pollRouter.activeRoute !== "Sondagem") {
            if (this.props.user.activeRole.roleName === ROLES_ENUM.ADMIN) {

               
                listDresOptions.push({ label: "Todas", value: "todas" });
            }
        }

        if (this.props.filters.filterTeachers !== null) {
            var DreSelected;
            var SchoolSelected;
            var enabledDre = false;
            var disabledSchool = false;
            // DRES de professor 
            for (var item in this.props.filters.filterTeachers.drEs) {
                listDresOptions.push({
                    value: this.props.filters.filterTeachers.drEs[item].codigo,
                    label: this.props.filters.filterTeachers.drEs[item].nome.replace("DIRETORIA REGIONAL DE EDUCACAO", "DRE -"),
                });
            }

            selectDre = <SelectChangeColor className="col-4" defaultText="Selecione a DRE"
                value={DreSelected} options={listDresOptions} disabled={enabledDre} onChange={this.selectedDreTeacher} />
            // escolas de professor 
            for (var item in this.state.listSchools) {
                listSchoolOptions.push({
                    value: this.state.listSchools[item].codigo,
                    label: this.state.listSchools[item].nome,
                });
            }

            selectSchool = <SelectChangeColor className="col-4" value={SchoolSelected} defaultText="Escola"
                options={listSchoolOptions} disabled={disabledSchool} onChange={this.selectedSchoolTeacher} resetColor={SchoolSelected === "" ? true : false} />

            if (this.props.user.activeRole.roleName === ROLES_ENUM.PROFESSOR) {


                if (this.state.classroom !== null)
                    for (var item in this.state.listClassRoomTeacher) {
                        if (this.state.listClassRoomTeacher[item].nome.startsWith(this.state.classroom))
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

                selectClassRoom = <SelectChangeColor className="col" value={selectedClassRoom} defaultText="Turma" options={listClassRoomOptions} disabled={hiddenDisabled} onChange={this.SelectedClassRoom} resetColor={selectedClassRoom === "" ? true : false} />

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
            }

            else if (this.props.user.activeRole.roleName === ROLES_ENUM.COORDENADOR_PEDAGOGICO ||
                     this.props.user.activeRole.roleName === ROLES_ENUM.DIRETOR) 
             {

                if (selectedSchool !== "todas") {
                    if (this.props.filters.listClassRoom !== [] && this.props.filters.listClassRoom !== null && this.props.filters.listClassRoom.length > 1) {
                        if (this.state.classroom !== null)
                            for (var item in this.props.filters.listClassRoom) {
                                if (this.props.filters.listClassRoom[item].nomeTurma.startsWith(this.state.classroom))
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

                selectClassRoom = <SelectChangeColor className="col" value={selectedClassRoom} defaultText="Turma" options={listClassRoomOptions} disabled={hiddenDisabled} onChange={this.SelectedClassRoom} resetColor={selectedClassRoom === "" ? true : false} />

                if (this.props.filters.listClassRoom !== null) {
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

        }

        //selectClassroom = <> <SelectChangeColor className="" value={this.state.classroom} defaultText="Ano" options={yearClassrooms} onChange={this.getClassroom} activeColor={this.state.classroom === "" ? false : true} resetColor={this.state.classroom === "" ? true : false} />
        //    <div className="px-2"></div>
        //    <SelectChangeColor className="" value={selectedClassRoom} defaultText="Turma" options={listClassRoomOptions} onChange={this.SelectedClassRoom} resetColor={selectedClassRoom === "" ? true : false} />
        //     </>


        else {
            selectDre = <SelectChangeColor className="col-4" defaultText="Selecione a DRE"
                value={selectedDre} options={listDresOptions} onChange={this.SelectedDre} />

            if (this.props.filters.activeDreCode !== null) {
                if (this.props.pollRouter.activeRoute !== "Sondagem") {
                    listSchoolOptions.push({ label: "Todas", value: "todas" });
                }
            }
            for (var item in this.props.filters.listDres) {
                listDresOptions.push({
                   
                    value: this.props.filters.listDres[item].codigoDRE,
                    label: this.props.filters.listDres[item].nomeDRE.replace("DIRETORIA REGIONAL DE EDUCACAO", "DRE -"),
                });
            }

            if (selectedDre !== "todas" && this.props.filters.scholls[0] !== undefined) {
                debugger
                for (var item in this.props.filters.scholls) {
                    listSchoolOptions.push({
                        value: this.props.filters.scholls[item].codigoEscola,
                        label: this.props.filters.scholls[item].nomeEscola,
                    });

                }

                selectSchool = <SelectChangeColor className="col-4" value={SchoolSelected} defaultText="Escola"
                    options={listSchoolOptions} onChange={this.SelectedSchool} resetColor={SchoolSelected === "" ? true : false} />

                if (selectedSchool !== "todas") {
                    if (this.props.filters.listClassRoom !== [] && this.props.filters.listClassRoom !== null && this.props.filters.listClassRoom.length > 1) {
                        if (this.state.classroom !== null)
                            for (var item in this.props.filters.listClassRoom) {
                                if (this.props.filters.listClassRoom[item].nomeTurma.startsWith(this.state.classroom))
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

                selectClassRoom = <SelectChangeColor className="col" value={selectedClassRoom} defaultText="Turma" options={listClassRoomOptions} disabled={hiddenDisabled} onChange={this.SelectedClassRoom} resetColor={selectedClassRoom === "" ? true : false} />

                if (this.props.filters.listClassRoom !== null) {
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
        }

        return (
            <div className="py-2 px-3 d-flex align-items-center">
                <SelectChangeColor className="" defaultText="2019" value={ano} disabled="true" />
                <div className="px-2"></div>
                {selectDre}
                <div className="px-2"></div>
                {selectSchool}
                <div className="px-2"></div>
                <SelectChangeColor className="col" value={this.state.classroom} defaultText="Ano" options={yearClassrooms} onChange={this.getClassroom} activeColor={this.state.classroom === "" ? false : true} resetColor={this.state.classroom === "" ? true : false} />
                <div className="px-2"></div>
                {selectClassRoom}
                <div className="px-2"></div>
                <CircleButton iconClass="fas fa-search" onClick={this.setSelectedFilter} disabled={!this.checkDisabledButton()} />
            </div>
        );

    }
}
export default connect(
    state => (
        {
            filters: state.filters,
            poll: state.poll,
            user: state.user,
            pollRouter: state.pollRouter
        }
    ),
    dispatch => (
        {
            filterMethods: bindActionCreators(actionCreatorsPoll, dispatch),
            poll2: bindActionCreators(actionCreatorsPoll2, dispatch),
            pollRouterMethods: bindActionCreators(actionCreatorsPollRouter, dispatch),
        }
    )
)(PollFilter);