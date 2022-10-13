#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Bodegas.Api/Bodegas.Api.csproj", "Bodegas.Api/"]
COPY ["Bodegas.Applications/Bodegas.Applications.csproj", "Bodegas.Applications/"]
COPY ["Bodegas.Domain/Bodegas.Domain.csproj", "Bodegas.Domain/"]
COPY ["Bodegas.Infrastructure/Bodegas.Infrastructure.csproj", "Bodegas.Infrastructure/"]
RUN dotnet restore "Bodegas.Api/Bodegas.Api.csproj"
COPY . .
WORKDIR "/src/Bodegas.Api"
RUN dotnet build "Bodegas.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bodegas.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bodegas.Api.dll"]