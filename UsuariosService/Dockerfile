FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore UsuariosService.csproj

RUN dotnet publish UsuariosService.csproj -c Release -o /app/out

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/out .
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "UsuariosService.dll"]