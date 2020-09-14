import React, { Component, useState, useEffect, useMemo } from "react";
import "../../polls/inputs/Common.css";
import shortid from "shortid";
import { Tooltip } from 'reactstrap';
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
}) => {

    const abertura1Semestre = useSelector((store) => store.filters.abertura1Semestre);
    const abertura2Semestre = useSelector((store) => store.filters.abertura2Semestre);


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
        if (!valor || !lista || lista.length === 0)
            return null;

        const option = lista.find(item => item.id === valor);

        return option && option.descricao
    }, [valor])

    useEffect(() => { console.log(tooltipOpen); setIdSelect(shortid.generate()) }, [tooltipOpen])
    console.log(id, tooltipOpen);
    
    return (
       
            <div>       
            
                <select className={"col-10 custom-select"}
                    perguntaId={perguntaId}
                    value={valor}
                    onChange={onOptionChange}
                    disabled={!verificaPeriodo}
                       id={"Tooltip-" + id}
                    key={shortid.generate()}
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
            <Tooltip placement="top" isOpen={tooltipOpen} target={"Tooltip-" + id} toggle={toggle}>
                {descricao}
            </Tooltip>

            </div>
    );
};

export default AutoralSelect;
