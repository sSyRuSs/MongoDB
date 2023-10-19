FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS bUILD
# Copy everything
WORKDIR /src
COPY ["clone.csproj","."]
# Restore as distinct layers
RUN dotnet restore "./clone.csproj"
COPY . . 
WORKDIR "/src/."
# Build and publish a release
RUN dotnet build "clone.csproj" -c release -o /app/build

# Build runtime image
FROM build AS publish
RUN dotnet publish "clone.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "clone.dll"]