FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# copy csproj and restore as distinct layers
COPY PackageRegistry/*.csproj ./
RUN dotnet restore

# copy everything else and build
COPY PackageRegistry/. ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "PackageRegistry.dll"]