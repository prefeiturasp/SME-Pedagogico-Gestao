import React from 'react';

// import { Container } from './styles';

function RelatorioPortuguesAutoral({ dados }) {

    return (
        <>
            <div className="d-flex poll-report-grid-header">
                <div className="col sc-gray border-right border-white">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center">{dados.grupoDescricao}</div>
                </div>
                <div className="col-7 sc-gray border-right border-right border-white">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">Alunos</div>
                </div>
                <div className="col-1 sc-gray border-right border-white">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">%</div>
                </div>
            </div>
            {
                dados && dados.perguntas && dados.perguntas.length > 0 && dados.perguntas.map(pergunta => {
                    return (
                        <div className="d-flex poll-report-grid-item border-bottom">
                            <div className="col">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">{pergunta.nome}</div>
                            </div>
                            <div className="col-7 sc-darkblue border-right border-white">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{pergunta.total.quantidade} Alunos</div>
                            </div>
                            <div className="col-1 sc-darkblue border-right border-white">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{pergunta.total.porcentagem}%</div>
                            </div>
                        </div>
                    );
                })
            }
            <div className="d-flex poll-report-grid-item">
                <div className="col sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">TOTAL</div>
                </div>
                <div className="col-7 sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">{dados.totais.quantidade} Alunos</div>
                </div>
                <div className="col-1 sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">{(dados.totais.porcentagem && `${dados.totais.porcentagem}%`)}</div>
                </div>
            </div>
        </>
    );
}

export default RelatorioPortuguesAutoral;