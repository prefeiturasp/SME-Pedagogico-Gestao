import React, { Component } from 'react';
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
        }

        this.SelectedDre = this.SelectedDre.bind(this);
    }

    SelectedDre(event) {

        var schoolCode = {
            schoolYear: "2019",

        }
    }

    componentDidMount() {
       this.props.filterMethods.getDre();
    }

    render() {
        const { selectedDre } = this.state;
        const listDresOptions = [];
        for (var item in this.props.filters.listDres) {
            listDresOptions.push({
                value: this.props.filters.listDres[item].codigoDRE,
                label: this.props.filters.listDres[item].siglaDRE,
            });
        }

        const options = [
            { value: "1", label: "One" },
            { value: "2", label: "Two" },
            { value: "3", label: "Three" },
            { value: "4", label: "Four" },
        ];

        return (
            <div className="py-2 px-3 d-flex align-items-center">
                <SelectChangeColor className="" defaultText="Ano" options={listDresOptions} disabled="true" />
                <div className="px-2"></div>
                <SelectChangeColor className="col-4" defaultText="Selecione a DRE"
                    value={selectedDre} options={listDresOptions} onChange={this.SelectedDre} />
                <div className="px-2"></div>
                <SelectChangeColor className="col-4" defaultText="Escola" options={options} />
                <div className="px-2"></div>
                <SelectChangeColor className="" defaultText="Curso" options={options} />
                <div className="px-2"></div>
                <SelectChangeColor className="" defaultText="Turma" options={options} />
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