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

ENTRYPOINT ["dotnet", "PackageRegistry.dll"]


# OLD DOCKER FILE
# FROM ubuntu:jammy AS base

# # RUN apt-get update && apt-get install -y --no-install-recommends \ 
# #     python-pip=20.3.4+dfsg-4 \
# #     dotnet-sdk-6.0=6.0.113-0ubuntu1~22.04.1 \
# #     dotnet-runtime-6.0=6.0.113-0ubuntu1~22.04.1 \
# #     && apt-get clean \
# #     && rm -rf /var/lib/apt/lists/*

# RUN apt-get update && apt-get install -y --no-install-recommends \ 
#     python3 \
#     python-pip \
#     dotnet-sdk-6.0 \
#     dotnet-runtime-6.0 \
#     && apt-get clean \
#     && rm -rf /var/lib/apt/lists/*

# WORKDIR /home/
# RUN mkdir project2
# WORKDIR /home/project2

# COPY . .
# RUN ls

# RUN ./run install && ./run build
