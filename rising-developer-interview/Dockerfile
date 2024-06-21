FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["rising-developer-interview/rising-developer-interview.csproj", "rising-developer-interview/"]
RUN dotnet restore "rising-developer-interview/rising-developer-interview.csproj"
COPY . .
WORKDIR "/src/rising-developer-interview"
RUN dotnet build "rising-developer-interview.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "rising-developer-interview.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "rising-developer-interview.dll"]
