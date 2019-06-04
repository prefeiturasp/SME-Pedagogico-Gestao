import React, { Component } from 'react';
import SelectChangeColor from '../inputs/SelectChangeColor';
import CircleButton from '../inputs/CircleButton';
import { connect } from 'react-redux';
import { actionCreators as actionCreatorsPoll } from '../../store/Filters';
import { actionCreators as actionCreatorsPoll2 } from '../../store/Poll';
import { bindActionCreators } from 'redux';

class PollFilter extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selectedDre: "",
            selectedSchool: "",
            selectedClassRoom: "",
            yearClassroom: null,
            classroom: "",
        }

        this.SelectedDre = this.SelectedDre.bind(this);
        this.SelectedSchool = this.SelectedSchool.bind(this);
        this.SelectedClassRoom = this.SelectedClassRoom.bind(this);
        this.setSelectedFilter = this.setSelectedFilter.bind(this);
        this.getClassroom = this.getClassroom.bind(this);
        this.checkDisabledButton = this.checkDisabledButton.bind(this);
    }

    componentWillMount() {
        this.props.filterMethods.resetPollFilters();
    }

    componentDidMount() {
        this.props.filterMethods.getDre();
    }

    SelectedDre(event) {
        this.props.filterMethods.resetPollFilters();
        this.props.filterMethods.getDre();
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
            this.props.filterMethods.activeClassroom("todas");
            this.props.filterMethods.getClassroom({
                schoolCodeEol: "todas",
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
    }

    checkDisabledButton() {
        if (this.props.reports) {
            if (this.props.filters.activeDreCode !== null && this.props.filters.activeSchollsCode !== null)
                return (true);
            else
                return (false);
        }
        else {
            if (this.props.filters.activeDreCode !== null && this.props.filters.activeSchollsCode !== null && this.props.filters.activeClassRoomCode !== null)
                return (true);
            else
                return (false);
        }
    }

    render() {
        const { selectedDre } = this.state;
        const { selectedSchool } = this.state;
        const { selectedClassRoom } = this.state;

        const listDresOptions = [{ label: "Todas", value: "todas" }];
        const listSchoolOptions = [{ label: "Todas", value: "todas" }];
        const listClassRoomOptions = [];


        for (var item in this.props.filters.listDres) {
            listDresOptions.push({
                value: this.props.filters.listDres[item].codigoDRE,
                label: this.props.filters.listDres[item].nomeDRE.replace("DIRETORIA REGIONAL DE EDUCACAO", "DRE -"),
            });
        }

        if (selectedDre !== "todas") {
            for (var item in this.props.filters.scholls) {
                listSchoolOptions.push({
                    value: this.props.filters.scholls[item].codigoEscola,
                    label: this.props.filters.scholls[item].nomeEscola,
                });

            }

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

            var yearClassrooms = [];

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

        const ano = "2019";

        return (
            <div className="py-2 px-3 d-flex align-items-center">
                <SelectChangeColor className="" defaultText="2019" value={ano} disabled="true" />
                <div className="px-2"></div>
                <SelectChangeColor className="col-4" defaultText="Selecione a DRE"
                    value={selectedDre} options={listDresOptions} onChange={this.SelectedDre} />
                <div className="px-2"></div>
                <SelectChangeColor className="col-4" value={selectedSchool} defaultText="Escola" options={listSchoolOptions} onChange={this.SelectedSchool} resetColor={selectedSchool === "" ? true : false} />
                <div className="px-2"></div>
                <SelectChangeColor className="" value={this.state.classroom} defaultText="Ano" options={yearClassrooms} onChange={this.getClassroom} activeColor={this.state.classroom === "" ? false : true} resetColor={this.state.classroom === "" ? true : false} />
                <div className="px-2"></div>
                <SelectChangeColor className="" value={selectedClassRoom} defaultText="Turma" options={listClassRoomOptions} onChange={this.SelectedClassRoom} resetColor={selectedClassRoom === "" ? true : false} />
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
            poll: state.poll
        }
    ),
    dispatch => (
        {
            filterMethods: bindActionCreators(actionCreatorsPoll, dispatch),
            poll2: bindActionCreators(actionCreatorsPoll2, dispatch),
        }
    )
)(PollFilter);