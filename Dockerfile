# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore as distinct layers
COPY ["GG.Api/GG.Api.csproj", "GG.Api/"]
COPY ["GG.Application/GG.Application.csproj", "GG.Application/"]
COPY ["GG.Communication/GG.Communication.csproj", "GG.Communication/"]
COPY ["GG.Domain/GG.Domain.csproj", "GG.Domain/"]
COPY ["GG.Exception/GG.Exception.csproj", "GG.Exception/"]
COPY ["GG.Infrastructure/GG.Infrastructure.csproj", "GG.Infrastructure/"]

RUN dotnet restore "GG.Api/GG.Api.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/GG.Api"
RUN dotnet build "GG.Api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "GG.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GG.Api.dll"]