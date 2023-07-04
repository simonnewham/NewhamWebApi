#Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "./WebApi/WebApi.csproj" --disable-parallel
RUN dotnet publish "./WebApi/WebApi.csproj" -c release -o /app

#Servce
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 5000
ENTRYPOINT ["dotnet", "WebApi.dll"]
