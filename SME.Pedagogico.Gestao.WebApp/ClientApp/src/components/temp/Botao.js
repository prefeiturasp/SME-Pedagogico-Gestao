import React, { Component } from 'react';
import TwoSteps from '../messaging/TwoSteps';

export default class Botao extends Component {
    constructor() {
        super();

        this.state = {
            showMessageBox: false,
        }

        this.disparaAcao = this.disparaAcao.bind(this);

        this.toggleMessageBox = this.toggleMessageBox.bind(this);
    }

    disparaAcao() {
        alert("clicou");
    }

    toggleMessageBox() {
        this.setState({
            showMessageBox: !this.state.showMessageBox,
        })
    }
    

    render() {
        return (
            <div className="container">
                
                <button id="btnSave" className="btn btn-save text-white" onClick={this.toggleMessageBox} disabled={false}>Salvar</button>
                <TwoSteps show={this.state.showMessageBox} showControl={this.toggleMessageBox} runMethod={this.disparaAcao} />
            </div>
        );
    }
}

