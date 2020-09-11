import React, { useMemo } from "react";
import { useSelector } from "react-redux";
import shortid from "shortid";

function SeletorDeOrdem({ ordens, ordemSelecionada, onClick }) {
  const sequenciaOrdens = useSelector((store) => store.sondagemPortugues.sequenciaOrdens);

  const obterBordas = (index) => {
    if (index === 0) return "btn-double-left border-right-0";

    if (index === ordens.length - 1) return "btn-double-right border-left-0";

    return "border-left-0 border-right-0";
  };

  const limiteOrdens = useMemo(() => {
    if (sequenciaOrdens.length !== 3)
      return;

    const index = sequenciaOrdens.findIndex(ordem => ordem === null);

    return index === -1;
  });

  const onClickOrdem = (event) => onClick(event.target.id);

  const obterAtivo = (id) => {
    return id === ordemSelecionada ? "active" : "";
  };

  const ehDesabilitado = (ordemId) => {
    const index = sequenciaOrdens.findIndex(ordem => ordem === ordemId);

    return index === -1 && limiteOrdens;
  }

  return (
    <div
      className="btn-group mr-2 btn-group-sm pills"
      role="group"
      aria-label="Second group"
    >
      {ordens &&
        ordens.length > 0 &&
        ordens.map((ordem, index) => {
          return (
            <button
              id={ordem.id}
              key={shortid.generate()}
              value={ordem.id}
              disabled={ehDesabilitado(ordem.id)}
              onClick={onClickOrdem}
              type="button"
              className={`btn btn-outline-primary btn-sm btn-matematica ${obterAtivo(
                ordem.id
              )} ${obterBordas(index)}`}
            >
              {ordem.descricao}
            </button>
          );
        })}
    </div>
  );
}

export default SeletorDeOrdem;
