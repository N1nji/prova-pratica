# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Claps.ProductCatalog.Api/Claps.ProductCatalog.Api.csproj", "Claps.ProductCatalog.Api/"]
COPY ["Claps.ProductCatalog.Application/Claps.ProductCatalog.Application.csproj", "Claps.ProductCatalog.Application/"]
COPY ["Claps.ProductCatalog.Domain/Claps.ProductCatalog.Domain.csproj", "Claps.ProductCatalog.Domain/"]
COPY ["Claps.ProductCatalog.Infrastructure/Claps.ProductCatalog.Infrastructure.csproj", "Claps.ProductCatalog.Infrastructure/"]

RUN dotnet restore "Claps.ProductCatalog.Api/Claps.ProductCatalog.Api.csproj"

COPY . .
WORKDIR "/src/Claps.ProductCatalog.Api"
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Claps.ProductCatalog.Api.dll"]
