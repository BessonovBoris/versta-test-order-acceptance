FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

USER root
RUN apt-get update && apt-get install -y openssl libnss3-tools

USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY . .
RUN dotnet restore "src/Console/Console.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "src/Console/Console.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "src/Console/Console.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY /src/Console/Properties/appsettings.json ./
ENTRYPOINT ["dotnet", "Console.dll"]
