import React, { useCallback, useEffect, useMemo } from "react";
import { useSelector } from "react-redux";
import shortid from "shortid";

function SeletorDeOrdem({ ordens, ordemSelecionada, onClick, ordensSalvas }) {
  const sequenciaOrdens = useSelector((store) => store.sondagemPortugues.sequenciaOrdens);

  const style = useMemo(() => {
    return { display: !ordens || ordens.length <= 1 ? "none" : "" }
  }, [ordens])

  const limiteOrdens = useMemo(() => {
    if (!sequenciaOrdens || sequenciaOrdens.length !== 3)
      return;

    const index = sequenciaOrdens.findIndex(ordem => ordem.ordemId === null);

    return index === -1;
  }, [sequenciaOrdens]);
  
  const obterSequenciaOrdem = useCallback((ordemId) => {
    return sequenciaOrdens ? sequenciaOrdens.findIndex(ordem => ordem && ordem.ordemId === ordemId) : -1;
  },[sequenciaOrdens])


  const ehDesabilitado = useCallback((ordemId) => {
    const index = obterSequenciaOrdem(ordemId);

    return index === -1 && limiteOrdens;
  }, [limiteOrdens, obterSequenciaOrdem])

 
  const ordensLista = useMemo(() => {
    return ordens && ordens.map(ordem => { return { ...ordem, desabilitado: ehDesabilitado(ordem.id), sequenciaOrdem: obterSequenciaOrdem(ordem.id) } });
  }, [ehDesabilitado, obterSequenciaOrdem, ordens]);

  const obterBordas = (index) => {
    if (index === 0) return "btn-double-left border-right-0";

    if (index === ordens.length - 1) return "btn-double-right border-left-0";

    return "border-left-0 border-right-0";
  };

  useEffect(() => {
    if (ordens && ordens.length === 1)
      onClick(ordens[0].id);
  }, [onClick, ordens])

  const onClickOrdem = (event) => {
    onClick(event.target.id)
  };

  const obterAtivo = (id) => {
    return id === ordemSelecionada ? "active" : "";
  };

  return (
    <div
      className="btn-group mr-2 btn-group-sm pills w-100 ml-2 mr-2"
      role="group"
      aria-label="Second group"
      style={style}
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
              {ordensSalvas && ordensSalvas.find(a => a.ordemId === ordem.id)?
                <i
                  className="fas fa-check-circle ml-2"
                  data-toggle="tooltip" 
                  data-placement="top" 
                  title="Ordem salva"
                  style={{
                    color: "#72BC17",
                    border: "1px solid white",
                    borderRadius: "50%",
                    backgroundColor: "white"
                  }}
                />
                :<i 
                  className="fas fa-exclamation-circle ml-2"
                  data-toggle="tooltip" 
                  data-placement="top" 
                  title="Ordem não salva"
                  style={{
                    color: "#DE9524",
                    border: "1px solid white",
                    borderRadius: "50%",
                    backgroundColor: "white"
                  }}
                />
              }
            </button>
          );
        })}
    </div>
  );
}

export default SeletorDeOrdem;
