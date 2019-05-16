import React, { Component } from 'react';


export default class LegendsReadWrite extends Component {
    render() {
        return (
            <div className="d-flex flex-column align-items-end">
                <div className="card" id="accordionescrita">
                    <div className="card-header-sondagem" role="tab" id="headingescrita">
                        <div data-toggle="collapse" data-parent="#accordionescrita" href="#collapseescrita" aria-expanded="false"
                            aria-controls="collapseescrita">
                            <div className="d-flex line">
                                <div className="p-2 p-2sondagem"><small>Legendas das classificações de escrita</small></div>
                                <div className="ml-auto p-2"><i className="fas fa-angle-down rotate-icon"></i></div>
                            </div>
                        </div>
                    </div>
                    <div id="collapseescrita" className="collapse" role="tabpanel" aria-labelledby="headingescrita" data-parent="#accordionescrita">
                        <div className="card-body-sondagem pt-0">
                            <div className="d-flex flex-column">
                                <div className="d-flex line max-column-size" >
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Pré-Silábico</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">PS</small></div>
                                </div>
                                <div className="d-flex line max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Silábico sem Valor</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">SSV</small></div>
                                </div>
                                <div className="d-flex line max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Silábico com Valor</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">SCV</small></div>
                                </div>
                                <div className="d-flex line max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Silábico Alfabético</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">SA</small></div>
                                </div>
                                <div className="d-flex max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Alfabético</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">A</small></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="card" id="accordionleitura">
                    <div className="card-header-sondagem" role="tab" id="headingescrita">
                        <div data-toggle="collapse" data-parent="#accordionleitura" href="#collapseleitura" aria-expanded="false"
                            aria-controls="collapseleitura">
                            <div className="d-flex line">
                                <div className="p-2 p-2sondagem"><small>Legendas das classificações de leitura</small></div>
                                <div className="ml-auto p-2"><i className="fas fa-angle-down rotate-icon"></i></div>
                            </div>
                        </div>
                    </div>
                    <div id="collapseleitura" className="collapse" role="tabpanel" aria-labelledby="headingescrita" data-parent="#accordionleitura">
                        <div className="card-body-sondagem pt-0">
                            <div className="d-flex flex-column">
                                <div className="d-flex line max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Não realizou a tarefa</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">Nível 1</small></div>
                                </div>
                                <div className="d-flex line max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Não associou nenhum(a) da(s) palavras ou títulos às imagens correspondentes</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">Nível 2</small></div>
                                </div>
                                <div className="d-flex line max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Não associou nenhum(a) da(s) palavras ou títulos às imagens correspondentes</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">Nível 3</small></div>
                                </div>
                                <div className="d-flex max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Associou 3 ou mais palavras ou títulos às imagens correspondentes</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">Nível 4</small></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}