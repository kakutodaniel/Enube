FROM microsoft/dotnet:2.1-sdk AS builder

COPY ENube.Integrations.API ENube.Integrations.API
COPY ENube.Integrations.Application ENube.Integrations.Application
COPY ENube.Integrations.sln ENube.Integrations.sln

WORKDIR /

RUN dotnet restore --no-cache --source https://api.nuget.org/v3/index.json #--source http://nuget-server.dotzmkt.com.br/nuget 

RUN dotnet publish --output /app/ -c Release --no-restore

FROM microsoft/dotnet:2.1-aspnetcore-runtime

WORKDIR /app
COPY --from=builder /app .

RUN apt-get update
#RUN apt-get -qq update

EXPOSE 80/tcp
ENV ASPNETCORE_URLS http://*:80
#ENV ASPNETCORE_URLS http://+:80
#ENV ASPNETCORE_URLS http://*:5000

ENV ASPNETCORE_ENVIRONMENT Production
#ENV ASPNETCORE_ENVIRONMENT Development

ENTRYPOINT ["dotnet", "ENube.Integrations.API.dll"]