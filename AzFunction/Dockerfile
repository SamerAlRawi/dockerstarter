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
ENV rabbitHost=rabbitmq
ENV rabbitUser=adminuser
ENV rabbitPass=adminpass
