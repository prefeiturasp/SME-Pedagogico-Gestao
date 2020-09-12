import React, { useCallback, useMemo } from "react";
import { useSelector } from "react-redux";
import shortid from "shortid";

function SeletorDeOrdem({ ordens, ordemSelecionada, onClick }) {
  const sequenciaOrdens = useSelector((store) => store.sondagemPortugues.sequenciaOrdens);

  const limiteOrdens = useMemo(() => {
    if (!sequenciaOrdens || sequenciaOrdens.length !== 3)
      return;

    const index = sequenciaOrdens.findIndex(ordem => ordem.ordemId === null);

    return index === -1;
  }, [sequenciaOrdens]);

  const ehDesabilitado = useCallback((ordemId) => {
    const index = obterSequenciaOrdem(ordemId);

    return index === -1 && limiteOrdens;
  }, [sequenciaOrdens])

  const obterSequenciaOrdem = (ordemId) => {
    return sequenciaOrdens.findIndex(ordem => ordem.ordemId === ordemId);
  }

  const ordensLista = useMemo(() => {
    return ordens && ordens.map(ordem => { return { ...ordem, desabilitado: ehDesabilitado(ordem.id), sequenciaOrdem: obterSequenciaOrdem(ordem.id) } });
  }, [ordens, sequenciaOrdens]);

  const obterBordas = (index) => {
    if (index === 0) return "btn-double-left border-right-0";

    if (index === ordens.length - 1) return "btn-double-right border-left-0";

    return "border-left-0 border-right-0";
  };

  const onClickOrdem = (event) => {
    console.log(event.target.sequenciaOrdem);
    onClick(event.target.id)
  };

  const obterAtivo = (id) => {
    return id === ordemSelecionada ? "active" : "";
  };

  return (
    <div
      className="btn-group mr-2 btn-group-sm pills"
      role="group"
      aria-label="Second group"
    >
      {ordensLista &&
        ordensLista.length > 0 &&
        ordensLista.map((ordem, index) => {
          return (
            <button
              id={ordem.id}
              key={shortid.generate()}
              value={ordem.id}
              sequenciaOrdem={ordem.sequnciaOrdem}
              disabled={ordem.desabilitado}
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
