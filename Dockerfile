FROM ubuntu:jammy AS base

RUN apt-get update

WORKDIR /home/
RUN mkdir project2
WORKDIR /home/project2

COPY . .
RUN ls

RUN ./run install && ./run build
