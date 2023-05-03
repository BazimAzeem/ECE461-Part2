# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# WORKDIR /app

# ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# # copy csproj and restore as distinct layers
# COPY *.csproj ./
# RUN dotnet restore

# # copy everything else and build
# COPY . ./
# RUN dotnet publish -c Release -o out
# # RUN dotnet build -o out

# # build runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app
# COPY --from=build-env /app/out .

# ENTRYPOINT ["dotnet", "IO.Swagger.dll"]

FROM ubuntu:jammy AS base

RUN apt-get update && apt-get install -y --no-install-recommends \ 
    python-pip=20.3.4+dfsg-4 \
    dotnet-sdk-6.0 \
    dotnet-runtime-6.0 \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /home/
RUN mkdir project2
WORKDIR /home/project2

COPY . .
RUN ls

RUN sh build.sh
# ENTRYPOINT ["dotnet", "IO.Swagger.dll"]