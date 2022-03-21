FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Zoomo/Zoomo.csproj", "Zoomo/"]
RUN dotnet restore "Zoomo/Zoomo.csproj"
COPY . .
WORKDIR "/src/Zoomo"
RUN dotnet build "Zoomo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zoomo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zoomo.dll"]
