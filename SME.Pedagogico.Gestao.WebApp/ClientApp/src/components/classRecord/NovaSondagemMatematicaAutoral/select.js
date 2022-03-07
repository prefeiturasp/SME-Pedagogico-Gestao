import React, { useMemo } from "react";
import { useSelector } from "react-redux";
import "../../polls/inputs/Common.css";
import shortid from "shortid";

const AutoralSelect = ({
  onChange,
  lista,
  valor,
  perguntaId,
  alunoId,
  sondagemId,
  mostraToolTipItens,
  subPerguntaId,
}) => {
  function onOptionChange(event) {
    onChange(
      event.target.value,
      perguntaId,
      alunoId,
      sondagemId,
      subPerguntaId
    );
  }

  const periodoAberto = useSelector((store) => store.autoral.periodoAberto);

  const descricao = useMemo(() => {
    if (!valor || !lista || lista.length === 0) return null;

    const option = lista.find((item) => item.id === valor);

    return option && option.descricao;
  }, [lista, valor]);

  const construirItens = (itens) => {
    if (itens) {
      const valores = mostraToolTipItens
        ? itens.map((item) => {
            return (
              <option
                class="d-inline-block"
                tabindex="0"
                data-toggle="tooltip"
                title={item.descricao}
                className={"custom-select custom-select-sm"}
                value={item.id}
                key={shortid.generate()}
              >
                {item.descricao}
              </option>
            );
          })
        : itens.map((item) => {
            return (
              <option
                className={"custom-select custom-select-sm"}
                value={item.id}
                key={shortid.generate()}
              >
                {item.descricao}
              </option>
            );
          });
      return valores;
    }
  };

  return (
    <div>
      {mostraToolTipItens ? (
        <select
          class="d-inline-block"
          tabindex="0"
          data-toggle="tooltip"
          title={descricao}
          className={"col-10 custom-select"}
          perguntaId={perguntaId}
          value={valor}
          onChange={onOptionChange}
          disabled={!periodoAberto}
          key={shortid.generate()}
        >
          <option
            className={"custom-select custom-select-sm"}
            value=""
          ></option>
          {construirItens(lista)}
        </select>
      ) : (
        <select
          className={"col-10 custom-select"}
          perguntaId={perguntaId}
          value={valor}
          onChange={onOptionChange}
          disabled={!periodoAberto}
          key={shortid.generate()}
        >
          <option
            className={"custom-select custom-select-sm"}
            value=""
          ></option>
          {construirItens(lista)}
        </select>
      )}
    </div>
  );
};

export default AutoralSelect;
