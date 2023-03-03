FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /GWUserSync
# Copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore "./GWUserSync.csproj" --disable-parallel
RUN dotnet publish "./GWUserSync.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
ENV ASPNETCORE_URLS=http://*:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "GWUserSync.dll"]