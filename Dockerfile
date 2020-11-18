FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build

RUN wget https://nodejs.org/dist/v8.17.0/node-v8.17.0-linux-x64.tar.gz \ 
    && tar -xzf node-v8.17.0-linux-x64.tar.gz \ 
    && ln -s /node-v8.17.0-linux-x64/bin/node /usr/bin/node \ 
    && ln -s /node-v8.17.0-linux-x64/bin/npm /usr/bin/npm \ 
    && ln -s /node-v8.17.0-linux-x64/bin/npx /usr/bin/npx

#COPY ["SME.Pedagogico.Gestao.Data/SME.Pedagogico.Gestao.Data.csproj", "/SME.Pedagogico.Gestao.Data/"]
#COPY ["SME.Pedagogico.Gestao.Models/SME.Pedagogico.Gestao.Models.csproj", "SME.Pedagogico.Gestao.Models/"]
#COPY ["SME.Pedagogico.Gestao.WebApp/SME.Pedagogico.Gestao.WebApp.csproj", "SME.Pedagogico.Gestao.WebApp/"]
#RUN dotnet restore "SME.Pedagogico.Gestao.WebApp/SME.Pedagogico.Gestao.WebApp.csproj"
COPY . .
WORKDIR "/SME.Pedagogico.Gestao.WebApp"
#RUN dotnet build "SME.Pedagogico.Gestao.WebApp.csproj" -c Release -o /app

#FROM build AS publish
#RUN dotnet publish "SME.Pedagogico.Gestao.WebApp.csproj" -c Release -o /app \

RUN cd ClientApp \
#    && npm i \
#    && npm run build \ 
    && cd .. \
    && mv ClientApp /app/ClientApp 
#    && cp SME.Pedagogico.Gestao.WebApp.xml /app/SME.Pedagogico.Gestao.WebApp.xml


## startup.sh script is launched at container run
ADD ClientApp/docker/startup.sh /startup.sh
RUN dos2unix "/startup.sh"
RUN ["chmod", "+x", "/startup.sh"]
CMD /startup.sh


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SME.Pedagogico.Gestao.WebApp.dll"]


