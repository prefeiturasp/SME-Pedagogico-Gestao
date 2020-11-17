const ApiService = {

  urlBase: "http://hom-latexservice.sme.prefeitura.sp.gov.br/api/Recipes/",

   RelatorioPortuguesEscrita: (urlBase) => {

        var endpoint = urlBase + "PollReportPortugueseWriting"
        return endpoint; 
   },
   

   BaixaPdf: (endpoint, report) => {
    return fetch("http://congo/api/Recipes/PollReportPortugueseWriting", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(report)
    })
      .then(response => response.blob())
      .then(blob => {
        const url = window.URL.createObjectURL(new Blob([blob]));
        const link = document.createElement("a");
        link.href = url;
        link.setAttribute("download", "relatorio.pdf");
        document.body.appendChild(link);
        link.click();
        link.parentNode.removeChild(link);
      });
  }
   }

   export default ApiService;
 