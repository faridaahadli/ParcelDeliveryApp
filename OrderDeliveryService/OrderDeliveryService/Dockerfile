#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrderDeliveryService/OrderDeliveryService.API.csproj", "OrderDeliveryService/"]
COPY ["OrderDelivery.Infrastructure/OrderDelivery.Infrastructure.csproj", "OrderDelivery.Infrastructure/"]
COPY ["OrderDelivery.Data/OrderDelivery.Data.csproj", "OrderDelivery.Data/"]
COPY ["OrderDelivery.Core/OrderDelivery.Core.csproj", "OrderDelivery.Core/"]
RUN dotnet restore "OrderDeliveryService/OrderDeliveryService.API.csproj"
COPY . .
WORKDIR "/src/OrderDeliveryService"
RUN dotnet build "OrderDeliveryService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderDeliveryService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderDeliveryService.API.dll"]