import React, { useEffect, useState } from 'react';
import { Spring, Transition } from 'react-spring/renderprops';
import { useTransition, animated } from 'react-spring';
import './TwoStepsSave.css';
import { Card } from 'reactstrap';

function MesangemConfirmacao(props) {

    const {
        controleExibicao,
        exibir,
        acaoPrincial,
        acaoSecundaria,
        tituloPrincipal,
        mensagemPrincipal,
        tituloFeedBack,
        feedBack,
        botaoPrincipal,
        botaoSecundario } = props;

    const [passo, setPasso] = useState(1);

    const proximoPasso = () => setPasso((oldState) => oldState > 1 ? 1 : 2);

    const resetarPasso = () => {
        controleExibicao();
        setPasso(1);
    }

    const onBotaoSecundarioClick = () => {
        if (acaoSecundaria) {
            acaoSecundaria().then(() => resetarPasso());
            return;
        }

        resetarPasso();
    }

    const onBotaoPrincipalClick = () => {
        acaoPrincial().then(() => proximoPasso());
    }

    useEffect(() => {
        return () => {
            if (exibir)
                controleExibicao();
        }
    }, [])

    return (
        <div>
            <Spring
                from={{
                    display: "none",
                    opacity: 0
                }}
                to={{
                    display: exibir ? "block" : "none",
                    opacity: exibir ? 1 : 0
                }}>
                {props =>
                    <animated.div style={props}>
                        <div id="block-screen" className="block-screen d-flex justify-content-center align-items-center">
                            {passo === 1 ?
                                <Card className="col-5 p-4">
                                    <div className="border-bottom sc-text-size-4">
                                        {tituloPrincipal}
                                    </div>

                                    <div className="pt-4 sc-text-size-1">
                                        {mensagemPrincipal}
                                    </div>

                                    <div className="pt-5 d-flex justify-content-end">
                                        <button type="button" className="btn btn-outline-primary btn-sm mr-3 sc-darkblue-outline-button" onClick={onBotaoSecundarioClick}>{botaoSecundario}</button>
                                        <button type="button" className="btn btn-primary btn-sm sc-darkblue-button" onClick={onBotaoPrincipalClick}>{botaoPrincipal}</button>
                                    </div>
                                </Card>
                                :
                                <Card className="col-5 p-4">
                                    <div className="border-bottom sc-text-size-4">
                                        {tituloFeedBack}
                                    </div>

                                    <div className="pt-4 sc-text-size-1">
                                        {feedBack}
                                    </div>

                                    <div className="pt-5 d-flex justify-content-end">
                                        <button type="button" className="col-3 btn btn-primary btn-sm sc-darkblue-button" onClick={resetarPasso}>Ok</button>
                                    </div>
                                </Card>
                            }
                        </div>
                    </animated.div>
                }
            </Spring>
        </div>);
}

export default MesangemConfirmacao;