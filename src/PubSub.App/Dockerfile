FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PubSub.App/PubSub.App.csproj", "PubSub.App/"]
RUN dotnet restore "src/PubSub.App/PubSub.App.csproj"
COPY . .
WORKDIR "/src/PubSub.App"
RUN dotnet build "PubSub.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PubSub.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PubSub.App.dll"]
