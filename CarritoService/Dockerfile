FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore CarritoService.csproj

RUN dotnet publish CarritoService.csproj -c Release -o /app/out

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/out .
EXPOSE 50
ENV ASPNETCORE_URLS=http://+:50

ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "CarritoService.dll"]