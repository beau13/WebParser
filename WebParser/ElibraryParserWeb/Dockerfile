FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ElibraryParserWeb.csproj", "./"]
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ElibraryParserWeb.dll"]