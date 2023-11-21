#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/mobile-app/app/CoinGardenWorldMobileApp.DotNetApi/CoinGardenWorldMobileApp.DotNetApi.csproj", "src/mobile-app/app/CoinGardenWorldMobileApp.DotNetApi/"]
RUN dotnet restore "src/mobile-app/app/CoinGardenWorldMobileApp.DotNetApi/CoinGardenWorldMobileApp.DotNetApi.csproj"
COPY . .
WORKDIR "/src/src/mobile-app/app/CoinGardenWorldMobileApp.DotNetApi"
RUN dotnet build "CoinGardenWorldMobileApp.DotNetApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "CoinGardenWorldMobileApp.DotNetApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoinGardenWorldMobileApp.DotNetApi.dll"]