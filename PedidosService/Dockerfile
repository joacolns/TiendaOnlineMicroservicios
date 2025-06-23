FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "PedidosService/PedidosService.csproj"
RUN dotnet publish "PedidosService/PedidosService.csproj" -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 40
ENV ASPNETCORE_URLS=http://+:40
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "PedidosService.dll"]