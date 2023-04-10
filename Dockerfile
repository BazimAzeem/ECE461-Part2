FROM ubuntu:jammy AS base

RUN apt-get update && apt-get install -y \ 
    python-pip \
    dotnet-sdk-6.0 \
    dotnet-runtime-6.0

WORKDIR /home/
RUN mkdir project2
WORKDIR /home/project2

COPY . .
RUN ls

RUN ./run install && ./run build
