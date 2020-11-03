export const montarCampoToolTipGrafico = (marker, name, valor) => {
    const palavras = `${name}: ${valor}`.split(' ');
    let textoComQuebras = "<span>";
    let linhaTexto = "";
    palavras.forEach((palavra) => {
      linhaTexto += palavra+' ';
      if (linhaTexto.length>=30){
        textoComQuebras += palavra + "</span><br/><span>";
        linhaTexto = '';
      }else{
        textoComQuebras += palavra + " ";
      }
    });
    const tag = `${marker}${textoComQuebras}</span>`;
    return tag;
  };