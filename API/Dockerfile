FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /app

COPY *.csproj .
COPY *.config .
RUN dotnet restore --configfile ./nuget.config 

COPY . .
RUN dotnet publish -c Release -o build

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS runtime
WORKDIR /app

COPY --from=build /app/build .
ENTRYPOINT [ "dotnet", "WebApi.dll" ]