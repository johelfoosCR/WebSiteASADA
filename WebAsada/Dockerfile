FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["WebAsada/WebAsada.csproj", "WebAsada/"]
RUN dotnet restore "WebAsada/WebAsada.csproj"
COPY . .
WORKDIR "/src/WebAsada"
RUN dotnet build "WebAsada.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebAsada.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAsada.dll"]