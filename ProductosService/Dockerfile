FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore ProductosService.csproj

RUN dotnet publish ProductosService.csproj -c Release -o /app/out

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/out .
EXPOSE 90
ENV ASPNETCORE_URLS=http://+:90

ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "ProductosService.dll"]