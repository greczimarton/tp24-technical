FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TP24.API/TP24.API.csproj", "TP24.API/"]
RUN dotnet restore "TP24.API/TP24.API.csproj"
COPY . .
WORKDIR "/src/TP24.API"
RUN dotnet build "TP24.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TP24.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TP24.API.dll"]
