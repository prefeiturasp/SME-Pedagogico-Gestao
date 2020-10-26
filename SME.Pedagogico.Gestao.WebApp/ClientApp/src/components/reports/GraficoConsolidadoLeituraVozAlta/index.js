import React from 'react';
import Grafico from '../Grafico';

function GraficoConsolidadoLeituraVozAlta({ dados }) {
    const id = "grafico-consolidado-leitura-voz-alta";

    return <Grafico id={id} dados={dados} />;
}

export default GraficoConsolidadoLeituraVozAlta;