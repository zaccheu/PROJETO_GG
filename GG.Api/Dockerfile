#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GG.Api/GG.Api.csproj", "GG.Api/"]
COPY ["GG.Aplication/GG.Application.csproj", "GG.Aplication/"]
COPY ["GG.Communication/GG.Communication.csproj", "GG.Communication/"]
COPY ["GG.Domain/GG.Domain.csproj", "GG.Domain/"]
COPY ["GG.Exception/GG.Exception.csproj", "GG.Exception/"]
COPY ["GG.Infrastructure/GG.Infrastructure.csproj", "GG.Infrastructure/"]
RUN dotnet restore "./GG.Api/GG.Api.csproj"
COPY . .
WORKDIR "/src/GG.Api"
RUN dotnet build "./GG.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GG.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GG.Api.dll"]