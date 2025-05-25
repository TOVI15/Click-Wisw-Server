# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Corrected paths for .csproj files based on your directory structure
COPY ["SchoolManagement.csproj", "."]
# COPY ["SchoolManagement/SchoolManagement.csproj", "SchoolManagement/"]
COPY ["DL/ClickWise.Data.csproj", "ClickWise.Data/"]
COPY ["ClickWise.Core/ClickWise.Core.csproj", "ClickWise.Core/"]
COPY ["ClickWise.Service/ClickWise.Service.csproj", "ClickWise.Service/"]

RUN dotnet restore "SchoolManagement/SchoolManagement.csproj"

COPY . .

WORKDIR "/src/SchoolManagement"
RUN dotnet build "SchoolManagement.csproj" -c Release -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SchoolManagement.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish . 
ENTRYPOINT ["dotnet", "SchoolManagement.dll"]
