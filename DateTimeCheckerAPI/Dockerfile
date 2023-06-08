#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DateTimeCheckerAPI/DateTimeCheckerAPI.csproj", "DateTimeCheckerAPI/"]
RUN dotnet restore "DateTimeCheckerAPI/DateTimeCheckerAPI.csproj"
COPY . .
WORKDIR "/src/DateTimeCheckerAPI"
RUN dotnet build "DateTimeCheckerAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DateTimeCheckerAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DateTimeCheckerAPI.dll"]