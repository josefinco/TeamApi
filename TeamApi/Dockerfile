FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TeamApi/TeamApi.csproj", "TeamApi/"]
RUN dotnet restore "TeamApi/TeamApi.csproj"
COPY . .
WORKDIR "/src/TeamApi"
RUN dotnet build "TeamApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamApi.dll"]