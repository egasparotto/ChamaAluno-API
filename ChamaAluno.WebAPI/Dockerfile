#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["nuget.config", "/"]
COPY ["ChamaAluno.WebAPI/ChamaAluno.WebAPI.csproj", "ChamaAluno.WebAPI/"]
COPY ["ChamaAluno.Dominio/ChamaAluno.Dominio.csproj", "ChamaAluno.Dominio/"]
COPY ["ChamaAluno.DTOs.Mapeamentos/ChamaAluno.DTOs.Mapeamentos.csproj", "ChamaAluno.DTOs.Mapeamentos/"]
COPY ["ChamaAluno.DTOs/ChamaAluno.DTOs.csproj", "ChamaAluno.DTOs/"]
COPY ["ChamaAluno.ServicosDeAplicacao.CRUD/ChamaAluno.ServicosDeAplicacao.CRUD.csproj", "ChamaAluno.ServicosDeAplicacao.CRUD/"]
COPY ["ChamaAluno.Inicializador/ChamaAluno.Inicializador.csproj", "ChamaAluno.Inicializador/"]
COPY ["ChamaAluno.Dados/ChamaAluno.Dados.csproj", "ChamaAluno.Dados/"]
RUN dotnet restore "ChamaAluno.WebAPI/ChamaAluno.WebAPI.csproj"
COPY . .
WORKDIR "/src/ChamaAluno.WebAPI"
RUN dotnet build "ChamaAluno.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChamaAluno.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChamaAluno.WebAPI.dll"]
