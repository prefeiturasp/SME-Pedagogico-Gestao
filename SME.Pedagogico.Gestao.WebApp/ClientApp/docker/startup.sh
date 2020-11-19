echo "Inicializando a Aplicação..."
echo "URL_SGP = ${URL_SGP}"
envsubst < "/usr/share/nginx/html/configuracoes/template.json" > "/usr/share/nginx/html/configuracoes/variaveis.json"
