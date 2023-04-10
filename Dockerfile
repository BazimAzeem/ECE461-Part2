FROM ubuntu:jammy AS base

RUN apt-get update && apt-get install -y --no-install-recommends \ 
    python-pip=22.0.2 \
    dotnet-sdk-6.0=6.0.113 \
    dotnet-runtime-6.0=6.0.113 \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /home/
RUN mkdir project2
WORKDIR /home/project2

COPY . .
RUN ls

RUN ./run install && ./run build
