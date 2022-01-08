FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ui/Ui.csproj", "Ui/"]
RUN dotnet restore "Ui/Ui.csproj"
COPY . .
WORKDIR "/src/Ui"
RUN dotnet build "Ui.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ui.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ui.dll"]
