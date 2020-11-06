import React, { useState, useEffect, useMemo } from "react";
import "../../polls/inputs/Common.css";
import shortid from "shortid";
// import { Tooltip } from "reactstrap";
import { useSelector } from "react-redux";

const AutoralSelect = ({
  onChange,
  lista,
  disabled,
  valor,
  perguntaId,
  periodoId,
  alunoId,
  id,
  sondagemId,
  mostraToolTipItens,
}) => {
  const abertura1Semestre = useSelector(
    (store) => store.filters.abertura1Semestre
  );
  const abertura2Semestre = useSelector(
    (store) => store.filters.abertura2Semestre
  );

  function onOptionChange(event) {
    onChange(event.target.value, perguntaId, periodoId, alunoId, sondagemId);
  }

  const verificaPeriodo = useMemo(() => {
    if (periodoId == "c93c1c4a-abb9-43a4-a8cd-283e4df365d8") {
      return abertura1Semestre;
    }

    if (periodoId == "8de86d08-b7a1-45df-b775-07550714756b") {
      return abertura2Semestre;
    }
  }, [periodoId]);
  const [tooltipOpen, setTooltipOpen] = useState(false);

  const toggle = () => setTooltipOpen(!tooltipOpen);

  const [idSelect, setIdSelect] = useState(null);

  const descricao = useMemo(() => {
    if (!valor || !lista || lista.length === 0) return null;

    const option = lista.find((item) => item.id === valor);

    return option && option.descricao;
  }, [valor]);

  useEffect(() => {
    setIdSelect(shortid.generate());
  }, [tooltipOpen]);

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
          disabled={!verificaPeriodo}
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
          disabled={!verificaPeriodo}
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
