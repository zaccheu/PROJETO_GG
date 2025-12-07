FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY src/ .

WORKDIR /app/GG.Api

RUN dotnet restore

RUN dotnet publish -c Release -o /app/out




FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "GG.Api.dll"]




# ./api/Dockerfile
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#WORKDIR /app
#EXPOSE 8080
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#COPY ["GG.Api/GG.Api.csproj", "GG.Api/"]
#RUN dotnet restore "ExpertStore.Api/ExpertStore.Api.csproj"
#COPY . .
#WORKDIR "/src/ExpertStore.Api"
#RUN dotnet publish -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=build /app/publish .
#ENTRYPOINT ["dotnet", "GG.Api.dll"]