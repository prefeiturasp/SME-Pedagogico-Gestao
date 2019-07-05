import React, { Component } from 'react';
import './NotFound.css'

export default class NotFound extends Component {
    render() {
        return (
            <>
                <div className="vw-100 vh-100">
                    <div className="h-100 d-flex flex-column justify-content-center align-items-center">
                        <div className="py-4"><img id="erro404" src="./img/img_error404.svg" alt="Erro 404" /></div>
                            <h1 className="message-title">Ocorreu algum erro :(</h1>
                        
                        <p className="message-text">
                            A página que você tentou acessar não está diponível no momento.
                        </p>
                        <button className="btn btn-erro404 text-white">Retornar à página anterior</button>
                    </div>
                </div>
            </>
        );
    }
}