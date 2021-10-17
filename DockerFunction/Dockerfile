#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/azure-functions/dotnet:4 AS base
WORKDIR /home/site/wwwroot
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DockerFunction/DockerFunction.csproj", "DockerFunction/"]
RUN dotnet restore "DockerFunction/DockerFunction.csproj"
COPY . .
WORKDIR "/src/DockerFunction"
RUN dotnet build "DockerFunction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerFunction.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot
ENV AzureFunctionsJobHost__Logging__Console__IsEnabled=true
