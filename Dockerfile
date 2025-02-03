FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Console/Console.csproj", "Console.csproj"]
COPY ["src/Application/Application.csproj", "Application.csproj"]
COPY ["src/DataBase/DataBase.csproj", "DataBase.csproj"]
RUN dotnet restore "Console.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "Console.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Console.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Console.dll"]
