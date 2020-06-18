#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NetCoreExample.UI/NetCoreExample.UI.csproj", "NetCoreExample.UI/"]
COPY ["NetCoreExample.Models/NetCoreExample.Models.csproj", "NetCoreExample.Models/"]
RUN dotnet restore "NetCoreExample.UI/NetCoreExample.UI.csproj"
COPY . .
WORKDIR "/src/NetCoreExample.UI"
RUN dotnet build "NetCoreExample.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreExample.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreExample.UI.dll"]
