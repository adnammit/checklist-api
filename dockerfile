# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the URLs to bind to all IPv4 addresses on port 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

WORKDIR /app

# Copy and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the app and build
COPY . ./
RUN dotnet publish -c Release -o /out

# Use a runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /out .

# Expose the application port
EXPOSE 80
CMD ["dotnet", "ChecklistAPI.dll"]
