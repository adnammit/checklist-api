FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
EXPOSE 5064

ENV ASPNETCORE_URLS=http://+:5064

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Debug -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ChecklistAPI.dll"]
