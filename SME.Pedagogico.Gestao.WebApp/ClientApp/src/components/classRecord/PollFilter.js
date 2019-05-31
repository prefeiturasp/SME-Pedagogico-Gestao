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
            selectedDre: null,
            selectedSchool: null,
            selectedClassRoom: null,
            yearClassroom: null,
            classroom: null,
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

    SelectedDre(event) {
        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].value;

        var schoolCode = {
            dreCodeEol: label,
            schoolYear: "2019",
        }

        this.props.filterMethods.getSchool(schoolCode);

    }

    SelectedClassRoom(event) {

        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].value;

        var codeClassRoom = label;

        this.props.filterMethods.activeClassroom(codeClassRoom);

        this.setState({
            classroom: label.substring(0, 1)
        });
    }

    SelectedSchool(event) {

        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].value;

        var classRoomFilter = {
            schoolCodeEol: label,
            schoolYear: "2019",
        }

        this.props.filterMethods.getClassroom(classRoomFilter);
    }

    componentDidMount() {
        this.props.filterMethods.getDre();
    }

    getClassroom(event) {
        this.setState({
            classroom: event.target.value
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

        const listDresOptions = [];
        const listSchoolOptions = [];
        const listClassRoomOptions = [];


        for (var item in this.props.filters.listDres) {
            listDresOptions.push({
                value: this.props.filters.listDres[item].codigoDRE,
                label: this.props.filters.listDres[item].nomeDRE.replace("DIRETORIA REGIONAL DE EDUCACAO", "DRE -"),
            });
        }


        for (var item in this.props.filters.scholls) {
            listSchoolOptions.push({
                value: this.props.filters.scholls[item].codigoEscola,
                label: this.props.filters.scholls[item].nomeEscola,
            });

        }
        if (this.props.filters.listClassRoom !== [] && this.props.filters.listClassRoom !== null) {
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

        const ano = "2019";

        return (
            <div className="py-2 px-3 d-flex align-items-center">
                <SelectChangeColor className="" defaultText="2019" value={ano} disabled="true" />
                <div className="px-2"></div>
                <SelectChangeColor className="col-4" defaultText="Selecione a DRE"
                    value={selectedDre} options={listDresOptions} onChange={this.SelectedDre} />
                <div className="px-2"></div>
                <SelectChangeColor className="col-4" value={selectedSchool} defaultText="Escola" options={listSchoolOptions} onChange={this.SelectedSchool} />
                <div className="px-2"></div>
                <SelectChangeColor className="" defaultText="Curso" options={yearClassrooms} onChange={this.getClassroom} />
                <div className="px-2"></div>
                <SelectChangeColor className="" value={selectedClassRoom} defaultText="Turma" options={listClassRoomOptions} onChange={this.SelectedClassRoom} />
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