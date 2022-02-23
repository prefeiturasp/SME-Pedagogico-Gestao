export const montarCampoToolTipGrafico = (marker, name, valor) => {
  const palavras = `${name}: ${valor}`.split(" ");
  let textoComQuebras = "<span>";
  let linhaTexto = "";
  palavras.forEach((palavra) => {
    linhaTexto += palavra + " ";
    if (linhaTexto.length >= 30) {
      textoComQuebras += palavra + "</span><br/><span>";
      linhaTexto = "";
    } else {
      textoComQuebras += palavra + " ";
    }
  });
  const tag = `${marker}${textoComQuebras}</span>`;
  return tag;
};

export const setasEsquerdaAutoral = {
  ativa: { src: "./img/icon_2_pt_7C4DFF.svg", classe: "testcursor" },
  inativa: { src: "./img/icon_pt_DADADA.svg", classe: "" },
};

export const setasDireitaAutoral = {
  ativa: { src: "./img/icon_pt_7C4DFF.svg", classe: "testcursor" },
  inativa: { src: "./img/icon_2_pt_DADADA.svg", classe: "" },
};

export const setasEsquerdaAlfabetizacao = {
  ativa: { src: "./img/icon_2_mat_FFFFFF.svg", classe: "testcursor" },
  inativa: { src: "./img/icon_mat_9975FF.svg", classe: "" },
};
export const setasDireitaAlfabetizacao = {
  ativa: { src: "./img/icon_mat_FFFFFF.svg", classe: "testcursor" },
  inativa: { src: "./img/icon_2_mat_9975FF.svg", classe: "" },
};
