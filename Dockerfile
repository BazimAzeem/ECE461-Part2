FROM ubuntu:jammy AS base

RUN apt-get update
RUN apt-get install -y python-pip
RUN apt-get install -y dotnet-sdk-6.0
RUN apt-get install -y dotnet-runtime-6.0

WORKDIR /home/
RUN mkdir project2
WORKDIR /home/project2

COPY . .
RUN ls

RUN ./run install && ./run build
