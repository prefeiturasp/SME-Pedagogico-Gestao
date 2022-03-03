import React from "react";
import { TIPO_SONDAGEM } from "../../../Enums";
import { escolherPropriedade } from "../funcoes/componentesMatematica";

const CabecalhoPerguntaAutoral = ({ props }) => {
  const {
    tamanhoLinhas = 0,
    anoEscolar,
    itemSelecionado,
    recuar,
    avancar,
    tipoSondagem,
    primeiraOrdenacao,
    ultimaOrdenacao,
    indexSelecionado,
    setasDireita,
    setasEsquerda,
    classes = "",
  } = props;

  const ehNumeric = tipoSondagem === escolherPropriedade.Numeric;
  const textoNumero = ehNumeric ? (
    <>
      | <b>{TIPO_SONDAGEM[tipoSondagem]}</b>
    </>
  ) : (
    ""
  );
  const estiloSetas = { height: 20, color: "#DADADA" };

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
          Sondagem - {anoEscolar}º ano {textoNumero}
        </div>
      </th>
      <th
        colSpan={2 + tamanhoLinhas}
        key={itemSelecionado && itemSelecionado.id}
        id={`col_head_${itemSelecionado && itemSelecionado.id}`}
        className={`text-center border text-color-purple text-center border ${classes}`}
        style={{ maxWidth: 40 }}
      >
        <div
          className="d-flex justify-content-center align-items-center"
          style={{
            height: 30,
          }}
        >
          <span onClick={() => recuar()} className={setaEsquerda.classe}>
            <img
              src={setaEsquerda.src}
              alt="seta esquerda"
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
          <span onClick={() => avancar()} className={setaDireita.classe}>
            <img src={setaDireita.src} alt="seta direita" style={estiloSetas} />
          </span>
        </div>
      </th>
    </>
  );
};

export default CabecalhoPerguntaAutoral;
