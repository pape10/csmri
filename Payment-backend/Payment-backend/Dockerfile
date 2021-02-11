#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Payment-backend/Payment-backend.csproj", "Payment-backend/"]
RUN dotnet restore "Payment-backend/Payment-backend.csproj"
COPY . .
WORKDIR "/src/Payment-backend"
RUN dotnet build "Payment-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payment-backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payment-backend.dll"]