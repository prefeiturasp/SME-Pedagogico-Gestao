import React, { Component, useState, useEffect } from "react";
import "../../polls/inputs/Common.css";
import shortid from "shortid";

const AutoralSelect = ({
  onChange,
  lista,
  disabled,
  valor,
  perguntaId,
  periodoId,
  alunoId,
  sondagemId,
}) => {
  const [perguntaIdState] = useState(perguntaId);
  const [periodoIdState] = useState(periodoId);
  const [alunoIdState] = useState(alunoId);
  const [sondagemIdState] = useState(sondagemId);

  function onOptionChange(event) {
    onChange(
      event.target.value,
      perguntaIdState,
      periodoIdState,
      alunoIdState,
      sondagemIdState
    );
  }


  return (
    <div>
      <select
        perguntaId={perguntaId}
        value={valor}
        onChange={onOptionChange}
        disabled={disabled}
      >
        <option className={"custom-select custom-select-sm"} value=""></option>
        {lista &&
          lista.map((item) => {
            return (
              <option
                className={"custom-select custom-select-sm"}
                value={item.id}
                key={shortid.generate()}
              >
                {item.descricao}
              </option>
            );
          })}
      </select>
    </div>
  );
};

export default AutoralSelect;
