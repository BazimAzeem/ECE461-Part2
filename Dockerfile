FROM ubuntu:jammy AS base

RUN apt-get update && apt-get install -y --no-install-recommends \ 
    python-pip=22.0 \
    dotnet-sdk-6.0=6.0 \
    dotnet-runtime-6.0=6.0 \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /home/
RUN mkdir project2
WORKDIR /home/project2

COPY . .
RUN ls

RUN ./run install && ./run build
