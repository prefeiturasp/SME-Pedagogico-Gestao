import React, { useState, useMemo, useEffect } from "react";
import { useSelector, useDispatch } from 'react-redux';
import { createStore } from 'redux'

import { actionCreators } from '../../store/SondagemAutoral';
import { actionCreators as actionCreatorsPoll } from '../../store/Filters';

function SondagemMatematicaAutoral() {
 
    //const store = createStore(actionCreators);
 //   console.log(store.getState());
   //const dispatch = useDispatch();

    const dispatch = useDispatch();
    const filtros = useSelector(store => store.filters);

 //   listarPerguntas: () => ({ type: types.LISTAR_PERGUNTAS }),
    console.log(dispatch(actionCreators.listarPerguntas()));

    const perguntas = useSelector(store => store.listaPerguntas);

  const [indexSelecionado, setIndexSelecionado] = useState(0);

    const itemSelecionado = useMemo(() => {
        return [];
      if (indexSelecionado == 0) return [];
      return perguntas.filter(x => x.ordenacao == indexSelecionado);
  }, [indexSelecionado]);


    //useEffect(() => {
    //    dispatch(actionCreators.listarPerguntas());

    //}, []);

    useEffect(() => {
        if (!perguntas || perguntas.length > 0) setIndexSelecionado(1);

    }, [perguntas]);

  const avancar = () => {
      if(indexSelecionado == (perguntas.length - 1))
      return;

      setIndexSelecionado((oldState) => oldState + 1);
  }

  const pStyle = {
    color: "#DADADA",
  };

  return (
    <table
      className="table table-sm table-bordered table-hover table-sondagem-matematica"
      style={{ overflow: "hidden", overflowX: "auto" }}
    >
      <thead>
        <tr>
          {itemSelecionado.map((pergunta, index) => (
            <th
              colSpan="2"
              key={pergunta.id}
              id={`col_head_${pergunta.id}`}
              className="text-center border text-color-purple"
            >
              {index > 0 ? (
                <span
                  value="opacos_col"
                  //onClick={this.hideShowOrdem}
                  className="testcursor"
                >
                  <img
                    src="./img/icon_2_pt_7C4DFF.svg"
                    alt="seta esquerda ativa"
                    style={{ height: 20 }}
                  />
                </span>
              ) : null}
              <b className="p-4">{pergunta.descricao}</b>
              <span
                value="zero_col"
                onClick={() => avancar()}
                className="testcursor"
              >
                <img
                  src="./img/icon_pt_7C4DFF.svg"
                  alt="seta direita ativa"
                  style={{ height: 20 }}
                />
              </span>
            </th>
          ))}
        </tr>
        <tr>
          <th className="text-center border poll-select-container">
            <small className="text-muted">1º Semestre</small>
          </th>
          <th className="text-center border poll-select-container">
            <small className="text-muted">2º Semestre</small>
          </th>
        </tr>
      </thead>

      <tbody></tbody>
    </table>
  );
}

export default SondagemMatematicaAutoral;
