# Base image for the final application
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files into the container
COPY ["CarCompass/CarCompassAPI.csproj", "CarCompass/"]  # Copy CarCompassAPI project file
COPY ["Services/Services.csproj", "Services/"]  # Copy Services project file
COPY ["Domain/Domain.csproj", "Domain/"]  # Copy Domain project file

# Restore dependencies
RUN dotnet restore "CarCompass/CarCompassAPI.csproj"

# Copy the entire source code into the container
COPY . .

# Set the working directory to the CarCompassAPI
WORKDIR "/src/CarCompass"

# List files for debugging (Optional, can be commented out later)
RUN ls -R

# Build the project
RUN dotnet build "CarCompassAPI.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "CarCompassAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarCompassAPI.dll"]
