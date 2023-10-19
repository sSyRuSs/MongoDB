FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS bUILD

WORKDIR /src
COPY ["clone.csproj","."]

RUN dotnet restore "./clone.csproj"
COPY . . 
WORKDIR "/src/."

RUN dotnet build "clone.csproj" -c release -o /app/build

FROM build AS publish
RUN dotnet publish "clone.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "clone.dll"]