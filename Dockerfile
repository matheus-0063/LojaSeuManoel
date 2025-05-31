FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/L2Code.API/L2Code.API.csproj", "src/L2Code.API/"]
COPY ["src/L2Code.Application/L2Code.Application.csproj", "src/L2Code.Application/"]
COPY ["src/L2Code.Domain/L2Code.Domain.csproj", "src/L2Code.Domain/"]
COPY ["src/L2Code.Infra/L2Code.Infra.csproj", "src/L2Code.Infra/"]
RUN dotnet restore "src/L2Code.API/L2Code.API.csproj"
COPY . .
WORKDIR "/src/src/L2Code.API"
RUN dotnet build "L2Code.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "L2Code.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "L2Code.API.dll"]
