import React from "react";
import shortid from "shortid";

function SeletorDeOrdem({ ordens, ordemSelecionada, onClick }) {
  const obterBordas = (index) => {
    if (index === 0) return "btn-double-left border-right-0";

    if (index === ordens.length - 1) return "btn-double-right border-left-0";

    return "border-left-0 border-right-0";
  };

  const onClickOrdem = (event) => onClick(event.target.id);

  const obterAtivo = (id) => {
    return id === ordemSelecionada ? "active" : "";
  };

  return (
    <div
      className="btn-group mr-2 btn-group-sm pills"
      role="group"
      aria-label="Second group"
    >
      {ordens &&
        ordens.length > 0 &&
        ordens.map((ordem, index) => {
          console.log(index);
          return (
            <button
              id={ordem.id}
              key={shortid.generate()}
              value={ordem.id}
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
