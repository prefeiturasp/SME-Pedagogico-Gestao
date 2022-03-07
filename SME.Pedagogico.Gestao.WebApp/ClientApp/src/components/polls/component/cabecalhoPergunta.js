import React from "react";
import { TIPO_SONDAGEM } from "../../../Enums";

const CabecalhoPergunta = ({ props }) => {
  const {
    tamanhoLinhas,
    anoEscolar,
    itemSelecionado,
    recuar,
    avancar,
    tipoSondagem,
    primeiraOrdenacao,
    ultimaOrdenacao,
    indexSelecionado,
  } = props;

  const estiloSetas = { height: 20, color: "#DADADA" };

  const setasEsquerda = {
    ativa: { src: "./img/icon_2_mat_FFFFFF.svg", classe: "ativa" },
    inativa: { src: "./img/icon_mat_9975FF.svg", classe: "inativa" },
  };
  const setasDireita = {
    ativa: { src: "./img/icon_mat_FFFFFF.svg", classe: "ativa" },
    inativa: { src: "./img/icon_2_mat_9975FF.svg", classe: "inativa" },
  };

  const setaEsquerda =
    primeiraOrdenacao === indexSelecionado
      ? setasEsquerda.inativa
      : setasEsquerda.ativa;

  const setaDireita =
    ultimaOrdenacao === indexSelecionado
      ? setasDireita.inativa
      : setasDireita.ativa;

  return (
    <>
      <th
        rowSpan={2 + tamanhoLinhas}
        className="align-middle border text-color-purple"
      >
        <div className="ml-2">
          Sondagem - {anoEscolar}º ano | <b>{TIPO_SONDAGEM[tipoSondagem]}</b>
        </div>
      </th>
      <th
        colSpan={2 + tamanhoLinhas}
        key={itemSelecionado && itemSelecionado.id}
        id={`col_head_${itemSelecionado && itemSelecionado.id}`}
        className="text-center border text-color-purple text-center border sondagem-matematica-title"
        style={{ maxWidth: 40 }}
      >
        <div
          className="d-flex justify-content-center align-items-center"
          style={{
            height: 30,
          }}
        >
          <span onClick={() => recuar()} className="testcursor">
            <img
              src={setaEsquerda.src}
              alt={`seta esquerda ${setaEsquerda.classe}`}
              style={estiloSetas}
            />
          </span>
          <b
            className="p-4 text-nowrap overflow-hidden text-truncate"
            data-bs-toggle="tooltip"
            title={itemSelecionado && itemSelecionado.descricao}
          >
            {itemSelecionado && itemSelecionado.descricao}
          </b>
          <span onClick={() => avancar()} className="testcursor">
            <img
              src={setaDireita.src}
              alt={`seta direita ${setaDireita.classe}`}
              style={estiloSetas}
            />
          </span>
        </div>
      </th>
    </>
  );
};

export default CabecalhoPergunta;
