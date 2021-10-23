FROM mcr.microsoft.com/azure-functions/dotnet:4 AS base
WORKDIR /home/site/wwwroot
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AzFunction/AzFunction.csproj", "AzFunction/"]

RUN dotnet restore "AzFunction/AzFunction.csproj"

COPY . .
WORKDIR "/src/AzFunction"
RUN dotnet build "AzFunction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AzFunction.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot
ENV AzureFunctionsJobHost__Logging__Console__IsEnabled=true

ENV RabbitMQConnection=amqp://adminuser:adminpass@rabbitmq:5672
ENV rabbitHost=rabbitmq
ENV rabbitUser=adminuser
ENV rabbitPass=adminpass
ENV AzureWebJobsStorage="DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://azurite:10000/devstoreaccount1;QueueEndpoint=http://azurite:10001/devstoreaccount1;TableEndpoint=http://azurite:10002/devstoreaccount1;"
