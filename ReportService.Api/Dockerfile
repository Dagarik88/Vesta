FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .
WORKDIR /src

RUN dotnet restore ReportService.Api/ReportService.Api.csproj
RUN dotnet restore ReportService.Tests/ReportService.Tests.csproj

RUN dotnet publish ReportService.Api/ReportService.Api.csproj --no-restore -c Release -o /app

FROM build as tests
WORKDIR /src/ReportService/ReportService.Tests/

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ReportService.Api.dll"]

