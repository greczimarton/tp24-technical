FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TP24ReceivablesAPI/TP24Receivables.API.csproj", "TP24ReceivablesAPI/"]
COPY ["TP24Receivables.Data/TP24Receivables.Data.csproj", "TP24Receivables.Data/"]
COPY ["TP24Receivables.Logic/TP24Receivables.Logic.csproj", "TP24Receivables.Logic/"]
COPY ["TP24Receivables.Repository/TP24Receivables.Repository.csproj", "TP24Receivables.Repository/"]
RUN dotnet restore "TP24ReceivablesAPI/TP24Receivables.API.csproj"
COPY . .
WORKDIR "/src/TP24ReceivablesAPI"
RUN dotnet build "TP24Receivables.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TP24Receivables.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TP24Receivables.API.dll"]
