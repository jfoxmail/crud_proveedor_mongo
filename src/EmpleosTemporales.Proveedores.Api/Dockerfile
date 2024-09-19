#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/EmpleosTemporales.Proveedores.Api/EmpleosTemporales.Proveedores.Api.csproj", "src/EmpleosTemporales.Proveedores.Api/"]
COPY ["src/EmpleosTemporales.Proveedores.Application/EmpleosTemporales.Proveedores.Application.csproj", "src/EmpleosTemporales.Proveedores.Application/"]
COPY ["src/EmpleosTemporales.Proveedores.Domain/EmpleosTemporales.Proveedores.Domain.csproj", "src/EmpleosTemporales.Proveedores.Domain/"]
COPY ["src/EmpleosTemporales.Proveedores.Common/EmpleosTemporales.Proveedores.Common.csproj", "src/EmpleosTemporales.Proveedores.Common/"]
COPY ["src/EmpleosTemporales.Proveedores.Persistence/EmpleosTemporales.Proveedores.Persistence.csproj", "src/EmpleosTemporales.Proveedores.Persistence/"]
RUN dotnet restore "./src/EmpleosTemporales.Proveedores.Api/EmpleosTemporales.Proveedores.Api.csproj"
COPY . .
WORKDIR "/src/src/EmpleosTemporales.Proveedores.Api"
RUN dotnet build "./EmpleosTemporales.Proveedores.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EmpleosTemporales.Proveedores.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmpleosTemporales.Proveedores.Api.dll"]