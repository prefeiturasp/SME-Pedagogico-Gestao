import React, { useMemo } from 'react';
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import { useDispatch } from 'react-redux';

function CheckBox({ lista, valor, codigoAluno, periodoId, bloqueado }) {
  const dispatch = useDispatch();

  const respostaVerdadeira = (perguntaId) => {
    var pergunta = lista.find(x => x.id === perguntaId);

    if (!pergunta)
      return;

    return pergunta.respostas.find(x => x.verdadeiro);
  }

  const perguntaUnica = ['0ef5e05f-a366-4da1-b6c0-594ae45f57e5', 'cfec69be-16fb-453d-8c47-fd5ebc4161ef']

  const verificaSeChecado = perguntaId => {
    if (!valor || valor.length === 0)
      return false;

    const resposta = valor.find(resposta => resposta.pergunta === perguntaId);

    if (!resposta || resposta.length === 0)
      return false;

    const respostaDaPergunta = resposta.pergunta === perguntaId && resposta.periodoId === periodoId && resposta.resposta === respostaVerdadeira(perguntaId).id;

    return respostaDaPergunta;
  }

  const verificarSePerguntaUnica = (pergunta) => {
    return perguntaUnica.findIndex(p => pergunta === p) > -1;
  }

  const verificaSeRespostaUnicaSelecionada = useMemo(() => {
    if (!valor || valor.length === 0)
      return false;

    let listaFiltrada = valor.filter(p => verificarSePerguntaUnica(p.pergunta));

    return listaFiltrada && listaFiltrada.length > 0;
  }, [valor])

  const verificarSeRespostaDesabilitada = (pergunta) => {
    if (!valor || valor.length === 0)
      return false;

    const index = valor.findIndex(p => p.pergunta === pergunta);

    return index === -1 && verificaSeRespostaUnicaSelecionada;
  }

  const onClick = event => {
    const checks = document.querySelectorAll(`input[name="${event.target.name}"]:checked`);

    if (!checks || checks.length === 0) {
      dispatch(PortuguesStore.limpar_respostas_aluno_especifico(codigoAluno));
      return;
    }

    let perguntasId = [];

    checks.forEach(check => perguntasId.push(check.value));

    if (!perguntasId || perguntasId.length === 0)
      return;

    let respostaUnica = false;

    perguntasId.forEach(p => {
      if (verificarSePerguntaUnica(p))
        respostaUnica = true;
    });

    if (respostaUnica)
      perguntasId = perguntasId.filter(p => verificarSePerguntaUnica(p));

    const respostas = [];

    perguntasId.forEach(perguntaId => {
      const pergunta = lista.find(pergunta => pergunta.id === perguntaId);

      if (!pergunta)
        return;

      const resposta = respostaVerdadeira(perguntaId);

      if (!resposta)
        return;

      const respostaAluno = {
        respostaId: resposta.id,
        perguntaId: pergunta.id,
        alunoId: codigoAluno,
        periodoId: periodoId
      };

      respostas.push(respostaAluno);
    });

    dispatch(PortuguesStore.atualizar_resposta_checkbox(respostas))
  }


  return (
    <>
      {
        lista && lista.map(pergunta => {
          return (
            <td className="justify-content-center">
              <div class="form-check justify-content-center justify-items-center justify-self-center">
                <input class="form-check-input justify-self-center" disabled={bloqueado || verificarSeRespostaDesabilitada(pergunta.id)} checked={verificaSeChecado(pergunta.id)} perguntaid={pergunta.id} onClick={onClick} type="checkbox" name={codigoAluno} value={pergunta.id} />
              </div>
            </td>
          );
        })
      }
    </>);
}

export default CheckBox;