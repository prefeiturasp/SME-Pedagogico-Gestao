import React, { Component } from 'react';


export default class LegendsReadWrite3A extends Component {
    render() {
        return ( 
            <div>
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
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Não realizou a reescrita do trecho.</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">Nível 1</small></div>
                                </div>
                                <div className="d-flex line max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Realizou parcialmente a reescrita do trecho, comprometendo o sentido da história e apresentando dificuldades em relação à escrita convencional (SEA), à segmentação e translineação das palavras e com erros de ortografia.</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">Nível 2</small></div>
                                </div>
                                <div className="d-flex line max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Realizou a reescrita do texto, escrevendo os principais acontecimentos, sem omissão que comprometa o sentido da história; ainda que com erros de ortografia, fazendo a segmentação e translienação* adequadas e observando parcialmente a progressão temática e os conteúdos do texto-fonte.</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">Nível 3</small></div>
                                </div>
                                <div className="d-flex line max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Realizou a reescrita do trecho, escrevendo com poucos erros ortográficos (em especial nas palavras de uso frequente), fazendo a segmentação e translienação adequadas, observando a progressão temática e os conteúdos do texto-fonte.</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">Nível 4</small></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="pb-2"></div>
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
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Não realizou a tarefa.</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">Nível 1</small></div>
                                </div>
                                <div className="d-flex line max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Não associou nenhum dos títulos à frase correspondente.</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">Nível 2</small></div>
                                </div>
                                <div className="d-flex line max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Realizou a tarefa, associando 3 ou menos títulos às frases correspondentes; porém, sem se utilizar de índices linguísticos e/ou contextuais.</small></div>
                                    <div className="ml-auto p-2"><small className="text-muted">Nível 3</small></div>
                                </div>
                                <div className="d-flex max-column-size">
                                    <div className="p-2 p-2sondagem"><small className="text-muted">Realizou a tarefa, associando todos os títulos as frases correspondentes; utilizando-se de índices linguísticos e contextuais para antecipar, inferir ou validar o que está escrito; além de fazer antecipações a respeito do conteúdo do texto.</small></div>
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