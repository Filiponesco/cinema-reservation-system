#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["cinema_reservation_system_individual_auth/cinema_reservation_system_individual_auth.csproj", "cinema_reservation_system_individual_auth/"]
RUN dotnet restore "cinema_reservation_system_individual_auth/cinema_reservation_system_individual_auth.csproj"
COPY . .
WORKDIR "/src/cinema_reservation_system_individual_auth"
RUN dotnet build "cinema_reservation_system_individual_auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cinema_reservation_system_individual_auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cinema_reservation_system_individual_auth.dll"]
