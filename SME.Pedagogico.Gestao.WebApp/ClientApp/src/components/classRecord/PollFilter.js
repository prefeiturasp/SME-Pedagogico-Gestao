﻿import React, { Component } from 'react';
import SelectChangeColor from '../inputs/SelectChangeColor';
import CircleButton from '../inputs/CircleButton';
import { connect } from 'react-redux';
import { actionCreators as actionCreatorsPoll } from '../../store/Filters';
import { bindActionCreators } from 'redux';

class PollFilter extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selectedDre: null,
            selectedSchool: null,
            selectedClassRoom: null,
        }

        this.SelectedDre = this.SelectedDre.bind(this);
        this.SelectedSchool = this.SelectedSchool.bind(this);
        this.SelectedClassRoom = this.SelectedClassRoom.bind(this);
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

    render() {
        const { selectedDre } = this.state;
        const { selectedSchool } = this.state;
        const { selectedClassRoom } = this.state;

        const listDresOptions = [];
        const listSchoolOptions = [];
        const listClassRoomOptions = [];

     
            for (var item in this.props.filters.listDres ) {
                listDresOptions.push({
                    value: this.props.filters.listDres[item].codigoDRE,
                    label: this.props.filters.listDres[item].siglaDRE,
                });
            }
       
     
            for (var item in this.props.filters.scholls) {
                listSchoolOptions.push({
                    value: this.props.filters.scholls[item].codigoEscola,
                    label: this.props.filters.scholls[item].nomeEscola,
                });
         
        }
        if (this.props.filters.listClassRoom != [] && this.props.filters.listClassRoom != null ) {
            for (var item in this.props.filters.listClassRoom) {
                listClassRoomOptions.push({
                    value: this.props.filters.listClassRoom[item].codigoTurma,
                    label: this.props.filters.listClassRoom[item].nomeTurma,
                });
            }
        }
        const ano = "2019";
        const options = [
            { value: "1", label: "One" },
            { value: "2", label: "Two" },
            { value: "3", label: "Three" },
            { value: "4", label: "Four" },
        ];

        return (
            <div className="py-2 px-3 d-flex align-items-center">
                <SelectChangeColor className="" defaultText="Ano" value={ano} disabled="true" />
                <div className="px-2"></div>
                <SelectChangeColor className="col-4" defaultText="Selecione a DRE"
                    value={selectedDre} options={listDresOptions} onChange={this.SelectedDre} />
                <div className="px-2"></div>
                <SelectChangeColor className="col-4" value={selectedSchool} defaultText="Escola" options={listSchoolOptions} onChange={this.SelectedSchool} />
                <div className="px-2"></div>
                <SelectChangeColor className="" defaultText="Curso" options={options} />
                <div className="px-2"></div>
                <SelectChangeColor className="" value={selectedClassRoom} defaultText="Turma" options={listClassRoomOptions} onChange={this.SelectedClassRoom} />
                <div className="px-2"></div>
                <CircleButton iconClass="fas fa-search" />
            </div>
        );
    }
}

export default connect(
    state => (
        {
            filters: state.filters
        }
    ),
    dispatch => (
        {
            filterMethods: bindActionCreators(actionCreatorsPoll, dispatch)
        }
    )
)(PollFilter);