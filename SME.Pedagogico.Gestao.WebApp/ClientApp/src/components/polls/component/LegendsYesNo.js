import React, { Component } from 'react';

export default class LegendsRightWrong extends Component {
    render() {
        return (
            <div className="d-flex flex-fill flex-row-reverse">
                <div className="d-flex flex-column align-items-end">
                    <div className="accordion md-accordion" id="accordionEx1" role="tablist" aria-multiselectable="true">
                        <div className="card">

                            <div className="card-header-sondagem" role="tab" id="headingTwo1">
                                <div className="collapsed" data-toggle="collapse" data-parent="#accordionEx1" href="#collapseTwo1"
                                    aria-expanded="false" aria-controls="collapseTwo1">
                                    <div className="d-flex line">
                                        <div className="p-2 p-2sondagem"><small>Legendas das classificações</small></div>
                                        <div className="ml-auto p-2"><i className="fas fa-angle-down rotate-icon"></i></div>
                                    </div>
                                </div>
                            </div>

                            <div id="collapseTwo1" className="collapse" role="tabpanel" aria-labelledby="headingTwo1"
                                data-parent="#accordionEx1">
                                <div className="card-body-sondagem">
                                    <div className="d-flex flex-column">
                                        <div className="d-flex line max-column-size" >
                                            <div className="p-2 p-2sondagem"><small className="text-muted">Escreve convencionalmente</small></div>
                                            <div className="ml-auto p-2"><small className="text-muted">S</small></div>
                                        </div>
                                        <div className="d-flex line max-column-size">
                                            <div className="p-2 p-2sondagem"><small className="text-muted">Não escreve convencionalmente</small></div>
                                            <div className="ml-auto p-2"><small className="text-muted">N</small></div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        );
    }
}