FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/InvenEase.Api/InvenEase.Api.csproj", "InvenEase.Api/"]
COPY ["src/InvenEase.Application/InvenEase.Application.csproj", "InvenEase.Application/"]
COPY ["src/InvenEase.Domain/InvenEase.Domain.csproj", "InvenEase.Domain/"]
COPY ["src/InvenEase.Contracts/InvenEase.Contracts.csproj", "InvenEase.Contracts/"]
COPY ["src/InvenEase.Infrastructure/InvenEase.Infrastructure.csproj", "InvenEase.Infrastructure/"]
# COPY ["Directory.Packages.props", "./"]
COPY ["Directory.Build.props", "./"]
RUN dotnet restore "InvenEase.Api/InvenEase.Api.csproj"
COPY . ../
WORKDIR /src/InvenEase.Api
RUN dotnet build "InvenEase.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5100
EXPOSE 5100
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvenEase.Api.dll"]