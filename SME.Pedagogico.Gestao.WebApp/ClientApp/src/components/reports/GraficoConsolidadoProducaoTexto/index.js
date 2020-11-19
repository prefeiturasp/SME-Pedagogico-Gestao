import React from 'react';
import Grafico from '../Grafico';

function GraficoConsolidadoProducaoTexto({ dados }) {
    const id = "grafico-consolidado-producao-texto";

    return <Grafico id={id} dados={dados} />;
}

export default GraficoConsolidadoProducaoTexto;