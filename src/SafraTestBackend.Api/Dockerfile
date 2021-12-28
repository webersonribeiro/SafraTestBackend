#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SafraTestBackend.Api/SafraTestBackend.Api.csproj", "SafraTestBackend.Api/"]
COPY ["SafraTestBackend.Business/SafraTestBackend.Business.csproj", "SafraTestBackend.Business/"]
COPY ["SafraTestBackend.Domain/SafraTestBackend.Domain.csproj", "SafraTestBackend.Domain/"]
COPY ["SafraTestBackend.Data/SafraTestBackend.Data.csproj", "SafraTestBackend.Data/"]
RUN dotnet restore "SafraTestBackend.Api/SafraTestBackend.Api.csproj"
COPY . .
WORKDIR "/src/SafraTestBackend.Api"
RUN dotnet build "SafraTestBackend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SafraTestBackend.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SafraTestBackend.Api.dll"]