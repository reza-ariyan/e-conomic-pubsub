FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PubSub.Application/PubSub.Application.csproj", "PubSub.Application/"]
RUN dotnet restore "src/PubSub.Application/PubSub.Application.csproj"
COPY . .
WORKDIR "/src/PubSub.Application"
RUN dotnet build "PubSub.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PubSub.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PubSub.Application.dll"]
