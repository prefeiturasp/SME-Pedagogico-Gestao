import React from "react";

import "../../polls/inputs/Common.css";
import shortid from "shortid";

function Select({ valorId, lista, onChangeSelect, dados }) {
  const onChange = (event) => {
    onChangeSelect(event.target.value, dados);
  };

  return (
    <select value={valorId} onChange={onChange}>
      <option className={"form-control custom-select custom-select-sm"} value=""></option>
      {lista &&
        lista.map((item) => {
          return (
            <option
              key={shortid.generate()}
              value={item.id}
              className={"custom-select custom-select-sm"}
            >
              {item.descricao}
            </option>
          );
        })}
    </select>
  );
}

export default Select;
